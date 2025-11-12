using ASKOM.Models;
using ASKOM.Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ASKOM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Order> _orders;
        private List<ProductionRecord> _productionHistory;

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                _orders = FileManager.LoadOrders();
                _productionHistory = FileManager.LoadProduction();

                OrderComboBox.ItemsSource = _orders;
                HistoryGrid.ItemsSource = _productionHistory;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrderComboBox.SelectedItem is not Order selectedOrder)
            {
                MessageBox.Show("Select an order.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(QuantityTextBox.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Enter a valid positive unit of pieces.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var record = new ProductionRecord
            {
                OrderId = selectedOrder.Id,
                Produkt = selectedOrder.Produkt,
                IloscWyprodukowana = quantity,
                DataRejestracji = DateTime.Now
            };

            _productionHistory.Add(record);
            FileManager.SaveProduction(_productionHistory);

            MessageBox.Show("Production registration saved.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            QuantityTextBox.Clear();
            RefreshHistory();
        }

        private void ShowHistory_Click(object sender, RoutedEventArgs e)
        {
            if (_productionHistory == null || _productionHistory.Count == 0)
            {
                MessageBox.Show("No production registrations saved.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            RefreshHistory();
        }

        private void RefreshHistory()
        {
            HistoryGrid.ItemsSource = null;
            HistoryGrid.ItemsSource = _productionHistory.OrderByDescending(r => r.DataRejestracji).ToList();
        }
    }
}
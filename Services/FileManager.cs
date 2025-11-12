using ASKOM.Config;
using ASKOM.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ASKOM.Services
{
    public static class FileManager
    {
        public static List<Order> LoadOrders()
        {
            if (!File.Exists(Paths.OrdersPath))
                throw new FileNotFoundException($"File missing {Paths.OrdersPath}");

            string json = File.ReadAllText(Paths.OrdersPath);
            return JsonSerializer.Deserialize<List<Order>>(json) ?? new List<Order>();
        }

        public static List<ProductionRecord> LoadProduction()
        {
            if (!File.Exists(Paths.ProductionPath))
                return new List<ProductionRecord>();

            string json = File.ReadAllText(Paths.ProductionPath);
            return JsonSerializer.Deserialize<List<ProductionRecord>>(json) ?? new List<ProductionRecord>();
        }

        public static void SaveProduction(List<ProductionRecord> records)
        {
            string json = JsonSerializer.Serialize(records, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Paths.ProductionPath, json);
        }
    }
}
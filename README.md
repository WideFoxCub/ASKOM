# 🏭 ASKOM

Aplikacja desktopowa WPF do rejestrowania i przeglądania produkcji na podstawie zamówień.  
Projekt zapisuje dane w formacie JSON i zapewnia prosty interfejs do zarządzania historią produkcji.

---

Aplikacja automatycznie wczyta dane i umożliwi:
- wybór zamówienia,
- zarejestrowanie ilości sztuk do produkcji wraz z datą,
- przeglądanie historii produkcji.

---

## 📂 Struktura projektu
```
ASKOM/
├── Config/Paths.cs # Ścieżki do plików
├── Data/orders.json # Plik danych JSON z zamówieniami
├── Models/ # Modele danych (Order, ProductionRecord)
├── Services/FileManager.cs # Wczytywanie/odczytywanie JSON
├── MainWindow.xaml # Interfejs graficzny (UI)
└── MainWindow.xaml.cs # Logika interfejsu użytkownika
```

## 🧩 `FileManager.cs`

Klasa odpowiedzialna za zarządzanie plikami danych (`orders.json`, `production.json`).  
Zapewnia odczyt i zapis danych w formacie JSON.

**Główne metody**

- LoadOrders() - Wczytuje listę zamówień (Order) z pliku orders.json. Jeśli plik nie istnieje – zgłasza wyjątek.
- LoadProduction() - Wczytuje historię produkcji (ProductionRecord) z pliku production.json. Jeśli plik nie istnieje, zwraca pustą listę.
- SaveProduction(List<ProductionRecord> records) - Zapisuje listę rejestracji produkcji do pliku production.json w formacie JSON.

## 🧩 `MainWindow.xaml.cs`

Główna logika okna aplikacji WPF.
Odpowiada za interakcję użytkownika, wyświetlanie danych, rejestrowanie produkcji i zapisywanie zmian.

- _orders — lista wszystkich zamówień wczytanych z pliku orders.json
- _productionHistory — lista wszystkich zapisanych rekordów produkcji z pliku production.json

- MainWindow() - Konstruktor inicjalizuje komponenty i wczytuje dane przy uruchomieniu.
- LoadData() - Wczytuje dane z plików JSON (zamówienia i historię produkcji) poprzez FileManager. Wypełnia kontrolki interfejsu (OrderComboBox, HistoryGrid).
- SaveButton_Click() - Obsługuje zapis nowego rekordu produkcji. Waliduje dane wejściowe, dodaje nowy wpis do historii i zapisuje zmiany do pliku.
- ShowHistory_Click() - Pokazuje pełną historię produkcji (jeśli istnieje).
- RefreshHistory() - Odświeża dane w tabeli historii, sortując je malejąco według daty rejestracji.

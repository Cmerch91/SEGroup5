using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


// / This class is responsible for managing the data query process, including the selection of the table, date and time range, and loading the data from the database.
// / It implements the INotifyPropertyChanged interface to support data binding in the UI, allowing for automatic updates when properties change.
// / The LoadDataCommand property is a command that can be bound to a button in the UI, triggering the data loading process when executed.
// / The Readings property is an ObservableCollection that holds the results of the data query, allowing for dynamic updates in the UI as new data is loaded.
// / The StartDate, StartTime, EndDate, and EndTime properties represent the date and time range for the data query, and they raise property changed notifications when modified.
// / The SelectedTable property allows the user to select which table to query from, and it also raises property changed notifications when modified.   

namespace SEGroup5.ViewModels
{
    public class DataQueryViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TimeSpan> HourOptions { get; } =
            new(Enumerable.Range(0, 24).Select(h => new TimeSpan(h, 0, 0)));

        private DateTime _startDate = new DateTime(2025, 2, 1);
        private TimeSpan _startTime = new(0, 0, 0);

        private DateTime _endDate = new DateTime(2025, 2, 28);
        private TimeSpan _endTime = new(23, 0, 0);

        private string _selectedTable = "Air_quality";
        public string SelectedTable
        {
            get => _selectedTable;
            set { _selectedTable = value; OnPropertyChanged(); }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set { _startDate = value; OnPropertyChanged(); }
        }

        public TimeSpan StartTime
        {
            get => _startTime;
            set { _startTime = value; OnPropertyChanged(); }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set { _endDate = value; OnPropertyChanged(); }
        }

        public TimeSpan EndTime
        {
            get => _endTime;
            set { _endTime = value; OnPropertyChanged(); }
        }

        public ObservableCollection<object> Readings { get; set; } = new();

        public Command LoadDataCommand { get; }

        public DataQueryViewModel()
        {
            LoadDataCommand = new Command(async () => await LoadData());
        }

        private async Task LoadData()
        {
            var sql = new SQLConnection();
            var start = StartDate.Date + StartTime;
            var end = EndDate.Date + EndTime;

            var results = await sql.GetReadingsInRangeAsync(SelectedTable, start, end);

            Console.WriteLine($"Returned {results.Count} readings from {SelectedTable}");

            Readings.Clear();
            foreach (var r in results)
            {
                Readings.Add(r);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

using SEGroup5.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SEGroup5.ViewModels
{
    public class ConfigWaterSensorViewModel
    {
        public string Status { get; set; }
        public List<string> StatusOptions { get; } = new() { "Online", "Offline" };

        public ObservableCollection<SensorConfigViewModel> Readings { get; set; }

        public ICommand UpdateCommand { get; }

        private SensorGroup _originalGroup;

        public ConfigWaterSensorViewModel(SensorGroup sensorGroup)
        {
            _originalGroup = sensorGroup;
            Status = sensorGroup.Status;

            Readings = new ObservableCollection<SensorConfigViewModel>(
                sensorGroup.Readings.Select(reading =>
                {
                    var vm = new SensorConfigViewModel
                    {
                        Quantity = reading.Quantity,
                        Frequency = reading.Frequency,
                        SafeLevel = reading.SafeLevel
                    };

                    vm.ApplyChanges = () =>
                    {
                        reading.Frequency = vm.Frequency;
                        reading.SafeLevel = vm.SafeLevel;
                    };

                    return vm;
                })
            );

            UpdateCommand = new Command(UpdateSensorData);
        }

        private void UpdateSensorData()
        {
            _originalGroup.Status = Status;

            foreach (var reading in Readings)
            {
                reading.ApplyChanges?.Invoke();
            }

            Application.Current.MainPage.DisplayAlert("Success", "Water sensor updated.", "OK");
        }
    }
}

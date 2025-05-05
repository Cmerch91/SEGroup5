using Microsoft.Data.SqlClient;
using SEGroup5.Models;
using System.Text;

namespace SEGroup5.Views
{
    public partial class TrendReportPage : ContentPage
    {
        // connect to database:wq
        private readonly SQLConnection _sqlConnection;

        public TrendReportPage()
        {
            InitializeComponent();
            _sqlConnection = new SQLConnection();
        }

        // event handler for air quality report button click
        public async void OnAirQualityReportClicked(object sender, EventArgs e)
        {
            await GenerateReport("Air_quality");
        }
       
        // event handler for water quality report button click
        public async void OnWaterQualityReportClicked(object sender, EventArgs e)
        {
            await GenerateReport("Water_quality");
        }

        // event handler for weather report button click
        public async void OnWeatherReportClicked(object sender, EventArgs e)
        {
            await GenerateReport("Weather");
        }

        private async Task GenerateReport(string tableName)
        {
            try
            {
                // set date range based on picker selection
                DateTime endDate = DateTime.Now;
                DateTime startDate;

                switch (PeriodPicker.SelectedIndex)
                {
                    case 0: // set period to last day
                        startDate = endDate.AddHours(-24);
                        break;
                    case 1: // last week
                        startDate = endDate.AddDays(-7);
                        break;
                    case 2: // last month
                        startDate = endDate.AddDays(-30);
                        break;
                    default: // default to last day
                        startDate = endDate.AddHours(-24);
                        break;
                }

                // connect to database
                var readings = await _sqlConnection.GetReadingsInRangeAsync(tableName, startDate, endDate);
                
                // generate report based on table
                var reportText = AnalyzeData(tableName, readings);
                
                // update ui with new report
                ReportTextLabel.Text = reportText;
            }
            catch (Exception ex) // exception handling
            {
                // error message on fail
                await DisplayAlert("Error", $"Failed to generate report: {ex.Message}", "OK");
                ReportTextLabel.Text = "Error generating report. Please try again.";
            }
        }

        private string AnalyzeData(string tableName, List<object> readings)
        {
            // verify readings exist
            if (readings == null || readings.Count == 0)
                return "No data available for the selected period.";

             // initialize report builder
            StringBuilder report = new StringBuilder();
            report.AppendLine($"Report for {tableName.Replace('_', ' ')} ({readings.Count} readings)");
            report.AppendLine($"Period: {PeriodPicker.SelectedItem}");
            report.AppendLine();

            switch (tableName)
            {
                // use appropriate analysis method for table
                case "Air_quality":
                    AnalyzeAirQuality(readings.Cast<AirReading>().ToList(), report);
                    break;
                case "Water_quality":
                    AnalyzeWaterQuality(readings.Cast<WaterReading>().ToList(), report);
                    break;
                case "Weather":
                    AnalyzeWeather(readings.Cast<WeatherReading>().ToList(), report);
                    break;
            }

            return report.ToString();
        }

        private void AnalyzeAirQuality(List<AirReading> readings, StringBuilder report)
        {

            // calculate trend for NO2
            var no2Values = readings.Where(r => r.NO2.HasValue).Select(r => r.NO2.Value).ToList();
            if (no2Values.Count > 0)
            {
                double avgNO2 = no2Values.Average(); // calculate average value
                double latestNO2 = readings.LastOrDefault(r => r.NO2.HasValue)?.NO2 ?? 0; // get latest value
                double percentChange = no2Values.Count > 1 ? ((latestNO2 - no2Values.First()) / no2Values.First()) * 100 : 0; // calculate percentage change of value
                
                // print all above
                report.AppendLine($"NO2 Average: {avgNO2:F2}");
                report.AppendLine($"Latest NO2: {latestNO2:F2}");
                report.AppendLine($"Change: {percentChange:F1}%");
                report.AppendLine();
            }

            // calculate trend for PM2.5
            var pm25Values = readings.Where(r => r.PM25.HasValue).Select(r => r.PM25.Value).ToList();
            if (pm25Values.Count > 0)
            {
                double avgPM25 = pm25Values.Average(); // calculate average
                double latestPM25 = readings.LastOrDefault(r => r.PM25.HasValue)?.PM25 ?? 0; // get latest value
                double percentChange = pm25Values.Count > 1 ? ((latestPM25 - pm25Values.First()) / pm25Values.First()) * 100 : 0;  // calculate percentage change of value
                
                // print all above
                report.AppendLine($"PM2.5 Average: {avgPM25:F2}");
                report.AppendLine($"Latest PM2.5: {latestPM25:F2}");
                report.AppendLine($"Change: {percentChange:F1}%");
            }
        }

        private void AnalyzeWaterQuality(List<WaterReading> readings, StringBuilder report)
        {
            // calculate nitrate trends
            var nitrateValues = readings.Where(r => r.Nitrate.HasValue).Select(r => r.Nitrate.Value).ToList();
            if (nitrateValues.Count > 0)
            {
                double avgNitrate = nitrateValues.Average(); // find average
                double latestNitrate = readings.LastOrDefault(r => r.Nitrate.HasValue)?.Nitrate ?? 0; // get latest value
                double percentChange = nitrateValues.Count > 1 ? ((latestNitrate - nitrateValues.First()) / nitrateValues.First()) * 100 : 0; // calculate percentage change of value
                
                // print all above
                report.AppendLine($"Nitrate Average: {avgNitrate:F2} mg/l");
                report.AppendLine($"Latest Nitrate: {latestNitrate:F2} mg/l");
                report.AppendLine($"Change: {percentChange:F1}%");
                report.AppendLine();
            }

            // calculate E. coli trends
            var ecoliValues = readings.Where(r => r.EColi.HasValue).Select(r => r.EColi.Value).ToList();
            if (ecoliValues.Count > 0)
            {
                double avgEColi = ecoliValues.Average(); // calculate average
                double latestEColi = readings.LastOrDefault(r => r.EColi.HasValue)?.EColi ?? 0; // get latest value
                double percentChange = ecoliValues.Count > 1 ? ((latestEColi - ecoliValues.First()) / ecoliValues.First()) * 100 : 0;  // calculate percentage change of value
                
                // print all above
                report.AppendLine($"E. coli Average: {avgEColi:F2} cfu/100ml");
                report.AppendLine($"Latest E. coli: {latestEColi:F2} cfu/100ml");
                report.AppendLine($"Change: {percentChange:F1}%");
            }
        }

        private void AnalyzeWeather(List<WeatherReading> readings, StringBuilder report)
        {
            // calculate temperature trends
            var tempValues = readings.Where(r => r.Temperature.HasValue).Select(r => r.Temperature.Value).ToList();
            if (tempValues.Count > 0)
            {
                double avgTemp = tempValues.Average(); // calculate average
                double latestTemp = readings.LastOrDefault(r => r.Temperature.HasValue)?.Temperature ?? 0; // find last value
                double minTemp = tempValues.Min(); // find highest value
                double maxTemp = tempValues.Max(); // find lowest value
                
                // print all above
                report.AppendLine($"Temperature Average: {avgTemp:F1}°C");
                report.AppendLine($"Temperature Range: {minTemp:F1}°C to {maxTemp:F1}°C");
                report.AppendLine($"Latest Temperature: {latestTemp:F1}°C");
                report.AppendLine();
            }

            // calculate humidity trends
            var humidityValues = readings.Where(r => r.RelativeHumidity.HasValue).Select(r => r.RelativeHumidity.Value).ToList();
            if (humidityValues.Count > 0)
            {
                double avgHumidity = humidityValues.Average(); // calculate average
                double latestHumidity = readings.LastOrDefault(r => r.RelativeHumidity.HasValue)?.RelativeHumidity ?? 0; // find last value
                
                // print all above
                report.AppendLine($"Relative Humidity Average: {avgHumidity:F1}%");
                report.AppendLine($"Latest Relative Humidity: {latestHumidity:F1}%");
            }
        }
    }
}
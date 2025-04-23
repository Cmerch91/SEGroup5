using Microsoft.Data.SqlClient;

public class SQLConnection
{
    private readonly string _connectionString = "Server=localhost;Database=CourseWork5;User Id=Cmerch;Password=MyStrong!Pass123;TrustServerCertificate=True;";

    public async Task<List<string>> GetNoonReadingsAsync()
    {
        var results = new List<string>();

        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var command = new SqlCommand(@"
            SELECT Date, Time, Nitrogen_dioxide, Sulphur_dioxide,
                   PM2_5_particulate_matter_Hourly_measured,
                   PM10_particulate_matter_Hourly_measured
            FROM Air_quality
            WHERE Time = '12:00:00';", connection);

        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            var date = reader.GetDateTime(0).ToString("yyyy-MM-dd");
            var time = reader.GetTimeSpan(1).ToString(@"hh\:mm");
            var no2 = reader.IsDBNull(2) ? "N/A" : reader.GetDouble(2).ToString("F2");
            var so2 = reader.IsDBNull(3) ? "N/A" : reader.GetDouble(3).ToString("F2");
            var pm25 = reader.IsDBNull(4) ? "N/A" : reader.GetDouble(4).ToString("F2");
            var pm10 = reader.IsDBNull(5) ? "N/A" : reader.GetDouble(5).ToString("F2");

            results.Add($"{date} {time} | NO₂: {no2}, SO₂: {so2}, PM2.5: {pm25}, PM10: {pm10}");
        }

        return results;
    }
}

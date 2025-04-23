using Microsoft.Data.SqlClient;
using SEGroup5.Models;

public class SQLConnection
{
    private readonly string _connectionString = "Server=localhost;Database=CourseWork5;User Id=Cmerch;Password=MyStrong!Pass123;TrustServerCertificate=True;";

public async Task<List<object>> GetReadingsInRangeAsync(string tableName, DateTime start, DateTime end)
{
    var results = new List<object>();

    using var connection = new SqlConnection(_connectionString);
    await connection.OpenAsync();

    SqlCommand command;

    if (tableName == "Air_quality")
    {
        command = new SqlCommand(@"
            SELECT Date, Time, Nitrogen_dioxide, Sulphur_dioxide,
                   PM2_5_particulate_matter_Hourly_measured,
                   PM10_particulate_matter_Hourly_measured
            FROM Air_quality
            WHERE (CAST(Date AS datetime) + CAST(Time AS datetime)) BETWEEN @Start AND @End
            ORDER BY Date, Time;", connection);
    }
    else
    {
        command = new SqlCommand(@"
            SELECT Date, Time, Nitrate_mg_l_1, Nitrite_mg_l_1, Phosphate_mg_l_1, EC_cfu_100ml
            FROM Water_quality
            WHERE (CAST(Date AS datetime) + CAST(Time AS datetime)) BETWEEN @Start AND @End
            ORDER BY Date, Time;", connection);

    }

    command.Parameters.AddWithValue("@Start", start);
    command.Parameters.AddWithValue("@End", end);

    using var reader = await command.ExecuteReaderAsync();

    while (await reader.ReadAsync())
    {
        if (tableName == "Air_quality")
        {
            results.Add(new AirReading
            {
                Date = reader.GetDateTime(0).ToString("yyyy-MM-dd"),
                Time = reader.GetTimeSpan(1).ToString(@"hh\:mm"),
                NO2 = reader.IsDBNull(2) ? null : reader.GetDouble(2),
                SO2 = reader.IsDBNull(3) ? null : reader.GetDouble(3),
                PM25 = reader.IsDBNull(4) ? null : reader.GetDouble(4),
                PM10 = reader.IsDBNull(5) ? null : reader.GetDouble(5),
            });
        }
        else
        {
            results.Add(new WaterReading
            {
                Date = reader.GetDateTime(0).ToString("yyyy-MM-dd"),
                Time = reader.GetTimeSpan(1).ToString(@"hh\:mm"),
                Nitrate = reader.IsDBNull(2) ? null : reader.GetDouble(2),
                Nitrite = reader.IsDBNull(3) ? null : reader.GetDouble(3),
                Phosphate = reader.IsDBNull(4) ? null : reader.GetDouble(4),
                EColi = reader.IsDBNull(5) ? null : Convert.ToDouble(reader.GetValue(5)),
            });
        }
    }

    return results;
}
    
    }

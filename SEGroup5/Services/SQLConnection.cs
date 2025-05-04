using Microsoft.Data.SqlClient;
using SEGroup5.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// This class is responsible for establishing a connection to the SQL database and executing queries.
// It uses async methods to ensure that database operations do not block the main thread, improving performance and responsiveness.
public class SQLConnection
{
    private readonly string _connectionString = "Server=localhost;Database=CourseWork5;User Id=Cmerch;Password=MyStrong!Pass123;TrustServerCertificate=True;";

    // This method retrieves readings from the specified table within a given date and time range.
    // It constructs a SQL query based on the table name and executes it asynchronously.
    // The results are then mapped to the appropriate model class (AirReading, WeatherReading, or WaterReading) and returned as a list of objects.
    public async Task<List<object>> GetReadingsInRangeAsync(string tableName, DateTime start, DateTime end)
    {
        var results = new List<object>();

        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        // Depending on the table name, we construct the appropriate SQL query.
        // This allows us to avoid using reflection or dynamic types, which can be slower and less type-safe.
        // Instead, we use a switch expression to define the query for each table type.
        // This approach is more efficient and easier to maintain.
        // The queries are defined as string literals, which makes them easy to read and modify if necessary.
        string query = tableName switch
        {
            "Air_quality" => @"
                SELECT Date, Time, Nitrogen_dioxide, Sulphur_dioxide,
                       PM2_5_particulate_matter_Hourly_measured,
                       PM10_particulate_matter_Hourly_measured
                FROM Air_quality
                WHERE (CAST(Date AS datetime) + CAST(Time AS datetime)) BETWEEN @Start AND @End
                ORDER BY Date, Time;",

            "Weather" => @"
                SELECT Date, Time, Temperature_2m_C, Relative_humidity_2m, Wind_speed_10m_m_s, Wind_direction_10m
                FROM Weather
                WHERE (CAST(Date AS datetime) + CAST(Time AS datetime)) BETWEEN @Start AND @End
                ORDER BY Date, Time;",

            _ => @"
                SELECT Date, Time, Nitrate_mg_l_1, Nitrite_mg_l_1, Phosphate_mg_l_1, EC_cfu_100ml
                FROM Water_quality
                WHERE (CAST(Date AS datetime) + CAST(Time AS datetime)) BETWEEN @Start AND @End
                ORDER BY Date, Time;"
        };

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Start", start);
        command.Parameters.AddWithValue("@End", end);

        using var reader = await command.ExecuteReaderAsync();

        // Depending on the table name, we select the appropriate mapping function.
        // This allows us to avoid using reflection or dynamic types, which can be slower and less type-safe.
        // Instead, we use a Func delegate to define the mapping logic for each table type.
        // This approach is more efficient and easier to maintain.
        // The mapping functions are defined inline using lambda expressions.
        // Each function takes a SqlDataReader as input and returns an object of the appropriate type.
        // This allows us to handle the different data types and structures of each table in a clean and concise manner.
        Func<SqlDataReader, object> mapFunc = tableName switch
        {
            "Air_quality" => r => new AirReading
            {
                Date = r.GetDateTime(0).ToString("yyyy-MM-dd"),
                Time = r.GetTimeSpan(1).ToString(@"hh\:mm"),
                NO2 = r.IsDBNull(2) ? null : r.GetDouble(2),
                SO2 = r.IsDBNull(3) ? null : r.GetDouble(3),
                PM25 = r.IsDBNull(4) ? null : r.GetDouble(4),
                PM10 = r.IsDBNull(5) ? null : r.GetDouble(5),
            },

            "Weather" => r => new WeatherReading
            {
                Date = r.GetDateTime(0).ToString("yyyy-MM-dd"),
                Time = r.GetTimeSpan(1).ToString(@"hh\:mm"),
                Temperature = r.IsDBNull(2) ? null : r.GetDouble(2),
                RelativeHumidity = r.IsDBNull(3) ? null : Convert.ToDouble(r.GetValue(3)),
                WindSpeed = r.IsDBNull(4) ? null : r.GetDouble(4),
                WindDirection = r.IsDBNull(5) ? null : Convert.ToDouble(r.GetValue(5)),
            },

            _ => r => new WaterReading
            {
                Date = r.GetDateTime(0).ToString("yyyy-MM-dd"),
                Time = r.GetTimeSpan(1).ToString(@"hh\:mm"),
                Nitrate = r.IsDBNull(2) ? null : r.GetDouble(2),
                Nitrite = r.IsDBNull(3) ? null : r.GetDouble(3),
                Phosphate = r.IsDBNull(4) ? null : r.GetDouble(4),
                EColi = r.IsDBNull(5) ? null : Convert.ToDouble(r.GetValue(5)),
            }
        };

        // Read the data from the SqlDataReader and map it to the appropriate model class.
        // This is done using a while loop that continues until there are no more rows to read.
        // The mapFunc delegate is called for each row, and the resulting object is added to the results list.
        // This allows us to handle the different data types and structures of each table in a clean and concise manner.
        while (await reader.ReadAsync())
        {
            results.Add(mapFunc(reader));
        }

        return results;
    }
}

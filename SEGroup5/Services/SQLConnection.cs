using Microsoft.Data.SqlClient;
using SEGroup5.Models;

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

    public async Task<List<string>> GetAllFromRoles(){

        var results = new List<string>();

        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var command = new SqlCommand(@"
            SELECT * FROM Roles;", connection);

        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            var name = reader[0].ToString();

            results.Add($"{name}");
        }

        return results;

    }

    public async Task<List<User>> GetAllFromUsers(){

        var results = new List<User>();

        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var command = new SqlCommand(@"
            SELECT * FROM Users;", connection);

        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            User user = new User();
            user.UserID = reader[0].ToString();
            user.UserRole = reader[1].ToString();
            user.Firstname = reader[2].ToString();
            user.Lastname = reader[3].ToString();
            user.Email = reader[4].ToString();
            user.Password = reader[5].ToString();

            results.Add(user);
        }

        return results;

    }

    public async Task<bool> CheckLogin(string id, string password)
    {
        var results = new List<string>();

        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var command = new SqlCommand(@"
            SELECT * FROM Users
            WHERE UserID='" + id + "' AND password='" + password + "';", connection);

        using var reader = await command.ExecuteReaderAsync();
        bool found = false;
        while (await reader.ReadAsync())
        {
            found = true;
        }

        return found;
    }

    public async Task UpdateRole(Role role, string newName)
    {

        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        /*
        SqlCommand command;

        if(startingName == ""){

            command = new SqlCommand(@"
                INSERT INTO Roles VALUES ('" + startingName + "');", connection);

        }
        else{

            command = new SqlCommand(@"
                UPDATE Roles SET RoleName = '" + role.RoleName + "' WHERE RoleName='" + startingName + "';", connection);

        }

        using var reader = await command.ExecuteReaderAsync();
        */
    }

    public async Task DeleteRole(Role role)
    {

        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var command = new SqlCommand(@"
            DELETE Roles WHERE RoleName='" + role.RoleName + "';", connection);

        using var reader = await command.ExecuteReaderAsync();
    }

}

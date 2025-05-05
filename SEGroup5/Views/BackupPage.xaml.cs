using Microsoft.Data.SqlClient;
using System.IO;

namespace SEGroup5.Views
{
    public partial class BackupPage : ContentPage
    {
		// database connection
        private readonly string _connectionString = "Server=localhost;Database=CourseWork5;User Id=Cmerch;Password=MyStrong!Pass123;TrustServerCertificate=True;";
        private readonly string _backupInfoPath;

        // constructor method
        public BackupPage() 
        {
            InitializeComponent();
            
            // path to backup, uses os app data directory
            _backupInfoPath = Path.Combine(FileSystem.AppDataDirectory, "last_backup.txt");
            
            // get time of last backup, if available
            LoadLastBackupTime();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // refresh last backup time
            LoadLastBackupTime();
        }

        private void LoadLastBackupTime()
        {
            // check if last_backup.txt exists
            if (File.Exists(_backupInfoPath))
            {
                // read new timestamp
                string lastBackup = File.ReadAllText(_backupInfoPath);

                // update ui with new timestamp
                LastBackupLabel.Text = lastBackup;
            }
        }

        // event handler for "create backup" button
        public async void OnCreateBackupClicked(object sender, EventArgs e)
        {
            try
            {
                // popup informing user of current process
                await DisplayAlert("Backup", "Creating backup...", "OK");
                
                // creating the backup file name with timestamp, uses os chache dir
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string backupFileName = $"CourseWork5_Backup_{timestamp}.bak";
                string backupPath = Path.Combine(FileSystem.CacheDirectory, backupFileName);

                //connect to SQL database
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    
                    // use T-SQL command to create .bak file
                    string backupCommand = $"BACKUP DATABASE CourseWork5 TO DISK = '{backupPath}'";
                    using (var command = new SqlCommand(backupCommand, connection))
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                }
                
                // update last backup time
                string backupTimeDisplay = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                File.WriteAllText(_backupInfoPath, backupTimeDisplay);
                
                // update ui label eith new time
                LastBackupLabel.Text = backupTimeDisplay;
                
                // successful backup confirmation
                await DisplayAlert("Success", $"Database backed up to {backupPath}", "OK");
            }
            catch (Exception ex) // exception handling
            {
                // unsuccessful backup warning
                await DisplayAlert("Error", $"Backup failed: {ex.Message}", "OK");
            }
        }
    }
}
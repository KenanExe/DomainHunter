using DomainChecker;
using System.Configuration;
using System.Data.SQLite;
namespace DomainHunter
{
    internal class ExportService
    {
        public static void ExportCsv()
        {
            SqlExportToCsv();
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Select Save Location";
                saveFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                saveFileDialog.DefaultExt = "csv";
                saveFileDialog.FileName = "Domains check result";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string Path = saveFileDialog.FileName;

                    CsvService.MoveCsv(Path);
                }
            }
        }
        public static void SqlExportToCsv()
        {
            string dbPath = ConfigurationManager.AppSettings["DbPath"];
            try
            {
                using (SQLiteConnection m_dbConnection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    try
                    {
                        string Request = @"SELECT * FROM TblResults";
                        using (SQLiteCommand command = new SQLiteCommand(Request, m_dbConnection))
                        {
                            m_dbConnection.Open();
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    CsvService.AddCsv(reader["name"].ToString(), (bool)reader["status"]);
                                }
                            }
                        }
                    }
                    catch (SQLiteException ex)
                    {
                        LoggingService.Log($"DB Error: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.Log($"System Error: {ex.Message}");
            }
        }
    }
}

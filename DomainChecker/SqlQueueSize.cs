using DomainChecker;
using System.Configuration;
using System.Data.SQLite;
namespace DomainHunter
{
    internal class SqlQueueSize
    {
        public static int GetQueueSize()
        {
            string dbPath = ConfigurationManager.AppSettings["DbPath"];
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    string query = "SELECT COUNT(*) FROM TblQueue";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
                        // ExecuteScalar tek ve hızlı bir sonuç (sayı) döner
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.Log($"DB/System Error: {ex.Message}");
                return -1;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static DomainChecker.Form1;

namespace DomainChecker
{
    internal class CheckingService
    {
        static bool DebugMode = ConfigurationManager.AppSettings["DebugMode"] == "true";
        public static async Task<bool> StartCheckingLoopAsync()
        {
            Stopwatch RdapTime = new Stopwatch();
            while (true)
            {
                bool autoSpeed = GetAutoSpeed();
                int time = 100;
                if (autoSpeed)
                {
                    RdapTime.Restart();
                }
                else
                {
                    time = GetSpeed();
                }
                bool result = await StartCheckingAsync();
                if (!result)
                {
                    break;
                }
                DataResultsUpDate();
                DataQueueUpDate();
                if (autoSpeed)
                {
                    RdapTime.Stop();
                    int TaskTime = (int)RdapTime.ElapsedMilliseconds;
                    if (TaskTime < 1010)
                    {
                        time = 1010 - TaskTime;
                    }
                    else
                    {
                        time = 10;
                    }
                }
                //LoggingService.Log($"Next check in {time} ms");
                //LoggingService.Log($"Rdap check time: {RdapTime.ElapsedMilliseconds} ms");
                await Task.Delay(time);
            }
            DataResultsUpDate();
            DataQueueUpDate();
            return true;
        }
        public static async Task<bool> StartCheckingAsync()
        {
            string dbPath = ConfigurationManager.AppSettings["DbPath"];
            string connectionString = $"Data Source={dbPath};Version=3;";

            string itemName = null;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    string selectSql = "SELECT Name FROM TblQueue ORDER BY rowid ASC LIMIT 1;";

                    using (SQLiteCommand selectCmd = new SQLiteCommand(selectSql, connection))
                    using (SQLiteDataReader reader = (SQLiteDataReader)await selectCmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            itemName = reader["Name"].ToString();
                        }
                        else
                        {
                            return false;
                        }
                    }

                    int isSuccess = await CheckDomainAsync(itemName);

                    if (isSuccess == 200)
                    {
                        SqlResults.AddResults(itemName, false);

                        string deleteSql = "DELETE FROM TblQueue WHERE Name = @Name;";
                        using (SQLiteCommand deleteCmd = new SQLiteCommand(deleteSql, connection))
                        {
                            deleteCmd.Parameters.AddWithValue("@Name", itemName);
                            await deleteCmd.ExecuteNonQueryAsync();
                            return true;
                        }
                    }
                    else if (isSuccess == 404)
                    {
                        SqlResults.AddResults(itemName, true);
                        string deleteSql = "DELETE FROM TblQueue WHERE Name = @Name;";
                        using (SQLiteCommand deleteCmd = new SQLiteCommand(deleteSql, connection))
                        {
                            deleteCmd.Parameters.AddWithValue("@Name", itemName);
                            await deleteCmd.ExecuteNonQueryAsync();
                            return true;
                        }
                    }
                    else
                    {
                        LoggingService.Log($"{itemName} html status code:{isSuccess} Error on checking domain.\n Maybe problem is rate limit\n Try speed down on checking speed");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    LoggingService.Log($"Error on DB: {ex.Message}");
                    return false;
                }
            }
        }

        static async Task<int> CheckDomainAsync(string domain)
        {
            //I did but .io needs whois check. Rdap doesn't show .io TLD's
            //ToDo: add other rdap services for .io, .ai and others
            return await RdapChecker.CheckDomainAsync(domain); // Add whois for .io TLD's and i think .gov too
        }
    }
}
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
using DomainHunter;

namespace DomainChecker
{
    internal class CheckingService
    {
        static bool DebugMode = ConfigurationManager.AppSettings["DebugMode"] == "true";
        public static async Task<bool> StartCheckingLoopAsync()
        {
            progressBarUpDate(true);
            ProgressBarSetMax(SqlQueueSize.GetQueueSize());
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
                    RdapTime.Restart();
                }
                int result = await StartCheckingAsync();
                if (result == -1)
                {
                    Console.WriteLine("No more items in the queue or an error occurred. Stopping the checking loop.");
                    break;
                }else if (result == 2000)
                {
                    LoggingService.Log($"Rate limit reached. Waiting for 2 seconds before next check.");
                    time = 2000;
                } else if (result == 10000)
                {
                    LoggingService.Log($"Rate limit reached. Waiting for 10 seconds before next check.\nPlease take control manually");
                    time = 10000;
                }
                progressBarUpDate();
                DataResultsUpDate();
                DataQueueUpDate();
                if (autoSpeed)
                {
                    RdapTime.Stop();
                    int TaskTime = (int)RdapTime.ElapsedMilliseconds;
                    if (TaskTime < result)
                    {
                        time = result - TaskTime;
                    }
                    else
                    {
                        time = 10;
                    }
                }

                //LoggingService.Log($"Next check in {time} ms");
                LoggingService.Log($"Rdap check time: {RdapTime.ElapsedMilliseconds} ms");
                await Task.Delay(time);
            }
            DataResultsUpDate();
            DataQueueUpDate();
            return true;
        }
        private static int DelayForTld(string tld)
        {
            switch (tld)
            {
                case "io":
                case "ai":
                case "com":
                case "net":
                    return 300;
                default:
                    return 1010;
            }
        }
        public static async Task<int> StartCheckingAsync()
        {
            bool isRateLimit = false;
            string dbPath = ConfigurationManager.AppSettings["DbPath"];
            string connectionString = $"Data Source={dbPath};Version=3;";

            string itemName = null;
            string tld = null;
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
                            tld = itemName.Split('.').Last().ToLower();
                        }
                        else
                        {
                            return -1;
                        }
                    }

                    int isSuccess = await CheckDomainAsync(itemName);

                    int waitTime = DelayForTld(tld);
                    if (isSuccess == 200)
                    {
                        SqlResults.AddResults(itemName, false);

                        string deleteSql = "DELETE FROM TblQueue WHERE Name = @Name;";
                        using (SQLiteCommand deleteCmd = new SQLiteCommand(deleteSql, connection))
                        {
                            isRateLimit = false;
                            deleteCmd.Parameters.AddWithValue("@Name", itemName);
                            await deleteCmd.ExecuteNonQueryAsync();
                            return waitTime;
                        }
                    }
                    else if (isSuccess == 404)
                    {
                        SqlResults.AddResults(itemName, true);
                        string deleteSql = "DELETE FROM TblQueue WHERE Name = @Name;";
                        using (SQLiteCommand deleteCmd = new SQLiteCommand(deleteSql, connection))
                        {
                            isRateLimit = false;
                            deleteCmd.Parameters.AddWithValue("@Name", itemName);
                            await deleteCmd.ExecuteNonQueryAsync();
                            return waitTime;
                        }
                    }else if (isSuccess == 429)
                    {
                        if (isRateLimit)
                        {
                            LoggingService.Log($"{itemName} html status code:{isSuccess} Error on checking domain.\n Maybe problem is rate limit\n Try speed down on checking speed");
                            isRateLimit = true;
                            return 10000;
                        }
                            LoggingService.Log($"{itemName} html status code:{isSuccess} Error on checking domain.\n Maybe problem is rate limit\n Try speed down on checking speed");
                        isRateLimit = true;
                        return 2000;
                    }
                    else
                    {
                        LoggingService.Log($"{itemName} html status code:{isSuccess} Error on checking domain.");
                        return -1;
                    }
                }
                catch (Exception ex)
                {
                    LoggingService.Log($"Error on DB: {ex.Message}");
                    return -1;
                }
            }
        }

        static async Task<int> CheckDomainAsync(string domain)
        {
            return await RdapChecker.CheckDomainAsync(domain);
        }
    }
}
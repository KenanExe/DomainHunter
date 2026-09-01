using System.Configuration;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DomainChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataQueue.Columns.Add("Name", "Name");
            dataResults.Columns.Add("Name", "Name");
            dataResults.Columns.Add("Status", "Status");


            dataResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataResults.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataResults.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataResults.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataResults.Columns[1].Width = 80;

            btnRefrash.PerformClick();
            AutoSpeed = AutoSpeedCheckBox.Checked;
        }
        static int speed = 1000;
        static bool AutoSpeed = false;
        static public bool GetAutoSpeed()
        {
            return AutoSpeed;
        }


        static public int GetSpeed()
        {
            return speed;
        }
        bool theme = false;
        private void SpeedScrol_Scroll(object sender, EventArgs e)
        {
            if (SpeedScrol.Value == 1)
            {
                lblSpeed.Text = "Speed: 0.7 Seconds (Very Danger)";
                speed = 700;
            }
            else if (SpeedScrol.Value == 2)
            {
                lblSpeed.Text = "Speed: 0.8 Seconds (Danger)";
                speed = 800;
            }
            else if (SpeedScrol.Value == 3)
            {
                lblSpeed.Text = "Speed: 0.9 Seconds";
                speed = 900;
            }
            else if (SpeedScrol.Value == 4)
            {
                lblSpeed.Text = "Speed: 1.0 Seconds";
                speed = 1000;
            }
            else if (SpeedScrol.Value == 5)
            {
                lblSpeed.Text = "Speed: 1.1 Seconds";
                speed = 1100;
            }
            else if (SpeedScrol.Value == 6)
            {
                lblSpeed.Text = "Speed: 1.3 Seconds";
                speed = 1300;
            }
            else if (SpeedScrol.Value == 7)
            {
                lblSpeed.Text = "Speed: 1.5 Seconds";
                speed = 1500;
            }
            else if (SpeedScrol.Value == 8)
            {
                lblSpeed.Text = "Speed: 2.0 Seconds";
                speed = 2000;
            }
            else if (SpeedScrol.Value == 9)
            {
                lblSpeed.Text = "Speed: 2.5 Seconds";
                speed = 2500;
            }
            else if (SpeedScrol.Value == 10)
            {
                lblSpeed.Text = "Speed: 5.0 Seconds";
                speed = 5000;
            }
        }

        private void btnThema_Click(object sender, EventArgs e)
        {
            if (theme == false)
            {
                theme = true;
                goDark();
            }
            else if (theme)
            {
                theme = false;
                goLight();
            }
        }
        //ToDo: Optimize the dark theme.
        private void goDark()
        {
            this.BackColor = Color.FromArgb(60, 60, 60);
            this.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            lblSpeed.ForeColor = Color.White;
            btnThema.ForeColor = Color.FromArgb(255, 109, 109, 109);
            btnThema.BackColor = Color.FromArgb(255, 60, 60, 60);
            SpeedScrol.BackColor = Color.FromArgb(60, 60, 60);
            btnThema.Text = "Change Light Mode";
            groupBox1.ForeColor = Color.White;
            groupBox2.ForeColor = Color.White;
            groupBox3.ForeColor = Color.White;
            groupBox4.ForeColor = Color.White;

            textBox1.BackColor = Color.FromArgb(60, 60, 60);
            textBox1.ForeColor = Color.White;

        }
        private void goLight()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            lblSpeed.ForeColor = Color.Black;
            btnThema.ForeColor = Color.FromArgb(255, 109, 109, 109);
            btnThema.BackColor = Color.FromArgb(255, 255, 255, 255);
            SpeedScrol.BackColor = Color.FromArgb(255, 255, 255, 255);
            btnThema.Text = "Change Dark Mode";
            groupBox1.ForeColor = Color.Black;
            groupBox2.ForeColor = Color.Black;
            groupBox3.ForeColor = Color.Black;
            groupBox4.ForeColor = Color.Black;
            textBox1.BackColor = Color.WhiteSmoke;
            textBox1.ForeColor = Color.Black;
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string[] lines = text.Split(new[] { "\r\n", "\r", "\n", " ", "," }, StringSplitOptions.None);
            int i = 0;
            progressBar.Value = 0;
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    i++;
                    //LoggingService.Log(line);
                    //SqlAddQueue.AddQueue(line);
                    AutoAddTDLs(line);
                    //dataQueue.Rows.Add(line);
                    btnStart.Enabled = false;
                    textBox1.Text = string.Empty;
                }
                else if (string.IsNullOrWhiteSpace(line))
                {
                    LoggingService.Log("Empty line detected, skipping.");
                }
            }
            progressBar.Maximum = i;
            //LoggingService.Log(progressBar.Maximum.ToString());
            //LoggingService.Log(i.ToString());

            DataQueueUpDate();
            bool result = await CheckingService.StartCheckingLoopAsync();
            if (result)
            {
                btnStart.Enabled = true;
            }
        }

        private void checkCom_CheckedChanged(object sender, EventArgs e)
        {

        }
        // To Do: Change this name to something more descriptive.
        #region DataResults Services
        public static void DataResultsUpDate()
        {
            dataResults.Rows.Clear();
            string dbPath = ConfigurationManager.AppSettings["DbPath"];
            try
            {
                using (SQLiteConnection m_dbConnection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    try
                    {
                        string Request = "select name, status from TblResults";
                        using (SQLiteCommand command = new SQLiteCommand(Request, m_dbConnection))
                        {
                            m_dbConnection.Open();
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                int count = 0;
                                while (reader.Read())
                                {
                                    count++;
                                    DataResultsAdd(
                                        reader["name"].ToString(),
                                        (bool)reader["status"]
                                    );
                                }

                                if (progressBar.InvokeRequired)
                                {
                                    progressBar.Invoke(new Action(() =>
                                        progressBar.Value = Math.Min(count, progressBar.Maximum)));
                                    StatusBarUpDate(count, progressBar.Maximum);
                                }
                                else
                                {
                                    progressBar.Value = Math.Min(count, progressBar.Maximum);
                                    StatusBarUpDate(count, progressBar.Maximum);
                                }
                                ExportBtn.Enabled = count > 0;
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
        #endregion
        #region DataQueue Services

        public static void DataQueueUpDate()
        {
            DataQueueClear();
            string dbPath = ConfigurationManager.AppSettings["DbPath"];
            try
            {
                using (SQLiteConnection m_dbConnection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    try
                    {
                        string Request = @"
                                          SELECT name FROM (
                                          SELECT name, 1 AS sira FROM (SELECT name FROM TblQueue LIMIT 3)
                                          UNION ALL
                                          SELECT '+ ' || (COUNT(*) - 3) || ' Domains' AS name, 2 AS sira 
                                          FROM TblQueue HAVING COUNT(*) > 3) ORDER BY sira ASC;";
                        using (SQLiteCommand command = new SQLiteCommand(Request, m_dbConnection))
                        {
                            m_dbConnection.Open();
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                DataQueueClear();
                                while (reader.Read())
                                {
                                    DataQueueAdd(reader["name"].ToString());
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
        #endregion

        #region DataQueue Services
        public static void DataQueueAdd(string name)
        {
            dataQueue.Rows.Add(name);
            //LoggingService.Log($"Added to queue: {name}");
        }
        public static void DataQueueClear()
        {
            dataQueue.Rows.Clear();
        }
        #endregion



        public static void DataResultsAdd(string name, bool status)
        {
            int rowIndex = dataResults.Rows.Add(name, status ? "\u2714" : "\u2716");
            var statusCell = dataResults.Rows[rowIndex].Cells[1];

            if (status)
            {
                statusCell.Style.BackColor = Color.LightGreen;
                statusCell.Style.ForeColor = Color.DarkGreen;
            }
            else
            {
                statusCell.Style.BackColor = Color.MistyRose;
                statusCell.Style.ForeColor = Color.DarkRed;
            }
        }

        private void btnRefrash_Click(object sender, EventArgs e)
        {
            DataQueueUpDate();
            DataResultsUpDate();
        }
        //To Do: add auto restarter affter error (like rate limit)
        //To Do: results table can's usable on checking.

        void AutoAddTDLs(string name)
        {
            int lastDot = name.LastIndexOf('.');

            if (lastDot != -1)
            {
                SqlAddQueue.AddQueue(name);
                return;
            }

            if (checkCom.Checked)
            {
                SqlAddQueue.AddQueue(name + ".com");
            }
            if (checkOrg.Checked)
            {
                SqlAddQueue.AddQueue(name + ".org");
            }
            if (checkNet.Checked)
            {
                SqlAddQueue.AddQueue(name + ".net");
            }
            if (checkGov.Checked)
            {
                SqlAddQueue.AddQueue(name + ".gov");
            }
            if (checkio.Checked)
            {
                SqlAddQueue.AddQueue(name + ".io");
            }
            if (checkAi.Checked)
            {
                SqlAddQueue.AddQueue(name + ".ai");
            }
        }
        // Alt bar (status bar)
        private static void StatusBarUpDate(int queueCount, int resultsCount)
        {
            string statusText = $"Queue: {queueCount} / {resultsCount}";
            AltBarStatus.Text = statusText;
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            ExportBtn.Enabled = false;
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
            ExportBtn.Enabled = true;
        }
        #region SqlExport Services

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
        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            AutoSpeed = AutoSpeedCheckBox.Checked;
        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }
    }
}

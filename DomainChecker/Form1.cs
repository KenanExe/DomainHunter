using DomainHunter;
using System.Configuration;
using System.Data.SQLite;
using System.Runtime.InteropServices;
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
                goDark(sender, e);
            }
            else if (theme)
            {
                theme = false;
                goLight(sender, e);
            }
        }
        private void goDark(object sender, EventArgs e)
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
            statusStrip1.BackColor = Color.FromArgb(60, 60, 60);
            statusStrip1.ForeColor = Color.White;
            btnRefrash.ForeColor = Color.FromArgb(255, 109, 109, 109);
            btnRefrash.BackColor = Color.FromArgb(255, 60, 60, 60);
            ExportBtn.ForeColor = Color.FromArgb(255, 109, 109, 109);
            ExportBtn.BackColor = Color.FromArgb(255, 60, 60, 60);


            DarkModeHelper.SetTitleBarDark(this.Handle, true);

            ApplyDataGridViewTheme(dataResults, true);
            ApplyDataGridViewTheme(dataQueue, true);
        }
        private void goLight(object sender, EventArgs e)
        {
            this.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.ForeColor = Color.Black;
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            lblSpeed.ForeColor = Color.Black;
            btnThema.ForeColor = Color.FromArgb(255, 109, 109, 109);
            btnThema.BackColor = Color.FromKnownColor(KnownColor.Control);
            SpeedScrol.BackColor = Color.FromKnownColor(KnownColor.Control);
            btnThema.Text = "Change Dark Mode";
            groupBox1.ForeColor = Color.Black;
            groupBox2.ForeColor = Color.Black;
            groupBox3.ForeColor = Color.Black;
            groupBox4.ForeColor = Color.Black;
            textBox1.BackColor = Color.WhiteSmoke;
            textBox1.ForeColor = Color.Black;
            statusStrip1.BackColor = Color.FromKnownColor(KnownColor.Control);
            statusStrip1.ForeColor = Color.Black;
            btnRefrash.ForeColor = Color.FromArgb(255, 109, 109, 109);
            btnRefrash.BackColor = Color.FromArgb(255, 255, 255, 255);
            ExportBtn.ForeColor = Color.FromArgb(255, 109, 109, 109);
            ExportBtn.BackColor = Color.FromArgb(255, 255, 255, 255);

            DarkModeHelper.SetTitleBarDark(this.Handle, false);
            ApplyDataGridViewTheme(dataResults, false);
            ApplyDataGridViewTheme(dataQueue, false);

        }

        private void ApplyDataGridViewTheme(DataGridView grid, bool isDark)
        {
            grid.EnableHeadersVisualStyles = !isDark;
            grid.BorderStyle = isDark ? BorderStyle.FixedSingle : BorderStyle.Fixed3D;
            grid.BackgroundColor = isDark ? Color.FromArgb(60, 60, 60) : Color.White;
            grid.GridColor = isDark ? Color.FromArgb(90, 90, 90) : Color.FromArgb(220, 220, 220);

            Color bg = isDark ? Color.FromArgb(45, 45, 45) : Color.White;
            Color fg = isDark ? Color.White : Color.Black;
            Color altBg = isDark ? Color.FromArgb(55, 55, 55) : Color.WhiteSmoke;
            Color headerBg = isDark ? Color.FromArgb(40, 40, 40) : SystemColors.Control;
            Color selectBg = Color.FromArgb(0, 120, 215);

            SetStyle(grid.DefaultCellStyle, bg, fg, selectBg, Color.White);
            SetStyle(grid.AlternatingRowsDefaultCellStyle, altBg, fg, selectBg, Color.White);
            SetStyle(grid.ColumnHeadersDefaultCellStyle, headerBg, fg, headerBg, fg);
            SetStyle(grid.RowHeadersDefaultCellStyle, bg, fg, selectBg, Color.White);

            void SetStyle(DataGridViewCellStyle style, Color back, Color fore, Color selBack, Color selFore)
            {
                style.BackColor = back;
                style.ForeColor = fore;
                style.SelectionBackColor = selBack;
                style.SelectionForeColor = selFore;
            }
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

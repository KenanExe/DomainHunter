namespace DomainChecker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            AutoSpeedCheckBox = new CheckBox();
            lblSpeed = new Label();
            SpeedScrol = new TrackBar();
            label3 = new Label();
            checkAi = new CheckBox();
            label2 = new Label();
            checkio = new CheckBox();
            checkCom = new CheckBox();
            checkGov = new CheckBox();
            checkOrg = new CheckBox();
            checkNet = new CheckBox();
            label1 = new Label();
            btnStart = new Button();
            progressBar = new ProgressBar();
            btnThema = new Button();
            groupBox2 = new GroupBox();
            textBox1 = new TextBox();
            groupBox3 = new GroupBox();
            dataQueue = new DataGridView();
            groupBox4 = new GroupBox();
            dataResults = new DataGridView();
            btnRefrash = new Button();
            statusStrip1 = new StatusStrip();
            AltBarStatus = new ToolStripStatusLabel();
            ExportBtn = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpeedScrol).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataQueue).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataResults).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(AutoSpeedCheckBox);
            groupBox1.Controls.Add(lblSpeed);
            groupBox1.Controls.Add(SpeedScrol);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(checkAi);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(checkio);
            groupBox1.Controls.Add(checkCom);
            groupBox1.Controls.Add(checkGov);
            groupBox1.Controls.Add(checkOrg);
            groupBox1.Controls.Add(checkNet);
            groupBox1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            groupBox1.Location = new Point(11, 35);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(246, 281);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Auto TLDs";
            // 
            // AutoSpeedCheckBox
            // 
            AutoSpeedCheckBox.AutoSize = true;
            AutoSpeedCheckBox.Checked = true;
            AutoSpeedCheckBox.CheckState = CheckState.Checked;
            AutoSpeedCheckBox.Location = new Point(11, 175);
            AutoSpeedCheckBox.Name = "AutoSpeedCheckBox";
            AutoSpeedCheckBox.Size = new Size(121, 27);
            AutoSpeedCheckBox.TabIndex = 11;
            AutoSpeedCheckBox.Text = "Auto Speed";
            AutoSpeedCheckBox.UseVisualStyleBackColor = true;
            AutoSpeedCheckBox.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // lblSpeed
            // 
            lblSpeed.AutoSize = true;
            lblSpeed.Font = new Font("Segoe UI", 9F);
            lblSpeed.Location = new Point(43, 245);
            lblSpeed.Name = "lblSpeed";
            lblSpeed.Size = new Size(136, 20);
            lblSpeed.TabIndex = 10;
            lblSpeed.Text = "Speed: 1.0 Seconds";
            // 
            // SpeedScrol
            // 
            SpeedScrol.BackColor = SystemColors.Control;
            SpeedScrol.LargeChange = 1;
            SpeedScrol.Location = new Point(5, 207);
            SpeedScrol.Minimum = 1;
            SpeedScrol.Name = "SpeedScrol";
            SpeedScrol.Size = new Size(234, 56);
            SpeedScrol.TabIndex = 9;
            SpeedScrol.Value = 4;
            SpeedScrol.Scroll += SpeedScrol_Scroll;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label3.Location = new Point(11, 149);
            label3.Name = "label3";
            label3.Size = new Size(146, 23);
            label3.TabIndex = 8;
            label3.Text = "Check Frequency:";
            // 
            // checkAi
            // 
            checkAi.AutoSize = true;
            checkAi.Font = new Font("Segoe UI", 9F);
            checkAi.Location = new Point(79, 122);
            checkAi.Name = "checkAi";
            checkAi.Size = new Size(46, 24);
            checkAi.TabIndex = 7;
            checkAi.Text = ".ai";
            checkAi.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label2.Location = new Point(6, 37);
            label2.Name = "label2";
            label2.Size = new Size(111, 23);
            label2.TabIndex = 2;
            label2.Text = "Include TLDs:";
            // 
            // checkio
            // 
            checkio.AutoSize = true;
            checkio.Font = new Font("Segoe UI", 9F);
            checkio.Location = new Point(79, 91);
            checkio.Name = "checkio";
            checkio.Size = new Size(47, 24);
            checkio.TabIndex = 6;
            checkio.Text = ".io";
            checkio.UseVisualStyleBackColor = true;
            // 
            // checkCom
            // 
            checkCom.AutoSize = true;
            checkCom.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            checkCom.Location = new Point(6, 60);
            checkCom.Name = "checkCom";
            checkCom.Size = new Size(63, 24);
            checkCom.TabIndex = 2;
            checkCom.Text = ".com";
            checkCom.UseVisualStyleBackColor = true;
            checkCom.CheckedChanged += checkCom_CheckedChanged;
            // 
            // checkGov
            // 
            checkGov.AutoSize = true;
            checkGov.Font = new Font("Segoe UI", 9F);
            checkGov.Location = new Point(79, 60);
            checkGov.Name = "checkGov";
            checkGov.Size = new Size(59, 24);
            checkGov.TabIndex = 5;
            checkGov.Text = ".gov";
            checkGov.UseVisualStyleBackColor = true;
            // 
            // checkOrg
            // 
            checkOrg.AutoSize = true;
            checkOrg.Font = new Font("Segoe UI", 9F);
            checkOrg.Location = new Point(6, 91);
            checkOrg.Name = "checkOrg";
            checkOrg.Size = new Size(57, 24);
            checkOrg.TabIndex = 3;
            checkOrg.Text = ".org";
            checkOrg.UseVisualStyleBackColor = true;
            // 
            // checkNet
            // 
            checkNet.AutoSize = true;
            checkNet.Font = new Font("Segoe UI", 9F);
            checkNet.Location = new Point(6, 120);
            checkNet.Name = "checkNet";
            checkNet.Size = new Size(55, 24);
            checkNet.TabIndex = 4;
            checkNet.Text = ".net";
            checkNet.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(11, 9);
            label1.Name = "label1";
            label1.Size = new Size(175, 23);
            label1.TabIndex = 1;
            label1.Text = "Domain Hunter V0.1";
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.LawnGreen;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnStart.ForeColor = SystemColors.ControlLightLight;
            btnStart.Location = new Point(11, 332);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(246, 67);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start Checking";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // progressBar
            // 
            progressBar.BackColor = SystemColors.Control;
            progressBar.Location = new Point(11, 405);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(246, 29);
            progressBar.TabIndex = 3;
            progressBar.UseWaitCursor = true;
            progressBar.Value = 50;
            progressBar.Click += progressBar_Click;
            // 
            // btnThema
            // 
            btnThema.FlatStyle = FlatStyle.Flat;
            btnThema.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btnThema.ForeColor = SystemColors.GrayText;
            btnThema.Location = new Point(11, 440);
            btnThema.Name = "btnThema";
            btnThema.Size = new Size(246, 67);
            btnThema.TabIndex = 4;
            btnThema.Text = "Change Dark Mode";
            btnThema.UseVisualStyleBackColor = false;
            btnThema.Click += btnThema_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox1);
            groupBox2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            groupBox2.Location = new Point(279, 35);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(246, 281);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Domain List (input)";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.WhiteSmoke;
            textBox1.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox1.Location = new Point(6, 28);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(234, 247);
            textBox1.TabIndex = 0;
            textBox1.Text = "Kenan.bio\r\nKenanExe.xyz\r\nGoogle.com\r\nKenanExe.com\r\nKenannnnnExe.com";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dataQueue);
            groupBox3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            groupBox3.Location = new Point(279, 322);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(246, 185);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Processing Queue (Active)";
            // 
            // dataQueue
            // 
            dataQueue.AllowUserToAddRows = false;
            dataQueue.AllowUserToDeleteRows = false;
            dataQueue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataQueue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataQueue.Location = new Point(6, 29);
            dataQueue.Name = "dataQueue";
            dataQueue.RowHeadersWidth = 51;
            dataQueue.Size = new Size(234, 150);
            dataQueue.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(dataResults);
            groupBox4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            groupBox4.Location = new Point(542, 35);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(485, 472);
            groupBox4.TabIndex = 7;
            groupBox4.TabStop = false;
            groupBox4.Text = "Results";
            // 
            // dataResults
            // 
            dataResults.AllowUserToAddRows = false;
            dataResults.AllowUserToDeleteRows = false;
            dataResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataResults.Location = new Point(6, 29);
            dataResults.Name = "dataResults";
            dataResults.RowHeadersWidth = 51;
            dataResults.Size = new Size(474, 437);
            dataResults.TabIndex = 0;
            // 
            // btnRefrash
            // 
            btnRefrash.Location = new Point(935, 12);
            btnRefrash.Name = "btnRefrash";
            btnRefrash.Size = new Size(94, 29);
            btnRefrash.TabIndex = 8;
            btnRefrash.Text = "Refrash";
            btnRefrash.UseVisualStyleBackColor = true;
            btnRefrash.Click += btnRefrash_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { AltBarStatus });
            statusStrip1.Location = new Point(0, 511);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1039, 26);
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            // 
            // AltBarStatus
            // 
            AltBarStatus.Name = "AltBarStatus";
            AltBarStatus.Size = new Size(151, 20);
            AltBarStatus.Text = "toolStripStatusLabel1";
            // 
            // ExportBtn
            // 
            ExportBtn.Location = new Point(810, 12);
            ExportBtn.Name = "ExportBtn";
            ExportBtn.Size = new Size(119, 29);
            ExportBtn.TabIndex = 10;
            ExportBtn.Text = "Export to CSV";
            ExportBtn.UseVisualStyleBackColor = true;
            ExportBtn.Click += ExportBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 537);
            Controls.Add(ExportBtn);
            Controls.Add(statusStrip1);
            Controls.Add(btnRefrash);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(btnThema);
            Controls.Add(progressBar);
            Controls.Add(btnStart);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SpeedScrol).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataQueue).EndInit();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataResults).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private CheckBox checkCom;
        private CheckBox checkOrg;
        private CheckBox checkNet;
        private CheckBox checkGov;
        private CheckBox checkio;
        private CheckBox checkAi;
        private Label label3;
        private TrackBar SpeedScrol;
        private Label lblSpeed;
        private Button btnStart;
        private Button btnThema;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox textBox1;
        private GroupBox groupBox4;
        private Button btnRefrash;
        private StatusStrip statusStrip1;
        private CheckBox AutoSpeedCheckBox;
        public static Button ExportBtn;
        private static ToolStripStatusLabel AltBarStatus;
        public static ProgressBar progressBar;
        public static DataGridView dataQueue;
        public static DataGridView dataResults;
    }
}

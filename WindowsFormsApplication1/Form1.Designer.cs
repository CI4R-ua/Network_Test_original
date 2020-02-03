namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.RFBeam = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LeapMotionC = new System.Windows.Forms.Label();
            this.LeapMotion = new System.Windows.Forms.CheckBox();
            this.KinectC = new System.Windows.Forms.Label();
            this.Kinect = new System.Windows.Forms.CheckBox();
            this.Ancortek98C = new System.Windows.Forms.Label();
            this.Ancortek58 = new System.Windows.Forms.CheckBox();
            this.RFBeamC = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NetworkLog = new System.Windows.Forms.TextBox();
            this.NetworkEnableButton = new System.Windows.Forms.Button();
            this.NetworkDisableButton = new System.Windows.Forms.Button();
            this.NetworkStatusLabel = new System.Windows.Forms.Label();
            this.IpLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.repo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 31;
            this.listBox1.Items.AddRange(new object[] {
            "Subject1",
            "Subject2",
            "Subject3",
            "Subject4",
            "Subject5",
            "Subject6",
            "Subject7",
            "Subject8",
            "Subject9"});
            this.listBox1.Location = new System.Drawing.Point(44, 78);
            this.listBox1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(266, 531);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Action:";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 31;
            this.listBox2.Items.AddRange(new object[] {
            "FSU Chop",
            "Come Here",
            "Wave Goodbye",
            "Finger L/R",
            "Finger F/B",
            "Walking Towards Radar",
            "Walking Away from Radar",
            "Picking up object",
            "Bending",
            "Sitting",
            "Kneeling",
            "Crawling"});
            this.listBox2.Location = new System.Drawing.Point(362, 80);
            this.listBox2.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(332, 531);
            this.listBox2.TabIndex = 3;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(732, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Angle:";
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 31;
            this.listBox3.Items.AddRange(new object[] {
            "0",
            "15",
            "30",
            "45",
            "60",
            "75",
            "90"});
            this.listBox3.Location = new System.Drawing.Point(738, 80);
            this.listBox3.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(210, 221);
            this.listBox3.TabIndex = 5;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 644);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(268, 50);
            this.button1.TabIndex = 8;
            this.button1.Text = "Add New Subject";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1004, 156);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(368, 56);
            this.button2.TabIndex = 9;
            this.button2.Text = "Start Recording";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(998, 42);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 32);
            this.label5.TabIndex = 10;
            this.label5.Text = "Seconds:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1004, 80);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(290, 38);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "5";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1004, 224);
            this.button3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(288, 56);
            this.button3.TabIndex = 12;
            this.button3.Text = "Delayed Start";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(1304, 224);
            this.textBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(64, 46);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "2";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(362, 644);
            this.button4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(336, 50);
            this.button4.TabIndex = 14;
            this.button4.Text = "Add New Motion";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1004, 294);
            this.button5.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(368, 66);
            this.button5.TabIndex = 15;
            this.button5.Text = "Delete Previous Rec";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // RFBeam
            // 
            this.RFBeam.AutoSize = true;
            this.RFBeam.Location = new System.Drawing.Point(12, 96);
            this.RFBeam.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.RFBeam.Name = "RFBeam";
            this.RFBeam.Size = new System.Drawing.Size(137, 36);
            this.RFBeam.TabIndex = 17;
            this.RFBeam.Text = "77Ghz";
            this.RFBeam.UseVisualStyleBackColor = true;
            this.RFBeam.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LeapMotionC);
            this.groupBox1.Controls.Add(this.LeapMotion);
            this.groupBox1.Controls.Add(this.KinectC);
            this.groupBox1.Controls.Add(this.Kinect);
            this.groupBox1.Controls.Add(this.Ancortek98C);
            this.groupBox1.Controls.Add(this.Ancortek58);
            this.groupBox1.Controls.Add(this.RFBeamC);
            this.groupBox1.Controls.Add(this.RFBeam);
            this.groupBox1.Location = new System.Drawing.Point(738, 372);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(520, 322);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Devices";
            // 
            // LeapMotionC
            // 
            this.LeapMotionC.AutoSize = true;
            this.LeapMotionC.BackColor = System.Drawing.Color.Crimson;
            this.LeapMotionC.Location = new System.Drawing.Point(294, 204);
            this.LeapMotionC.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LeapMotionC.Name = "LeapMotionC";
            this.LeapMotionC.Size = new System.Drawing.Size(178, 32);
            this.LeapMotionC.TabIndex = 24;
            this.LeapMotionC.Text = "Local Device";
            // 
            // LeapMotion
            // 
            this.LeapMotion.AutoSize = true;
            this.LeapMotion.Enabled = false;
            this.LeapMotion.Location = new System.Drawing.Point(12, 204);
            this.LeapMotion.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.LeapMotion.Name = "LeapMotion";
            this.LeapMotion.Size = new System.Drawing.Size(203, 36);
            this.LeapMotion.TabIndex = 23;
            this.LeapMotion.Text = "LeapMotion";
            this.LeapMotion.UseVisualStyleBackColor = true;
            // 
            // KinectC
            // 
            this.KinectC.AutoSize = true;
            this.KinectC.BackColor = System.Drawing.Color.Crimson;
            this.KinectC.Location = new System.Drawing.Point(294, 150);
            this.KinectC.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.KinectC.Name = "KinectC";
            this.KinectC.Size = new System.Drawing.Size(178, 32);
            this.KinectC.TabIndex = 22;
            this.KinectC.Text = "Local Device";
            // 
            // Kinect
            // 
            this.Kinect.AutoSize = true;
            this.Kinect.Enabled = false;
            this.Kinect.Location = new System.Drawing.Point(12, 150);
            this.Kinect.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Kinect.Name = "Kinect";
            this.Kinect.Size = new System.Drawing.Size(156, 36);
            this.Kinect.TabIndex = 21;
            this.Kinect.Text = "Kinect 2";
            this.Kinect.UseVisualStyleBackColor = true;
            // 
            // Ancortek98C
            // 
            this.Ancortek98C.AutoSize = true;
            this.Ancortek98C.BackColor = System.Drawing.Color.Crimson;
            this.Ancortek98C.Location = new System.Drawing.Point(294, 50);
            this.Ancortek98C.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Ancortek98C.Name = "Ancortek98C";
            this.Ancortek98C.Size = new System.Drawing.Size(178, 32);
            this.Ancortek98C.TabIndex = 20;
            this.Ancortek98C.Text = "Local Device";
            // 
            // Ancortek58
            // 
            this.Ancortek58.AutoSize = true;
            this.Ancortek58.Enabled = false;
            this.Ancortek58.Location = new System.Drawing.Point(12, 42);
            this.Ancortek58.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Ancortek58.Name = "Ancortek58";
            this.Ancortek58.Size = new System.Drawing.Size(260, 36);
            this.Ancortek58.TabIndex = 19;
            this.Ancortek58.Text = "Ancortek 5.8 Hz ";
            this.Ancortek58.UseVisualStyleBackColor = true;
            // 
            // RFBeamC
            // 
            this.RFBeamC.AutoSize = true;
            this.RFBeamC.BackColor = System.Drawing.Color.LawnGreen;
            this.RFBeamC.Location = new System.Drawing.Point(294, 98);
            this.RFBeamC.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.RFBeamC.Name = "RFBeamC";
            this.RFBeamC.Size = new System.Drawing.Size(178, 32);
            this.RFBeamC.TabIndex = 18;
            this.RFBeamC.Text = "Local Device";
            this.RFBeamC.Click += new System.EventHandler(this.RFBeamC_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ipBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.NetworkLog);
            this.groupBox2.Controls.Add(this.NetworkEnableButton);
            this.groupBox2.Controls.Add(this.NetworkDisableButton);
            this.groupBox2.Controls.Add(this.NetworkStatusLabel);
            this.groupBox2.Controls.Add(this.IpLabel);
            this.groupBox2.Location = new System.Drawing.Point(1706, 60);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Size = new System.Drawing.Size(650, 758);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Networking";
            // 
            // ipBox
            // 
            this.ipBox.Location = new System.Drawing.Point(332, 32);
            this.ipBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(276, 38);
            this.ipBox.TabIndex = 7;
            this.ipBox.Text = "192.168.43.60";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 82);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(256, 32);
            this.label7.TabIndex = 6;
            this.label7.Text = "Connection Status:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 222);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 32);
            this.label6.TabIndex = 5;
            this.label6.Text = "Network Log:";
            // 
            // NetworkLog
            // 
            this.NetworkLog.Location = new System.Drawing.Point(36, 262);
            this.NetworkLog.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.NetworkLog.Multiline = true;
            this.NetworkLog.Name = "NetworkLog";
            this.NetworkLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.NetworkLog.Size = new System.Drawing.Size(572, 436);
            this.NetworkLog.TabIndex = 4;
            this.NetworkLog.Text = "Application Started...";
            this.NetworkLog.WordWrap = false;
            // 
            // NetworkEnableButton
            // 
            this.NetworkEnableButton.Location = new System.Drawing.Point(332, 160);
            this.NetworkEnableButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.NetworkEnableButton.Name = "NetworkEnableButton";
            this.NetworkEnableButton.Size = new System.Drawing.Size(280, 56);
            this.NetworkEnableButton.TabIndex = 3;
            this.NetworkEnableButton.Text = "Connect ";
            this.NetworkEnableButton.UseVisualStyleBackColor = true;
            this.NetworkEnableButton.Click += new System.EventHandler(this.NetworkEnableButton_Click);
            // 
            // NetworkDisableButton
            // 
            this.NetworkDisableButton.Enabled = false;
            this.NetworkDisableButton.Location = new System.Drawing.Point(36, 160);
            this.NetworkDisableButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.NetworkDisableButton.Name = "NetworkDisableButton";
            this.NetworkDisableButton.Size = new System.Drawing.Size(284, 56);
            this.NetworkDisableButton.TabIndex = 2;
            this.NetworkDisableButton.Text = "Disconnect";
            this.NetworkDisableButton.UseVisualStyleBackColor = true;
            this.NetworkDisableButton.Click += new System.EventHandler(this.NetworkDisableButton_Click);
            // 
            // NetworkStatusLabel
            // 
            this.NetworkStatusLabel.AutoSize = true;
            this.NetworkStatusLabel.BackColor = System.Drawing.Color.Red;
            this.NetworkStatusLabel.Location = new System.Drawing.Point(424, 82);
            this.NetworkStatusLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NetworkStatusLabel.Name = "NetworkStatusLabel";
            this.NetworkStatusLabel.Size = new System.Drawing.Size(188, 32);
            this.NetworkStatusLabel.TabIndex = 1;
            this.NetworkStatusLabel.Text = "Disconnected";
            // 
            // IpLabel
            // 
            this.IpLabel.AutoSize = true;
            this.IpLabel.Location = new System.Drawing.Point(30, 38);
            this.IpLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.IpLabel.Name = "IpLabel";
            this.IpLabel.Size = new System.Drawing.Size(280, 32);
            this.IpLabel.TabIndex = 0;
            this.IpLabel.Text = "Server IPv4 Address:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.repo);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.listBox2);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.listBox3);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(80, 60);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox3.Size = new System.Drawing.Size(1548, 758);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Local Devices";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(738, 704);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(218, 32);
            this.label4.TabIndex = 19;
            this.label4.Text = "Repo Directory: ";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // repo
            // 
            this.repo.Location = new System.Drawing.Point(950, 704);
            this.repo.Name = "repo";
            this.repo.Size = new System.Drawing.Size(589, 38);
            this.repo.TabIndex = 20;
            this.repo.Text = "C:\\Users\\Home\\Documents\\GestureDataRepo\\";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(2454, 884);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "Form1";
            this.Text = "Radar Data Collection";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox RFBeam;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label RFBeamC;
        private System.Windows.Forms.CheckBox Ancortek58;
        private System.Windows.Forms.Label Ancortek98C;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label IpLabel;
        private System.Windows.Forms.Label NetworkStatusLabel;
        private System.Windows.Forms.Button NetworkEnableButton;
        private System.Windows.Forms.Button NetworkDisableButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NetworkLog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ipBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label KinectC;
        private System.Windows.Forms.CheckBox Kinect;
        private System.Windows.Forms.Label LeapMotionC;
        private System.Windows.Forms.CheckBox LeapMotion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox repo;
    }
}


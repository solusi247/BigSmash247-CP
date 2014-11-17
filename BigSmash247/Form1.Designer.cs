namespace BigSmash247
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStopYARN = new System.Windows.Forms.Button();
            this.btnStopHDFS = new System.Windows.Forms.Button();
            this.btnStartYARN = new System.Windows.Forms.Button();
            this.labelYARN = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStartHDFS = new System.Windows.Forms.Button();
            this.labelHDFS = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStopStorm = new System.Windows.Forms.Button();
            this.btnStopZoo = new System.Windows.Forms.Button();
            this.btnStartStorm = new System.Windows.Forms.Button();
            this.labelStorm = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartZoo = new System.Windows.Forms.Button();
            this.labelZoo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnStopSpark = new System.Windows.Forms.Button();
            this.btnStartSpark = new System.Windows.Forms.Button();
            this.labelSpark = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnApplyMode = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.linkLabelHDFS = new System.Windows.Forms.LinkLabel();
            this.linkLabelYARN = new System.Windows.Forms.LinkLabel();
            this.linkLabelStorm = new System.Windows.Forms.LinkLabel();
            this.linkLabelSpark = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabelYARN);
            this.groupBox1.Controls.Add(this.linkLabelHDFS);
            this.groupBox1.Controls.Add(this.btnStopYARN);
            this.groupBox1.Controls.Add(this.btnStopHDFS);
            this.groupBox1.Controls.Add(this.btnStartYARN);
            this.groupBox1.Controls.Add(this.labelYARN);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnStartHDFS);
            this.groupBox1.Controls.Add(this.labelHDFS);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hadoop";
            // 
            // btnStopYARN
            // 
            this.btnStopYARN.Enabled = false;
            this.btnStopYARN.Location = new System.Drawing.Point(274, 50);
            this.btnStopYARN.Name = "btnStopYARN";
            this.btnStopYARN.Size = new System.Drawing.Size(75, 23);
            this.btnStopYARN.TabIndex = 7;
            this.btnStopYARN.Text = "Stop";
            this.btnStopYARN.UseVisualStyleBackColor = true;
            this.btnStopYARN.Click += new System.EventHandler(this.btnStopYARN_Click);
            // 
            // btnStopHDFS
            // 
            this.btnStopHDFS.Enabled = false;
            this.btnStopHDFS.Location = new System.Drawing.Point(274, 16);
            this.btnStopHDFS.Name = "btnStopHDFS";
            this.btnStopHDFS.Size = new System.Drawing.Size(75, 23);
            this.btnStopHDFS.TabIndex = 6;
            this.btnStopHDFS.Text = "Stop";
            this.btnStopHDFS.UseVisualStyleBackColor = true;
            this.btnStopHDFS.Click += new System.EventHandler(this.btnStopHDFS_Click);
            // 
            // btnStartYARN
            // 
            this.btnStartYARN.Location = new System.Drawing.Point(196, 50);
            this.btnStartYARN.Name = "btnStartYARN";
            this.btnStartYARN.Size = new System.Drawing.Size(75, 23);
            this.btnStartYARN.TabIndex = 5;
            this.btnStartYARN.Text = "Start";
            this.btnStartYARN.UseVisualStyleBackColor = true;
            this.btnStartYARN.Click += new System.EventHandler(this.btnStartYARN_Click);
            // 
            // labelYARN
            // 
            this.labelYARN.AutoSize = true;
            this.labelYARN.BackColor = System.Drawing.Color.Salmon;
            this.labelYARN.Location = new System.Drawing.Point(85, 55);
            this.labelYARN.Name = "labelYARN";
            this.labelYARN.Size = new System.Drawing.Size(29, 13);
            this.labelYARN.TabIndex = 4;
            this.labelYARN.Text = "Stop";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "YARN";
            // 
            // btnStartHDFS
            // 
            this.btnStartHDFS.Location = new System.Drawing.Point(196, 16);
            this.btnStartHDFS.Name = "btnStartHDFS";
            this.btnStartHDFS.Size = new System.Drawing.Size(75, 23);
            this.btnStartHDFS.TabIndex = 2;
            this.btnStartHDFS.Text = "Start";
            this.btnStartHDFS.UseVisualStyleBackColor = true;
            this.btnStartHDFS.Click += new System.EventHandler(this.btnStartHDFS_Click);
            // 
            // labelHDFS
            // 
            this.labelHDFS.AutoSize = true;
            this.labelHDFS.BackColor = System.Drawing.Color.Salmon;
            this.labelHDFS.Location = new System.Drawing.Point(85, 21);
            this.labelHDFS.Name = "labelHDFS";
            this.labelHDFS.Size = new System.Drawing.Size(29, 13);
            this.labelHDFS.TabIndex = 1;
            this.labelHDFS.Text = "Stop";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "HDFS";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "BigSmash247";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
            this.contextMenuStrip1.Text = "About";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem1.Text = "About";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem2.Text = "Exit";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkLabelStorm);
            this.groupBox2.Controls.Add(this.btnStopStorm);
            this.groupBox2.Controls.Add(this.btnStopZoo);
            this.groupBox2.Controls.Add(this.btnStartStorm);
            this.groupBox2.Controls.Add(this.labelStorm);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnStartZoo);
            this.groupBox2.Controls.Add(this.labelZoo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(4, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 86);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Storm";
            // 
            // btnStopStorm
            // 
            this.btnStopStorm.Enabled = false;
            this.btnStopStorm.Location = new System.Drawing.Point(274, 50);
            this.btnStopStorm.Name = "btnStopStorm";
            this.btnStopStorm.Size = new System.Drawing.Size(75, 23);
            this.btnStopStorm.TabIndex = 7;
            this.btnStopStorm.Text = "Stop";
            this.btnStopStorm.UseVisualStyleBackColor = true;
            this.btnStopStorm.Click += new System.EventHandler(this.btnStopStorm_Click);
            // 
            // btnStopZoo
            // 
            this.btnStopZoo.Enabled = false;
            this.btnStopZoo.Location = new System.Drawing.Point(274, 18);
            this.btnStopZoo.Name = "btnStopZoo";
            this.btnStopZoo.Size = new System.Drawing.Size(75, 23);
            this.btnStopZoo.TabIndex = 6;
            this.btnStopZoo.Text = "Stop";
            this.btnStopZoo.UseVisualStyleBackColor = true;
            this.btnStopZoo.Click += new System.EventHandler(this.btnStopZoo_Click);
            // 
            // btnStartStorm
            // 
            this.btnStartStorm.Location = new System.Drawing.Point(196, 50);
            this.btnStartStorm.Name = "btnStartStorm";
            this.btnStartStorm.Size = new System.Drawing.Size(75, 23);
            this.btnStartStorm.TabIndex = 5;
            this.btnStartStorm.Text = "Start";
            this.btnStartStorm.UseVisualStyleBackColor = true;
            this.btnStartStorm.Click += new System.EventHandler(this.btnStartStorm_Click);
            // 
            // labelStorm
            // 
            this.labelStorm.AutoSize = true;
            this.labelStorm.BackColor = System.Drawing.Color.Salmon;
            this.labelStorm.Location = new System.Drawing.Point(85, 55);
            this.labelStorm.Name = "labelStorm";
            this.labelStorm.Size = new System.Drawing.Size(29, 13);
            this.labelStorm.TabIndex = 4;
            this.labelStorm.Text = "Stop";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "STORM";
            // 
            // btnStartZoo
            // 
            this.btnStartZoo.Location = new System.Drawing.Point(196, 18);
            this.btnStartZoo.Name = "btnStartZoo";
            this.btnStartZoo.Size = new System.Drawing.Size(75, 23);
            this.btnStartZoo.TabIndex = 2;
            this.btnStartZoo.Text = "Start";
            this.btnStartZoo.UseVisualStyleBackColor = true;
            this.btnStartZoo.Click += new System.EventHandler(this.btnStartZoo_Click);
            // 
            // labelZoo
            // 
            this.labelZoo.AutoSize = true;
            this.labelZoo.BackColor = System.Drawing.Color.Salmon;
            this.labelZoo.Location = new System.Drawing.Point(85, 23);
            this.labelZoo.Name = "labelZoo";
            this.labelZoo.Size = new System.Drawing.Size(29, 13);
            this.labelZoo.TabIndex = 1;
            this.labelZoo.Text = "Stop";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "ZooKeeper";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.linkLabelSpark);
            this.groupBox3.Controls.Add(this.btnStopSpark);
            this.groupBox3.Controls.Add(this.btnStartSpark);
            this.groupBox3.Controls.Add(this.labelSpark);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(4, 222);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(354, 59);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Other";
            // 
            // btnStopSpark
            // 
            this.btnStopSpark.Enabled = false;
            this.btnStopSpark.Location = new System.Drawing.Point(274, 19);
            this.btnStopSpark.Name = "btnStopSpark";
            this.btnStopSpark.Size = new System.Drawing.Size(75, 23);
            this.btnStopSpark.TabIndex = 6;
            this.btnStopSpark.Text = "Stop";
            this.btnStopSpark.UseVisualStyleBackColor = true;
            this.btnStopSpark.Click += new System.EventHandler(this.btnStopSpark_Click);
            // 
            // btnStartSpark
            // 
            this.btnStartSpark.Location = new System.Drawing.Point(196, 19);
            this.btnStartSpark.Name = "btnStartSpark";
            this.btnStartSpark.Size = new System.Drawing.Size(75, 23);
            this.btnStartSpark.TabIndex = 2;
            this.btnStartSpark.Text = "Start";
            this.btnStartSpark.UseVisualStyleBackColor = true;
            this.btnStartSpark.Click += new System.EventHandler(this.btnStartSpark_Click);
            // 
            // labelSpark
            // 
            this.labelSpark.AutoSize = true;
            this.labelSpark.BackColor = System.Drawing.Color.Salmon;
            this.labelSpark.Location = new System.Drawing.Point(85, 24);
            this.labelSpark.Name = "labelSpark";
            this.labelSpark.Size = new System.Drawing.Size(29, 13);
            this.labelSpark.TabIndex = 1;
            this.labelSpark.Text = "Stop";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Spark";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mode: ";
            // 
            // btnApplyMode
            // 
            this.btnApplyMode.Location = new System.Drawing.Point(278, 8);
            this.btnApplyMode.Name = "btnApplyMode";
            this.btnApplyMode.Size = new System.Drawing.Size(75, 23);
            this.btnApplyMode.TabIndex = 12;
            this.btnApplyMode.Text = "Apply";
            this.btnApplyMode.UseVisualStyleBackColor = true;
            this.btnApplyMode.Click += new System.EventHandler(this.btnApplyMode_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Standalone",
            "Pseudo"});
            this.comboBox1.Location = new System.Drawing.Point(90, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(182, 21);
            this.comboBox1.TabIndex = 13;
            // 
            // linkLabelHDFS
            // 
            this.linkLabelHDFS.AutoSize = true;
            this.linkLabelHDFS.Location = new System.Drawing.Point(83, 35);
            this.linkLabelHDFS.Name = "linkLabelHDFS";
            this.linkLabelHDFS.Size = new System.Drawing.Size(113, 13);
            this.linkLabelHDFS.TabIndex = 8;
            this.linkLabelHDFS.TabStop = true;
            this.linkLabelHDFS.Text = "http://localhost:50070";
            this.linkLabelHDFS.Visible = false;
            this.linkLabelHDFS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHDFS_LinkClicked);
            // 
            // linkLabelYARN
            // 
            this.linkLabelYARN.AutoSize = true;
            this.linkLabelYARN.Location = new System.Drawing.Point(83, 69);
            this.linkLabelYARN.Name = "linkLabelYARN";
            this.linkLabelYARN.Size = new System.Drawing.Size(107, 13);
            this.linkLabelYARN.TabIndex = 9;
            this.linkLabelYARN.TabStop = true;
            this.linkLabelYARN.Text = "http://localhost:8088";
            this.linkLabelYARN.Visible = false;
            this.linkLabelYARN.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelYARN_LinkClicked);
            // 
            // linkLabelStorm
            // 
            this.linkLabelStorm.AutoSize = true;
            this.linkLabelStorm.Location = new System.Drawing.Point(83, 69);
            this.linkLabelStorm.Name = "linkLabelStorm";
            this.linkLabelStorm.Size = new System.Drawing.Size(107, 13);
            this.linkLabelStorm.TabIndex = 8;
            this.linkLabelStorm.TabStop = true;
            this.linkLabelStorm.Text = "http://localhost:8080";
            this.linkLabelStorm.Visible = false;
            this.linkLabelStorm.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelStorm_LinkClicked);
            // 
            // linkLabelSpark
            // 
            this.linkLabelSpark.AutoSize = true;
            this.linkLabelSpark.Location = new System.Drawing.Point(83, 38);
            this.linkLabelSpark.Name = "linkLabelSpark";
            this.linkLabelSpark.Size = new System.Drawing.Size(107, 13);
            this.linkLabelSpark.TabIndex = 7;
            this.linkLabelSpark.TabStop = true;
            this.linkLabelSpark.Text = "http://localhost:8000";
            this.linkLabelSpark.Visible = false;
            this.linkLabelSpark.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSpark_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(363, 296);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnApplyMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BigSmash247 Control Panel";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStartYARN;
        private System.Windows.Forms.Label labelYARN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStartHDFS;
        private System.Windows.Forms.Label labelHDFS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStopYARN;
        private System.Windows.Forms.Button btnStopHDFS;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStopStorm;
        private System.Windows.Forms.Button btnStopZoo;
        private System.Windows.Forms.Button btnStartStorm;
        private System.Windows.Forms.Label labelStorm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStartZoo;
        private System.Windows.Forms.Label labelZoo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnStopSpark;
        private System.Windows.Forms.Button btnStartSpark;
        private System.Windows.Forms.Label labelSpark;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnApplyMode;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.LinkLabel linkLabelYARN;
        private System.Windows.Forms.LinkLabel linkLabelHDFS;
        private System.Windows.Forms.LinkLabel linkLabelStorm;
        private System.Windows.Forms.LinkLabel linkLabelSpark;
    }
}

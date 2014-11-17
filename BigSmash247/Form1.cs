using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;

namespace BigSmash247
{
    public partial class Form1 : Form
    {
        string bigSmashPath;
        string hadoopPath;
        string zooPath;
        string stormPath;
        string sparkPath;        

        // Create Symlink
        // http://stackoverflow.com/questions/11156754/what-the-c-sharp-equivalent-of-mklink-j 
        [DllImport("kernel32.dll")]
        static extern bool CreateSymbolicLink(
        string lpSymlinkFileName, string lpTargetFileName, SymbolicLink dwFlags);

        enum SymbolicLink
        {
            File = 0,
            Directory = 1
        }

        public Form1()
        {
            InitializeComponent();

            // check envvars
            bigSmashPath = GetEnvironmentVariableByName("BIGSMASH_HOME");
            if (bigSmashPath == "Not found!")
            {
                MessageBox.Show("Environment variable BIGSMASH_HOME not found.", "Exit Application",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            hadoopPath = GetEnvironmentVariableByName("HADOOP_HOME");
            if (hadoopPath == "Not found!")
            {
                MessageBox.Show("Environment variable HADOOP_HOME not found.", "Exit Application",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            zooPath = GetEnvironmentVariableByName("ZOOKEEPER_HOME");
            if (zooPath == "Not found!")
            {
                MessageBox.Show("Environment variable ZOOKEEPER_HOME not found.", "Exit Application",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            stormPath = GetEnvironmentVariableByName("STORM_HOME");
            if (stormPath == "Not found!")
            {
                MessageBox.Show("Environment variable STORM_HOME not found.", "Exit Application",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            sparkPath = GetEnvironmentVariableByName("SPARK_HOME");
            if (sparkPath == "Not found!")
            {
                MessageBox.Show("Environment variable SPARK_HOME not found.", "Exit Application",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }  

            /* Taken from:
             * https://namgivu.wordpress.com/2010/11/12/c-how-to-get-screen-resolutionwidthheight
             */
            var screen = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            var width = screen.Width;
            var height = screen.Height;
            this.Top = height - 370;
            this.Left = width - 380;

            // Check hadoop mode
            checkHadoopMode();
        }

        /* My Functions */
        //private void checkEnvVars(string pathName, string )

        // http://www.dreamincode.net/forums/topic/178713-working-with-environment-variables-in-c%23/
        public string GetEnvironmentVariableByName(string envName)
        {
            try
            {
                //get the variable
                string variable = Environment.GetEnvironmentVariable(envName);

                //check for a value, if nothing is returned let the application know
                if (!string.IsNullOrEmpty(variable))
                    return variable;
                else
                    return "Not found!";                    
            }
            catch (SecurityException ex)
            {
                //Console.WriteLine(string.Format("Error searching for environment variable: {0}", ex.Message));
                MessageBox.Show("Error searching for environment variable: " + ex.Message, "Error");
                return string.Empty;
            }
        }

        private void checkHadoopMode()
        {
            string hdp_mode = GetSetting("hadoop_mode");
            if (hdp_mode == "Standalone")
            {
                comboBox1.Text = "Standalone";
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
            }
            else if (hdp_mode == "Pseudo")
            {
                comboBox1.Text = "Pseudo";
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                checkDaemonsStatus();
            }
        }

        public void refreshYarnStatus()
        {
            string res3 = checkDaemons("ResourceManager");
            string res4 = checkDaemons("NodeManager");
            if (res3 == "0" & res4 == "0")
            {
                labelYARN.Text = "Running";
                labelYARN.BackColor = Color.LightGreen;
                btnStartYARN.Enabled = false;
                btnStopYARN.Enabled = true;
            }
            else
            {
                labelYARN.Text = "Stop";
                labelYARN.BackColor = Color.Salmon;
                btnStartYARN.Enabled = true;
                btnStopYARN.Enabled = false;
            }
        }

        private void checkDaemonsStatus()
        {
            /* Check if daemons is already running. */
            // HDFS (NameNode & DataNode)
            string res1 = checkDaemons("NameNode");
            string res2 = checkDaemons("DataNode");
            if (res1 == "0" & res2 == "0")
            {
                labelHDFS.Text = "Running";
                labelHDFS.BackColor = Color.LightGreen;
                btnStartHDFS.Enabled = false;
                btnStopHDFS.Enabled = true;
            }
            else
            {
                labelHDFS.Text = "Stop";
                labelHDFS.BackColor = Color.Salmon;
                btnStartHDFS.Enabled = true;
                btnStopHDFS.Enabled = false;
            }
            // YARN (ResourceManager & NodeManager)
            string res3 = checkDaemons("ResourceManager");
            string res4 = checkDaemons("NodeManager");
            if (res3 == "0" & res4 == "0")
            {
                labelYARN.Text = "Running";
                labelYARN.BackColor = Color.LightGreen;
                btnStartYARN.Enabled = false;
                btnStopYARN.Enabled = true;
            }
            else
            {
                labelYARN.Text = "Stop";
                labelYARN.BackColor = Color.Salmon;
                btnStartYARN.Enabled = true;
                btnStopYARN.Enabled = false;
            }
            // ZooKeeper
            string res5 = checkDaemons("org.apache.zookeeper.server.quorum.QuorumPeerMain");
            if (res5 == "0")
            {
                labelZoo.Text = "Running";
                labelZoo.BackColor = Color.LightGreen;
                btnStartZoo.Enabled = false;
                btnStopZoo.Enabled = true;
            }
            else
            {
                labelZoo.Text = "Stop";
                labelZoo.BackColor = Color.Salmon;
                btnStartZoo.Enabled = true;
                btnStopZoo.Enabled = false;
            }
            // Storm Daemons (Nimbus, Supervisor & UI)
            string res6 = checkDaemons("backtype.storm.daemon.nimbus");
            string res7 = checkDaemons("backtype.storm.daemon.supervisor");
            string res8 = checkDaemons("backtype.storm.ui.core");
            if (res6 == "0" & res7 == "0" & res8 == "0")
            {
                labelStorm.Text = "Running";
                labelStorm.BackColor = Color.LightGreen;
                btnStartStorm.Enabled = false;
                btnStopStorm.Enabled = true;
            }
            else
            {
                labelStorm.Text = "Stop";
                labelStorm.BackColor = Color.Salmon;
                btnStartStorm.Enabled = true;
                btnStopStorm.Enabled = false;
            }
            // Spark Daemons (Master, Worker)
            string res9 = checkDaemons("org.apache.spark.deploy.master.Master");
            string res10 = checkDaemons("org.apache.spark.deploy.worker.Worker");
            if (res9 == "0" & res10 == "0")
            {
                labelSpark.Text = "Running";
                labelSpark.BackColor = Color.LightGreen;
                btnStartSpark.Enabled = false;
                btnStopSpark.Enabled = true;
            }
            else
            {
                labelSpark.Text = "Stop";
                labelSpark.BackColor = Color.Salmon;
                btnStartSpark.Enabled = true;
                btnStopSpark.Enabled = false;
            }
        }

        private string checkDaemons(string paramName)
        {
            ProcessStartInfo si = new System.Diagnostics.ProcessStartInfo();
            si.CreateNoWindow = true;
            si.FileName = bigSmashPath + "\\tools\\check_daemons.cmd";
            si.Arguments = paramName;
            si.UseShellExecute = false;
            si.RedirectStandardOutput = true;
            Process p = System.Diagnostics.Process.Start(si);
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return output.ToString().TrimEnd('\r', '\n');
        }

        private string getPID(string paramName)
        {
            ProcessStartInfo si = new System.Diagnostics.ProcessStartInfo();
            si.CreateNoWindow = true;
            si.FileName = bigSmashPath + "\\tools\\get_pid.cmd";
            si.Arguments = paramName;
            si.UseShellExecute = false;
            si.RedirectStandardOutput = true;
            Process p = System.Diagnostics.Process.Start(si);
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return output.ToString().TrimEnd('\r', '\n');
        }

        private int runDaemons(string pFileName, string pArgName)
        {
            /*
             * Taken from:
             * http://stackoverflow.com/questions/1271938/how-to-run-batch-file-from-c-sharp-in-the-background
             * http://stackoverflow.com/questions/1585354/get-return-value-from-process
             */
            ProcessStartInfo si = new System.Diagnostics.ProcessStartInfo();
            si.CreateNoWindow = true;
            si.FileName = pFileName;
            if (pArgName != "")
            {
                si.Arguments = " " + pArgName;
            }
            si.UseShellExecute = false;
            Process p = System.Diagnostics.Process.Start(si);
            p.WaitForExit();
            int retval = p.ExitCode;
            return retval;
        }

        private int runDaemonsAsAdmin(string pFileName, string pArgName)
        {
            ProcessStartInfo si = new System.Diagnostics.ProcessStartInfo();
            si.CreateNoWindow = true;
            si.FileName = pFileName;
            if (pArgName != "")
            {
                si.Arguments = " " + pArgName;
            }
            si.UseShellExecute = true;
            si.Verb = "runas";
            Process p = System.Diagnostics.Process.Start(si);
            p.WaitForExit();
            int retval = p.ExitCode;
            return retval;
        }

        private int runDaemonsNoWait(string pFileName, string pArgName, string pDaemonName)
        {
            ProcessStartInfo si = new System.Diagnostics.ProcessStartInfo();
            si.CreateNoWindow = true;
            si.FileName = pFileName;
            if (pArgName != "")
            {
                si.Arguments = " " + pArgName;
            }
            si.UseShellExecute = false;
            Process p = System.Diagnostics.Process.Start(si);
            Thread.Sleep(5000); // 5 detik
            // check if daemons is running well
            string retval = checkDaemons(pDaemonName);
            if (retval == "0")
                return 0;
            else
                return 1;
        }

        private int killDaemons(string paramName)
        {
            string daemonPID = getPID(paramName);
            ProcessStartInfo si = new System.Diagnostics.ProcessStartInfo();
            si.CreateNoWindow = true;
            si.FileName = "taskkill.exe";
            si.Arguments = " /F /PID " + daemonPID;
            si.UseShellExecute = false;
            Process p = System.Diagnostics.Process.Start(si);
            p.WaitForExit();
            int retval = p.ExitCode;
            return retval;
        }

        // App.config
        // http://stackoverflow.com/questions/4758598/write-values-in-app-config-file
        private static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        private static void SetSetting(string key, string value)
        {
            /*
            Configuration configuration =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
            */
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
        }

        /* Auto Generated Functions */
        private void btnStartHDFS_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int retval = runDaemons(hadoopPath + "\\sbin\\start-dfs.cmd", "");
            Thread.Sleep(15000); // 15 detik
            if (retval == 0)
            {
                labelHDFS.Text = "Running";
                labelHDFS.BackColor = Color.LightGreen;
                btnStartHDFS.Enabled = false;
                btnStopHDFS.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnStopHDFS_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int retval = runDaemons(hadoopPath + "\\sbin\\stop-dfs.cmd", "");
            if (retval == 0)
            {
                labelHDFS.Text = "Stop";
                labelHDFS.BackColor = Color.Salmon;
                btnStartHDFS.Enabled = true;
                btnStopHDFS.Enabled = false;
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnStartYARN_Click(object sender, EventArgs e)
        {
            if (System.Environment.OSVersion.Version.Major == 6 &&
                System.Environment.OSVersion.Version.Minor == 1)
            {
                frmYarnError a = new frmYarnError(this);
                a.ShowDialog();
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                int retval = runDaemons(hadoopPath + "\\sbin\\start-yarn.cmd", "");
                Thread.Sleep(10000); // 10 detik           

                if (retval == 0)
                {
                    labelYARN.Text = "Running";
                    labelYARN.BackColor = Color.LightGreen;
                    btnStartYARN.Enabled = false;
                    btnStopYARN.Enabled = true;
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void btnStopYARN_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int retval = runDaemons(hadoopPath + "\\sbin\\stop-yarn.cmd", "");
            if (retval == 0)
            {
                labelYARN.Text = "Stop";
                labelYARN.BackColor = Color.Salmon;
                btnStartYARN.Enabled = true;
                btnStopYARN.Enabled = false;
                Cursor.Current = Cursors.Default;
            }
        }

        /*
         * NotifyIcon examples taken from:
         * http://www.developer.com/net/net/article.php/3336751/C-Tip-Placing-Your-C-Application-in-the-System-Tray.htm
         */
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
            else if (FormWindowState.Normal == WindowState)
            {
                Hide();
                WindowState = FormWindowState.Minimized;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.ShowDialog();
        }

        private void btnStartZoo_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int retval = runDaemonsNoWait(zooPath + "\\bin\\zkServer.cmd", "", "org.apache.zookeeper.server.quorum.QuorumPeerMain");

            if (retval == 0)
            {
                labelZoo.Text = "Running";
                labelZoo.BackColor = Color.LightGreen;
                btnStartZoo.Enabled = false;
                btnStopZoo.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnStopZoo_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            // ZooKeeper
            int retvalZoo = killDaemons("org.apache.zookeeper.server.quorum.QuorumPeerMain");

            if (retvalZoo == 0)
            {
                labelZoo.Text = "Stop";
                labelZoo.BackColor = Color.Salmon;
                btnStartZoo.Enabled = true;
                btnStopZoo.Enabled = false;
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnStartStorm_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            // make sure ZooKeeper is running
            string zooPID = getPID("org.apache.zookeeper.server.quorum.QuorumPeerMain");
            if (zooPID == "")
            {
                MessageBox.Show("Please start the ZooKeeper service first.", "ZooKeeper not running",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // nimbus
                int retvalNimbus = runDaemons(stormPath + "\\bin\\storm.cmd", "nimbus");
                // supervisor
                int retvalSupervisor = runDaemons(stormPath + "\\bin\\storm.cmd", "supervisor");
                // ui
                int retvalUI = runDaemons(stormPath + "\\bin\\storm.cmd", "ui");

                if (retvalNimbus == 0 & retvalSupervisor == 0 & retvalUI == 0)
                {
                    labelStorm.Text = "Running";
                    labelStorm.BackColor = Color.LightGreen;
                    btnStartStorm.Enabled = false;
                    btnStopStorm.Enabled = true;
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void btnStopStorm_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            // nimbus
            int retvalNimbus = killDaemons("backtype.storm.daemon.nimbus");
            // supervisor
            int retvalSupervisor = killDaemons("backtype.storm.daemon.supervisor");
            // ui
            int retvalUI = killDaemons("backtype.storm.ui.core");

            if (retvalNimbus == 0 & retvalSupervisor == 0 & retvalUI == 0)
            {
                labelStorm.Text = "Stop";
                labelStorm.BackColor = Color.Salmon;
                btnStartStorm.Enabled = true;
                btnStopStorm.Enabled = false;
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnStartSpark_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int retvalMaster = runDaemonsNoWait(sparkPath + "\\bin\\spark-class.cmd", "org.apache.spark.deploy.master.Master", "org.apache.spark.deploy.master.Master");
            int retvalWorker = runDaemonsNoWait(sparkPath + "\\bin\\spark-class.cmd", "org.apache.spark.deploy.worker.Worker spark://localhost:7077", "org.apache.spark.deploy.worker.Worker");

            if (retvalMaster == 0 & retvalWorker == 0)
            {
                labelSpark.Text = "Running";
                labelSpark.BackColor = Color.LightGreen;
                btnStartSpark.Enabled = false;
                btnStopSpark.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnStopSpark_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int retvalMaster = killDaemons("org.apache.spark.deploy.master.Master");
            int retvalWorker = killDaemons("org.apache.spark.deploy.worker.Worker");

            if (retvalMaster == 0 & retvalWorker == 0)
            {
                labelSpark.Text = "Stop";
                labelSpark.BackColor = Color.Salmon;
                btnStartSpark.Enabled = true;
                btnStopSpark.Enabled = false;
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnApplyMode_Click(object sender, EventArgs e)
        {
            SetSetting("hadoop_mode", comboBox1.Text);
            // Create Symlink
            // http://stackoverflow.com/questions/11156754/what-the-c-sharp-equivalent-of-mklink-j        
            string symbolicLink = hadoopPath + "\\etc\\hadoop";
            string fileName = hadoopPath + "\\etc\\hadoop_" + comboBox1.Text;
            if (Directory.Exists(symbolicLink))
            {
                Directory.Delete(symbolicLink, true);
            }
            CreateSymbolicLink(symbolicLink, fileName, SymbolicLink.Directory);

            // check daemons status
            if (comboBox1.Text == "Standalone")
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
            }
            else if (comboBox1.Text == "Pseudo")
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                checkDaemonsStatus();
            }
        }
    }
}

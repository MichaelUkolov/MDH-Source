using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.notifyIcon1.MouseDoubleClick += new MouseEventHandler(notifyIcon1_MouseDoubleClick);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            string[] Drives = Environment.GetLogicalDrives();
            foreach (string s in Drives)
            {
                comboBox1.Items.Insert(0, s);
            }
            comboBox1.Items.Remove(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Disk = comboBox1.Text;
            Process Cmd = new Process();
            Cmd.StartInfo.FileName = "cmd.exe";
            Cmd.StartInfo.Verb = "runas";
            Cmd.StartInfo.Arguments = @"/c CHKDSK /F /R " + (Disk.Remove(Disk.LastIndexOf('\\')));
            Cmd.Start();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 box = new AboutBox1();
            box.Show();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            GET("http://micl.hol.es/apps/mdh/launch.php","new");
        }
        public void Form1_Resize(Object sender, System.EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;

                this.Hide();
            }
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private static string GET(string Url, string Data)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(Url + "?" + Data);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }

        private void обновленияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GET("http://micl.hol.es/apps/mdh/chkupd/check.php", "value=39511r1") == "39511r1")
            {
                Form check = new Form3("Установлена последняя версия.");
                check.Size = new Size(250,99);
                check.Show();
            }
            else
            {
                Form check = new Form3("Доступно обновление: http://micl.hol.es/mdh_update");
                check.Size = new Size(330, 99);
                check.Show();
            }
        }
        

       
    }
}

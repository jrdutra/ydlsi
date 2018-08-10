using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ydlsi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtUrl.Text = "";
            txtUrl.Text = Clipboard.GetText();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUrl.Text = "";
            txtUrl.Text = Clipboard.GetText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("youtube-dl.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            string ytdl_args;
            ytdl_args = "\"" + txtUrl.Text + "\"";
            startInfo.Arguments = ytdl_args;


            Process.Start(startInfo);
        }

        private void btnDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                lblDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}

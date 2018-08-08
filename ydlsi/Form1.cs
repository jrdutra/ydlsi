using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string strCmdText;
            strCmdText = "start youtube-dl \"" + txtUrl.Text + "\"";
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        }
    }
}

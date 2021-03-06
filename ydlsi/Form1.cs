﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;


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
            //Lendo Json
            string path = ".\\info.json";
            string json_string;
            if (File.Exists(path))
            {
                json_string = File.ReadAllText(path);
                Data data = JsonConvert.DeserializeObject<Data>(json_string);
                btnDir.Text = data.out_dir;
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("youtube-dl.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            string ytdl_args;
            ytdl_args = "-o \"" + lblDir.Text + "\\%(title)s.%(ext)s\" " + txtUrl.Text;
            startInfo.Arguments = ytdl_args;


            Process.Start(startInfo);
        }

        private void btnDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Data _data = new Data();
                _data.out_dir = folderBrowserDialog1.SelectedPath;
                string json = JsonConvert.SerializeObject(_data);
                System.IO.File.WriteAllText(".\\info.json", json);
                btnDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }

    public class Data
    {
        public string out_dir { get; set; }
    }
}

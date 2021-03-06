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
using System.IO;

namespace G_Code_to_NanoScribe
{
    public partial class Main_App : Form
    {

        public Main_App()
        {
            InitializeComponent();
        }

        public void p_Exited(object sender, EventArgs e)
        {
            SetStatus(Status, "Done");
        }

        delegate void SetTextCallback(TextBox Status, string text);

        private void SetStatus(TextBox Status, string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (Status.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetStatus);
                this.Invoke(d, new object[] { Status, text });
            }
            else
            {
                Status.Text = text;
            }
        }

        public void Find_Python_Script()
        {
            if (File.Exists(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\convert.py"))
            {
                System.IO.File.WriteAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\setup.ini", System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\convert.py");
            }
            else
            {
                OpenFileDialog Python_Script = new OpenFileDialog();
                Python_Script.Filter = "Python Scripts (.py)|*.py|All Files (*.*)|*.*";
                Python_Script.FilterIndex = 1;
                Python_Script.Title = "Choose a Python Script";
                bool done = Convert.ToBoolean(Python_Script.ShowDialog());
                if (done)
                {
                    System.IO.File.WriteAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\setup.ini", Python_Script.FileName);
                }
            }
        }

        private void Run_Button_Click(object sender, EventArgs e)
        {
            p.StartInfo.FileName = "C:\\Python27\\python.exe";
            if (!File.Exists(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\setup.ini"))
                Find_Python_Script();
            try
            {
                if (!File.Exists(System.IO.File.ReadAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\setup.ini")))
                    Find_Python_Script();
                Convert.ToInt32(Skip_Layers.Text);
                p.StartInfo.Arguments = "\"" + System.IO.File.ReadAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\setup.ini") + "\" \"" + Input_File.Text + "\" \"" + Output_File.Text + "\" " + Skip_Layers.Text + " " + X_Size.Text + " " + Y_Size.Text + " " + Z_Size.Text + " " + X_Shift.Text + " " + Y_Shift.Text;
                Console.WriteLine(p.StartInfo.Arguments);
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                p.Start();
                Output_Data.Text = "";
                try
                {
                    p.BeginOutputReadLine();
                    p.BeginErrorReadLine();
                }
                catch (InvalidOperationException)
                { }
                Status.Text = "Running";
            }
            catch (FormatException)
            {
                Status.Text = "Error: Enter the right Format in text boxes";
            }
        }

        private void Save_File_Click(object sender, EventArgs e)
        {
            SaveFileDialog Out_File = new SaveFileDialog();
            Out_File.Filter = "General Writing Language Files (.gwl)|*.gwl|All Files (*.*)|*.*";
            Out_File.FilterIndex = 1;
            Out_File.Title = "Choose a file to Output to";
            bool okClicked = Convert.ToBoolean(Out_File.ShowDialog());
            if (okClicked)
            {
                Output_File.Text = Out_File.FileName;
            }
        }

        private void Open_File_Click(object sender, EventArgs e)
        {
            OpenFileDialog Open_File_Box = new OpenFileDialog();
            Open_File_Box.Filter = "G-Code Files (.gcode)|*.gcode|All Files (*.*)|*.*";
            Open_File_Box.FilterIndex = 1;
            Open_File_Box.Multiselect = false;
            Open_File_Box.Title = "Choose a File to Convert";
            bool okClicked = Convert.ToBoolean(Open_File_Box.ShowDialog());
            if (okClicked)
                Input_File.Text = Open_File_Box.FileName;
        }

        async Task Get_Status()
        {
            StreamReader q = p.StandardOutput;
            while (!p.HasExited)
                Console.WriteLine(q.ReadLine());
            await Task.Delay(1000);
        }

        private void Main_App_Load(object sender, EventArgs e)
        {
            p.EnableRaisingEvents = true;
            p.Exited += new System.EventHandler(p_Exited);
            p.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(p_OutputDataReceived);
            p.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(p_OutputDataReceived);
        }

        private void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine("Hi");
            SetStatus(Output_Data,Output_Data.Text + e.Data);
        }
    }
}

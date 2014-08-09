using System.Diagnostics;

namespace G_Code_to_NanoScribe
{
    partial class Main_App
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
        public Process p = new Process();
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_App));
            this.Run_Button = new System.Windows.Forms.Button();
            this.Open_File = new System.Windows.Forms.Button();
            this.Save_File = new System.Windows.Forms.Button();
            this.Input_Label = new System.Windows.Forms.Label();
            this.Output_Label = new System.Windows.Forms.Label();
            this.Input_File = new System.Windows.Forms.TextBox();
            this.Output_File = new System.Windows.Forms.TextBox();
            this.Status = new System.Windows.Forms.TextBox();
            this.Status_Label = new System.Windows.Forms.Label();
            this.Skip_Layers = new System.Windows.Forms.TextBox();
            this.SkipLayersLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Run_Button
            // 
            this.Run_Button.Location = new System.Drawing.Point(210, 167);
            this.Run_Button.Name = "Run_Button";
            this.Run_Button.Size = new System.Drawing.Size(235, 23);
            this.Run_Button.TabIndex = 0;
            this.Run_Button.Text = "Run";
            this.Run_Button.UseVisualStyleBackColor = true;
            this.Run_Button.Click += new System.EventHandler(this.Run_Button_Click);
            // 
            // Open_File
            // 
            this.Open_File.Location = new System.Drawing.Point(15, 25);
            this.Open_File.Name = "Open_File";
            this.Open_File.Size = new System.Drawing.Size(75, 23);
            this.Open_File.TabIndex = 1;
            this.Open_File.Text = "Choose File";
            this.Open_File.UseVisualStyleBackColor = true;
            this.Open_File.Click += new System.EventHandler(this.Open_File_Click);
            // 
            // Save_File
            // 
            this.Save_File.Location = new System.Drawing.Point(15, 87);
            this.Save_File.Name = "Save_File";
            this.Save_File.Size = new System.Drawing.Size(75, 23);
            this.Save_File.TabIndex = 1;
            this.Save_File.Text = "Choose File";
            this.Save_File.UseVisualStyleBackColor = true;
            this.Save_File.Click += new System.EventHandler(this.Save_File_Click);
            // 
            // Input_Label
            // 
            this.Input_Label.AutoSize = true;
            this.Input_Label.Location = new System.Drawing.Point(12, 9);
            this.Input_Label.Name = "Input_Label";
            this.Input_Label.Size = new System.Drawing.Size(89, 13);
            this.Input_Label.TabIndex = 2;
            this.Input_Label.Text = "G-Code Input File";
            // 
            // Output_Label
            // 
            this.Output_Label.AutoSize = true;
            this.Output_Label.Location = new System.Drawing.Point(12, 71);
            this.Output_Label.Name = "Output_Label";
            this.Output_Label.Size = new System.Drawing.Size(117, 13);
            this.Output_Label.TabIndex = 2;
            this.Output_Label.Text = "NanoScribe Output File";
            // 
            // Input_File
            // 
            this.Input_File.Location = new System.Drawing.Point(96, 27);
            this.Input_File.Name = "Input_File";
            this.Input_File.Size = new System.Drawing.Size(538, 20);
            this.Input_File.TabIndex = 3;
            // 
            // Output_File
            // 
            this.Output_File.Location = new System.Drawing.Point(96, 89);
            this.Output_File.Name = "Output_File";
            this.Output_File.Size = new System.Drawing.Size(538, 20);
            this.Output_File.TabIndex = 3;
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(210, 196);
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Size = new System.Drawing.Size(235, 20);
            this.Status.TabIndex = 4;
            this.Status.Text = "Idle";
            // 
            // Status_Label
            // 
            this.Status_Label.AutoSize = true;
            this.Status_Label.Location = new System.Drawing.Point(158, 199);
            this.Status_Label.Name = "Status_Label";
            this.Status_Label.Size = new System.Drawing.Size(37, 13);
            this.Status_Label.TabIndex = 5;
            this.Status_Label.Text = "Status";
            // 
            // Skip_Layers
            // 
            this.Skip_Layers.Location = new System.Drawing.Point(161, 169);
            this.Skip_Layers.Name = "Skip_Layers";
            this.Skip_Layers.Size = new System.Drawing.Size(43, 20);
            this.Skip_Layers.TabIndex = 6;
            this.Skip_Layers.Text = "0";
            // 
            // SkipLayersLabel
            // 
            this.SkipLayersLabel.AutoSize = true;
            this.SkipLayersLabel.Location = new System.Drawing.Point(93, 172);
            this.SkipLayersLabel.Name = "SkipLayersLabel";
            this.SkipLayersLabel.Size = new System.Drawing.Size(62, 13);
            this.SkipLayersLabel.TabIndex = 7;
            this.SkipLayersLabel.Text = "Skip Layers";
            // 
            // Main_App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(646, 263);
            this.Controls.Add(this.SkipLayersLabel);
            this.Controls.Add(this.Skip_Layers);
            this.Controls.Add(this.Status_Label);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Output_File);
            this.Controls.Add(this.Input_File);
            this.Controls.Add(this.Output_Label);
            this.Controls.Add(this.Input_Label);
            this.Controls.Add(this.Save_File);
            this.Controls.Add(this.Open_File);
            this.Controls.Add(this.Run_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main_App";
            this.Text = "G-Code to NanoScribe";
            this.TransparencyKey = System.Drawing.Color.Gainsboro;
            this.ResumeLayout(false);
            this.PerformLayout();
            this.p.EnableRaisingEvents = true;
            this.p.Exited += new System.EventHandler(p_Exited);

        }

        #endregion

        private System.Windows.Forms.Button Run_Button;
        private System.Windows.Forms.Button Open_File;
        private System.Windows.Forms.Button Save_File;
        private System.Windows.Forms.Label Input_Label;
        private System.Windows.Forms.Label Output_Label;
        private System.Windows.Forms.TextBox Input_File;
        private System.Windows.Forms.TextBox Output_File;
        private System.Windows.Forms.TextBox Status;
        private System.Windows.Forms.Label Status_Label;
        private System.Windows.Forms.TextBox Skip_Layers;
        private System.Windows.Forms.Label SkipLayersLabel;
    }
}


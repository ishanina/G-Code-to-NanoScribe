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
            this.Skip_Layers_Label = new System.Windows.Forms.Label();
            this.X_Shift = new System.Windows.Forms.TextBox();
            this.Y_Shift = new System.Windows.Forms.TextBox();
            this.X_Shift_Label = new System.Windows.Forms.Label();
            this.Y_Shift_Label = new System.Windows.Forms.Label();
            this.Z_Size = new System.Windows.Forms.TextBox();
            this.Z_Size_Label = new System.Windows.Forms.Label();
            this.Y_Size = new System.Windows.Forms.TextBox();
            this.X_Size = new System.Windows.Forms.TextBox();
            this.Y_Size_Label = new System.Windows.Forms.Label();
            this.X_Size_Label = new System.Windows.Forms.Label();
            this.Output_Data = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Run_Button
            // 
            this.Run_Button.Location = new System.Drawing.Point(210, 115);
            this.Run_Button.Name = "Run_Button";
            this.Run_Button.Size = new System.Drawing.Size(235, 23);
            this.Run_Button.TabIndex = 5;
            this.Run_Button.Text = "Run";
            this.Run_Button.UseVisualStyleBackColor = true;
            this.Run_Button.Click += new System.EventHandler(this.Run_Button_Click);
            // 
            // Open_File
            // 
            this.Open_File.Location = new System.Drawing.Point(15, 25);
            this.Open_File.Name = "Open_File";
            this.Open_File.Size = new System.Drawing.Size(75, 23);
            this.Open_File.TabIndex = 0;
            this.Open_File.Text = "Choose File";
            this.Open_File.UseVisualStyleBackColor = true;
            this.Open_File.Click += new System.EventHandler(this.Open_File_Click);
            // 
            // Save_File
            // 
            this.Save_File.Location = new System.Drawing.Point(15, 87);
            this.Save_File.Name = "Save_File";
            this.Save_File.Size = new System.Drawing.Size(75, 23);
            this.Save_File.TabIndex = 2;
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
            this.Input_File.TabIndex = 1;
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
            this.Status.Location = new System.Drawing.Point(210, 143);
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Size = new System.Drawing.Size(235, 20);
            this.Status.TabIndex = 4;
            this.Status.TabStop = false;
            this.Status.Text = "Idle";
            // 
            // Status_Label
            // 
            this.Status_Label.AutoSize = true;
            this.Status_Label.Location = new System.Drawing.Point(158, 146);
            this.Status_Label.Name = "Status_Label";
            this.Status_Label.Size = new System.Drawing.Size(37, 13);
            this.Status_Label.TabIndex = 5;
            this.Status_Label.Text = "Status";
            // 
            // Skip_Layers
            // 
            this.Skip_Layers.Location = new System.Drawing.Point(161, 117);
            this.Skip_Layers.Name = "Skip_Layers";
            this.Skip_Layers.Size = new System.Drawing.Size(43, 20);
            this.Skip_Layers.TabIndex = 4;
            this.Skip_Layers.Text = "0";
            // 
            // Skip_Layers_Label
            // 
            this.Skip_Layers_Label.AutoSize = true;
            this.Skip_Layers_Label.Location = new System.Drawing.Point(93, 120);
            this.Skip_Layers_Label.Name = "Skip_Layers_Label";
            this.Skip_Layers_Label.Size = new System.Drawing.Size(62, 13);
            this.Skip_Layers_Label.TabIndex = 7;
            this.Skip_Layers_Label.Text = "Skip Layers";
            // 
            // X_Shift
            // 
            this.X_Shift.Location = new System.Drawing.Point(533, 196);
            this.X_Shift.Name = "X_Shift";
            this.X_Shift.Size = new System.Drawing.Size(70, 20);
            this.X_Shift.TabIndex = 9;
            this.X_Shift.Text = "0";
            // 
            // Y_Shift
            // 
            this.Y_Shift.Location = new System.Drawing.Point(533, 222);
            this.Y_Shift.Name = "Y_Shift";
            this.Y_Shift.Size = new System.Drawing.Size(70, 20);
            this.Y_Shift.TabIndex = 10;
            this.Y_Shift.Text = "0";
            // 
            // X_Shift_Label
            // 
            this.X_Shift_Label.AutoSize = true;
            this.X_Shift_Label.Location = new System.Drawing.Point(489, 199);
            this.X_Shift_Label.Name = "X_Shift_Label";
            this.X_Shift_Label.Size = new System.Drawing.Size(38, 13);
            this.X_Shift_Label.TabIndex = 10;
            this.X_Shift_Label.Text = "X Shift";
            // 
            // Y_Shift_Label
            // 
            this.Y_Shift_Label.AutoSize = true;
            this.Y_Shift_Label.Location = new System.Drawing.Point(489, 225);
            this.Y_Shift_Label.Name = "Y_Shift_Label";
            this.Y_Shift_Label.Size = new System.Drawing.Size(38, 13);
            this.Y_Shift_Label.TabIndex = 11;
            this.Y_Shift_Label.Text = "Y Shift";
            // 
            // Z_Size
            // 
            this.Z_Size.Location = new System.Drawing.Point(533, 169);
            this.Z_Size.Name = "Z_Size";
            this.Z_Size.Size = new System.Drawing.Size(70, 20);
            this.Z_Size.TabIndex = 8;
            this.Z_Size.Text = "1";
            // 
            // Z_Size_Label
            // 
            this.Z_Size_Label.AutoSize = true;
            this.Z_Size_Label.Location = new System.Drawing.Point(490, 172);
            this.Z_Size_Label.Name = "Z_Size_Label";
            this.Z_Size_Label.Size = new System.Drawing.Size(37, 13);
            this.Z_Size_Label.TabIndex = 13;
            this.Z_Size_Label.Text = "Z Size";
            // 
            // Y_Size
            // 
            this.Y_Size.Location = new System.Drawing.Point(533, 143);
            this.Y_Size.Name = "Y_Size";
            this.Y_Size.Size = new System.Drawing.Size(70, 20);
            this.Y_Size.TabIndex = 7;
            this.Y_Size.Text = "1";
            // 
            // X_Size
            // 
            this.X_Size.Location = new System.Drawing.Point(533, 117);
            this.X_Size.Name = "X_Size";
            this.X_Size.Size = new System.Drawing.Size(70, 20);
            this.X_Size.TabIndex = 6;
            this.X_Size.Text = "1";
            // 
            // Y_Size_Label
            // 
            this.Y_Size_Label.AutoSize = true;
            this.Y_Size_Label.Location = new System.Drawing.Point(490, 146);
            this.Y_Size_Label.Name = "Y_Size_Label";
            this.Y_Size_Label.Size = new System.Drawing.Size(37, 13);
            this.Y_Size_Label.TabIndex = 16;
            this.Y_Size_Label.Text = "Y Size";
            // 
            // X_Size_Label
            // 
            this.X_Size_Label.AutoSize = true;
            this.X_Size_Label.Location = new System.Drawing.Point(490, 120);
            this.X_Size_Label.Name = "X_Size_Label";
            this.X_Size_Label.Size = new System.Drawing.Size(37, 13);
            this.X_Size_Label.TabIndex = 17;
            this.X_Size_Label.Text = "X Size";
            // 
            // Output_Data
            // 
            this.Output_Data.Location = new System.Drawing.Point(210, 169);
            this.Output_Data.Multiline = true;
            this.Output_Data.Name = "Output_Data";
            this.Output_Data.ReadOnly = true;
            this.Output_Data.Size = new System.Drawing.Size(235, 20);
            this.Output_Data.TabIndex = 18;
            this.Output_Data.TabStop = false;
            this.Output_Data.Visible = false;
            // 
            // Main_App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(646, 263);
            this.Controls.Add(this.Output_Data);
            this.Controls.Add(this.X_Size_Label);
            this.Controls.Add(this.Y_Size_Label);
            this.Controls.Add(this.X_Size);
            this.Controls.Add(this.Y_Size);
            this.Controls.Add(this.Z_Size_Label);
            this.Controls.Add(this.Z_Size);
            this.Controls.Add(this.Y_Shift_Label);
            this.Controls.Add(this.X_Shift_Label);
            this.Controls.Add(this.Y_Shift);
            this.Controls.Add(this.X_Shift);
            this.Controls.Add(this.Skip_Layers_Label);
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
            this.Load += new System.EventHandler(this.Main_App_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label Skip_Layers_Label;
        private System.Windows.Forms.TextBox X_Shift;
        private System.Windows.Forms.TextBox Y_Shift;
        private System.Windows.Forms.Label X_Shift_Label;
        private System.Windows.Forms.Label Y_Shift_Label;
        private System.Windows.Forms.TextBox Z_Size;
        private System.Windows.Forms.Label Z_Size_Label;
        private System.Windows.Forms.TextBox Y_Size;
        private System.Windows.Forms.TextBox X_Size;
        private System.Windows.Forms.Label Y_Size_Label;
        private System.Windows.Forms.Label X_Size_Label;
        private System.Windows.Forms.TextBox Output_Data;
    }
}


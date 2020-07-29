namespace Monitoreo_360
{
    partial class Cadena_
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
            this.TextBox_Log = new MetroFramework.Controls.MetroTextBox();
            this.metroProgressSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new MetroFramework.Controls.MetroTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBox_Log
            // 
            // 
            // 
            // 
            this.TextBox_Log.CustomButton.Image = null;
            this.TextBox_Log.CustomButton.Location = new System.Drawing.Point(598, 2);
            this.TextBox_Log.CustomButton.Name = "";
            this.TextBox_Log.CustomButton.Size = new System.Drawing.Size(247, 247);
            this.TextBox_Log.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBox_Log.CustomButton.TabIndex = 1;
            this.TextBox_Log.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBox_Log.CustomButton.UseSelectable = true;
            this.TextBox_Log.CustomButton.Visible = false;
            this.TextBox_Log.Lines = new string[0];
            this.TextBox_Log.Location = new System.Drawing.Point(23, 36);
            this.TextBox_Log.MaxLength = 32767;
            this.TextBox_Log.Multiline = true;
            this.TextBox_Log.Name = "TextBox_Log";
            this.TextBox_Log.PasswordChar = '\0';
            this.TextBox_Log.ReadOnly = true;
            this.TextBox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBox_Log.SelectedText = "";
            this.TextBox_Log.SelectionLength = 0;
            this.TextBox_Log.SelectionStart = 0;
            this.TextBox_Log.ShortcutsEnabled = true;
            this.TextBox_Log.Size = new System.Drawing.Size(848, 252);
            this.TextBox_Log.Style = MetroFramework.MetroColorStyle.Red;
            this.TextBox_Log.TabIndex = 4;
            this.TextBox_Log.UseSelectable = true;
            this.TextBox_Log.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBox_Log.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroProgressSpinner
            // 
            this.metroProgressSpinner.Location = new System.Drawing.Point(396, 164);
            this.metroProgressSpinner.Maximum = 100;
            this.metroProgressSpinner.Name = "metroProgressSpinner";
            this.metroProgressSpinner.Size = new System.Drawing.Size(110, 105);
            this.metroProgressSpinner.Style = MetroFramework.MetroColorStyle.Red;
            this.metroProgressSpinner.TabIndex = 5;
            this.metroProgressSpinner.UseSelectable = true;
            this.metroProgressSpinner.Value = 75;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.TextBox_Log);
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 386);
            this.panel1.TabIndex = 6;
            this.panel1.Visible = false;
            // 
            // textBox1
            // 
            // 
            // 
            // 
            this.textBox1.CustomButton.Image = null;
            this.textBox1.CustomButton.Location = new System.Drawing.Point(823, 1);
            this.textBox1.CustomButton.Name = "";
            this.textBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox1.CustomButton.TabIndex = 1;
            this.textBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox1.CustomButton.UseSelectable = true;
            this.textBox1.CustomButton.Visible = false;
            this.textBox1.Lines = new string[0];
            this.textBox1.Location = new System.Drawing.Point(26, 312);
            this.textBox1.MaxLength = 32767;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.Size = new System.Drawing.Size(845, 23);
            this.textBox1.Style = MetroFramework.MetroColorStyle.Red;
            this.textBox1.TabIndex = 7;
            this.textBox1.UseSelectable = true;
            this.textBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(796, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Cadena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 444);
            this.Controls.Add(this.metroProgressSpinner);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cadena";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Log";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTextBox TextBox_Log;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroTextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}
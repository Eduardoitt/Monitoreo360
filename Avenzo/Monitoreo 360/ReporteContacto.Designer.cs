namespace Monitoreo_360
{
    partial class ReporteContacto
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
            this.metroComboBox_Llamada = new MetroFramework.Controls.MetroComboBox();
            this.metroTextBox_Comentarios = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.metroButton_Guardar = new MetroFramework.Controls.MetroButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.metroComboBox_Estatus = new MetroFramework.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // metroComboBox_Llamada
            // 
            this.metroComboBox_Llamada.FontWeight = MetroFramework.MetroComboBoxWeight.Light;
            this.metroComboBox_Llamada.FormattingEnabled = true;
            this.metroComboBox_Llamada.ItemHeight = 23;
            this.metroComboBox_Llamada.Items.AddRange(new object[] {
            "No contesto",
            "Contesto",
            "No Disponible",
            "Numero Equivocado"});
            this.metroComboBox_Llamada.Location = new System.Drawing.Point(12, 104);
            this.metroComboBox_Llamada.Name = "metroComboBox_Llamada";
            this.metroComboBox_Llamada.Size = new System.Drawing.Size(175, 29);
            this.metroComboBox_Llamada.Style = MetroFramework.MetroColorStyle.Red;
            this.metroComboBox_Llamada.TabIndex = 0;
            this.metroComboBox_Llamada.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroComboBox_Llamada.UseSelectable = true;
            // 
            // metroTextBox_Comentarios
            // 
            // 
            // 
            // 
            this.metroTextBox_Comentarios.CustomButton.Image = null;
            this.metroTextBox_Comentarios.CustomButton.Location = new System.Drawing.Point(343, 2);
            this.metroTextBox_Comentarios.CustomButton.Name = "";
            this.metroTextBox_Comentarios.CustomButton.Size = new System.Drawing.Size(111, 111);
            this.metroTextBox_Comentarios.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox_Comentarios.CustomButton.TabIndex = 1;
            this.metroTextBox_Comentarios.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox_Comentarios.CustomButton.UseSelectable = true;
            this.metroTextBox_Comentarios.CustomButton.Visible = false;
            this.metroTextBox_Comentarios.Lines = new string[0];
            this.metroTextBox_Comentarios.Location = new System.Drawing.Point(12, 174);
            this.metroTextBox_Comentarios.MaxLength = 32767;
            this.metroTextBox_Comentarios.Multiline = true;
            this.metroTextBox_Comentarios.Name = "metroTextBox_Comentarios";
            this.metroTextBox_Comentarios.PasswordChar = '\0';
            this.metroTextBox_Comentarios.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox_Comentarios.SelectedText = "";
            this.metroTextBox_Comentarios.SelectionLength = 0;
            this.metroTextBox_Comentarios.SelectionStart = 0;
            this.metroTextBox_Comentarios.ShortcutsEnabled = true;
            this.metroTextBox_Comentarios.Size = new System.Drawing.Size(457, 116);
            this.metroTextBox_Comentarios.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTextBox_Comentarios.TabIndex = 1;
            this.metroTextBox_Comentarios.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox_Comentarios.UseSelectable = true;
            this.metroTextBox_Comentarios.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox_Comentarios.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Llamada";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroButton_Guardar
            // 
            this.metroButton_Guardar.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton_Guardar.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButton_Guardar.Location = new System.Drawing.Point(394, 305);
            this.metroButton_Guardar.Name = "metroButton_Guardar";
            this.metroButton_Guardar.Size = new System.Drawing.Size(75, 23);
            this.metroButton_Guardar.Style = MetroFramework.MetroColorStyle.Red;
            this.metroButton_Guardar.TabIndex = 3;
            this.metroButton_Guardar.Text = "Guardar";
            this.metroButton_Guardar.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton_Guardar.UseSelectable = true;
            this.metroButton_Guardar.Click += new System.EventHandler(this.metroButton_Guardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Comentarios";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(287, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Estatus";
            // 
            // metroComboBox_Estatus
            // 
            this.metroComboBox_Estatus.FormattingEnabled = true;
            this.metroComboBox_Estatus.ItemHeight = 23;
            this.metroComboBox_Estatus.Items.AddRange(new object[] {
            "Falsa alarma",
            "No Aplica"});
            this.metroComboBox_Estatus.Location = new System.Drawing.Point(291, 104);
            this.metroComboBox_Estatus.Name = "metroComboBox_Estatus";
            this.metroComboBox_Estatus.Size = new System.Drawing.Size(178, 29);
            this.metroComboBox_Estatus.Style = MetroFramework.MetroColorStyle.Red;
            this.metroComboBox_Estatus.TabIndex = 6;
            this.metroComboBox_Estatus.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroComboBox_Estatus.UseSelectable = true;
            // 
            // ReporteContacto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(492, 351);
            this.Controls.Add(this.metroComboBox_Estatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.metroButton_Guardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metroTextBox_Comentarios);
            this.Controls.Add(this.metroComboBox_Llamada);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReporteContacto";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Reporte de llamada";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox metroComboBox_Llamada;
        private MetroFramework.Controls.MetroTextBox metroTextBox_Comentarios;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton metroButton_Guardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroComboBox metroComboBox_Estatus;
    }
}
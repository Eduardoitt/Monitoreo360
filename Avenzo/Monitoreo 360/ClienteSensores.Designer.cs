namespace Monitoreo_360
{
    partial class ClienteSensores
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView_Sensores = new MetroFramework.Controls.MetroGrid();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ubicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip_Sensor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarSensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Sensores)).BeginInit();
            this.contextMenuStrip_Sensor.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_Sensores
            // 
            this.dataGridView_Sensores.AllowUserToDeleteRows = false;
            this.dataGridView_Sensores.AllowUserToResizeRows = false;
            this.dataGridView_Sensores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Sensores.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView_Sensores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Sensores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_Sensores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(19)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Sensores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Sensores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Sensores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Numero,
            this.Tipo,
            this.Ubicacion});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(19)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Sensores.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Sensores.EnableHeadersVisualStyles = false;
            this.dataGridView_Sensores.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridView_Sensores.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView_Sensores.Location = new System.Drawing.Point(33, 63);
            this.dataGridView_Sensores.Name = "dataGridView_Sensores";
            this.dataGridView_Sensores.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(19)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Sensores.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Sensores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_Sensores.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_Sensores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Sensores.Size = new System.Drawing.Size(612, 302);
            this.dataGridView_Sensores.Style = MetroFramework.MetroColorStyle.Red;
            this.dataGridView_Sensores.TabIndex = 0;
            this.dataGridView_Sensores.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dataGridView_Sensores.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Sensores_RowLeave);
            this.dataGridView_Sensores.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_Sensores_MouseClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Numero
            // 
            this.Numero.HeaderText = "Numero de sensor";
            this.Numero.Name = "Numero";
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo de Sensor";
            this.Tipo.Name = "Tipo";
            // 
            // Ubicacion
            // 
            this.Ubicacion.HeaderText = "Ubicacion";
            this.Ubicacion.Name = "Ubicacion";
            // 
            // contextMenuStrip_Sensor
            // 
            this.contextMenuStrip_Sensor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarSensorToolStripMenuItem});
            this.contextMenuStrip_Sensor.Name = "contextMenuStrip_Sensor";
            this.contextMenuStrip_Sensor.Size = new System.Drawing.Size(156, 26);
            // 
            // eliminarSensorToolStripMenuItem
            // 
            this.eliminarSensorToolStripMenuItem.Name = "eliminarSensorToolStripMenuItem";
            this.eliminarSensorToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.eliminarSensorToolStripMenuItem.Text = "Eliminar Sensor";
            this.eliminarSensorToolStripMenuItem.Click += new System.EventHandler(this.eliminarSensorToolStripMenuItem_Click);
            // 
            // ClienteSensores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 379);
            this.Controls.Add(this.dataGridView_Sensores);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClienteSensores";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Sensores";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Sensores)).EndInit();
            this.contextMenuStrip_Sensor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Sensor;
        private System.Windows.Forms.ToolStripMenuItem eliminarSensorToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubicacion;
        private MetroFramework.Controls.MetroGrid dataGridView_Sensores;
    }
}
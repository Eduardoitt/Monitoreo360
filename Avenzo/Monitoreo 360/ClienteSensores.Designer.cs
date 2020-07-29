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
            this.dataGridView_Sensores = new System.Windows.Forms.DataGridView();
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
            this.dataGridView_Sensores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Sensores.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_Sensores.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_Sensores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Sensores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Sensores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Numero,
            this.Tipo,
            this.Ubicacion});
            this.dataGridView_Sensores.EnableHeadersVisualStyles = false;
            this.dataGridView_Sensores.Location = new System.Drawing.Point(33, 63);
            this.dataGridView_Sensores.Name = "dataGridView_Sensores";
            this.dataGridView_Sensores.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_Sensores.Size = new System.Drawing.Size(612, 302);
            this.dataGridView_Sensores.TabIndex = 0;
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

        private System.Windows.Forms.DataGridView dataGridView_Sensores;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Sensor;
        private System.Windows.Forms.ToolStripMenuItem eliminarSensorToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubicacion;
    }
}
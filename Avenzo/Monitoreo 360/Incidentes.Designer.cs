namespace Monitoreo_360
{
    partial class Incidentes
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

        #region Component Designer generated code

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
            this.bunifuElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.DataGrid_Incidentes = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eventos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaHoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaHoraFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgressBar = new Bunifu.Framework.UI.BunifuProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Incidentes)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse
            // 
            this.bunifuElipse.ElipseRadius = 30;
            this.bunifuElipse.TargetControl = this;
            // 
            // DataGrid_Incidentes
            // 
            this.DataGrid_Incidentes.AllowUserToAddRows = false;
            this.DataGrid_Incidentes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DataGrid_Incidentes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGrid_Incidentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGrid_Incidentes.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.DataGrid_Incidentes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGrid_Incidentes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DataGrid_Incidentes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid_Incidentes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGrid_Incidentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid_Incidentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Cliente,
            this.Eventos,
            this.FechaHoraInicio,
            this.FechaHoraFinal,
            this.Estatus});
            this.DataGrid_Incidentes.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(151)))), ((int)(((byte)(203)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGrid_Incidentes.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGrid_Incidentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGrid_Incidentes.DoubleBuffered = true;
            this.DataGrid_Incidentes.EnableHeadersVisualStyles = false;
            this.DataGrid_Incidentes.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            this.DataGrid_Incidentes.HeaderForeColor = System.Drawing.Color.White;
            this.DataGrid_Incidentes.Location = new System.Drawing.Point(0, 0);
            this.DataGrid_Incidentes.Name = "DataGrid_Incidentes";
            this.DataGrid_Incidentes.ReadOnly = true;
            this.DataGrid_Incidentes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGrid_Incidentes.RowHeadersVisible = false;
            this.DataGrid_Incidentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGrid_Incidentes.Size = new System.Drawing.Size(814, 414);
            this.DataGrid_Incidentes.TabIndex = 1;
            this.DataGrid_Incidentes.Visible = false;
            this.DataGrid_Incidentes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_Incidentes_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            // 
            // Eventos
            // 
            this.Eventos.HeaderText = "Eventos";
            this.Eventos.Name = "Eventos";
            this.Eventos.ReadOnly = true;
            // 
            // FechaHoraInicio
            // 
            this.FechaHoraInicio.HeaderText = "Fecha y Hora de Inicio";
            this.FechaHoraInicio.Name = "FechaHoraInicio";
            this.FechaHoraInicio.ReadOnly = true;
            // 
            // FechaHoraFinal
            // 
            this.FechaHoraFinal.HeaderText = "Fecha y Hora Final";
            this.FechaHoraFinal.Name = "FechaHoraFinal";
            this.FechaHoraFinal.ReadOnly = true;
            // 
            // Estatus
            // 
            this.Estatus.HeaderText = "Estatus";
            this.Estatus.Name = "Estatus";
            this.Estatus.ReadOnly = true;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.BackColor = System.Drawing.Color.Silver;
            this.ProgressBar.BorderRadius = 5;
            this.ProgressBar.Location = new System.Drawing.Point(148, 202);
            this.ProgressBar.MaximumValue = 100;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            this.ProgressBar.Size = new System.Drawing.Size(519, 10);
            this.ProgressBar.TabIndex = 4;
            this.ProgressBar.Value = 5;
            // 
            // Incidentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.DataGrid_Incidentes);
            this.Name = "Incidentes";
            this.Size = new System.Drawing.Size(814, 414);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Incidentes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse;
        private Bunifu.Framework.UI.BunifuCustomDataGrid DataGrid_Incidentes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Eventos;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaHoraInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaHoraFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estatus;
        private Bunifu.Framework.UI.BunifuProgressBar ProgressBar;
    }
}

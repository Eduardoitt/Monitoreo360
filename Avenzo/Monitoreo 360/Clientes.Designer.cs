namespace Monitoreo_360
{
    partial class Clientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGrid_Clientes = new System.Windows.Forms.DataGridView();
            this.IdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroDeCuentaa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoPaternoo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoMaternoo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefonoo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroTelefonoAlarma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroDeCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.bunifuElipse_Clientes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Clientes)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGrid_Clientes
            // 
            this.DataGrid_Clientes.AllowUserToAddRows = false;
            this.DataGrid_Clientes.AllowUserToDeleteRows = false;
            this.DataGrid_Clientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGrid_Clientes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataGrid_Clientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGrid_Clientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DataGrid_Clientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid_Clientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGrid_Clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGrid_Clientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdCliente,
            this.NumeroDeCuentaa,
            this.Nombres,
            this.ApellidoPaternoo,
            this.ApellidoMaternoo,
            this.Telefonoo,
            this.Email,
            this.NumeroTelefonoAlarma});
            this.DataGrid_Clientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DataGrid_Clientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGrid_Clientes.EnableHeadersVisualStyles = false;
            this.DataGrid_Clientes.Location = new System.Drawing.Point(0, 0);
            this.DataGrid_Clientes.Name = "DataGrid_Clientes";
            this.DataGrid_Clientes.ReadOnly = true;
            this.DataGrid_Clientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGrid_Clientes.RowHeadersVisible = false;
            this.DataGrid_Clientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGrid_Clientes.Size = new System.Drawing.Size(841, 414);
            this.DataGrid_Clientes.TabIndex = 1;
            this.DataGrid_Clientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_Clientes_CellContentClick);
            // 
            // IdCliente
            // 
            this.IdCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IdCliente.HeaderText = "IdCliente";
            this.IdCliente.Name = "IdCliente";
            this.IdCliente.ReadOnly = true;
            this.IdCliente.Visible = false;
            // 
            // NumeroDeCuentaa
            // 
            this.NumeroDeCuentaa.HeaderText = "Numero De Cuenta";
            this.NumeroDeCuentaa.Name = "NumeroDeCuentaa";
            this.NumeroDeCuentaa.ReadOnly = true;
            // 
            // Nombres
            // 
            this.Nombres.HeaderText = "Nombre";
            this.Nombres.Name = "Nombres";
            this.Nombres.ReadOnly = true;
            // 
            // ApellidoPaternoo
            // 
            this.ApellidoPaternoo.HeaderText = "Apellido Paterno";
            this.ApellidoPaternoo.Name = "ApellidoPaternoo";
            this.ApellidoPaternoo.ReadOnly = true;
            // 
            // ApellidoMaternoo
            // 
            this.ApellidoMaternoo.HeaderText = "Apellido Materno";
            this.ApellidoMaternoo.Name = "ApellidoMaternoo";
            this.ApellidoMaternoo.ReadOnly = true;
            // 
            // Telefonoo
            // 
            this.Telefonoo.HeaderText = "Telefono";
            this.Telefonoo.Name = "Telefonoo";
            this.Telefonoo.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // NumeroTelefonoAlarma
            // 
            this.NumeroTelefonoAlarma.HeaderText = "Telefono de Alarma";
            this.NumeroTelefonoAlarma.Name = "NumeroTelefonoAlarma";
            this.NumeroTelefonoAlarma.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // NumeroDeCuenta
            // 
            this.NumeroDeCuenta.HeaderText = "Numero de cuenta";
            this.NumeroDeCuenta.Name = "NumeroDeCuenta";
            this.NumeroDeCuenta.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre(s)";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // ApellidoPaterno
            // 
            this.ApellidoPaterno.HeaderText = "Apellido Paterno";
            this.ApellidoPaterno.Name = "ApellidoPaterno";
            this.ApellidoPaterno.ReadOnly = true;
            // 
            // ApellidoMaterno
            // 
            this.ApellidoMaterno.HeaderText = "Apellido Materno";
            this.ApellidoMaterno.Name = "ApellidoMaterno";
            this.ApellidoMaterno.ReadOnly = true;
            // 
            // Panel
            // 
            this.Panel.HeaderText = "Panel";
            this.Panel.Name = "Panel";
            this.Panel.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Correo electronico";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.BackColor = System.Drawing.Color.Silver;
            this.ProgressBar.Location = new System.Drawing.Point(158, 186);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(519, 10);
            this.ProgressBar.TabIndex = 3;
            this.ProgressBar.Value = 5;
            // 
            // bunifuElipse_Clientes
            // 
            this.bunifuElipse_Clientes.Location = new System.Drawing.Point(0, 0);
            this.bunifuElipse_Clientes.Name = "bunifuElipse_Clientes";
            this.bunifuElipse_Clientes.Size = new System.Drawing.Size(75, 23);
            this.bunifuElipse_Clientes.TabIndex = 0;
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.DataGrid_Clientes);
            this.Name = "Clientes";
            this.Size = new System.Drawing.Size(841, 414);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Clientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private Bunifu.Framework.UI.BunifuCustomDataGrid DataGrid_Clientes;
        private System.Windows.Forms.DataGridView DataGrid_Clientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroDeCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Panel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        //private Bunifu.Framework.UI.BunifuProgressBar ProgressBar;
        private System.Windows.Forms.ProgressBar ProgressBar;
        //private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Clientes;
        private System.Windows.Forms.Button bunifuElipse_Clientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroDeCuentaa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoPaternoo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoMaternoo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefonoo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroTelefonoAlarma;
    }
}

namespace TestApp
{
    partial class mdiForm3
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.chcboxListaNumerosIncidencia = new System.Windows.Forms.CheckedListBox();
            this.lblNumCliente = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbDelegacion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.txtComentarios = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMiUsuario = new System.Windows.Forms.Label();
            this.lblid = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(23, 273);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Save";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(104, 273);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Close";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.chcboxListaNumerosIncidencia);
            this.panel1.Controls.Add(this.lblNumCliente);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cmbDelegacion);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cmbCategoria);
            this.panel1.Controls.Add(this.txtComentarios);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 235);
            this.panel1.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(186, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Telefonos a los que reporte el Usuario";
            // 
            // chcboxListaNumerosIncidencia
            // 
            this.chcboxListaNumerosIncidencia.CheckOnClick = true;
            this.chcboxListaNumerosIncidencia.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcboxListaNumerosIncidencia.FormattingEnabled = true;
            this.chcboxListaNumerosIncidencia.Location = new System.Drawing.Point(11, 44);
            this.chcboxListaNumerosIncidencia.Name = "chcboxListaNumerosIncidencia";
            this.chcboxListaNumerosIncidencia.Size = new System.Drawing.Size(189, 169);
            this.chcboxListaNumerosIncidencia.TabIndex = 21;
            this.chcboxListaNumerosIncidencia.Click += new System.EventHandler(this.chcboxListaNumerosIncidencia_Click);
            // 
            // lblNumCliente
            // 
            this.lblNumCliente.AutoSize = true;
            this.lblNumCliente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumCliente.Location = new System.Drawing.Point(102, 6);
            this.lblNumCliente.Name = "lblNumCliente";
            this.lblNumCliente.Size = new System.Drawing.Size(68, 19);
            this.lblNumCliente.TabIndex = 20;
            this.lblNumCliente.Text = "numero";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Seleccionar Delegacion";
            // 
            // cmbDelegacion
            // 
            this.cmbDelegacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDelegacion.FormattingEnabled = true;
            this.cmbDelegacion.Location = new System.Drawing.Point(323, 130);
            this.cmbDelegacion.Name = "cmbDelegacion";
            this.cmbDelegacion.Size = new System.Drawing.Size(121, 21);
            this.cmbDelegacion.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(201, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Seleccionar Categoria:";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(323, 103);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(121, 21);
            this.cmbCategoria.TabIndex = 14;
            // 
            // txtComentarios
            // 
            this.txtComentarios.BackColor = System.Drawing.Color.White;
            this.txtComentarios.Location = new System.Drawing.Point(226, 27);
            this.txtComentarios.Multiline = true;
            this.txtComentarios.Name = "txtComentarios";
            this.txtComentarios.Size = new System.Drawing.Size(215, 70);
            this.txtComentarios.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(225, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Comentarios";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Telefono del cliente";
            // 
            // lblMiUsuario
            // 
            this.lblMiUsuario.AutoSize = true;
            this.lblMiUsuario.Location = new System.Drawing.Point(12, 9);
            this.lblMiUsuario.Name = "lblMiUsuario";
            this.lblMiUsuario.Size = new System.Drawing.Size(57, 13);
            this.lblMiUsuario.TabIndex = 18;
            this.lblMiUsuario.Text = "Mi Usuario";
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(407, 9);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(61, 13);
            this.lblid.TabIndex = 19;
            this.lblid.Text = "ID Llamada";
            // 
            // mdiForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 301);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblMiUsuario);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnGuardar);
            this.Name = "mdiForm3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestApps";
            this.Load += new System.EventHandler(this.mdiForm3_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.TextBox txtComentarios;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDelegacion;
        private System.Windows.Forms.Label lblMiUsuario;
        public System.Windows.Forms.Label lblNumCliente;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckedListBox chcboxListaNumerosIncidencia;
        private System.Windows.Forms.Label lblid;
    }
}
namespace TestApp
{
    partial class Form4
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblComentarios = new System.Windows.Forms.Label();
            this.txtComentarios = new System.Windows.Forms.TextBox();
            this.lblNumeroReporta = new System.Windows.Forms.Label();
            this.lblNombreReporta = new System.Windows.Forms.Label();
            this.lblCelular = new System.Windows.Forms.Label();
            this.lblSiNo = new System.Windows.Forms.Label();
            this.lblComentarioReporta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(61, 148);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Grabar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(142, 148);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblComentarios
            // 
            this.lblComentarios.AutoSize = true;
            this.lblComentarios.Location = new System.Drawing.Point(14, 37);
            this.lblComentarios.Name = "lblComentarios";
            this.lblComentarios.Size = new System.Drawing.Size(68, 13);
            this.lblComentarios.TabIndex = 2;
            this.lblComentarios.Text = "Comentarios:";
            // 
            // txtComentarios
            // 
            this.txtComentarios.Location = new System.Drawing.Point(12, 71);
            this.txtComentarios.Multiline = true;
            this.txtComentarios.Name = "txtComentarios";
            this.txtComentarios.Size = new System.Drawing.Size(260, 71);
            this.txtComentarios.TabIndex = 3;
            // 
            // lblNumeroReporta
            // 
            this.lblNumeroReporta.AutoSize = true;
            this.lblNumeroReporta.Location = new System.Drawing.Point(109, 9);
            this.lblNumeroReporta.Name = "lblNumeroReporta";
            this.lblNumeroReporta.Size = new System.Drawing.Size(83, 13);
            this.lblNumeroReporta.TabIndex = 4;
            this.lblNumeroReporta.Text = "numero Reporta";
            // 
            // lblNombreReporta
            // 
            this.lblNombreReporta.AutoSize = true;
            this.lblNombreReporta.Location = new System.Drawing.Point(9, 9);
            this.lblNombreReporta.Name = "lblNombreReporta";
            this.lblNombreReporta.Size = new System.Drawing.Size(85, 13);
            this.lblNombreReporta.TabIndex = 5;
            this.lblNombreReporta.Text = "Nombre Reporta";
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Location = new System.Drawing.Point(216, 9);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(56, 13);
            this.lblCelular.TabIndex = 6;
            this.lblCelular.Text = "Es celular.";
            // 
            // lblSiNo
            // 
            this.lblSiNo.AutoSize = true;
            this.lblSiNo.Location = new System.Drawing.Point(233, 26);
            this.lblSiNo.Name = "lblSiNo";
            this.lblSiNo.Size = new System.Drawing.Size(22, 13);
            this.lblSiNo.TabIndex = 7;
            this.lblSiNo.Text = "xxx";
            // 
            // lblComentarioReporta
            // 
            this.lblComentarioReporta.AutoSize = true;
            this.lblComentarioReporta.Location = new System.Drawing.Point(13, 52);
            this.lblComentarioReporta.Name = "lblComentarioReporta";
            this.lblComentarioReporta.Size = new System.Drawing.Size(98, 13);
            this.lblComentarioReporta.TabIndex = 8;
            this.lblComentarioReporta.Text = "ComentarioReporta";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 186);
            this.Controls.Add(this.lblComentarioReporta);
            this.Controls.Add(this.lblSiNo);
            this.Controls.Add(this.lblCelular);
            this.Controls.Add(this.lblNombreReporta);
            this.Controls.Add(this.lblNumeroReporta);
            this.Controls.Add(this.txtComentarios);
            this.Controls.Add(this.lblComentarios);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblComentarios;
        private System.Windows.Forms.TextBox txtComentarios;
        private System.Windows.Forms.Label lblNumeroReporta;
        private System.Windows.Forms.Label lblNombreReporta;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.Label lblSiNo;
        private System.Windows.Forms.Label lblComentarioReporta;
    }
}
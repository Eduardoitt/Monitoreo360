namespace TestApp
{
    partial class IncidentReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IncidentReport));
            this.myGroupBox1 = new TestApp.myGroupBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtIncidentDescription = new System.Windows.Forms.TextBox();
            this.lblIncidentDescription = new System.Windows.Forms.Label();
            this.txtContactAddress = new System.Windows.Forms.TextBox();
            this.lblClientAddress = new System.Windows.Forms.Label();
            this.txtContactPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtClientContact = new System.Windows.Forms.TextBox();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.lblContactPhoneNumber = new System.Windows.Forms.Label();
            this.lblClientContact = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.myGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // myGroupBox1
            // 
            this.myGroupBox1.ActualBackColor = System.Drawing.Color.Transparent;
            this.myGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.myGroupBox1.Controls.Add(this.cbStatus);
            this.myGroupBox1.Controls.Add(this.lblStatus);
            this.myGroupBox1.Controls.Add(this.txtIncidentDescription);
            this.myGroupBox1.Controls.Add(this.lblIncidentDescription);
            this.myGroupBox1.Controls.Add(this.txtContactAddress);
            this.myGroupBox1.Controls.Add(this.lblClientAddress);
            this.myGroupBox1.Controls.Add(this.txtContactPhoneNumber);
            this.myGroupBox1.Controls.Add(this.txtClientContact);
            this.myGroupBox1.Controls.Add(this.txtClientName);
            this.myGroupBox1.Controls.Add(this.lblContactPhoneNumber);
            this.myGroupBox1.Controls.Add(this.lblClientContact);
            this.myGroupBox1.Controls.Add(this.lblClientName);
            this.myGroupBox1.Location = new System.Drawing.Point(15, 16);
            this.myGroupBox1.Name = "myGroupBox1";
            this.myGroupBox1.Size = new System.Drawing.Size(684, 344);
            this.myGroupBox1.TabIndex = 53;
            this.myGroupBox1.TabStop = false;
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(296, 302);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(200, 21);
            this.cbStatus.TabIndex = 62;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(191, 305);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(53, 13);
            this.lblStatus.TabIndex = 61;
            this.lblStatus.Text = "Estatus:";
            // 
            // txtIncidentDescription
            // 
            this.txtIncidentDescription.Location = new System.Drawing.Point(177, 122);
            this.txtIncidentDescription.Multiline = true;
            this.txtIncidentDescription.Name = "txtIncidentDescription";
            this.txtIncidentDescription.Size = new System.Drawing.Size(483, 150);
            this.txtIncidentDescription.TabIndex = 60;
            // 
            // lblIncidentDescription
            // 
            this.lblIncidentDescription.AutoSize = true;
            this.lblIncidentDescription.BackColor = System.Drawing.Color.White;
            this.lblIncidentDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncidentDescription.Location = new System.Drawing.Point(15, 188);
            this.lblIncidentDescription.Name = "lblIncidentDescription";
            this.lblIncidentDescription.Size = new System.Drawing.Size(156, 13);
            this.lblIncidentDescription.TabIndex = 59;
            this.lblIncidentDescription.Text = "Descripción del Incidente:";
            // 
            // txtContactAddress
            // 
            this.txtContactAddress.Enabled = false;
            this.txtContactAddress.Location = new System.Drawing.Point(162, 64);
            this.txtContactAddress.Multiline = true;
            this.txtContactAddress.Name = "txtContactAddress";
            this.txtContactAddress.Size = new System.Drawing.Size(188, 43);
            this.txtContactAddress.TabIndex = 58;
            // 
            // lblClientAddress
            // 
            this.lblClientAddress.AutoSize = true;
            this.lblClientAddress.BackColor = System.Drawing.Color.White;
            this.lblClientAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientAddress.Location = new System.Drawing.Point(15, 71);
            this.lblClientAddress.Name = "lblClientAddress";
            this.lblClientAddress.Size = new System.Drawing.Size(141, 13);
            this.lblClientAddress.TabIndex = 57;
            this.lblClientAddress.Text = "Dirección del Contacto:";
            // 
            // txtContactPhoneNumber
            // 
            this.txtContactPhoneNumber.Enabled = false;
            this.txtContactPhoneNumber.Location = new System.Drawing.Point(513, 68);
            this.txtContactPhoneNumber.Name = "txtContactPhoneNumber";
            this.txtContactPhoneNumber.Size = new System.Drawing.Size(147, 20);
            this.txtContactPhoneNumber.TabIndex = 56;
            // 
            // txtClientContact
            // 
            this.txtClientContact.Enabled = false;
            this.txtClientContact.Location = new System.Drawing.Point(513, 29);
            this.txtClientContact.Name = "txtClientContact";
            this.txtClientContact.Size = new System.Drawing.Size(147, 20);
            this.txtClientContact.TabIndex = 55;
            // 
            // txtClientName
            // 
            this.txtClientName.Enabled = false;
            this.txtClientName.Location = new System.Drawing.Point(162, 29);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(188, 20);
            this.txtClientName.TabIndex = 54;
            // 
            // lblContactPhoneNumber
            // 
            this.lblContactPhoneNumber.AutoSize = true;
            this.lblContactPhoneNumber.BackColor = System.Drawing.Color.White;
            this.lblContactPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactPhoneNumber.Location = new System.Drawing.Point(370, 71);
            this.lblContactPhoneNumber.Name = "lblContactPhoneNumber";
            this.lblContactPhoneNumber.Size = new System.Drawing.Size(137, 13);
            this.lblContactPhoneNumber.TabIndex = 53;
            this.lblContactPhoneNumber.Text = "Telefono del Contacto:";
            // 
            // lblClientContact
            // 
            this.lblClientContact.AutoSize = true;
            this.lblClientContact.BackColor = System.Drawing.Color.White;
            this.lblClientContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientContact.Location = new System.Drawing.Point(370, 32);
            this.lblClientContact.Name = "lblClientContact";
            this.lblClientContact.Size = new System.Drawing.Size(126, 13);
            this.lblClientContact.TabIndex = 52;
            this.lblClientContact.Text = "Contacto del Cliente:";
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.BackColor = System.Drawing.Color.White;
            this.lblClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientName.Location = new System.Drawing.Point(15, 32);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(118, 13);
            this.lblClientName.TabIndex = 51;
            this.lblClientName.Text = "Nombre del Cliente:";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::TestApp.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(378, 379);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 46);
            this.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCancel.TabIndex = 68;
            this.btnCancel.TabStop = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::TestApp.Properties.Resources.guardar;
            this.btnSave.Location = new System.Drawing.Point(214, 379);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 46);
            this.btnSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSave.TabIndex = 67;
            this.btnSave.TabStop = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::TestApp.Properties.Resources.Avenzo_SecuritySystem_Rojo_01;
            this.pictureBox4.Location = new System.Drawing.Point(0, 412);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(49, 33);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 52;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::TestApp.Properties.Resources.Footer_Informacion_Cliente;
            this.pictureBox1.Location = new System.Drawing.Point(0, 440);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(719, 34);
            this.pictureBox1.TabIndex = 52;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::TestApp.Properties.Resources.Avenzo_Seguridad1;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = global::TestApp.Properties.Resources.Avenzo_Proteccion_Red;
            this.pictureBox2.Location = new System.Drawing.Point(614, 403);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(91, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 69;
            this.pictureBox2.TabStop = false;
            // 
            // IncidentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(717, 468);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.myGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IncidentReport";
            this.Text = "Reporte de Incidente";
            this.Load += new System.EventHandler(this.IncidentReport_Load);
            this.myGroupBox1.ResumeLayout(false);
            this.myGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private myGroupBox myGroupBox1;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtIncidentDescription;
        private System.Windows.Forms.Label lblIncidentDescription;
        private System.Windows.Forms.TextBox txtContactAddress;
        private System.Windows.Forms.Label lblClientAddress;
        private System.Windows.Forms.TextBox txtContactPhoneNumber;
        private System.Windows.Forms.TextBox txtClientContact;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label lblContactPhoneNumber;
        private System.Windows.Forms.Label lblClientContact;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.PictureBox btnSave;
        private System.Windows.Forms.PictureBox btnCancel;
        private System.Windows.Forms.PictureBox pictureBox2;

    }
}
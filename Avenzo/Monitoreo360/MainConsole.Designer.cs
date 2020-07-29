namespace TestApp
{
    partial class mdiForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdiForm2));
            this.lbl_date = new System.Windows.Forms.Label();
            this.lbl_phone = new System.Windows.Forms.Label();
            this.lbl_call = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnCommand = new System.Windows.Forms.PictureBox();
            this.btnDisconnect = new System.Windows.Forms.PictureBox();
            this.btnConnect = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCommand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDisconnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_date.Location = new System.Drawing.Point(412, 98);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(59, 20);
            this.lbl_date.TabIndex = 13;
            this.lbl_date.Text = "Fecha";
            // 
            // lbl_phone
            // 
            this.lbl_phone.AutoSize = true;
            this.lbl_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_phone.Location = new System.Drawing.Point(239, 98);
            this.lbl_phone.Name = "lbl_phone";
            this.lbl_phone.Size = new System.Drawing.Size(79, 20);
            this.lbl_phone.TabIndex = 12;
            this.lbl_phone.Text = "Teléfono";
            // 
            // lbl_call
            // 
            this.lbl_call.AutoSize = true;
            this.lbl_call.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_call.Location = new System.Drawing.Point(80, 98);
            this.lbl_call.Name = "lbl_call";
            this.lbl_call.Size = new System.Drawing.Size(25, 20);
            this.lbl_call.TabIndex = 11;
            this.lbl_call.Text = "Id";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(79, 121);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(569, 328);
            this.textBox1.TabIndex = 14;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "#abc GET USERSTATUS",
            "#abc SET USERSTATUS OFFLINE",
            "#abc PING",
            "#abc CALL +18005551234",
            "#abc GET SKYPEVERSION",
            "#abc GET CURRENTUSERHANDLE",
            "#abc GET PROFILE FULLNAME",
            "#abc GET USER john_doe ONLINESTATUS"});
            this.comboBox1.Location = new System.Drawing.Point(79, 536);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(488, 21);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::TestApp.Properties.Resources.Avenzo_Seguridad1;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = global::TestApp.Properties.Resources.Avenzo_Proteccion_Red;
            this.pictureBox2.Location = new System.Drawing.Point(595, 553);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(112, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 72;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::TestApp.Properties.Resources.salir;
            this.pictureBox3.Location = new System.Drawing.Point(616, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(91, 46);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 71;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // btnCommand
            // 
            this.btnCommand.Image = global::TestApp.Properties.Resources.manual;
            this.btnCommand.Location = new System.Drawing.Point(580, 455);
            this.btnCommand.Name = "btnCommand";
            this.btnCommand.Size = new System.Drawing.Size(116, 58);
            this.btnCommand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCommand.TabIndex = 70;
            this.btnCommand.TabStop = false;
            this.btnCommand.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Image = global::TestApp.Properties.Resources.desconectarbtn1;
            this.btnDisconnect.Location = new System.Drawing.Point(373, 477);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(129, 60);
            this.btnDisconnect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDisconnect.TabIndex = 69;
            this.btnDisconnect.TabStop = false;
            this.btnDisconnect.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Image = global::TestApp.Properties.Resources.conectarbt2n1;
            this.btnConnect.Location = new System.Drawing.Point(192, 477);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(129, 60);
            this.btnConnect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnConnect.TabIndex = 68;
            this.btnConnect.TabStop = false;
            this.btnConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::TestApp.Properties.Resources.Avenzo_SecuritySystem_Rojo_01;
            this.pictureBox4.Location = new System.Drawing.Point(0, 561);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(62, 42);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 55;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::TestApp.Properties.Resources.Footer_Informacion_Cliente;
            this.pictureBox1.Location = new System.Drawing.Point(0, 598);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(719, 34);
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // mdiForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(719, 629);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnCommand);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_date);
            this.Controls.Add(this.lbl_phone);
            this.Controls.Add(this.lbl_call);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mdiForm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avenzo Proteccion |  Monitoreo 360";
            this.Load += new System.EventHandler(this.mdiForm2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCommand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDisconnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.Label lbl_call;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.Label lbl_phone;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnConnect;
        private System.Windows.Forms.PictureBox btnDisconnect;
        private System.Windows.Forms.PictureBox btnCommand;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
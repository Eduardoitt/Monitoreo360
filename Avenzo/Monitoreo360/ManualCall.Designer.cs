namespace TestApp
{
    partial class ManualCall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualCall));
            this.lblStartDate = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.PictureBox();
            this.lblAlarmNumber = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtAlarmNumber = new System.Windows.Forms.TextBox();
            this.myGroupBox1 = new TestApp.myGroupBox();
            this.DTEND = new System.Windows.Forms.DateTimePicker();
            this.DTStart = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.myGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.BackColor = System.Drawing.Color.White;
            this.lblStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.Location = new System.Drawing.Point(154, 76);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(81, 13);
            this.lblStartDate.TabIndex = 79;
            this.lblStartDate.Text = "Fecha Inicio:";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::TestApp.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(377, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 46);
            this.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCancel.TabIndex = 78;
            this.btnCancel.TabStop = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::TestApp.Properties.Resources.guardar;
            this.btnSave.Location = new System.Drawing.Point(213, 205);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 46);
            this.btnSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSave.TabIndex = 77;
            this.btnSave.TabStop = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblAlarmNumber
            // 
            this.lblAlarmNumber.AutoSize = true;
            this.lblAlarmNumber.BackColor = System.Drawing.Color.White;
            this.lblAlarmNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarmNumber.Location = new System.Drawing.Point(167, 53);
            this.lblAlarmNumber.Name = "lblAlarmNumber";
            this.lblAlarmNumber.Size = new System.Drawing.Size(110, 13);
            this.lblAlarmNumber.TabIndex = 72;
            this.lblAlarmNumber.Text = "Número de Alarma";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::TestApp.Properties.Resources.Avenzo_SecuritySystem_Rojo_01;
            this.pictureBox4.Location = new System.Drawing.Point(-1, 238);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(49, 33);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 73;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::TestApp.Properties.Resources.Footer_Informacion_Cliente;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 266);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(719, 34);
            this.pictureBox1.TabIndex = 74;
            this.pictureBox1.TabStop = false;
            // 
            // txtAlarmNumber
            // 
            this.txtAlarmNumber.Location = new System.Drawing.Point(314, 50);
            this.txtAlarmNumber.Name = "txtAlarmNumber";
            this.txtAlarmNumber.Size = new System.Drawing.Size(188, 20);
            this.txtAlarmNumber.TabIndex = 76;
            // 
            // myGroupBox1
            // 
            this.myGroupBox1.ActualBackColor = System.Drawing.Color.Transparent;
            this.myGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.myGroupBox1.Controls.Add(this.DTEND);
            this.myGroupBox1.Controls.Add(this.DTStart);
            this.myGroupBox1.Controls.Add(this.lblEndDate);
            this.myGroupBox1.Controls.Add(this.lblStartDate);
            this.myGroupBox1.Location = new System.Drawing.Point(14, 11);
            this.myGroupBox1.Name = "myGroupBox1";
            this.myGroupBox1.Size = new System.Drawing.Size(684, 157);
            this.myGroupBox1.TabIndex = 75;
            this.myGroupBox1.TabStop = false;
            // 
            // DTEND
            // 
            this.DTEND.Location = new System.Drawing.Point(300, 104);
            this.DTEND.Name = "DTEND";
            this.DTEND.Size = new System.Drawing.Size(188, 20);
            this.DTEND.TabIndex = 84;
            // 
            // DTStart
            // 
            this.DTStart.Location = new System.Drawing.Point(300, 70);
            this.DTStart.Name = "DTStart";
            this.DTStart.Size = new System.Drawing.Size(188, 20);
            this.DTStart.TabIndex = 83;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.BackColor = System.Drawing.Color.White;
            this.lblEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.Location = new System.Drawing.Point(154, 111);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(67, 13);
            this.lblEndDate.TabIndex = 81;
            this.lblEndDate.Text = "Fecha Fin:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::TestApp.Properties.Resources.Avenzo_Seguridad1;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = global::TestApp.Properties.Resources.Avenzo_Proteccion_Red;
            this.pictureBox2.Location = new System.Drawing.Point(614, 229);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(91, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 79;
            this.pictureBox2.TabStop = false;
            // 
            // ManualCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(717, 310);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblAlarmNumber);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtAlarmNumber);
            this.Controls.Add(this.myGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManualCall";
            this.Text = "Reporte de Incidente";
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.myGroupBox1.ResumeLayout(false);
            this.myGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.PictureBox btnCancel;
        private System.Windows.Forms.PictureBox btnSave;
        private System.Windows.Forms.Label lblAlarmNumber;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtAlarmNumber;
        private myGroupBox myGroupBox1;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DateTimePicker DTEND;
        private System.Windows.Forms.DateTimePicker DTStart;
    }
}
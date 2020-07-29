namespace Monitoreo_360
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label_Error = new System.Windows.Forms.Label();
            this.metroButton_Login = new MetroFramework.Controls.MetroButton();
            this.bunifuElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.textBox_Password = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.textBox_Email = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(564, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Correo Electronico";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(593, 496);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 182);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1255, 220);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(435, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(414, 158);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // label_Error
            // 
            this.label_Error.AutoSize = true;
            this.label_Error.BackColor = System.Drawing.Color.Firebrick;
            this.label_Error.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Error.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_Error.Location = new System.Drawing.Point(496, 618);
            this.label_Error.Name = "label_Error";
            this.label_Error.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label_Error.Size = new System.Drawing.Size(299, 30);
            this.label_Error.TabIndex = 10;
            this.label_Error.Text = "Hubo un error con el correo o contraseña";
            this.label_Error.Visible = false;
            // 
            // metroButton_Login
            // 
            this.metroButton_Login.Location = new System.Drawing.Point(597, 563);
            this.metroButton_Login.Name = "metroButton_Login";
            this.metroButton_Login.Size = new System.Drawing.Size(75, 23);
            this.metroButton_Login.Style = MetroFramework.MetroColorStyle.Red;
            this.metroButton_Login.TabIndex = 3;
            this.metroButton_Login.Text = "Inicar sesion";
            this.metroButton_Login.UseSelectable = true;
            this.metroButton_Login.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // bunifuElipse
            // 
            this.bunifuElipse.ElipseRadius = 20;
            this.bunifuElipse.TargetControl = this;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_Password.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox_Password.HintForeColor = System.Drawing.Color.Empty;
            this.textBox_Password.HintText = "";
            this.textBox_Password.isPassword = true;
            this.textBox_Password.LineFocusedColor = System.Drawing.Color.Maroon;
            this.textBox_Password.LineIdleColor = System.Drawing.Color.Gray;
            this.textBox_Password.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_Password.LineThickness = 4;
            this.textBox_Password.Location = new System.Drawing.Point(535, 516);
            this.textBox_Password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(215, 39);
            this.textBox_Password.TabIndex = 2;
            this.textBox_Password.Text = "Prueba";
            this.textBox_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Email
            // 
            this.textBox_Email.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_Email.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox_Email.HintForeColor = System.Drawing.Color.Empty;
            this.textBox_Email.HintText = "";
            this.textBox_Email.isPassword = false;
            this.textBox_Email.LineFocusedColor = System.Drawing.Color.Maroon;
            this.textBox_Email.LineIdleColor = System.Drawing.Color.Gray;
            this.textBox_Email.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_Email.LineThickness = 4;
            this.textBox_Email.Location = new System.Drawing.Point(535, 452);
            this.textBox_Email.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(215, 39);
            this.textBox_Email.TabIndex = 1;
            this.textBox_Email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(23, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 11;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1248, 667);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox_Email);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.metroButton_Login);
            this.Controls.Add(this.label_Error);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label_Error;
        private MetroFramework.Controls.MetroButton metroButton_Login;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse;
        private Bunifu.Framework.UI.BunifuMaterialTextbox textBox_Password;
        private Bunifu.Framework.UI.BunifuMaterialTextbox textBox_Email;
        private System.Windows.Forms.Panel panel1;
    }
}


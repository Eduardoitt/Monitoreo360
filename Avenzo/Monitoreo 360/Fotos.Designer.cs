namespace Monitoreo_360
{
    partial class Fotos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fotos));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            //this.bunifuElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse = new System.Windows.Forms.Button();
            this.panel_Galeria = new System.Windows.Forms.Panel();
            
            //this.Button_AgregarFotos = new Bunifu.Framework.UI.BunifuThinButton2();
            this.Button_AgregarFotos = new System.Windows.Forms.Button();
            this.panel_Galeria.SuspendLayout();
           
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "*.jpg|*.png";
            // 
            // bunifuElipse
            // 
            //this.bunifuElipse.ElipseRadius = 15;
            //this.bunifuElipse.TargetControl = this;
            // 
            // panel_Galeria
            // 
            this.panel_Galeria.AutoScroll = true;
            
            this.panel_Galeria.Location = new System.Drawing.Point(25, 129);
            this.panel_Galeria.Name = "panel_Galeria";
            this.panel_Galeria.Size = new System.Drawing.Size(863, 450);
            this.panel_Galeria.TabIndex = 1;
           
            // 
            // Button_AgregarFotos
            // 
            //this.Button_AgregarFotos.ActiveBorderThickness = 1;
            //this.Button_AgregarFotos.ActiveCornerRadius = 20;
            //this.Button_AgregarFotos.ActiveFillColor = System.Drawing.Color.Firebrick;
            //this.Button_AgregarFotos.ActiveForecolor = System.Drawing.Color.White;
            //this.Button_AgregarFotos.ActiveLineColor = System.Drawing.Color.Firebrick;
            this.Button_AgregarFotos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Button_AgregarFotos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button_AgregarFotos.BackgroundImage")));
            //this.Button_AgregarFotos.ButtonText = "Agregar Fotos";
            this.Button_AgregarFotos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_AgregarFotos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_AgregarFotos.ForeColor = System.Drawing.Color.Firebrick;
           /* this.Button_AgregarFotos.IdleBorderThickness = 1;
            this.Button_AgregarFotos.IdleCornerRadius = 10;
            this.Button_AgregarFotos.IdleFillColor = System.Drawing.Color.White;
            this.Button_AgregarFotos.IdleForecolor = System.Drawing.Color.Firebrick;
            this.Button_AgregarFotos.IdleLineColor = System.Drawing.Color.Firebrick;*/
            this.Button_AgregarFotos.Location = new System.Drawing.Point(25, 80);
            this.Button_AgregarFotos.Margin = new System.Windows.Forms.Padding(5);
            this.Button_AgregarFotos.Name = "Button_AgregarFotos";
            this.Button_AgregarFotos.Size = new System.Drawing.Size(181, 41);
            this.Button_AgregarFotos.TabIndex = 0;
            this.Button_AgregarFotos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button_AgregarFotos.Click += new System.EventHandler(this.Button_AgregarFotos_Click);
            // 
            // Fotos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 602);
            this.Controls.Add(this.panel_Galeria);
            this.Controls.Add(this.Button_AgregarFotos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Fotos";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Fotos";
            this.panel_Galeria.ResumeLayout(false);
            
            this.ResumeLayout(false);

        }

        #endregion

        //private Bunifu.Framework.UI.BunifuThinButton2 Button_AgregarFotos;
        private System.Windows.Forms.Button Button_AgregarFotos;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        //private Bunifu.Framework.UI.BunifuElipse bunifuElipse;
        private System.Windows.Forms.Button bunifuElipse;
        private System.Windows.Forms.Panel panel_Galeria;
        //private System.Windows.Forms.Panel panel;
       // private Bunifu.Framework.UI.BunifuImageButton Button_Close;
        //private System.Windows.Forms.Button Button_Close;
        //private System.Windows.Forms.PictureBox pictureBox;
    }
}
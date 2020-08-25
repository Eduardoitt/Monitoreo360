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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bunifuElipse = new System.Windows.Forms.Button();
            this.Button_AgregarFotos = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "*.jpg|*.png";
            // 
            // bunifuElipse
            // 
            this.bunifuElipse.Location = new System.Drawing.Point(0, 0);
            this.bunifuElipse.Name = "bunifuElipse";
            this.bunifuElipse.Size = new System.Drawing.Size(75, 23);
            this.bunifuElipse.TabIndex = 0;
            // 
            // Button_AgregarFotos
            // 
            this.Button_AgregarFotos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Button_AgregarFotos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_AgregarFotos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_AgregarFotos.ForeColor = System.Drawing.Color.Firebrick;
            this.Button_AgregarFotos.Location = new System.Drawing.Point(25, 80);
            this.Button_AgregarFotos.Margin = new System.Windows.Forms.Padding(5);
            this.Button_AgregarFotos.Name = "Button_AgregarFotos";
            this.Button_AgregarFotos.Size = new System.Drawing.Size(181, 41);
            this.Button_AgregarFotos.TabIndex = 0;
            this.Button_AgregarFotos.Text = "Agregar Fotos";
            this.Button_AgregarFotos.UseVisualStyleBackColor = false;
            this.Button_AgregarFotos.Click += new System.EventHandler(this.Button_AgregarFotos_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(25, 129);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(863, 450);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // Fotos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 602);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.Button_AgregarFotos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Fotos";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Fotos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Fotos_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        //private Bunifu.Framework.UI.BunifuThinButton2 Button_AgregarFotos;
        private System.Windows.Forms.Button Button_AgregarFotos;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        //private Bunifu.Framework.UI.BunifuElipse bunifuElipse;
        private System.Windows.Forms.Button bunifuElipse;
        //private System.Windows.Forms.Panel panel;
       // private Bunifu.Framework.UI.BunifuImageButton Button_Close;
        private System.Windows.Forms.Button Button_Close;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        //private System.Windows.Forms.PictureBox pictureBox;
    }
}
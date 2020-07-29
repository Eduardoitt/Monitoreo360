namespace Monitoreo_360
{
    partial class Monitor_
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
            this.panel_Clientes = new System.Windows.Forms.Panel();
            this.bunifuElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // panel_Clientes
            // 
            this.panel_Clientes.AutoScroll = true;
            this.panel_Clientes.BackColor = System.Drawing.Color.Transparent;
            this.panel_Clientes.Location = new System.Drawing.Point(17, 51);
            this.panel_Clientes.Name = "panel_Clientes";
            this.panel_Clientes.Size = new System.Drawing.Size(1160, 560);
            this.panel_Clientes.TabIndex = 1;
            // 
            // bunifuElipse
            // 
            this.bunifuElipse.ElipseRadius = 15;
            this.bunifuElipse.TargetControl = this;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 30000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 634);
            this.Controls.Add(this.panel_Clientes);
            this.MinimizeBox = false;
            this.Name = "Monitor";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Monitor";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.Load += new System.EventHandler(this.Monitor_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_Clientes;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse;
        private System.Windows.Forms.Timer timer;
    }
}
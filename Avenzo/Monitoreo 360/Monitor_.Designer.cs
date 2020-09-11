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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monitor_));
            this.panel_Clientes = new System.Windows.Forms.Panel();
            this.bunifuElipse = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // panel_Clientes
            // 
            resources.ApplyResources(this.panel_Clientes, "panel_Clientes");
            this.panel_Clientes.BackColor = System.Drawing.Color.Transparent;
            this.panel_Clientes.Name = "panel_Clientes";
            // 
            // bunifuElipse
            // 
            resources.ApplyResources(this.bunifuElipse, "bunifuElipse");
            this.bunifuElipse.Name = "bunifuElipse";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 30000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ProgressBar
            // 
            resources.ApplyResources(this.ProgressBar, "ProgressBar");
            this.ProgressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Value = 5;
            // 
            // Monitor_
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.panel_Clientes);
            this.MinimizeBox = false;
            this.Name = "Monitor_";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Monitor__FormClosed);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_Clientes;
        private System.Windows.Forms.Button bunifuElipse;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ProgressBar ProgressBar;
    }
}
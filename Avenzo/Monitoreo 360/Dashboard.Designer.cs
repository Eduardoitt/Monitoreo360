namespace Monitoreo_360
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.monitoreoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresarCadenaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incidentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel_Notificaciones = new System.Windows.Forms.Panel();
            //this.button_Notificaciones = new Bunifu.Framework.UI.BunifuTileButton();
            this.button_Notificaciones = new System.Windows.Forms.Button();
            //this.bunifuElipse_Badge = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_Badge = new System.Windows.Forms.Button();
            //this.Button_Badge = new Bunifu.Framework.UI.BunifuFlatButton();
            this.Button_Badge = new System.Windows.Forms.Button();
            //this.bunifuElipse_Notificaciones = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_Notificaciones = new System.Windows.Forms.Button();
            //this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.bunifuCards1 = new System.Windows.Forms.ContainerControl();
            this.menuStrip.SuspendLayout();
            this.panel_Notificaciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.White;
            this.menuStrip.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monitoreoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(20, 60);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(996, 25);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // monitoreoToolStripMenuItem
            // 
            this.monitoreoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.monitorToolStripMenuItem,
            this.ingresarCadenaToolStripMenuItem,
            this.incidentesToolStripMenuItem});
            this.monitoreoToolStripMenuItem.Name = "monitoreoToolStripMenuItem";
            this.monitoreoToolStripMenuItem.Size = new System.Drawing.Size(82, 21);
            this.monitoreoToolStripMenuItem.Text = "Monitoreo";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // monitorToolStripMenuItem
            // 
            this.monitorToolStripMenuItem.Name = "monitorToolStripMenuItem";
            this.monitorToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.monitorToolStripMenuItem.Text = "Monitor";
            this.monitorToolStripMenuItem.Click += new System.EventHandler(this.monitorToolStripMenuItem_Click);
            // 
            // ingresarCadenaToolStripMenuItem
            // 
            this.ingresarCadenaToolStripMenuItem.Name = "ingresarCadenaToolStripMenuItem";
            this.ingresarCadenaToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.ingresarCadenaToolStripMenuItem.Text = "Ingresar Cadena";
            this.ingresarCadenaToolStripMenuItem.Click += new System.EventHandler(this.ingresarCadenaToolStripMenuItem_Click);
            // 
            // incidentesToolStripMenuItem
            // 
            this.incidentesToolStripMenuItem.Name = "incidentesToolStripMenuItem";
            this.incidentesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.incidentesToolStripMenuItem.Text = "Incidentes";
            this.incidentesToolStripMenuItem.Click += new System.EventHandler(this.incidentesToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(45, 21);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 60000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panel_Notificaciones
            // 
            this.panel_Notificaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Notificaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            this.panel_Notificaciones.Controls.Add(this.bunifuCards1);
            this.panel_Notificaciones.Location = new System.Drawing.Point(702, 85);
            this.panel_Notificaciones.Name = "panel_Notificaciones";
            this.panel_Notificaciones.Size = new System.Drawing.Size(343, 611);
            this.panel_Notificaciones.TabIndex = 4;
            this.panel_Notificaciones.Visible = false;
            // 
            // button_Notificaciones
            // 
            this.button_Notificaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Notificaciones.BackColor = System.Drawing.Color.Transparent;
            //this.button_Notificaciones.color = System.Drawing.Color.Transparent;
            //this.button_Notificaciones.colorActive = System.Drawing.Color.Transparent;
            this.button_Notificaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Notificaciones.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.button_Notificaciones.ForeColor = System.Drawing.Color.White;
            this.button_Notificaciones.Image = global::Monitoreo_360.Properties.Resources.Notification__Gray_48px;
            //this.button_Notificaciones.ImagePosition = 10;
            //this.button_Notificaciones.ImageZoom = 50;
            //this.button_Notificaciones.LabelPosition = 0;
            //this.button_Notificaciones.LabelText = "";
            this.button_Notificaciones.Location = new System.Drawing.Point(961, 33);
            this.button_Notificaciones.Margin = new System.Windows.Forms.Padding(6);
            this.button_Notificaciones.Name = "button_Notificaciones";
            this.button_Notificaciones.Size = new System.Drawing.Size(70, 48);
            this.button_Notificaciones.TabIndex = 6;
            this.button_Notificaciones.Click += new System.EventHandler(this.button_Notificaciones_Click);
            this.button_Notificaciones.MouseEnter += new System.EventHandler(this.button_Notificaciones_hover);
            this.button_Notificaciones.MouseLeave += new System.EventHandler(this.button_Notificaciones_MouseLeave);
            // 
            // bunifuElipse_Badge
            // 
            //this.bunifuElipse_Badge.ElipseRadius = 30;
            //this.bunifuElipse_Badge.TargetControl = this.Button_Badge;
            // 
            // Button_Badge
            // 
           // this.Button_Badge.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(92)))), ((int)(((byte)(166)))));
            this.Button_Badge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Badge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(92)))), ((int)(((byte)(166)))));
            this.Button_Badge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //this.Button_Badge.BorderRadius = 0;
            //this.Button_Badge.ButtonText = "";
            this.Button_Badge.Cursor = System.Windows.Forms.Cursors.Hand;
            //this.Button_Badge.DisabledColor = System.Drawing.Color.Gray;
            //this.Button_Badge.Iconcolor = System.Drawing.Color.Transparent;
            //this.Button_Badge.Iconimage = null;
            //this.Button_Badge.Iconimage_right = null;
            //this.Button_Badge.Iconimage_right_Selected = null;
            //this.Button_Badge.Iconimage_Selected = null;
            //this.Button_Badge.IconMarginLeft = 0;
            //this.Button_Badge.IconMarginRight = 0;
            //this.Button_Badge.IconRightVisible = true;
            //this.Button_Badge.IconRightZoom = 0D;
            //this.Button_Badge.IconVisible = true;
            //this.Button_Badge.IconZoom = 90D;
            //this.Button_Badge.IsTab = false;
            this.Button_Badge.Location = new System.Drawing.Point(993, 38);
            this.Button_Badge.Name = "Button_Badge";
            //this.Button_Badge.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(92)))), ((int)(((byte)(166)))));
            //this.Button_Badge.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(92)))), ((int)(((byte)(166)))));
            //this.Button_Badge.OnHoverTextColor = System.Drawing.Color.White;
            //this.Button_Badge.selected = false;
            this.Button_Badge.Size = new System.Drawing.Size(24, 24);
            this.Button_Badge.TabIndex = 8;
            this.Button_Badge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //this.Button_Badge.Textcolor = System.Drawing.Color.White;
            //this.Button_Badge.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Badge.Visible = false;
            this.Button_Badge.Click += new System.EventHandler(this.button_Notificaciones_Click);
            this.Button_Badge.MouseEnter += new System.EventHandler(this.button_Notificaciones_hover);
            this.Button_Badge.MouseLeave += new System.EventHandler(this.button_Notificaciones_Click);
            // 
            // bunifuElipse_Notificaciones
            // 
           // this.bunifuElipse_Notificaciones.ElipseRadius = 15;
            //this.bunifuElipse_Notificaciones.TargetControl = this.panel_Notificaciones;
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            //this.bunifuCards1.BorderRadius = 5;
            //this.bunifuCards1.BottomSahddow = true;
            //this.bunifuCards1.color = System.Drawing.Color.IndianRed;
            //this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(3, 471);
            this.bunifuCards1.Name = "bunifuCards1";
            //this.bunifuCards1.RightSahddow = true;
            //this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(340, 78);
            this.bunifuCards1.TabIndex = 0;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 691);
            this.Controls.Add(this.Button_Badge);
            this.Controls.Add(this.button_Notificaciones);
            this.Controls.Add(this.panel_Notificaciones);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Dashboard";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Dashboard";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dashboard_FormClosed);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel_Notificaciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem monitoreoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresarCadenaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incidentesToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panel_Notificaciones;
        private System.Windows.Forms.Button button_Notificaciones;
        private System.Windows.Forms.Button bunifuElipse_Badge;
        private System.Windows.Forms.Button Button_Badge;
        //private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Notificaciones;
        private System.Windows.Forms.Button bunifuElipse_Notificaciones;
       // private Bunifu.Framework.UI.BunifuThinButton2 Notificacion;
        private System.Windows.Forms.Button Notificacion;
        //private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.ContainerControl bunifuCards1;
    }
}
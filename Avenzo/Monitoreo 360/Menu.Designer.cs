namespace Monitoreo_360
{
    partial class Menu
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
            this.bunifuElipse = new System.Windows.Forms.Button();
            this.bunifuElipse_Badge = new System.Windows.Forms.Button();
            this.Button_Badge = new System.Windows.Forms.Button();
            this.panel_Menu = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Header = new System.Windows.Forms.Panel();
            this.label_title = new System.Windows.Forms.Label();
            this.panel_Controls = new System.Windows.Forms.Panel();
            this.panel_Content = new System.Windows.Forms.Panel();
            this.panel_divider = new System.Windows.Forms.Panel();
            this.label_Nombre = new System.Windows.Forms.Label();
            this.bunifuElipse_Profile = new System.Windows.Forms.Button();
            //this.DragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel_Notificaciones = new System.Windows.Forms.Panel();
            this.bunifuElipse_PanelNotificaciones = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox_Profile = new System.Windows.Forms.PictureBox();
            this.Button_Usuarios = new System.Windows.Forms.Button();
            this.Button_CerrarSesion = new System.Windows.Forms.Button();
            this.Button_Cadena = new System.Windows.Forms.Button();
            this.Button_Incidentes = new System.Windows.Forms.Button();
            this.Button_Monitor = new System.Windows.Forms.Button();
            this.Button_Clientes = new System.Windows.Forms.Button();
            this.button_Maximize = new System.Windows.Forms.Button();
            this.Button_Close = new System.Windows.Forms.Button();
            this.Button_Notificacion = new System.Windows.Forms.Button();
            this.panel_Menu.SuspendLayout();
            this.panel_Header.SuspendLayout();
            this.panel_divider.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Profile)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.button_Maximize)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.Button_Close)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.Button_Notificacion)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse
            // 
            //this.bunifuElipse.ElipseRadius = 20;
            //this.bunifuElipse.TargetControl = this;
            // 
            // bunifuElipse_Badge
            // 
            //this.bunifuElipse_Badge.ElipseRadius = 30;
            //this.bunifuElipse_Badge.TargetControl = this.Button_Badge;
            // 
            // Button_Badge
            // 
            //this.Button_Badge.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            this.Button_Badge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Badge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            this.Button_Badge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //this.Button_Badge.BorderRadius = 0;
            //this.Button_Badge.ButtonText = "1";
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
            this.Button_Badge.Location = new System.Drawing.Point(787, 55);
            this.Button_Badge.Name = "Button_Badge";
            //this.Button_Badge.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            //this.Button_Badge.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            //this.Button_Badge.OnHoverTextColor = System.Drawing.Color.White;
            //this.Button_Badge.selected = false;
            this.Button_Badge.Size = new System.Drawing.Size(17, 17);
            this.Button_Badge.TabIndex = 10;
            this.Button_Badge.Text = "1";
            this.Button_Badge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //this.Button_Badge.Textcolor = System.Drawing.Color.White;
            //this.Button_Badge.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Badge.Click += new System.EventHandler(this.Button_Notificacion_Click);
            // 
            // panel_Menu
            // 
            this.panel_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            this.panel_Menu.Controls.Add(this.Button_Usuarios);
            this.panel_Menu.Controls.Add(this.Button_CerrarSesion);
            this.panel_Menu.Controls.Add(this.Button_Cadena);
            this.panel_Menu.Controls.Add(this.Button_Incidentes);
            this.panel_Menu.Controls.Add(this.Button_Monitor);
            this.panel_Menu.Controls.Add(this.Button_Clientes);
            this.panel_Menu.Controls.Add(this.label1);
            this.panel_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Menu.Location = new System.Drawing.Point(0, 0);
            this.panel_Menu.Name = "panel_Menu";
            this.panel_Menu.Size = new System.Drawing.Size(203, 541);
            this.panel_Menu.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Monitoreo 360";
            // 
            // panel_Header
            // 
            this.panel_Header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Header.BackColor = System.Drawing.Color.White;
            this.panel_Header.Controls.Add(this.label_title);
            this.panel_Header.Controls.Add(this.button_Maximize);
            this.panel_Header.Controls.Add(this.Button_Close);
            this.panel_Header.Controls.Add(this.Button_Badge);
            this.panel_Header.Controls.Add(this.Button_Notificacion);
            this.panel_Header.Location = new System.Drawing.Point(203, -1);
            this.panel_Header.Name = "panel_Header";
            this.panel_Header.Size = new System.Drawing.Size(814, 91);
            this.panel_Header.TabIndex = 4;
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.Location = new System.Drawing.Point(15, 31);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(123, 24);
            this.label_title.TabIndex = 11;
            this.label_title.Text = "Dashboard";
            // 
            // panel_Controls
            // 
            this.panel_Controls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Controls.BackColor = System.Drawing.Color.Silver;
            this.panel_Controls.Location = new System.Drawing.Point(203, 90);
            this.panel_Controls.Name = "panel_Controls";
            this.panel_Controls.Size = new System.Drawing.Size(814, 46);
            this.panel_Controls.TabIndex = 5;
            // 
            // panel_Content
            // 
            this.panel_Content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Content.BackColor = System.Drawing.SystemColors.Control;
            this.panel_Content.Location = new System.Drawing.Point(203, 136);
            this.panel_Content.Name = "panel_Content";
            this.panel_Content.Size = new System.Drawing.Size(813, 404);
            this.panel_Content.TabIndex = 6;
            // 
            // panel_divider
            // 
            this.panel_divider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            this.panel_divider.Controls.Add(this.label_Nombre);
            this.panel_divider.Controls.Add(this.pictureBox_Profile);
            this.panel_divider.Location = new System.Drawing.Point(-16, 90);
            this.panel_divider.Name = "panel_divider";
            this.panel_divider.Size = new System.Drawing.Size(219, 46);
            this.panel_divider.TabIndex = 1;
            // 
            // label_Nombre
            // 
            this.label_Nombre.BackColor = System.Drawing.Color.Transparent;
            this.label_Nombre.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Nombre.ForeColor = System.Drawing.Color.White;
            this.label_Nombre.Location = new System.Drawing.Point(63, 3);
            this.label_Nombre.Name = "label_Nombre";
            this.label_Nombre.Size = new System.Drawing.Size(156, 43);
            this.label_Nombre.TabIndex = 1;
            this.label_Nombre.Text = "Cristian Santiago rosas";
            this.label_Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuElipse_Profile
            // 
            //this.bunifuElipse_Profile.ElipseRadius = 15;
            //this.bunifuElipse_Profile.TargetControl = this.pictureBox_Profile;
            // 
            // DragControl
            // 
            //this.DragControl.Fixed = true;
            //this.DragControl.Horizontal = true;
            //this.DragControl.TargetControl = this.panel_Header;
            //this.DragControl.Vertical = true;
            // 
            // panel_Notificaciones
            // 
            this.panel_Notificaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Notificaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(92)))), ((int)(((byte)(166)))));
            this.panel_Notificaciones.Location = new System.Drawing.Point(770, 90);
            this.panel_Notificaciones.Name = "panel_Notificaciones";
            this.panel_Notificaciones.Size = new System.Drawing.Size(256, 451);
            this.panel_Notificaciones.TabIndex = 7;
            this.panel_Notificaciones.Visible = false;
            // 
            // bunifuElipse_PanelNotificaciones
            // 
            //this.bunifuElipse_PanelNotificaciones.ElipseRadius = 10;
            //this.bunifuElipse_PanelNotificaciones.TargetControl = this.panel_Notificaciones;
            //// 
            // timer
            // 
            this.timer.Interval = 60000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pictureBox_Profile
            // 
            this.pictureBox_Profile.BackgroundImage = global::Monitoreo_360.Properties.Resources.user;
            this.pictureBox_Profile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_Profile.Location = new System.Drawing.Point(23, 4);
            this.pictureBox_Profile.Name = "pictureBox_Profile";
            this.pictureBox_Profile.Size = new System.Drawing.Size(36, 38);
            this.pictureBox_Profile.TabIndex = 0;
            this.pictureBox_Profile.TabStop = false;
            // 
            // Button_Usuarios
            // 
           // this.Button_Usuarios.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            this.Button_Usuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            this.Button_Usuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //this.Button_Usuarios.BorderRadius = 0;
           // this.Button_Usuarios.ButtonText = "Usuarios";
            this.Button_Usuarios.Cursor = System.Windows.Forms.Cursors.Hand;
           // this.Button_Usuarios.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            //this.Button_Usuarios.Iconcolor = System.Drawing.Color.Transparent;
            //this.Button_Usuarios.Iconimage = global::Monitoreo_360.Properties.Resources.User_Account_100px;
            //this.Button_Usuarios.Iconimage_right = null;
            //this.Button_Usuarios.Iconimage_right_Selected = null;
            //this.Button_Usuarios.Iconimage_Selected = null;
            //this.Button_Usuarios.IconMarginLeft = 0;
            //this.Button_Usuarios.IconMarginRight = 0;
            //this.Button_Usuarios.IconRightVisible = true;
            //this.Button_Usuarios.IconRightZoom = 0D;
            //this.Button_Usuarios.IconVisible = true;
            //this.Button_Usuarios.IconZoom = 80D;
            //this.Button_Usuarios.IsTab = false;
            this.Button_Usuarios.Location = new System.Drawing.Point(0, 334);
            this.Button_Usuarios.Name = "Button_Usuarios";
            //this.Button_Usuarios.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            //this.Button_Usuarios.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            //this.Button_Usuarios.OnHoverTextColor = System.Drawing.Color.White;
            //this.Button_Usuarios.selected = false;
            this.Button_Usuarios.Size = new System.Drawing.Size(207, 48);
            this.Button_Usuarios.TabIndex = 11;
            this.Button_Usuarios.Text = "Usuarios";
            this.Button_Usuarios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //this.Button_Usuarios.Textcolor = System.Drawing.Color.White;
            //this.Button_Usuarios.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Usuarios.Click += new System.EventHandler(this.Button_Usuarios_Click);
            // 
            // Button_CerrarSesion
            // 
            //this.Button_CerrarSesion.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            this.Button_CerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_CerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            this.Button_CerrarSesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //this.Button_CerrarSesion.BorderRadius = 0;
            this.Button_CerrarSesion.Text = "Cerrar Sesion";
            this.Button_CerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            //this.Button_CerrarSesion.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            //this.Button_CerrarSesion.Iconcolor = System.Drawing.Color.Transparent;
            //this.Button_CerrarSesion.Iconimage = global::Monitoreo_360.Properties.Resources.Shutdown_96px;
            //this.Button_CerrarSesion.Iconimage_right = null;
            //this.Button_CerrarSesion.Iconimage_right_Selected = null;
            //this.Button_CerrarSesion.Iconimage_Selected = null;
            //this.Button_CerrarSesion.IconMarginLeft = 0;
            //this.Button_CerrarSesion.IconMarginRight = 0;
            //this.Button_CerrarSesion.IconRightVisible = true;
            //this.Button_CerrarSesion.IconRightZoom = 0D;
            //this.Button_CerrarSesion.IconVisible = true;
            //this.Button_CerrarSesion.IconZoom = 80D;
            //this.Button_CerrarSesion.IsTab = false;
            this.Button_CerrarSesion.Location = new System.Drawing.Point(0, 490);
            this.Button_CerrarSesion.Name = "Button_CerrarSesion";
            //this.Button_CerrarSesion.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            //this.Button_CerrarSesion.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            //this.Button_CerrarSesion.OnHoverTextColor = System.Drawing.Color.White;
            //this.Button_CerrarSesion.selected = false;
            this.Button_CerrarSesion.Size = new System.Drawing.Size(207, 51);
            this.Button_CerrarSesion.TabIndex = 10;
            this.Button_CerrarSesion.Text = "Cerrar Sesion";
            this.Button_CerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //this.Button_CerrarSesion.Textcolor = System.Drawing.Color.White;
            //this.Button_CerrarSesion.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_CerrarSesion.Click += new System.EventHandler(this.Button_CerrarSesion_Click);
            // 
            // Button_Cadena
            // 
            //this.Button_Cadena.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            this.Button_Cadena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            this.Button_Cadena.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //this.Button_Cadena.BorderRadius = 0;
            this.Button_Cadena.Text = "Ingresar Cadena";
            this.Button_Cadena.Cursor = System.Windows.Forms.Cursors.Hand;
            //this.Button_Cadena.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            //this.Button_Cadena.Iconcolor = System.Drawing.Color.Transparent;
            //this.Button_Cadena.Iconimage = global::Monitoreo_360.Properties.Resources.Text_Color_104px;
            //this.Button_Cadena.Iconimage_right = null;
            //this.Button_Cadena.Iconimage_right_Selected = null;
            //this.Button_Cadena.Iconimage_Selected = null;
            //this.Button_Cadena.IconMarginLeft = 0;
            //this.Button_Cadena.IconMarginRight = 0;
            //this.Button_Cadena.IconRightVisible = true;
            //this.Button_Cadena.IconRightZoom = 0D;
            //this.Button_Cadena.IconVisible = true;
            //this.Button_Cadena.IconZoom = 80D;
            //this.Button_Cadena.IsTab = false;
            this.Button_Cadena.Location = new System.Drawing.Point(0, 280);
            this.Button_Cadena.Name = "Button_Cadena";
            //this.Button_Cadena.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            //this.Button_Cadena.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            //this.Button_Cadena.OnHoverTextColor = System.Drawing.Color.White;
            //this.Button_Cadena.selected = false;
            this.Button_Cadena.Size = new System.Drawing.Size(207, 48);
            this.Button_Cadena.TabIndex = 9;
            this.Button_Cadena.Text = "Ingresar Cadena";
            this.Button_Cadena.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //this.Button_Cadena.Textcolor = System.Drawing.Color.White;
            //this.Button_Cadena.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Cadena.Click += new System.EventHandler(this.Button_Cadena_Click);
            // 
            // Button_Incidentes
            // 
            //this.Button_Incidentes.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            this.Button_Incidentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            this.Button_Incidentes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //this.Button_Incidentes.BorderRadius = 0;
            //this.Button_Incidentes.ButtonText = "Incidentes";
            this.Button_Incidentes.Cursor = System.Windows.Forms.Cursors.Hand;
            //this.Button_Incidentes.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            //this.Button_Incidentes.Iconcolor = System.Drawing.Color.Transparent;
            //this.Button_Incidentes.Iconimage = global::Monitoreo_360.Properties.Resources.System_Report_104px;
            //this.Button_Incidentes.Iconimage_right = null;
            //this.Button_Incidentes.Iconimage_right_Selected = null;
            //this.Button_Incidentes.Iconimage_Selected = null;
            //this.Button_Incidentes.IconMarginLeft = 0;
            //this.Button_Incidentes.IconMarginRight = 0;
            //this.Button_Incidentes.IconRightVisible = true;
            //this.Button_Incidentes.IconRightZoom = 0D;
            //this.Button_Incidentes.IconVisible = true;
            //this.Button_Incidentes.IconZoom = 80D;
            //this.Button_Incidentes.IsTab = false;
            this.Button_Incidentes.Location = new System.Drawing.Point(0, 232);
            this.Button_Incidentes.Name = "Button_Incidentes";
            //this.Button_Incidentes.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            //this.Button_Incidentes.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            //this.Button_Incidentes.OnHoverTextColor = System.Drawing.Color.White;
            //this.Button_Incidentes.selected = false;
            this.Button_Incidentes.Size = new System.Drawing.Size(207, 48);
            this.Button_Incidentes.TabIndex = 8;
            this.Button_Incidentes.Text = "Incidentes";
            this.Button_Incidentes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //this.Button_Incidentes.Textcolor = System.Drawing.Color.White;
            //this.Button_Incidentes.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Incidentes.Click += new System.EventHandler(this.Button_Incidentes_Click);
            // 
            // Button_Monitor
            // 
            //this.Button_Monitor.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            this.Button_Monitor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            this.Button_Monitor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
           // this.Button_Monitor.BorderRadius = 0;
            //this.Button_Monitor.ButtonText = "Monitoreo";
            this.Button_Monitor.Cursor = System.Windows.Forms.Cursors.Hand;
            //this.Button_Monitor.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            //this.Button_Monitor.Iconcolor = System.Drawing.Color.Transparent;
            //this.Button_Monitor.Iconimage = global::Monitoreo_360.Properties.Resources.HIPS_104px;
            //this.Button_Monitor.Iconimage_right = null;
            //this.Button_Monitor.Iconimage_right_Selected = null;
            //this.Button_Monitor.Iconimage_Selected = null;
            //this.Button_Monitor.IconMarginLeft = 0;
            //this.Button_Monitor.IconMarginRight = 0;
            //this.Button_Monitor.IconRightVisible = true;
            //this.Button_Monitor.IconRightZoom = 0D;
            //this.Button_Monitor.IconVisible = true;
            //this.Button_Monitor.IconZoom = 80D;
            //this.Button_Monitor.IsTab = false;
            this.Button_Monitor.Location = new System.Drawing.Point(0, 184);
            this.Button_Monitor.Name = "Button_Monitor";
            //this.Button_Monitor.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            //this.Button_Monitor.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            //this.Button_Monitor.OnHoverTextColor = System.Drawing.Color.White;
            //this.Button_Monitor.selected = false;
            this.Button_Monitor.Size = new System.Drawing.Size(207, 48);
            this.Button_Monitor.TabIndex = 7;
            this.Button_Monitor.Text = "Monitoreo";
            this.Button_Monitor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //this.Button_Monitor.Textcolor = System.Drawing.Color.White;
            //this.Button_Monitor.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Monitor.Click += new System.EventHandler(this.Button_Monitor_Click);
            // 
            // Button_Clientes
            // 
            //this.Button_Clientes.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            this.Button_Clientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            this.Button_Clientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
           // this.Button_Clientes.BorderRadius = 0;
           // this.Button_Clientes.Text = "Clientes";
            this.Button_Clientes.Cursor = System.Windows.Forms.Cursors.Hand;
            //this.Button_Clientes.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            //this.Button_Clientes.Iconcolor = System.Drawing.Color.Transparent;
            //this.Button_Clientes.Iconimage = global::Monitoreo_360.Properties.Resources.People_96px;
            //this.Button_Clientes.Iconimage_right = null;
            //this.Button_Clientes.Iconimage_right_Selected = null;
            //this.Button_Clientes.Iconimage_Selected = null;
            //this.Button_Clientes.IconMarginLeft = 0;
            //this.Button_Clientes.IconMarginRight = 0;
            //this.Button_Clientes.IconRightVisible = true;
            //this.Button_Clientes.IconRightZoom = 0D;
            //this.Button_Clientes.IconVisible = true;
            //this.Button_Clientes.IconZoom = 80D;
            //this.Button_Clientes.IsTab = false;
            this.Button_Clientes.Location = new System.Drawing.Point(0, 136);
            this.Button_Clientes.Name = "Button_Clientes";
            //this.Button_Clientes.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            //this.Button_Clientes.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            //this.Button_Clientes.OnHoverTextColor = System.Drawing.Color.White;
            //this.Button_Clientes.selected = false;
            this.Button_Clientes.Size = new System.Drawing.Size(207, 48);
            this.Button_Clientes.TabIndex = 6;
            this.Button_Clientes.Text = "Clientes";
            this.Button_Clientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
           // this.Button_Clientes.Textcolor = System.Drawing.Color.White;
            //this.Button_Clientes.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Clientes.Click += new System.EventHandler(this.Button_Clientes_Click);
            // 
            // button_Maximize
            // 
            this.button_Maximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Maximize.BackColor = System.Drawing.Color.Transparent;
            this.button_Maximize.Image = global::Monitoreo_360.Properties.Resources.Maximize_Window_100px;
            //this.button_Maximize.ImageActive = global::Monitoreo_360.Properties.Resources.Maximize_Window_100px_Red;
            this.button_Maximize.Location = new System.Drawing.Point(755, 8);
            this.button_Maximize.Name = "button_Maximize";
            this.button_Maximize.Size = new System.Drawing.Size(21, 20);
            //this.button_Maximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.button_Maximize.TabIndex = 7;
            // this.button_Maximize.TabStop = false;
           // this.button_Maximize.Zoom = 10;
            this.button_Maximize.Click += new System.EventHandler(this.button_Maximize_Click);
            // 
            // Button_Close
            // 
            this.Button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Close.BackColor = System.Drawing.Color.Transparent;
            this.Button_Close.Image = global::Monitoreo_360.Properties.Resources.Delete_50px;
            //this.Button_Close.ImageActive = global::Monitoreo_360.Properties.Resources.Delete_50px_red;
            this.Button_Close.Location = new System.Drawing.Point(782, 8);
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Size = new System.Drawing.Size(21, 20);
            //this.Button_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Button_Close.TabIndex = 6;
            this.Button_Close.TabStop = false;
            //this.Button_Close.Zoom = 10;
            this.Button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // Button_Notificacion
            // 
            this.Button_Notificacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Notificacion.BackColor = System.Drawing.Color.Transparent;
            this.Button_Notificacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Notificacion.Image = global::Monitoreo_360.Properties.Resources.Notification__Gray_48px;
            //this.Button_Notificacion.ImageActive = global::Monitoreo_360.Properties.Resources.Notification_48px_Blue;
            this.Button_Notificacion.Location = new System.Drawing.Point(776, 56);
            this.Button_Notificacion.Name = "Button_Notificacion";
            this.Button_Notificacion.Size = new System.Drawing.Size(27, 29);
           // this.Button_Notificacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Button_Notificacion.TabIndex = 6;
            this.Button_Notificacion.TabStop = false;
            //this.Button_Notificacion.Zoom = 15;
            this.Button_Notificacion.Click += new System.EventHandler(this.Button_Notificacion_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1018, 541);
            this.ControlBox = false;
            this.Controls.Add(this.panel_Notificaciones);
            this.Controls.Add(this.panel_divider);
            this.Controls.Add(this.panel_Menu);
            this.Controls.Add(this.panel_Header);
            this.Controls.Add(this.panel_Content);
            this.Controls.Add(this.panel_Controls);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.panel_Menu.ResumeLayout(false);
            this.panel_Menu.PerformLayout();
            this.panel_Header.ResumeLayout(false);
            this.panel_Header.PerformLayout();
            this.panel_divider.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Profile)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.button_Maximize)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.Button_Close)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.Button_Notificacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bunifuElipse;
        private System.Windows.Forms.Panel panel_Header;
        private System.Windows.Forms.Panel panel_Menu;
        private System.Windows.Forms.Button bunifuElipse_Badge;
        private System.Windows.Forms.Panel panel_Controls;
        private System.Windows.Forms.Panel panel_divider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_Badge;
        private System.Windows.Forms.Button Button_Close;
        private System.Windows.Forms.Button Button_Incidentes;
        private System.Windows.Forms.Button Button_Monitor;
        private System.Windows.Forms.Button Button_Clientes;
        private System.Windows.Forms.Button Button_Cadena;
        private System.Windows.Forms.Button Button_Notificacion;
        private System.Windows.Forms.PictureBox pictureBox_Profile;
        private System.Windows.Forms.Button bunifuElipse_Profile;
        private System.Windows.Forms.Label label_Nombre;
        private System.Windows.Forms.Button Button_CerrarSesion;
        private System.Windows.Forms.Button button_Maximize;
        private System.Windows.Forms.Panel panel_Content;
        private System.Windows.Forms.Label label_title;
       // private Bunifu.Framework.UI.BunifuDragControl DragControl;
        private System.Windows.Forms.Panel panel_Notificaciones;
        private System.Windows.Forms.Panel bunifuElipse_PanelNotificaciones;

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button Button_Usuarios;
    }
}
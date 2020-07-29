using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace Monitoreo_360
{
    public partial class Menu : Form
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        public int y = 0;
        private Guid IdUsuario;
        Login login;
        public Menu(Guid IdUsuario,Login login)
        {
            this.IdUsuario = IdUsuario;
            this.login = login;
            InitializeComponent();
            List<Model.Incidentes> Incidentes = new List<Model.Incidentes>();
            Incidentes = db.Incidentes.Where(x => x.Activo == true && x.Estatus == "Pendiente").ToList();
            
            foreach (var incidente in Incidentes)
            {
                if (string.IsNullOrEmpty(Button_Badge.Text))
                {
                    Button_Badge.Text = "1";
                    Button_Badge.Visible = true;
                }
                else
                {
                    Button_Badge.Text = (int.Parse(Button_Badge.Text) + 1) + "";
                    Button_Badge.Visible = true;
                }
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
                Bunifu.Framework.UI.BunifuFlatButton Button_Alerta = new Bunifu.Framework.UI.BunifuFlatButton();
                Button_Alerta.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(151)))), ((int)(((byte)(203)))));
                Button_Alerta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(92)))), ((int)(((byte)(166)))));
                Button_Alerta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                Button_Alerta.BorderRadius = 0;
                string text=incidente.Clientes.Nombres + " " + incidente.Clientes.ApellidoPaterno + " : " + incidente.FechaHoraInicio.Day + "/" + incidente.FechaHoraInicio.Month + "/" + incidente.FechaHoraInicio.Year+" "+incidente.FechaHoraInicio.Hour+":"+incidente.FechaHoraInicio.Minute;
                Button_Alerta.ButtonText = text;
                Button_Alerta.Cursor = System.Windows.Forms.Cursors.Hand;
                Button_Alerta.Click += new EventHandler(Button_Alerta_Click);
                Button_Alerta.DisabledColor = System.Drawing.Color.Gray;
                Button_Alerta.Iconcolor = System.Drawing.Color.Transparent;
                Button_Alerta.Iconimage = ((System.Drawing.Image)(resources.GetObject("Button_Alerta.Iconimage")));
                Button_Alerta.Iconimage_right = null;
                Button_Alerta.Iconimage_right_Selected = null;
                Button_Alerta.Iconimage_Selected = null;
                Button_Alerta.IconMarginLeft = 0;
                Button_Alerta.IconMarginRight = 0;
                Button_Alerta.IconRightVisible = true;
                Button_Alerta.IconRightZoom = 0D;
                Button_Alerta.IconVisible = true;
                Button_Alerta.IconZoom = 90D;
                Button_Alerta.IsTab = false;
                Button_Alerta.Location = new System.Drawing.Point(-7, y);
                Button_Alerta.Name = incidente.Id.ToString();
                Button_Alerta.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(92)))), ((int)(((byte)(166)))));
                Button_Alerta.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(44)))), ((int)(((byte)(100)))));
                Button_Alerta.OnHoverTextColor = System.Drawing.Color.White;
                Button_Alerta.selected = false;
                Button_Alerta.Size = new System.Drawing.Size(265, 48);
                Button_Alerta.TabIndex = 0;
                Button_Alerta.Text = text;
                Button_Alerta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                Button_Alerta.Textcolor = System.Drawing.Color.White;
                Button_Alerta.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.panel_Notificaciones.Controls.Add(Button_Alerta);                
                y += 48;
            }
        }
        private void Button_Alerta_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Button_Badge.Text))
                {
                Button_Badge.Text = "";
                Button_Badge.Visible = true;
            }
                else
                {
                Button_Badge.Text = (int.Parse(Button_Badge.Text) - 1) + "";
                Button_Badge.Visible = true;
            }
            string name = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Name;
            Guid Id = Guid.Parse(name);
            Model.Incidentes incidente = db.Incidentes.Where(model => model.Id == Id).FirstOrDefault();
            CultureInfo CI = new CultureInfo("es-MX");
            LogMonitoreo360 Log = db.LogMonitoreo360.Where(x => x.Id == incidente.IdLog).FirstOrDefault();
            string f = Log.Log.Substring(0, 20);
            DateTime fecha = DateTime.Parse(f);
            f = Log.Log.Substring(23, 20).Replace("-", " ");
            DateTime fecha2 = DateTime.Parse(f);
            string NumeroTelefono = Log.Log.Substring(54, 6).Replace("-", "");
            string NumeroCuenta = Log.Log.Substring(61, 4);
            string report = Log.Log.Substring(66, Log.Log.Length - 66);
            string[] eventos = report.Split('-')[1].Split('/');
            Model.Clientes cliente = db.Clientes.Where(x => x.IdCliente == incidente.IdCliente).FirstOrDefault();
            bool ParticionZona = false;
            List<ClienteEventos> Eventos = new List<ClienteEventos>();
            string Zona = "1";
            try
            {
                if (eventos.Count() > 1)
                {
                    List<Sensores> clienteSensores = db.GetSensores(cliente.IdCliente, 2).ToList();
                    HorarioOperaciones Horario = db.GetHorarioOperaciones(cliente.IdCliente).FirstOrDefault();
                    List<CodigoEventos> CodigosEventos = db.CodigoEventos.ToList();
                    foreach (var evento in eventos)
                    {
                        ClienteEventos clienteEventos = new ClienteEventos();
                        if (evento.Contains("ri"))
                        {
                            clienteEventos.ParticionArea = evento.Split('i')[1];
                            Zona = evento.Split('i')[1];
                            ParticionZona = true;
                        }
                        else if (CodigosEventos.Where(x => x.Codigo.Contains(evento.Substring(0, 2))).Any())
                        {
                            ParticionZona = false;
                            CodigoEventos ClienteEvento = CodigosEventos.Where(x => x.Codigo.Contains(evento.Substring(0, 2))).First();
                            clienteEventos.Tipo = ClienteEvento.Tipo;
                            clienteEventos.Codigo = ClienteEvento.Codigo;
                            clienteEventos.Descripcion = ClienteEvento.Descripcion;
                            clienteEventos.Numero = evento.Substring(2, 4);
                            clienteEventos.ParticionArea = Zona;
                            if (Horario != null)
                            {
                                if (ClienteEvento.Codigo.Contains("OP") || ClienteEvento.Codigo.Contains("CL") || ClienteEvento.Codigo.Contains("OR") || ClienteEvento.Codigo.Contains("CR"))
                                {

                                    TimeSpan Inicial = new TimeSpan();
                                    TimeSpan Final = new TimeSpan();
                                    TimeSpan H = new TimeSpan(fecha.Hour, fecha.Minute, fecha.Second);
                                    if (fecha.ToString("dddd", CI) == "lunes")
                                    {
                                        Inicial = new TimeSpan(Horario.LunesInicio.Value.Hours, Horario.LunesInicio.Value.Minutes, Horario.LunesInicio.Value.Seconds);
                                        Final = new TimeSpan(Horario.LunesFinal.Value.Hours, Horario.LunesFinal.Value.Minutes, Horario.LunesFinal.Value.Seconds);
                                    }
                                    if (fecha.ToString("dddd", CI) == "martes")
                                    {
                                        Inicial = new TimeSpan(Horario.MartesInicio.Value.Hours, Horario.MartesInicio.Value.Minutes, Horario.MartesInicio.Value.Seconds);
                                        Final = new TimeSpan(Horario.MartesFinal.Value.Hours, Horario.MartesFinal.Value.Minutes, Horario.MartesFinal.Value.Seconds);
                                    }
                                    if (fecha.ToString("dddd", CI) == "miercoles")
                                    {
                                        Inicial = new TimeSpan(Horario.MiercolesInicio.Value.Hours, Horario.MiercolesInicio.Value.Minutes, Horario.MiercolesInicio.Value.Seconds);
                                        Final = new TimeSpan(Horario.MiercolesFinal.Value.Hours, Horario.MiercolesFinal.Value.Minutes, Horario.MiercolesFinal.Value.Seconds);
                                    }
                                    if (fecha.ToString("dddd", CI) == "jueves")
                                    {
                                        Inicial = new TimeSpan(Horario.JuevesInicio.Value.Hours, Horario.JuevesInicio.Value.Minutes, Horario.JuevesInicio.Value.Seconds);
                                        Final = new TimeSpan(Horario.JuevesFinal.Value.Hours, Horario.JuevesFinal.Value.Minutes, Horario.JuevesFinal.Value.Seconds);
                                    }
                                    if (fecha.ToString("dddd", CI) == "viernes")
                                    {
                                        Inicial = new TimeSpan(Horario.ViernesInicio.Value.Hours, Horario.ViernesInicio.Value.Minutes, Horario.ViernesInicio.Value.Seconds);
                                        Final = new TimeSpan(Horario.ViernesFinal.Value.Hours, Horario.ViernesFinal.Value.Minutes, Horario.ViernesFinal.Value.Seconds);
                                    }
                                    if (fecha.ToString("dddd", CI) == "sabado")
                                    {
                                        Inicial = new TimeSpan(Horario.SabadoInicio.Value.Hours, Horario.SabadoInicio.Value.Minutes, Horario.SabadoInicio.Value.Seconds);
                                        Final = new TimeSpan(Horario.SabadoFinal.Value.Hours, Horario.SabadoFinal.Value.Minutes, Horario.SabadoFinal.Value.Seconds);
                                    }
                                    if (fecha.ToString("dddd", CI) == "domingo")
                                    {
                                        Inicial = new TimeSpan(Horario.DomingoInicio.Value.Hours, Horario.DomingoInicio.Value.Minutes, Horario.DomingoInicio.Value.Seconds);
                                        Final = new TimeSpan(Horario.DomingoFinal.Value.Hours, Horario.DomingoFinal.Value.Minutes, Horario.DomingoFinal.Value.Seconds);
                                    }
                                    if (H < Inicial || H > Final)
                                    {
                                        ClienteEventos horarioDesfasado = new ClienteEventos();
                                        horarioDesfasado.Codigo = "00";
                                        horarioDesfasado.Descripcion = "La alarma se activo/Desactivo fuera de sus horarios de operaciones";
                                        horarioDesfasado.Numero = "N/A";
                                        horarioDesfasado.ParticionArea = "N/A";
                                        horarioDesfasado.Tipo = "N/A";
                                        Eventos.Add(horarioDesfasado);
                                    }
                                }
                            }
                            if (ClienteEvento.Tipo == "Sensor")
                            {
                                if (clienteSensores.Where(x => x.NumeroDeSensor == clienteEventos.Numero).Any())
                                {
                                    clienteEventos.Ubicacion = clienteSensores.Where(x => x.NumeroDeSensor == clienteEventos.Numero).First().Ubicacion;
                                }
                                else
                                {
                                    clienteEventos.Ubicacion = "Ubicacion desconocidad";
                                }
                            }
                            else if (ClienteEvento.Tipo == "Usuario")
                            {
                                clienteEventos.Ubicacion = "N/A";
                            }
                            else
                            {
                                clienteEventos.Ubicacion = "N/A";
                            }
                            clienteEventos.ParticionArea = Zona;
                        }
                        if (!ParticionZona)
                        {
                            Eventos.Add(clienteEventos);
                        }
                    }
                    bool IsOpen = false;
                    FormCollection forms = Application.OpenForms;
                    foreach (var form in forms)
                    {
                        if (((Form)form).Name == "ClienteAlerta")
                        {
                            if (((ClienteAlerta)form).IdI.Text == incidente.Id.ToString())
                            {
                                IsOpen = true;
                            }
                        }
                    }
                    if (!IsOpen)
                    {
                        ClienteAlerta alerta = new ClienteAlerta(this.IdUsuario, incidente.Id);
                        db.UpdateIncidente(incidente.Id, incidente.IdCliente, incidente.IdLog, incidente.Comentarios, incidente.FechaHoraInicio, incidente.FechaHoraFin, "Pendiente", true, incidente.FechaCreacion, incidente.UsuarioCreacion);
                        alerta.setInfo(cliente, Log.Id);
                        alerta.setButton(this.Button_Badge, panel_Notificaciones);
                        alerta.setEventos(Eventos);
                        alerta.Text = "Alerta - Incidente sin seguimiento";
                        alerta.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message + " Inner:" + ex.InnerException);
            }
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Maximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)            
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
            if (!Button_Monitor.Enabled) {
                int width = this.panel_Content.Width;
                int height = this.panel_Content.Height;
                this.panel_Content.Controls.Clear();
                this.panel_Controls.Controls.Clear();
                Button_Clientes.Enabled = true;
                Button_Incidentes.Enabled = true;
                Button_Monitor.Enabled = false;
                Monitor form = new Monitor();
                form.Width = width - 40;
                form.Height = height - 40;
                form.Location = new Point(20, 20);
                form.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top;
                form.Data();
                this.panel_Content.Controls.Add(form);
            }            
        }

        private void Button_Clientes_Click(object sender, EventArgs e)
        {            
            try {
                int width = this.panel_Content.Width;
                int height = this.panel_Content.Height;
                Button_Cadena.Enabled = true;
                this.panel_Content.Controls.Clear();
                Button_Clientes.Enabled = false;
                Button_Incidentes.Enabled = true;
                Button_Monitor.Enabled = true;
                Button_Usuarios.Enabled = true;
                Clientes form = new Clientes();
                form.Width = width - 40;
                form.Height = height - 40;
                form.Location = new Point(20, 20);
                form.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top;

                Bunifu.Framework.UI.BunifuFlatButton Button_AgregarClientes = new Bunifu.Framework.UI.BunifuFlatButton(); ;
                Bunifu.Framework.UI.BunifuElipse bunifuElipse_AgregarClientes = new Bunifu.Framework.UI.BunifuElipse(this.components); ;
                Button_AgregarClientes.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(92)))), ((int)(((byte)(166)))));
                Button_AgregarClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(92)))), ((int)(((byte)(166)))));
                Button_AgregarClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                Button_AgregarClientes.BorderRadius = 0;
                Button_AgregarClientes.ButtonText = "Agregar Clientes";
                Button_AgregarClientes.Cursor = System.Windows.Forms.Cursors.Hand;
                Button_AgregarClientes.DisabledColor = System.Drawing.Color.Gray;
                Button_AgregarClientes.Iconcolor = System.Drawing.Color.Transparent;
                Button_AgregarClientes.Iconimage = global::Monitoreo_360.Properties.Resources.Add_User_Male_104px;
                Button_AgregarClientes.Iconimage_right = null;
                Button_AgregarClientes.Iconimage_right_Selected = null;
                Button_AgregarClientes.Iconimage_Selected = null;
                Button_AgregarClientes.IconMarginLeft = 0;
                Button_AgregarClientes.IconMarginRight = 0;
                Button_AgregarClientes.IconRightVisible = true;
                Button_AgregarClientes.IconRightZoom = 0D;
                Button_AgregarClientes.IconVisible = true;
                Button_AgregarClientes.IconZoom = 70D;
                Button_AgregarClientes.IsTab = false;
                Button_AgregarClientes.Location = new System.Drawing.Point(20, 8);
                Button_AgregarClientes.Name = "Button_AgregarClientes";
                Button_AgregarClientes.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(92)))), ((int)(((byte)(166)))));
                Button_AgregarClientes.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(44)))), ((int)(((byte)(100)))));
                Button_AgregarClientes.OnHoverTextColor = System.Drawing.Color.White;
                Button_AgregarClientes.selected = false;
                Button_AgregarClientes.Size = new System.Drawing.Size(174, 30);
                Button_AgregarClientes.TabIndex = 0;
                Button_AgregarClientes.Text = "Agregar Clientes";
                Button_AgregarClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                Button_AgregarClientes.Textcolor = System.Drawing.Color.White;
                Button_AgregarClientes.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Button_AgregarClientes.Click += new System.EventHandler(this.Button_AgregarClientes_Click);

                bunifuElipse_AgregarClientes.ElipseRadius = 5;
                bunifuElipse_AgregarClientes.TargetControl = Button_AgregarClientes;
                this.panel_Controls.Controls.Add(Button_AgregarClientes);
                this.panel_Content.Controls.Add(form);
                
            } catch (Exception ex) {
                Console.WriteLine(ex.Message+" "+ex.InnerException);
            }

            
        }

        private void Button_CerrarSesion_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Hide();
            //this.Close();
        }

        private void Button_Incidentes_Click(object sender, EventArgs e)
        {
            int width = this.panel_Content.Width;
            int height = this.panel_Content.Height;
            this.panel_Content.Controls.Clear();
            this.panel_Controls.Controls.Clear();
            Button_Clientes.Enabled = true;
            Button_Incidentes.Enabled = false;
            Button_Cadena.Enabled = true;
            Button_Monitor.Enabled = true;
            Button_Usuarios.Enabled = true;
            Incidentes form = new Incidentes();
            form.Width = width - 40;
            form.Height = height - 40;
            form.Location = new Point(20, 20);
            form.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top;
            this.panel_Content.Controls.Add(form);

            
        }

        private void Button_AgregarClientes_Click(object sender, EventArgs e)
        {

        }

        private void Button_Monitor_Click(object sender, EventArgs e)
        {
            int width = this.panel_Content.Width;
            int height = this.panel_Content.Height;
            this.panel_Content.Controls.Clear();
            this.panel_Controls.Controls.Clear();
            Button_Clientes.Enabled = true;
            Button_Incidentes.Enabled = true;
            Button_Cadena.Enabled = true; 
            Button_Monitor.Enabled = false;
            Button_Usuarios.Enabled = true;
            Monitor form = new Monitor();
            form.Width = width - 40;
            form.Height = height - 40;
            form.Location = new Point(20, 20);
            form.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top;
            form.Data();
            this.panel_Content.Controls.Add(form);
            
        }

        private void Button_Notificacion_Click(object sender, EventArgs e)
        {
            this.panel_Notificaciones.Visible = !panel_Notificaciones.Visible;
        }

        private void Button_Cadena_Click(object sender, EventArgs e)
        {
            int width = this.panel_Content.Width;
            int height = this.panel_Content.Height;
            this.panel_Content.Controls.Clear();
            this.panel_Controls.Controls.Clear();
            Button_Clientes.Enabled = true;
            Button_Incidentes.Enabled = true;
            Button_Monitor.Enabled = true;
            Button_Cadena.Enabled = false;
            Button_Usuarios.Enabled = true;
            Cadena form = new Cadena(IdUsuario,this.Button_Badge,this.panel_Notificaciones);
            form.Width = width - 40;
            form.Height = height - 40;
            form.Location = new Point(20, 20);
            form.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top;
            this.panel_Content.Controls.Add(form);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.timer.Stop();
            CultureInfo CI = new CultureInfo("es-MX");
            //*********************************************************************************
            //*************************** Incidentes Pendientes *******************************
            //*********************************************************************************
            List<Model.Incidentes> Incidentes = new List<Model.Incidentes>();
            Incidentes = db.Incidentes.Where(x => x.Activo == true && x.Estatus != "Completo" && x.Estatus != "Pendiente").ToList();
            foreach (var incidente in Incidentes)
            {
                LogMonitoreo360 Log = db.LogMonitoreo360.Where(x => x.Id == incidente.IdLog).FirstOrDefault();
                string f = Log.Log.Substring(0, 20);
                DateTime fecha = DateTime.Parse(f);
                f = Log.Log.Substring(23, 20).Replace("-", " ");
                DateTime fecha2 = DateTime.Parse(f);
                string NumeroTelefono = Log.Log.Substring(54, 6).Replace("-", "");
                string NumeroCuenta = Log.Log.Substring(61, 4);
                string report = Log.Log.Substring(66, Log.Log.Length - 66);
                string[] eventos = report.Split('-')[1].Split('/');
                Model.Clientes cliente = db.Clientes.Where(x => x.IdCliente == incidente.IdCliente).FirstOrDefault();
                bool ParticionZona = false;
                List<ClienteEventos> Eventos = new List<ClienteEventos>();
                string Zona = "1";
                try
                {
                    if (eventos.Count() > 1)
                    {
                        List<Sensores> clienteSensores = db.GetSensores(cliente.IdCliente, 2).ToList();
                        HorarioOperaciones Horario = db.GetHorarioOperaciones(cliente.IdCliente).FirstOrDefault();
                        List<CodigoEventos> CodigosEventos = db.CodigoEventos.ToList();
                        foreach (var evento in eventos)
                        {
                            ClienteEventos clienteEventos = new ClienteEventos();
                            if (evento.Contains("ri"))
                            {
                                clienteEventos.ParticionArea = evento.Split('i')[1];
                                Zona = evento.Split('i')[1];
                                ParticionZona = true;
                            }
                            else if (CodigosEventos.Where(x => x.Codigo.Contains(evento.Substring(0, 2))).Any())
                            {
                                ParticionZona = false;
                                CodigoEventos ClienteEvento = CodigosEventos.Where(x => x.Codigo.Contains(evento.Substring(0, 2))).First();
                                clienteEventos.Tipo = ClienteEvento.Tipo;
                                clienteEventos.Codigo = ClienteEvento.Codigo;
                                clienteEventos.Descripcion = ClienteEvento.Descripcion;
                                clienteEventos.Numero = evento.Substring(2, 4);
                                clienteEventos.ParticionArea = Zona;
                                if (Horario != null)
                                {
                                    if (ClienteEvento.Codigo.Contains("OP") || ClienteEvento.Codigo.Contains("CL") || ClienteEvento.Codigo.Contains("OR") || ClienteEvento.Codigo.Contains("CR"))
                                    {

                                        TimeSpan Inicial = new TimeSpan();
                                        TimeSpan Final = new TimeSpan();
                                        TimeSpan H = new TimeSpan(fecha.Hour, fecha.Minute, fecha.Second);
                                        if (fecha.ToString("dddd", CI) == "lunes")
                                        {
                                            Inicial = new TimeSpan(Horario.LunesInicio.Value.Hours, Horario.LunesInicio.Value.Minutes, Horario.LunesInicio.Value.Seconds);
                                            Final = new TimeSpan(Horario.LunesFinal.Value.Hours, Horario.LunesFinal.Value.Minutes, Horario.LunesFinal.Value.Seconds);
                                        }
                                        if (fecha.ToString("dddd", CI) == "martes")
                                        {
                                            Inicial = new TimeSpan(Horario.MartesInicio.Value.Hours, Horario.MartesInicio.Value.Minutes, Horario.MartesInicio.Value.Seconds);
                                            Final = new TimeSpan(Horario.MartesFinal.Value.Hours, Horario.MartesFinal.Value.Minutes, Horario.MartesFinal.Value.Seconds);
                                        }
                                        if (fecha.ToString("dddd", CI) == "miercoles")
                                        {
                                            Inicial = new TimeSpan(Horario.MiercolesInicio.Value.Hours, Horario.MiercolesInicio.Value.Minutes, Horario.MiercolesInicio.Value.Seconds);
                                            Final = new TimeSpan(Horario.MiercolesFinal.Value.Hours, Horario.MiercolesFinal.Value.Minutes, Horario.MiercolesFinal.Value.Seconds);
                                        }
                                        if (fecha.ToString("dddd", CI) == "jueves")
                                        {
                                            Inicial = new TimeSpan(Horario.JuevesInicio.Value.Hours, Horario.JuevesInicio.Value.Minutes, Horario.JuevesInicio.Value.Seconds);
                                            Final = new TimeSpan(Horario.JuevesFinal.Value.Hours, Horario.JuevesFinal.Value.Minutes, Horario.JuevesFinal.Value.Seconds);
                                        }
                                        if (fecha.ToString("dddd", CI) == "viernes")
                                        {
                                            Inicial = new TimeSpan(Horario.ViernesInicio.Value.Hours, Horario.ViernesInicio.Value.Minutes, Horario.ViernesInicio.Value.Seconds);
                                            Final = new TimeSpan(Horario.ViernesFinal.Value.Hours, Horario.ViernesFinal.Value.Minutes, Horario.ViernesFinal.Value.Seconds);
                                        }
                                        if (fecha.ToString("dddd", CI) == "sabado")
                                        {
                                            Inicial = new TimeSpan(Horario.SabadoInicio.Value.Hours, Horario.SabadoInicio.Value.Minutes, Horario.SabadoInicio.Value.Seconds);
                                            Final = new TimeSpan(Horario.SabadoFinal.Value.Hours, Horario.SabadoFinal.Value.Minutes, Horario.SabadoFinal.Value.Seconds);
                                        }
                                        if (fecha.ToString("dddd", CI) == "domingo")
                                        {
                                            Inicial = new TimeSpan(Horario.DomingoInicio.Value.Hours, Horario.DomingoInicio.Value.Minutes, Horario.DomingoInicio.Value.Seconds);
                                            Final = new TimeSpan(Horario.DomingoFinal.Value.Hours, Horario.DomingoFinal.Value.Minutes, Horario.DomingoFinal.Value.Seconds);
                                        }
                                        if (H < Inicial || H > Final)
                                        {
                                            ClienteEventos horarioDesfasado = new ClienteEventos();
                                            horarioDesfasado.Codigo = "00";
                                            horarioDesfasado.Descripcion = "La alarma se activo/Desactivo fuera de sus horarios de operaciones";
                                            horarioDesfasado.Numero = "N/A";
                                            horarioDesfasado.ParticionArea = "N/A";
                                            horarioDesfasado.Tipo = "N/A";
                                            Eventos.Add(horarioDesfasado);
                                        }
                                    }
                                }
                                if (ClienteEvento.Tipo == "Sensor")
                                {
                                    if (clienteSensores.Where(x => x.NumeroDeSensor == clienteEventos.Numero).Any())
                                    {
                                        clienteEventos.Ubicacion = clienteSensores.Where(x => x.NumeroDeSensor == clienteEventos.Numero).First().Ubicacion;
                                    }
                                    else
                                    {
                                        clienteEventos.Ubicacion = "Ubicacion desconocidad";
                                    }
                                }
                                else if (ClienteEvento.Tipo == "Usuario")
                                {
                                    clienteEventos.Ubicacion = "N/A";
                                }
                                else
                                {
                                    clienteEventos.Ubicacion = "N/A";
                                }
                                clienteEventos.ParticionArea = Zona;
                            }
                            if (!ParticionZona)
                            {
                                Eventos.Add(clienteEventos);
                            }
                        }
                        bool IsOpen = false;
                        FormCollection forms = Application.OpenForms;
                        foreach (var form in forms)
                        {
                            if (((Form)form).Name == "ClienteAlerta")
                            {
                                if (((ClienteAlerta)form).IdI.Text == incidente.Id.ToString())
                                {
                                    IsOpen = true;
                                }
                            }
                        }
                        if (!IsOpen)
                        {
                            ClienteAlerta alerta = new ClienteAlerta(this.IdUsuario, incidente.Id);
                            db.UpdateIncidente(incidente.Id, incidente.IdCliente, incidente.IdLog, incidente.Comentarios, incidente.FechaHoraInicio, incidente.FechaHoraFin, "Pendiente", true, incidente.FechaCreacion, incidente.UsuarioCreacion);
                            alerta.setInfo(cliente, Log.Id);
                            alerta.setButton(this.Button_Badge, panel_Notificaciones);
                            alerta.setEventos(Eventos);
                            alerta.Text = "Alerta - Incidente sin seguimiento";
                            //form.MdiParent = this.MdiParent;
                            alerta.ShowDialog();
                        }

                    }
                    /**/
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:" + ex.Message + " Inner:" + ex.InnerException);
                }
            }
            Console.WriteLine("Termino");

            //*********************************************************************************
            //****************************** Dias sin Incidentes ******************************
            //*********************************************************************************
            try
            {
                List<Model.Clientes> Clients = db.Clientes.Where(x => x.Activo == true && x.NumeroTelefonoAlarma != null && x.NumeroDeCuenta != null).OrderBy(x => x.Nombres).ToList();
                List<LogMonitoreo360> Logs = db.LogMonitoreo360.ToList();
                foreach (var client in Clients.OrderBy(x => x.Nombres))
                {
                    foreach (var log in Logs)
                    {
                        var findLog = db.Incidentes.Where(x => x.IdLog == log.Id).Any();
                        if (!findLog)
                        {
                            string NumeroTelefono = log.Log.Substring(54, 6).Replace("-", "");
                            string NumeroCuenta = log.Log.Substring(61, 4);
                            Console.WriteLine(NumeroCuenta);
                            string f = log.Log.Substring(0, 20);
                            DateTime fecha = DateTime.Parse(f);
                            f = log.Log.Substring(23, 20).Replace("-", " ");
                            DateTime fecha2 = DateTime.Parse(f);
                            bool find = client.NumeroDeCuenta.Contains(NumeroCuenta) && client.NumeroTelefonoAlarma.Contains(NumeroTelefono);
                            Console.WriteLine("Lo encontro " + client.Nombres + "? " + find);
                            if (find != false)
                            {
                                List<ClienteEventos> Eventos = new List<ClienteEventos>();
                                var Days = (DateTime.Now - fecha2).Days;
                                if (Days >= 2)
                                {
                                    ClienteEventos Evento = new ClienteEventos();
                                    Evento.Codigo = "00";
                                    Evento.Descripcion = "El cliente lleva mas de " + Days + " dias sin llegar Algun evento";
                                    Evento.Numero = "N/A";
                                    Evento.ParticionArea = "N/A";
                                    Evento.Ubicacion = "N/A";
                                    Eventos.Add(Evento);
                                    Guid IdIncidente = Guid.NewGuid();
                                    db.InsertIncidentes(IdIncidente, client.IdCliente, log.Id, "", DateTime.Now, null, "Pendiente", true, DateTime.Now, this.IdUsuario);
                                    ClienteAlerta form = new ClienteAlerta(this.IdUsuario, IdIncidente);
                                    form.setInfo(client, log.Id);
                                    form.setEventos(Eventos);
                                    form.setButton(this.Button_Badge, this.panel_Notificaciones);
                                    //form.MdiParent = this.MdiParent;
                                    form.ShowDialog();
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message + " Inner:" + ex.InnerException);
            }
            this.timer.Start();
        }

        private void Button_Usuarios_Click(object sender, EventArgs e)
        {
            int width = this.panel_Content.Width;
            int height = this.panel_Content.Height;
            Button_Cadena.Enabled = true;
            this.panel_Content.Controls.Clear();
            Button_Clientes.Enabled = true;
            Button_Usuarios.Enabled = false;
            Button_Incidentes.Enabled = true;
            Button_Monitor.Enabled = true;
            Usuarios form = new Usuarios();
            form.Width = width - 40;
            form.Height = height - 40;
            form.Location = new Point(20, 20);
            form.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top;
            
            this.panel_Content.Controls.Add(form);
        }
    }
}

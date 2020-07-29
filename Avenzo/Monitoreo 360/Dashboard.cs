using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Model;

namespace Monitoreo_360
{
    public partial class Dashboard : MetroFramework.Forms.MetroForm
    {
        
        private readonly BackgroundWorker worker = new BackgroundWorker();
        private Guid Idusuario;
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        public Dashboard(Guid IdUsuario)
        {
            InitializeComponent();           
            this.Idusuario = IdUsuario;
            List<Model.Incidentes> Incidentes = new List<Model.Incidentes>();
            Incidentes = db.Incidentes.Where(x => x.Activo == true&&x.Estatus == "Pendiente").ToList();
            int y = 0;
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
                Bunifu.Framework.UI.BunifuThinButton2 Notificacion1 = new Bunifu.Framework.UI.BunifuThinButton2();
                Notificacion1.ActiveBorderThickness = 1;
                Notificacion1.ActiveCornerRadius = 20;
                Notificacion1.ActiveFillColor = System.Drawing.Color.SeaGreen;
                Notificacion1.ActiveForecolor = System.Drawing.Color.White;
                Notificacion1.ActiveLineColor = System.Drawing.Color.SeaGreen;
                Notificacion1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
                //Notificaci1on.BackgroundImage = ((System.Drawing.Image)(Resources.GetObject("Notificacion.BackgroundImage")));
                Notificacion1.ButtonText = incidente.Clientes.Nombres+" "+incidente.Clientes.ApellidoPaterno;
                Notificacion1.Cursor = System.Windows.Forms.Cursors.Hand;
                Notificacion1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Notificacion1.ForeColor = System.Drawing.Color.SeaGreen;
                Notificacion1.IdleBorderThickness = 1;
                Notificacion1.IdleCornerRadius = 20;
                Notificacion1.IdleFillColor = System.Drawing.Color.White;
                Notificacion1.IdleForecolor = System.Drawing.Color.SeaGreen;
                Notificacion1.IdleLineColor = System.Drawing.Color.SeaGreen;
                Notificacion1.Location = new System.Drawing.Point(0, y);
                Notificacion1.Margin = new System.Windows.Forms.Padding(5);
                Notificacion1.Name = incidente.Id.ToString();
                Notificacion1.Size = new System.Drawing.Size(203, 54);
                Notificacion1.TabIndex = 0;
                Notificacion1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                panel_Notificaciones.Controls.Add(Notificacion1);
                y += 56;
            }
        }
        
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cliente form3 = new Cliente(this.Idusuario);
            form3.MdiParent = this;
            form3.Show();
        }

        private void monitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Monitor_ form = new Monitor_();
            form.MdiParent = this;
            form.Show();
        }

        private void ingresarCadenaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadena_ form = new Cadena_(Idusuario,this.panel_Notificaciones,this.Button_Badge);
            form.MdiParent = this;
            form.Show();
        }

        
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void incidentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Incidentes_ form = new Incidentes_();
            form.MdiParent = this;
            form.setInfo(this.Idusuario);
            form.Show();
        }
        
        private void timer_Tick(object sender, EventArgs e)
        {

            this.timer.Stop();
            CultureInfo CI = new CultureInfo("es-MX");
            //*********************************************************************************
            //*************************** Incidentes Pendientes *******************************
            //*********************************************************************************
            List<Model.Incidentes> Incidentes = new List<Model.Incidentes>();
            Incidentes = db.Incidentes.Where(x => x.Activo == true && x.Estatus != "Completo"&&x.Estatus!="Pendiente").ToList();
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
                        foreach (var form in forms) {
                            if (((Form)form).Name == "ClienteAlerta") {
                                if (((ClienteAlerta)form).IdI.Text == incidente.Id.ToString()) {
                                    IsOpen = true;
                                }
                            }
                        }
                        if (!IsOpen) {
                            ClienteAlerta alerta = new ClienteAlerta(this.Idusuario, incidente.Id);
                            db.UpdateIncidente(incidente.Id, incidente.IdCliente, incidente.IdLog, incidente.Comentarios, incidente.FechaHoraInicio, incidente.FechaHoraFin, "Pendiente", true, incidente.FechaCreacion, incidente.UsuarioCreacion);
                            alerta.setInfo(cliente, Log.Id);
                            alerta.setButton(this.Button_Badge,panel_Notificaciones);
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
                            Console.WriteLine("Lo encontro "+client.Nombres+"? " +find);
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
                                    db.InsertIncidentes(IdIncidente, client.IdCliente, log.Id, "", DateTime.Now, null,"Pendiente", true, DateTime.Now, this.Idusuario);
                                    ClienteAlerta form = new ClienteAlerta(this.Idusuario, IdIncidente);
                                    form.setInfo(client, log.Id);
                                    form.setEventos(Eventos);
                                    form.setButton(this.Button_Badge,this.panel_Notificaciones);
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

        private void button_Notificaciones_hover(object sender, EventArgs e)
        {
            this.button_Notificaciones.Image = global::Monitoreo_360.Properties.Resources.Notification_48px_Blue;
        }

        private void button_Notificaciones_MouseLeave(object sender, EventArgs e)
        {
            this.button_Notificaciones.Image = global::Monitoreo_360.Properties.Resources.Notification__Gray_48px;
        }

        private void button_Notificaciones_Click(object sender, EventArgs e)
        {
            panel_Notificaciones.Visible = !panel_Notificaciones.Visible;
           
            
        }

        private void button_Badge_Click(object sender, EventArgs e)
        {

        }
    }
}

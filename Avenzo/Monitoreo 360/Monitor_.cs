using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Monitoreo_360.Models;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
namespace Monitoreo_360
{
    public partial class Monitor_ : MetroFramework.Forms.MetroForm
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        private readonly BackgroundWorker worker = new BackgroundWorker();
        public Monitor_()
        {
            InitializeComponent();
            SK_Cliente();
        }

        private static void SK_Cliente()
        {
            byte[] bytes = new byte[1024];
            try
            {
                //listening
                
                IPHostEntry iphost = Dns.GetHostEntry("DESKTOP-SRPL3UH");//192.168.0.254
                IPAddress ipAddress = IPAddress.Parse("192.168.0.200");//192.168.0.200 ip de receptora del moden al que esta conectada
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 1024);//aqui poner el puerto que se utiliza en la receptora 1024 o 69
                Socket sender = new Socket(ipAddress.AddressFamily,SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    sender.Connect(localEndPoint);
                    sender.Bind(localEndPoint);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error {0}",ex.ToString());
                }
                sender.Listen(1);//numeros de clientes permitidos
                //fin listening

                //Solicitudes
                Console.WriteLine("En espera de la conexion");
                Socket handler = sender.Accept();
                String data = null;
                while (true)
                {
                    byte [] bt = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf("<EOF>") > -1)
                    {
                        break;
                    }
                }

                try
                {
                    
                    Console.WriteLine("Text received : {0}", data);
                    Console.WriteLine("Socket conectado a {0}", sender.RemoteEndPoint.ToString());
                    byte[] msg = Encoding.ASCII.GetBytes(data);
                    handler.Send(msg);

                    handler.Receive(bytes);

                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Monitor_Load(object sender, EventArgs e)
        {
            List<Models.Clientes> Clientes = db.Clientes.Where(model => model.Activo == true && !string.IsNullOrEmpty(model.NumeroTelefonoAlarma)&&!string.IsNullOrEmpty(model.NumeroDeCuenta)).ToList();
            int width = this.panel_Clientes.Width;
            int ClientesRow = ((int)(width / 35));
            int x = 5; int y = 5;
            int count = 0;
            foreach (var cliente in Clientes.OrderBy(model => model.Nombres))
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monitor_));
                Button buttonStatus = new Button();
                buttonStatus.BackColor = System.Drawing.Color.LightGray;
                //buttonStatus.Image = ((System.Drawing.Image)(resources.GetObject(cliente.NumeroDeCuenta + ".Image")));
                //buttonStatus.ImageActive = null;
                buttonStatus.Location = new System.Drawing.Point(x, y);
                buttonStatus.Name = cliente.NumeroDeCuenta;
                buttonStatus.Text = cliente.NumeroDeCuenta;
                buttonStatus.FlatStyle = FlatStyle.Flat;
                buttonStatus.Font = new System.Drawing.Font("Century Gothic",5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));                
                buttonStatus.Size = new System.Drawing.Size(30, 30);
                buttonStatus.Anchor = (AnchorStyles.Top & AnchorStyles.Bottom & AnchorStyles.Right&AnchorStyles.Left);
                //buttonStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                buttonStatus.TabIndex = 3;
                buttonStatus.TabStop = false;
                //buttonStatus.Zoom = 10;
                buttonStatus.Click += new EventHandler(buttonStatus_Click);
                this.panel_Clientes.Controls.Add(buttonStatus);                
                this.panel_Clientes.Location = new System.Drawing.Point(20, 60);
                this.panel_Clientes.Name = "panel_" + cliente.NumeroDeCuenta;                
                this.panel_Clientes.TabIndex = 1;
                
                List<LogMonitoreo360> logs = db.LogMonitoreo360.Where(model => cliente.NumeroDeCuenta.Contains(model.Log.Substring(61, 4)) && cliente.NumeroTelefonoAlarma.Contains(model.Log.Substring(54, 6).Replace("-", ""))).ToList();
                foreach (var log in logs.OrderBy(model => model.FechaCreacion))
                {
                    string report = log.Log.Substring(66, log.Log.Length - 66);
                    string[] eventos = report.Split('-')[1].Split('/');
                    if (eventos.Count() > 1)
                    {
                        List<CodigoEventos> CodigosEventos = db.CodigoEventos.ToList();
                        foreach (var evento in eventos)
                        {
                            if (evento.Substring(0, 2).Contains("OP"))
                            {
                                buttonStatus.BackColor = System.Drawing.Color.SeaGreen;
                                
                            }
                            else if (evento.Substring(0, 2).Contains("CL"))
                            {
                                buttonStatus.BackColor = System.Drawing.Color.GreenYellow;
                                
                            }
                            else if (evento.Substring(0, 2).Contains("CR"))
                            {
                                buttonStatus.BackColor = System.Drawing.Color.IndianRed;
                                
                            }
                            else if (evento.Substring(0, 2).Contains("OR"))
                            {
                                buttonStatus.BackColor = System.Drawing.Color.BlueViolet;
                                
                            }
                        }
                    }
                }
                x = x + 35;
                count = count + 1;
                if ((x+30)>width )
                {
                    y = y +  35;
                    x = 5;
                    count = 0;
                }
            }
        }

        private void buttonStatus_Click(object sender, EventArgs e)
        {
            Button button = ((Button)sender);
            Models.Clientes cliente = db.Clientes.Where(x=>x.NumeroDeCuenta==button.Name).FirstOrDefault();
            ClienteInfo form = new ClienteInfo();
            form.Text = "Cliente " + cliente.Nombres + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
            form.setInfo(cliente);
            form.ShowDialog();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.timer.Stop();
            CultureInfo CI = new CultureInfo("es-MX");
            List<Models.Clientes> Clientes = db.Clientes.Where(model => model.Activo == true && !string.IsNullOrEmpty(model.NumeroTelefonoAlarma) && !string.IsNullOrEmpty(model.NumeroDeCuenta)).ToList();            
            foreach (var cliente in Clientes.OrderBy(model => model.Nombres))
            {
                List<LogMonitoreo360> logs = db.LogMonitoreo360.Where(model => cliente.NumeroDeCuenta.Contains(model.Log.Substring(61, 4)) && cliente.NumeroTelefonoAlarma.Contains(model.Log.Substring(54, 6).Replace("-", ""))).ToList();
                foreach (var log in logs.OrderBy(model => model.FechaCreacion))
                {
                    string report = log.Log.Substring(66, log.Log.Length - 66);
                    string[] eventos = report.Split('-')[1].Split('/');
                    if (eventos.Count() > 1)
                    {
                        List<CodigoEventos> CodigosEventos = db.CodigoEventos.ToList();
                        foreach (var evento in eventos)
                        {
                            if (evento.Substring(0, 2).Contains("OP"))
                            {
                                foreach (Control button in this.panel_Clientes.Controls)
                                {          
                                    if (button.Name == cliente.NumeroDeCuenta)
                                        ((Button)button).BackColor = System.Drawing.Color.SeaGreen;
                                }
                            }
                            else if (evento.Substring(0, 2).Contains("CL")) {
                                foreach (Control button in this.panel_Clientes.Controls)
                                {   
                                    if (button.Name == cliente.NumeroDeCuenta)
                                        button.BackColor = System.Drawing.Color.YellowGreen;
                                }
                            }
                            else if (evento.Substring(0, 2).Contains("CR"))
                            {
                                foreach (Control button in this.panel_Clientes.Controls)
                                {   
                                    if (button.Name ==cliente.NumeroDeCuenta)
                                        button.BackColor = System.Drawing.Color.IndianRed;                                        
                                }
                            }
                            else if (evento.Substring(0, 2).Contains("OR"))
                            {
                                foreach (Control button in this.panel_Clientes.Controls)
                                {
                                    if (button.Name ==cliente.NumeroDeCuenta)
                                        button.BackColor = System.Drawing.Color.BlueViolet;                                       
                                }
                            }                            
                        }
                    }
                }
            }
            //*********************************************************************************
            //******************************** Fuera de horario *******************************
            //*********************************************************************************

            List<HorarioOperaciones> horarios = db.HorarioOperaciones.ToList();
            DateTime now = DateTime.Now;
            TimeSpan Hora = new TimeSpan(now.Hour, now.Minute, now.Second);
            foreach (var horario in horarios)
            {
                Models.Clientes cliente = db.Clientes.Where(x => x.IdCliente == horario.IdCliente).FirstOrDefault();
                List<LogMonitoreo360> logs = db.LogMonitoreo360.Where(model => cliente.NumeroDeCuenta.Contains(model.Log.Substring(61, 4)) && cliente.NumeroTelefonoAlarma.Contains(model.Log.Substring(54, 6).Replace("-", ""))).OrderBy(x => x.FechaCreacion).ToList();
                foreach (var log in logs)
                {
                    string f = log.Log.Substring(0, 20);
                    DateTime fecha = DateTime.Parse(f);
                    f = log.Log.Substring(23, 20).Replace("-", " ");
                    DateTime fecha2 = DateTime.Parse(f);
                    string report = log.Log.Substring(66, log.Log.Length - 66);
                    string[] eventos = report.Split('-')[1].Split('/');
                    Console.WriteLine(fecha.Day + "==" + now.Day + "&&" + fecha.Month + "==" + now.Month + "&&" + fecha.Year + "==" + now.Year);                    
                    if (fecha.Day == now.Day && fecha.Month == now.Month && fecha.Year == now.Year)
                    {
                        foreach (var evento in eventos)
                        {
                            if (evento.Substring(0, 2).Contains("OP")|| evento.Substring(0, 2).Contains("OR")||evento.Substring(0, 2).Contains("CR")|| evento.Substring(0, 2).Contains("CL")) {
                                Console.WriteLine(fecha.ToString("dddd", new CultureInfo("es-MX")));
                                if (fecha.ToString("dddd", CI) == "lunes")
                                {
                                    if (Hora < horario.LunesInicio || Hora > horario.LunesFinal)
                                    {
                                        foreach (Control button in this.panel_Clientes.Controls)
                                        {
                                          if (button.Name == "button_Estatus_" + cliente.NumeroDeCuenta)
                                            ((Button)button).BackColor = System.Drawing.Color.IndianRed;
                                            
                                        }
                                    }
                                }
                                if (fecha.ToString("dddd", CI) == "martes")
                                {
                                    if (Hora < horario.MartesInicio || Hora > horario.MartesFinal)
                                    {
                                        foreach (Control button in this.panel_Clientes.Controls)
                                        {                                            
                                            if (button.Name == cliente.NumeroDeCuenta)
                                                ((Button)button).BackColor = System.Drawing.Color.IndianRed;                                             
                                        }
                                    }
                                }
                                if (fecha.ToString("dddd", CI) == "miercoles")
                                {
                                    if (Hora < horario.MiercolesInicio || Hora > horario.MiercolesFinal)
                                    {
                                        foreach (Control button in this.panel_Clientes.Controls)
                                        {
                                            if (button.Name == cliente.NumeroDeCuenta)
                                                ((Button)button).BackColor = System.Drawing.Color.IndianRed;
                                        }
                                    }
                                }
                                if (fecha.ToString("dddd", CI) == "jueves")
                                {
                                    if (Hora < horario.JuevesInicio || Hora > horario.JuevesFinal)
                                    {
                                        foreach (Control button in this.panel_Clientes.Controls)
                                        {
                                            if (button.Name == cliente.NumeroDeCuenta)
                                                ((Button)button).BackColor = System.Drawing.Color.IndianRed;
                                        }
                                    }
                                }
                                if (fecha.ToString("dddd", CI) == "viernes")
                                {
                                    if (Hora < horario.ViernesInicio || Hora > horario.ViernesFinal)
                                    {
                                        foreach (Control button in this.panel_Clientes.Controls)
                                        {
                                            if (button.Name ==cliente.NumeroDeCuenta)
                                                ((Button)button).BackColor = System.Drawing.Color.IndianRed;                                               
                                        }
                                    }
                                }
                                if (fecha.ToString("dddd", CI) == "sabado")
                                {
                                    if (Hora < horario.SabadoInicio || Hora > horario.SabadoFinal)
                                    {
                                        foreach (Control button in this.panel_Clientes.Controls)
                                        {   
                                            if (button.Name == cliente.NumeroDeCuenta)
                                                ((Button)button).BackColor = System.Drawing.Color.IndianRed;                                                
                                        }
                                    }
                                }
                                if (fecha.ToString("dddd", CI) == "domingo")
                                {
                                    if (Hora < horario.DomingoInicio || Hora > horario.DomingoFinal)
                                    {
                                        foreach (Control button in this.panel_Clientes.Controls)
                                        {                                            
                                            if (button.Name == cliente.NumeroDeCuenta)
                                                ((Button)button).BackColor = System.Drawing.Color.IndianRed;                                               
                                        }
                                    }
                                }
                            }
                        }                        
                    }
                }
            }
            this.timer.Start();
        }
    }
}

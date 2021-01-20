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
using System.Threading;
using System.Web.Http.Controllers;

namespace Monitoreo_360
{
    public partial class Monitor_ : MetroFramework.Forms.MetroForm
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        //private readonly BackgroundWorker worker = new BackgroundWorker();
        delegate void setMaximunD(int max);
        delegate void setDataList(Models.Clientes cliente);
        delegate void setVisiblePanel(bool visible);
        private int x = 5; int y = 5;
        private int count = 0;
        private int width = 0;
        private int ClientesRow = 0;
        Guid IdUsuario;
        Panel panel;
        System.Windows.Forms.Button Button;

        public Monitor_(Guid IdUsuario, Panel panel, System.Windows.Forms.Button Button)
        {
            InitializeComponent();
            this.ProgressBar.Value = 5;
         //   SK_Cliente();
            Data();
            this.IdUsuario = IdUsuario;
            
        }
 

        #region carga de datos
        public async void Data()
        {
            await Task.Run(() =>
            {
                x = 5;
                y = 5;
                count = 0;
                width = this.panel_Clientes.Width;
                ClientesRow = ((int)(width / 35));
                var finallyDB = getData();
                if (finallyDB)
                    setVisibleDataPanel(true);
            });
        }
        public bool getData()
        {
            List<Models.Clientes> clientes = new List<Models.Clientes>();

            clientes = db.Clientes.Where(model => model.Activo == true && !string.IsNullOrEmpty(model.NumeroTelefonoAlarma) && !string.IsNullOrEmpty(model.NumeroDeCuenta)).ToList();
            // this.ProgressBar.Maximum = clientes.Count() + 5;
            int max = clientes.Count() + 5;
            setMaximo(max);
            foreach (var cliente in clientes)
            {
                setDataPanel(cliente);
            }
            return true;
        }
        public void setMaximo(int max)
        {
            if (panel_Clientes.InvokeRequired)
            {
                setMaximunD d = new setMaximunD(setMaximo);
                this.Invoke(d, new object[] { max });
            }
            else
            {
                ProgressBar.Maximum = max;
            }
        }
        public void setVisibleDataPanel(bool visible)
        {
            if (panel_Clientes.InvokeRequired)
            {
                setVisiblePanel d = new setVisiblePanel(setVisibleDataPanel);
                this.Invoke(d, new object[] { visible });
                IngresarCadena("29 Jan 2018 11:28:41   29 Jan 2018-11:28:40-01/01-SG -81-459-0163--Nri0/RR0000 - Acknowledged by User 00");
            }
            else
            {
                this.panel_Clientes.Visible = visible;
                ProgressBar.Visible = !visible;
            }
        }
        public void setDataPanel(Models.Clientes cliente)
        {
            if (panel_Clientes.InvokeRequired)
            {
                setDataList d = new setDataList(setDataPanel);
                try
                {
                    this.Invoke(d, new object[] { cliente });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

            }
            else
            {
                this.ProgressBar.Value += 1;
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monitor_));
                Button buttonStatus = new Button();
                buttonStatus.BackColor = System.Drawing.Color.LightGray;
                buttonStatus.Location = new System.Drawing.Point(x, y);
                buttonStatus.Name = cliente.NumeroDeCuenta;
                buttonStatus.Text = cliente.NumeroDeCuenta;
                buttonStatus.FlatStyle = FlatStyle.Flat;
                buttonStatus.Font = new System.Drawing.Font("Century Gothic", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                buttonStatus.Size = new System.Drawing.Size(30, 30);
                buttonStatus.Anchor = (AnchorStyles.Top & AnchorStyles.Bottom & AnchorStyles.Right & AnchorStyles.Left);
                buttonStatus.TabIndex = 3;
                buttonStatus.TabStop = false;
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
                if ((x + 30) > width)
                {
                    y = y + 35;
                    x = 5;
                    count = 0;
                }
            }
        }
        #endregion
        #region Socket
        private void SK_Cliente()
        {
            string server = "192.168.0.200";
            Int32 port = 1027;
            string message = string.Empty;
            try
            {
                while (true)
                {
                    //Se establce conexion
                    TcpClient client = new TcpClient(server, port);

                    // traduce el mensaje en un array
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes("Input\n");

                    NetworkStream stream = client.GetStream();

                    data = new Byte[256];

                    // string para guardar mensaje ascii
                    String responseData = string.Empty;

                    // Lee el mensaje y sentraduce
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    
                    if (responseData.Length>30)
                    {
                        IngresarCadena(responseData);
                    }
                    stream.Close();
                    client.Close();
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
   
        }
        public void IngresarCadena(string Data)
        {
            if (Data.Length > 30)
            {
                try
                {
                    string f = Data.Substring(0, 20);
                    DateTime fecha = DateTime.Parse(f);
                    f = Data.Substring(23, 20).Replace("-", " ");
                    DateTime fecha2 = DateTime.Parse(f);
                    string NumeroTelefono = Data.Substring(54, 6).Replace("-", "");
                    string NumeroCuenta = Data.Substring(61, 4);
                    string report = Data.Substring(66, Data.Length - 66);
                    string[] eventos = report.Split('-')[1].Split('/');
                    Models.Clientes cliente = db.Clientes.Where(x => x.NumeroDeCuenta.Contains(NumeroCuenta) && x.NumeroTelefonoAlarma.Contains(NumeroTelefono)).FirstOrDefault();
                    bool ParticionZona = false;
                    List<ClienteEventos> Eventos = new List<ClienteEventos>();
                    string Zona = "1";
                    if (cliente != null)
                    {
                        if (eventos.Count() > 1)
                        {
                            List<GetSensores_Result> clienteSensores = db.GetSensores(cliente.IdCliente, 2).ToList();
                            GetHorarioOperaciones_Result Horario = db.GetHorarioOperaciones(cliente.IdCliente).FirstOrDefault();
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
                                            if (fecha.ToString("dddd", new CultureInfo("es-MX")) == "lunes")
                                            {
                                                Inicial = new TimeSpan(Horario.LunesInicio.Value.Hours, Horario.LunesInicio.Value.Minutes, Horario.LunesInicio.Value.Seconds);
                                                Final = new TimeSpan(Horario.LunesFinal.Value.Hours, Horario.LunesFinal.Value.Minutes, Horario.LunesFinal.Value.Seconds);
                                            }
                                            if (fecha.ToString("dddd", new CultureInfo("es-MX")) == "martes")
                                            {
                                                Inicial = new TimeSpan(Horario.MartesInicio.Value.Hours, Horario.MartesInicio.Value.Minutes, Horario.MartesInicio.Value.Seconds);
                                                Final = new TimeSpan(Horario.MartesFinal.Value.Hours, Horario.MartesFinal.Value.Minutes, Horario.MartesFinal.Value.Seconds);
                                            }
                                            if (fecha.ToString("dddd", new CultureInfo("es-MX")) == "miercoles")
                                            {
                                                Inicial = new TimeSpan(Horario.MiercolesInicio.Value.Hours, Horario.MiercolesInicio.Value.Minutes, Horario.MiercolesInicio.Value.Seconds);
                                                Final = new TimeSpan(Horario.MiercolesFinal.Value.Hours, Horario.MiercolesFinal.Value.Minutes, Horario.MiercolesFinal.Value.Seconds);
                                            }
                                            if (fecha.ToString("dddd", new CultureInfo("es-MX")) == "jueves")
                                            {
                                                Inicial = new TimeSpan(Horario.JuevesInicio.Value.Hours, Horario.JuevesInicio.Value.Minutes, Horario.JuevesInicio.Value.Seconds);
                                                Final = new TimeSpan(Horario.JuevesFinal.Value.Hours, Horario.JuevesFinal.Value.Minutes, Horario.JuevesFinal.Value.Seconds);
                                            }
                                            if (fecha.ToString("dddd", new CultureInfo("es-MX")) == "viernes")
                                            {
                                                Inicial = new TimeSpan(Horario.ViernesInicio.Value.Hours, Horario.ViernesInicio.Value.Minutes, Horario.ViernesInicio.Value.Seconds);
                                                Final = new TimeSpan(Horario.ViernesFinal.Value.Hours, Horario.ViernesFinal.Value.Minutes, Horario.ViernesFinal.Value.Seconds);
                                            }
                                            if (fecha.ToString("dddd", new CultureInfo("es-MX")) == "sabado")
                                            {
                                                Inicial = new TimeSpan(Horario.SabadoInicio.Value.Hours, Horario.SabadoInicio.Value.Minutes, Horario.SabadoInicio.Value.Seconds);
                                                Final = new TimeSpan(Horario.SabadoFinal.Value.Hours, Horario.SabadoFinal.Value.Minutes, Horario.SabadoFinal.Value.Seconds);
                                            }
                                            if (fecha.ToString("dddd", new CultureInfo("es-MX")) == "domingo")
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
                            //this.TextBox_Log.AppendText(this.textBox1.Text + Environment.NewLine);
                            Guid IdLog = Guid.NewGuid();
                            db.InsertLogMonitoreo360(IdLog, Data, Guid.Parse("8BEAD89F-B0CA-4CA9-9268-4DE6C727E3A2"), DateTime.Now);
                            Data = String.Empty;
                            Guid IdIncidente = Guid.NewGuid();
                            ClienteAlerta form = new ClienteAlerta(IdUsuario, IdIncidente);
                            form.setInfo(cliente, IdLog);
                            db.InsertIncidentes(IdIncidente, cliente.IdCliente, IdLog, "", DateTime.Now, null, null, true, DateTime.Now, Guid.Parse("8BEAD89F-B0CA-4CA9-9268-4DE6C727E3A2"));
                            form.setEventos(Eventos);
                            form.setButton(this.Button, this.panel);

                            form.ShowDialog();

                        }
                    }
                }
                catch (Exception ex)
                {
                    //textBox1.Text = "";
                    MetroFramework.MetroMessageBox.Show(this, "Error en el formato del texto:\n" + ex.Message + "\n" + ex.InnerException, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 200);
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Caracteres insuficientes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 200);
            }
        }
        #endregion
        #region Boton
        private void buttonStatus_Click(object sender, EventArgs e)
        {
            Button button = ((Button)sender);
            Models.Clientes cliente = db.Clientes.Where(x => x.NumeroDeCuenta == button.Name).FirstOrDefault();
            ClienteInfo form = new ClienteInfo();
            form.Text = "Cliente " + cliente.Nombres + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
            form.setInfo(cliente);
            form.ShowDialog();
        }
        #endregion
        #region timer
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
                            else if (evento.Substring(0, 2).Contains("CL"))
                            {
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
                                    if (button.Name == cliente.NumeroDeCuenta)
                                        button.BackColor = System.Drawing.Color.IndianRed;
                                }
                            }
                            else if (evento.Substring(0, 2).Contains("OR"))
                            {
                                foreach (Control button in this.panel_Clientes.Controls)
                                {
                                    if (button.Name == cliente.NumeroDeCuenta)
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
                            if (evento.Substring(0, 2).Contains("OP") || evento.Substring(0, 2).Contains("OR") || evento.Substring(0, 2).Contains("CR") || evento.Substring(0, 2).Contains("CL"))
                            {
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
                                            if (button.Name == cliente.NumeroDeCuenta)
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
        #endregion

        private void Monitor__FormClosed(object sender, FormClosedEventArgs e)
        {
            setDataList d = new setDataList(setDataPanel);
            this.Dispose();
        }

     
    }
}

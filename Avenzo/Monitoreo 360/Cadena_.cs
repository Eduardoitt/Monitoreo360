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
using Monitoreo_360.Models;


namespace Monitoreo_360
{
    public partial class Cadena_ : MetroFramework.Forms.MetroForm
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        Panel panel;
        System.Windows.Forms.Button Button;
        //delegate void setDataList(string log);
        delegate void setVisiblePanel(bool visible);
        delegate void setDataTextBox(string log);
        Guid IdUsuario;
        public Cadena_(Guid IdUsuario,Panel panel, System.Windows.Forms.Button Button)
        {
            InitializeComponent();
            this.panel = panel;
            this.Button = Button;
            data();
            this.IdUsuario = IdUsuario;
        }
        async void data() {
            await Task.Run(() => {
                var finallyDB = GetData();
                if (finallyDB)
                    setVisiblePanelA(true);
            });
        }
        public void setVisiblePanelA(bool visible) {
            if (panel1.InvokeRequired) {
                setVisiblePanel d = new setVisiblePanel(setVisiblePanelA);
                this.Invoke(d, new object[] { visible});
            }
            else
            {
                TextBox_Log.Visible = visible;
                metroProgressSpinner.Visible = !visible;
                panel1.Visible = visible;
            }
            
        }
        public bool GetData()
        {
            List<LogMonitoreo360> logs = db.LogMonitoreo360.OrderBy(x => x.FechaCreacion).OrderByDescending(x => x.FechaCreacion).Take(50).ToList();
            foreach (var log in logs.OrderBy(x=>x.FechaCreacion))
            {
                setTextBoxLog(log.Log);
            }
            return true;
        }
        public void setTextBoxLog(string Log) {
            if (TextBox_Log.InvokeRequired)
            {
                setDataTextBox d = new setDataTextBox(setTextBoxLog);
                this.Invoke(d, new object[] { Log });
            }
            else
            {
                TextBox_Log.Text += Log+Environment.NewLine;                
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length>30)
            {
                try
                {
                    string f = this.textBox1.Text.Substring(0, 20);
                    DateTime fecha = DateTime.Parse(f);
                    f = this.textBox1.Text.Substring(23, 20).Replace("-", " ");
                    DateTime fecha2 = DateTime.Parse(f);
                    string NumeroTelefono = this.textBox1.Text.Substring(54, 6).Replace("-", "");
                    string NumeroCuenta = this.textBox1.Text.Substring(61, 4);
                    string report = this.textBox1.Text.Substring(66, this.textBox1.Text.Length - 66);
                    string[] eventos = report.Split('-')[1].Split('/');
                    Models.Clientes cliente = db.Clientes.Where(x => x.NumeroDeCuenta.Contains(NumeroCuenta) && x.NumeroTelefonoAlarma.Contains(NumeroTelefono)).FirstOrDefault();
                    bool ParticionZona = false;
                    List<ClienteEventos> Eventos = new List<ClienteEventos>();
                    string Zona = "1";
                    if (cliente!=null) {
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
                                    if (Horario != null) {
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
                            this.TextBox_Log.AppendText(this.textBox1.Text + Environment.NewLine);
                            Guid IdLog = Guid.NewGuid();
                            db.InsertLogMonitoreo360(IdLog, this.textBox1.Text, Guid.Parse("8BEAD89F-B0CA-4CA9-9268-4DE6C727E3A2"), DateTime.Now);
                            this.textBox1.Text = "";
                            Guid IdIncidente = Guid.NewGuid();
                            ClienteAlerta form = new ClienteAlerta(IdUsuario,IdIncidente);
                            form.setInfo(cliente, IdLog);
                            db.InsertIncidentes(IdIncidente, cliente.IdCliente, IdLog, "", DateTime.Now, null, null, true, DateTime.Now, Guid.Parse("8BEAD89F-B0CA-4CA9-9268-4DE6C727E3A2"));
                            form.setEventos(Eventos);
                            form.setButton(this.Button,this.panel);
                            //form.MdiParent = this.MdiParent;
                            form.ShowDialog();
                            //ClienteInfo form = new ClienteInfo();
                            /*form.MdiParent = this.MdiParent;
                            form.Show();
                            form.setInfo(cliente);
                            form.setEventos(Eventos);*/
                        }
                    }
                }
                catch (Exception ex)
                {
                    textBox1.Text = "";
                    MetroFramework.MetroMessageBox.Show(this, "Error en el formato del texto:\n"+ex.Message+"\n"+ex.InnerException,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1,200);
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Caracteres insuficientes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 200);
            }
        }

        private void textBox1_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter||e.KeyCode==Keys.Return) {
                button1_Click(sender, null);
            }
        }
    }
}

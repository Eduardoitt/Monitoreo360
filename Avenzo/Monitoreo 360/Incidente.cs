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
    public partial class Incidente : MetroFramework.Forms.MetroForm
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        public Incidente(Model.Incidentes incidentes)
        {
            InitializeComponent();
            this.TextBox_Comentarios.Text = incidentes.Comentarios;
            this.label_NumeroDeCuenta.Text = incidentes.Clientes.NumeroDeCuenta;
            this.label_Nombres.Text = incidentes.Clientes.Nombres + " "+incidentes.Clientes.ApellidoPaterno+" "+incidentes.Clientes.ApellidoMaterno;
            this.label_TelefonoAlarma.Text = incidentes.Clientes.NumeroTelefonoAlarma;
            this.label_Telefono.Text = incidentes.Clientes.Telefono;
            this.label_Correo.Text = incidentes.Clientes.Email;
            this.label_FechaCreation.Text = incidentes.Clientes.FechaCreacion.ToString();
            this.label_PalabraClave.Text = incidentes.Clientes.PalabraClave;
            this.label_PalabraClaveSilenciosa.Text = incidentes.Clientes.PalabraClaveSilenciosa;
            this.label_ColorEstablecimiento.Text = incidentes.Clientes.ColorEstablecimiento;
            this.label_Colonia.Text = "Col. " + incidentes.Clientes.Colonia + ", Calle " + incidentes.Clientes.Calle;
            this.label_NoInterior.Text= " No Interior " + incidentes.Clientes.NoInterior + " No Exterior " + incidentes.Clientes.NoExterior;
            this.label_Entre_Calles.Text = incidentes.Clientes.EntreCalles;
            List<ClienteContactos> contactos = db.GetClienteContactos(2, incidentes.Clientes.IdCliente).ToList();
            foreach (var contacto in contactos.OrderBy(x => x.Prioridad))
            {
                ReporteLlamada llamada = db.ReporteLlamada.Where(x=>x.IdClienteContacto==contacto.Id).FirstOrDefault();
                var n = dataGridView_Contactos.Rows.Add();
                this.dataGridView_Contactos.Rows[n].Cells[0].Value = contacto.Id;
                this.dataGridView_Contactos.Rows[n].Cells[1].Value = contacto.Prioridad;
                this.dataGridView_Contactos.Rows[n].Cells[2].Value = contacto.Nombre;
                this.dataGridView_Contactos.Rows[n].Cells[3].Value = "";
                this.dataGridView_Contactos.Rows[n].Cells[4].Value = contacto.Telefono;
                if (llamada != null) {
                    this.dataGridView_Contactos.Rows[n].Cells[5].Value = llamada.Estatus;
                    this.dataGridView_Contactos.Rows[n].Cells[6].Value = llamada.Comentarios;
                    this.dataGridView_Contactos.Rows[n].Cells[7].Value = llamada.UsuarioCreacion;
                }                
            }
            LogMonitoreo360 log = db.LogMonitoreo360.Where(x=>x.Id==incidentes.IdLog).FirstOrDefault();
            string f = log.Log.Substring(0, 20);
            DateTime fecha = DateTime.Parse(f);
            f = log.Log.Substring(23, 20).Replace("-", " ");
            DateTime fecha2 = DateTime.Parse(f);
            string report = log.Log.Substring(66, log.Log.Length - 66);
            string[] eventos = report.Split('-')[1].Split('/');
            bool ParticionZona = false;
            List<ClienteEventos> Eventos = new List<ClienteEventos>();
            string Zona = "1";
            if (eventos.Count() > 1)
            {
                List<Sensores> clienteSensores = db.GetSensores(incidentes.Clientes.IdCliente, 2).ToList();
                HorarioOperaciones Horario = db.GetHorarioOperaciones(incidentes.Clientes.IdCliente).FirstOrDefault();
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
                            CultureInfo CI = new CultureInfo("es-MX");
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
                foreach (var e in Eventos) {
                    var n = dataGridView_Eventos.Rows.Add();
                    dataGridView_Eventos.Rows[n].Cells[0].Value = e.Codigo;
                    dataGridView_Eventos.Rows[n].Cells[1].Value = e.Descripcion;
                    if (e.Tipo == "Usuario")
                    {
                        dataGridView_Eventos.Rows[n].Cells[2].Value = e.Numero;
                        dataGridView_Eventos.Rows[n].Cells[3].Value = "N/A";
                    }
                    else if (e.Tipo == "Sensor")
                    {
                        dataGridView_Eventos.Rows[n].Cells[3].Value = e.Numero;
                        dataGridView_Eventos.Rows[n].Cells[2].Value = "N/A";
                    }
                    else
                    {
                        dataGridView_Eventos.Rows[n].Cells[3].Value = "N/A";
                        dataGridView_Eventos.Rows[n].Cells[2].Value = "N/A";
                    }
                    dataGridView_Eventos.Rows[n].Cells[4].Value = e.Ubicacion;
                    dataGridView_Eventos.Rows[n].Cells[5].Value = e.ParticionArea;
                }
            }
        }
    }
}

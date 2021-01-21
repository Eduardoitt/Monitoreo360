using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using FireSharp;
using FireSharp.Extensions;
using FireSharp.Interfaces;
using FireSharp.Response;
using Google.Apis.Auth.OAuth2;
using Monitoreo_360.Models;
using Monitoreo_360.ClasesFirebase;

namespace Monitoreo_360
{
    public partial class ClienteAlerta : MetroFramework.Forms.MetroForm
    {
        private AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        private SoundPlayer player = new SoundPlayer();
        private Firebase.Auth.User User;
        private FirebaseAuthLink Auth;
        private System.Windows.Forms.Button Button;
        private Guid IdIncidente = Guid.NewGuid();
        Models.Clientes cliente = new Models.Clientes();
        DateTime TiempoInicio;
        Panel panel;
        Guid IdUsuario;
        private bool close = false;
        int y = 48;
        public ClienteAlerta(Guid IdUsuario,Guid IdIncidente)
        {
            if (this.InvokeRequired) {
                this.Close();
            }
            else { 
                InitializeComponent();
                this.IdUsuario = IdUsuario;
                this.IdIncidente = IdIncidente;
                TiempoInicio = DateTime.Now;
            }
        }

        public void setInfo(Models.Clientes cliente, Guid IdLog)
        {
            
            this.cliente = cliente;
            IdI.Text = this.IdIncidente.ToString();
            label_NumeroDeCuenta.Text = cliente.NumeroDeCuenta;
            label_TelefonoAlarma.Text = cliente.NumeroTelefonoAlarma;
            label_Telefono.Text = cliente.Telefono;
            label_Nombres.Text = cliente.Nombres + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
            label_Colonia.Text = "Col. " + cliente.Colonia + ", Calle " + cliente.Calle;
            label_NoInterior.Text = " No Interior " + cliente.NoInterior + " No Exterior " + cliente.NoExterior;
            label_Entre_Calles.Text = cliente.EntreCalles;
            label_Correo.Text = cliente.Email;
            label_PalabraClave.Text = cliente.PalabraClave;
            label_PalabraClaveSilenciosa.Text = cliente.PalabraClaveSilenciosa;
            label_ColorEstablecimiento.Text = cliente.ColorEstablecimiento;
            label_FechaCreation.Text = cliente.FechaCreacion.ToString();
            VerifyAsync(cliente.NumeroDeCuenta + "@avenzo.mx", cliente.NumeroDeCuenta);
            List<GetClienteContactos_Result> contactos = db.GetClienteContactos(2, cliente.IdCliente).ToList();
            foreach (var contacto in contactos.OrderBy(x => x.Prioridad))
            {
                var n = dataGridView_Contactos.Rows.Add();
                this.dataGridView_Contactos.Rows[n].Cells[0].Value = contacto.Id;
                this.dataGridView_Contactos.Rows[n].Cells[1].Value = contacto.Prioridad;
                this.dataGridView_Contactos.Rows[n].Cells[2].Value = contacto.Nombre;
                this.dataGridView_Contactos.Rows[n].Cells[3].Value = "";
                this.dataGridView_Contactos.Rows[n].Cells[4].Value = contacto.Telefono;
            }
            if (!string.IsNullOrEmpty(cliente.GoogleMaps))
            {
                var t = new Thread(setBrowseMap);
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
        }
        public void setButton(System.Windows.Forms.Button Button,Panel panel) {
            this.Button = Button;
            this.panel = panel;

        }
        public async void VerifyAsync(string email, string password)
        {
            var authProvider = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig("AIzaSyCjNHR6PHEqCbUj_Of7Mx2NxePvoXwkvAM"));
            //
            try
            {
                Auth = await Task.Run(() => authProvider.SignInWithEmailAndPasswordAsync(email, password));
                User = Auth.User;
            }
            catch (Exception ex)
            {
                User = null;
            }

            if (User == null)
            {
                Button_Android.Enabled = false;
                label_Android_Disponible.Text = "No Disponible";
                label_Android_Disponible.BackColor = Color.Red;
            }
            else
            {
                var select = client.Get(@"Accesos/"+cliente.NumeroDeCuenta.ToString());
                AccesosFb acc = select.ResultAs<AccesosFb>();
                if (acc.Movil == true)
                {

                    Button_Android.Enabled = true;
                    label_Android_Disponible.Text = "Disponible";
                    label_Android_Disponible.BackColor = Color.LimeGreen;
                }
                else
                {
                    Button_Android.Enabled = false;
                    label_Android_Disponible.Text = "No Disponible";
                    label_Android_Disponible.BackColor = Color.Red;
                }

            }
        }
        public void setEventos(List<ClienteEventos> eventos)
        {
            foreach (var evento in eventos)
            {
                var n = dataGridView_Eventos.Rows.Add();
                dataGridView_Eventos.Rows[n].Cells[0].Value = evento.Codigo;
                dataGridView_Eventos.Rows[n].Cells[1].Value = evento.Descripcion;
                if (evento.Tipo == "Usuario")
                {
                    dataGridView_Eventos.Rows[n].Cells[2].Value = evento.Numero;
                    dataGridView_Eventos.Rows[n].Cells[3].Value = "N/A";
                }
                else if (evento.Tipo == "Sensor")
                {
                    dataGridView_Eventos.Rows[n].Cells[3].Value = evento.Numero;
                    dataGridView_Eventos.Rows[n].Cells[2].Value = "N/A";
                }
                else
                {
                    dataGridView_Eventos.Rows[n].Cells[3].Value = "N/A";
                    dataGridView_Eventos.Rows[n].Cells[2].Value = "N/A";
                }
                dataGridView_Eventos.Rows[n].Cells[4].Value = evento.Ubicacion;
                dataGridView_Eventos.Rows[n].Cells[5].Value = evento.ParticionArea;
            }
        }
        private void ClienteAlerta_FormClosing(object sender, FormClosingEventArgs e)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCjNHR6PHEqCbUj_Of7Mx2NxePvoXwkvAM"));
            try
            {
                Auth = null;
            }
            catch (Exception ex)
            {
                User = null;
            }
        }
        private void dataGridView_Contactos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.RowIndex >= 0)
            {
                Guid id = Guid.Parse(this.dataGridView_Contactos.Rows[e.RowIndex].Cells[0].Value.ToString());
                ReporteContacto reporteContatcto = new ReporteContacto(IdIncidente, id);
                reporteContatcto.ShowDialog();
            }
        }

        private void Button_Fotos_Click(object sender, EventArgs e)
        {
            Fotos form = new Fotos(this.cliente.NumeroDeCuenta);
            form.ShowDialog();
        }

            
        private void setBrowseMap()
        {
            try
            {                
                this.webBrowser.Url = new Uri(cliente.GoogleMaps);                                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ":" + ex.InnerException);
            }
        }

        private void ClienteAlerta_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
        }
        IFirebaseClient client;

        IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
        {
            AuthSecret = "y9qo73rzWLMhKRHqAsgXpbO53XvE1GK0tf0Pm9O2",
            BasePath = "https://monitoreo-360.firebaseio.com/"
        };
        private void Button_Guardar_Click(object sender, EventArgs e)
        {
            Models.Incidentes incidentes = db.Incidentes.Where(x=>x.Id==IdIncidente).FirstOrDefault();
            db.UpdateIncidente(IdIncidente,incidentes.IdCliente,incidentes.IdLog,this.TextBox_Comentarios.Text, TiempoInicio,DateTime.Now,"Completo",true,DateTime.Now,IdUsuario);
            if (string.IsNullOrEmpty(Button.Text))
            {
                Button.Text = "";
                Button.Visible = false;
            }
            else
            {
                Button.Text = (int.Parse(Button.Text) - 1) + "";
                if ((int.Parse(Button.Text)) == 0)
                    Button.Visible = false;
            }

            DialogResult result =MetroFramework.MetroMessageBox.Show(this,"Listo! Se guardo correctamente","Monitoreo 360",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            this.FormClosing -= ClienteAlerta_FormClosing_1;
            if (result == DialogResult.OK)
            {
                close = true;
                this.Close();                
            }
            
        }

        private void ClienteAlerta_FormClosing_1(object sender, FormClosingEventArgs e)
        {

            if (string.IsNullOrEmpty(Button.Text))
            {
                Button.Text = "1";
                Button.Visible = true;
            }
            else
            {
                Button.Text = (int.Parse(Button.Text) + 1) + "";
                Button.Visible = true;
            }
            System.Windows.Forms.Button Notificacion = new System.Windows.Forms.Button();
            Notificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(61)))));
            Notificacion.Text = label_Nombres.Text;
            Notificacion.Cursor = System.Windows.Forms.Cursors.Hand;
            Notificacion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Notificacion.ForeColor = System.Drawing.Color.SeaGreen;
            Notificacion.Location = new System.Drawing.Point(0, y);
            Notificacion.Margin = new System.Windows.Forms.Padding(5);
            Notificacion.Name = "Notificacion";
            Notificacion.Size = new System.Drawing.Size(203, 54);
            Notificacion.TabIndex = 0;
            Notificacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            panel.Controls.Add(Notificacion);
            y += 48;
            /*if (!close) { 
                e.Cancel = true ;
                MetroFramework.MetroMessageBox.Show(this, "No se puede cerrar hasta dar seguimiento a la alerta", "Monitoreo 360", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }*/
        }
        
        
        private async void Button_Android_ClickAsync(object sender, EventArgs e)
        {
            
            DateTime now = DateTime.Now;
            foreach (DataGridViewRow row in dataGridView_Eventos.Rows)
            {
                Random r = new Random();
                int aleatorio = r.Next(0, 100);
                var todo = new Alerta
                {
                    activo = true,
                    codigoDeAlarma = row.Cells[0].Value.ToString(),
                    color = 2,
                    fecha = now.Year + "-" + now.Month + "-" + now.Day + " " + now.Hour + ":" + now.Minute + ":" + now.Second + "." + now.Millisecond,
                    fechaRecibido = "",
                    id = aleatorio,
                    recibido = false,
                    sensor = row.Cells[3].Value.ToString(),
                    usuario = row.Cells[2].Value.ToString(),
                    usuarioCreacion = "001"
                };
                FireSharp.Response.SetResponse response = await client.SetAsync("Alertas/" + cliente.NumeroDeCuenta + "/" + aleatorio, todo);
                Alerta result = response.ResultAs<Alerta>();
            }

            MetroFramework.MetroMessageBox.Show(this, "Mensaje Enviado\n", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 100);
           
        }
    }
}
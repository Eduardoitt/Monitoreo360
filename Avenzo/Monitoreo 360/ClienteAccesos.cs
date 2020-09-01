using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using FireSharp;
using FireSharp.Extensions;
using FireSharp.Interfaces;
using FireSharp.Response;
using MetroFramework;
using Monitoreo_360.ClasesFirebase;
using Monitoreo_360.Models;
using Newtonsoft.Json.Linq;

namespace Monitoreo_360
{
    public partial class ClienteAccesos : MetroFramework.Forms.MetroForm
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        private FirebaseAuthLink Auth;
        private Firebase.Auth.User User;
        private Models.Clientes cliente = new Models.Clientes();
        private Usuarios usuario = new Usuarios();
        ClienteEdit formEdit;
        public ClienteAccesos(ClienteEdit formEdit)
        {
            InitializeComponent();
            this.formEdit = formEdit;
        }
        private void ClienteAccesos_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
        }
        IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
        {
            AuthSecret = "y9qo73rzWLMhKRHqAsgXpbO53XvE1GK0tf0Pm9O2",
            BasePath = "https://monitoreo-360.firebaseio.com/",
        };
        IFirebaseClient client;

        public async void setInfoAsync(Guid id)
        {
            cliente = db.Clientes.Where(x => x.IdCliente == id).FirstOrDefault();

            if (cliente.IdUsuario != null)
            {   // Entra cuando tiene un usuario y tiene un numero de cuenta 
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCjNHR6PHEqCbUj_Of7Mx2NxePvoXwkvAM"));
                try
                {
                    //Autentificacion si el usuario existe en firebase
                    Auth = await Task.Run(() => authProvider.SignInWithEmailAndPasswordAsync(cliente.NumeroDeCuenta + "@avenzo.mx", cliente.NumeroDeCuenta));
                    User = Auth.User;
                    
                }
                catch (Firebase.Auth.FirebaseAuthException ex)
                {
                    JObject jObject = JObject.Parse(ex.ResponseData);
                    DialogResult dr = MetroMessageBox.Show(this, "error:" + jObject["error"]["errors"].First.Last.First.ToString(), "Error en la base de datos de google", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    User = null;
                }
                if (User == null)
                {
                    //Entra si el usuario tiene usuario en sql pero no esta autenticado
                    //Si no esta autenticado bloquar o no permitir la entrada a esta ventana
                    formEdit.Text="Cliente no cuenta con acceso a aplicacion web ni movil";
                    metroToggle_Android.Checked = false;
                    metroToggle_Web.Checked = true;
                }
                else
                {
                    //Select para traer los datos de firebase
                    try
                    {
                        var res = client.Get(@"Accesos/" + cliente.NumeroDeCuenta.ToString());
                        AccesosFb acc = res.ResultAs<AccesosFb>();
                        metroTextBox_Email.Text = acc.Mail;
                        metroToggle_Android.Checked = acc.Movil;
                        metroToggle_Web.Checked = acc.Web;
                       
                    }
                    catch (FirebaseAuthException ex)
                    {
                        Console.WriteLine(ex);
                    }

                }
            }
            else
            {

                metroToggle_Android.Checked = false;
                metroToggle_Web.Checked = false;
            }
        }
        private void metroButton_Guardar_Click(object sender, EventArgs e)
        {
            AccesosFb acc = new AccesosFb()
            {
                Web=metroToggle_Web.Checked,
                Movil=metroToggle_Android.Checked,
                Mail= metroTextBox_Email.Text
            };

            var set = client.Update(@"Accesos/" + cliente.NumeroDeCuenta.ToString(), acc);
            if(set.StatusCode==HttpStatusCode.OK)
                MetroMessageBox.Show(this, "", "Los cambios fueron guardados exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //var set = client.Set(@"Accesos/" + numCuenta, std);
            /*string Email = metroTextBox_Email.Text;
            string Password = "santiago01";
            string Name = cliente.Nombres + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
            if (metroToggle_Android.Checked)
            {
                if (User != null)
                {
                }
                else
                {
                    var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCjNHR6PHEqCbUj_Of7Mx2NxePvoXwkvAM"));                    
                    authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password, Name, true);
                    formEdit.setEmail(Email);
                    this.Close();
                }
            }
            else {
                if (User!=null) {
                    var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCjNHR6PHEqCbUj_Of7Mx2NxePvoXwkvAM"));
                    authProvider.DeleteUser(Auth.FirebaseToken);
                }
            }*/
        }

        private void metroButton_CambiarContrasena_Click(object sender, EventArgs e)
        {

            metroTextBox_Password.Visible = true;
            metroTextBox_Password_Repeat.Visible = true;
            label_Contrasena.Visible = true;
            label_Repeat_Contrasena.Visible = true;
        }

        private void metroTextBox_Password_Repeat_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroTextBox_Password_TextChanged(object sender, EventArgs e)
        {

        }

 
    }
}

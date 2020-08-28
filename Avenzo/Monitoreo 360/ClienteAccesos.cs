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

        IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
        {
            AuthSecret = "AIzaSyCjNHR6PHEqCbUj_Of7Mx2NxePvoXwkvAM",
            BasePath = "https://monitoreo-360.firebaseio.com/",

        };
        IFirebaseClient client;

        private void ClienteAccesos_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    client = new FireSharp.FirebaseClient(config);
            //}

            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }

        public async void setInfoAsync(Guid id)
        {
            cliente = db.Clientes.Where(x => x.IdCliente == id).FirstOrDefault();

            if (cliente.IdUsuario != null)
            {   // Entra cuando tiene un usuario y tiene un numero de cuenta 
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCjNHR6PHEqCbUj_Of7Mx2NxePvoXwkvAM"));
                try
                {
                    Auth = await Task.Run(() => authProvider.SignInWithEmailAndPasswordAsync(cliente.NumeroDeCuenta + "@avenzo.mx", cliente.NumeroDeCuenta));
                    User = Auth.User;
                    client = new FireSharp.FirebaseClient(config);
                }
                catch (Firebase.Auth.FirebaseAuthException ex)
                {
                    JObject jObject = JObject.Parse(ex.ResponseData);
                    DialogResult dr = MetroMessageBox.Show(this, "error:" + jObject["error"]["errors"].First.Last.First.ToString(), "Error en la base de datos de google", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    User = null;
                }
                if (User == null)
                {
                    metroToggle_Android.Checked = false;
                    metroToggle_Web.Checked = true;
                }
                else
                {

                    try
                    {

                        //FirebaseResponse query = await client.GetAsync("Accesos", FireSharp.QueryBuilder.New().OrderBy("ID").LimitToLast(1));

                        //FirebaseResponse res = await client.GetAsync("Accesos", FireSharp.QueryBuilder.New().OrderBy("Mail").LimitToLast(1));
                        //query.Equals(cliente.);
                        //FirebaseResponse res = await client.Get(@"Accesos/"+ cliente.Email);
                        var res = client.Get(@"Accesos/" + cliente.Email.ToString());
                        AccesosFb acc = res.ResultAs<AccesosFb>();
                        metroTextBox_Email.Text = acc.Mail;
                        metroToggle_Android.Checked = acc.Movil;
                        metroToggle_Web.Checked = acc.Web;


                        MessageBox.Show("data retrieved sucessfully!");
                    }catch (FirebaseAuthException ex)
                    {
                        Console.WriteLine(ex);
                    }

                    // FireSharp.FirebaseClient client = new FireSharp.FirebaseClient(config);
                    //FirebaseResponse response = await client.GetAsync("Monitoreo-360/Accesos/");
                    //var myJson = response.Body;
                    //Firebase.Database.Query query = new Firebase.Database.Query.FirebaseQuery();
               
                }
            }
            else
            {

                metroToggle_Android.Checked = false;
                metroToggle_Web.Checked = false;
            }
           // metroTextBox_Email.Text = cliente.Email;
            //metroTextBox_Password.Visible = false;
            //metroTextBox_Password_Repeat.Visible = false;
        }
        private void metroButton_Guardar_Click(object sender, EventArgs e)
        {

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

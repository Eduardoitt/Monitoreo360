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
using MetroFramework;
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
        public async void setInfoAsync(Guid id)
        {
            cliente = db.Clientes.Where(x => x.IdCliente == id).FirstOrDefault();
            if (cliente.IdUsuario != null)
            {               
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCjNHR6PHEqCbUj_Of7Mx2NxePvoXwkvAM"));
                try {
                    Auth = await Task.Run(() => authProvider.SignInWithEmailAndPasswordAsync(cliente.NumeroDeCuenta+"@avenzo.mx", cliente.NumeroDeCuenta));
                    User = Auth.User;
                } catch (Firebase.Auth.FirebaseAuthException ex) {
                    JObject jObject = JObject.Parse(ex.ResponseData);
                    DialogResult dr = MetroMessageBox.Show(this,"error:"+jObject["error"]["errors"].First.Last.First.ToString(), "Error en la base de datos de google", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    User = null;
                }                
                if (User == null)
                {
                    metroToggle_Android.Checked = false;
                    metroToggle_Web.Checked = true;
                }
                else
                {
                    metroToggle_Android.Checked = true;
                    metroToggle_Web.Checked = true;
                }
            }
            else {
                metroToggle_Android.Checked = false;
                metroToggle_Web.Checked = false;
            }
            metroTextBox_Email.Text = cliente.Email;
            metroTextBox_Password.Visible = false;
            metroTextBox_Password_Repeat.Visible = false;
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

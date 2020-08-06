using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monitoreo_360.Models;
using Helpers;

namespace Monitoreo_360
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        Menu MainWindow;
        public Login()
        {
            InitializeComponent();
        }

        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try {
                
                string Password = Helpers.SHA1.Encode(textBox_Password.Text);
                string Email = textBox_Email.Text;
                if (db.Usuarios.Where(x => x.Usuario == Email && x.Contraseña == Password).Any())
                {

                    if (MainWindow != null)
                        MainWindow.Close();                    
                    MainWindow = new Menu(db.Usuarios.Where(x => x.Usuario == Email && x.Contraseña == Password).FirstOrDefault().Id, this);
                    MainWindow.Show();
                    this.Hide();
                    textBox_Email.Text = "";
                    textBox_Password.Text = "Prueba";
                }
                else
                {
                    label_Error.Visible = true;
                }
            } catch (Exception ex) {
                MetroFramework.MetroMessageBox.Show(this, ex.Message+" "+ex.InnerException+" "+ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


    }
}

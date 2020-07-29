using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        
        private void pictureBox4_Click(object sender, EventArgs e)
        {
                
            mdiForm2 mainWindow = new mdiForm2();
            this.Hide();
            mainWindow.Show();
        }
    }
}

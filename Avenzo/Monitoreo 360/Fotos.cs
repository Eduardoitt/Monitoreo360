using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitoreo_360
{
    public partial class Fotos : MetroFramework.Forms.MetroForm
    {
        private string NumeroDeCuenta;
        private int x = 36, y = 14, i = 0;
        public Fotos(string NumeroDeCuenta)
        {
            InitializeComponent();
            this.NumeroDeCuenta = NumeroDeCuenta;
            string path = String.Format(@"{0}\Fotos\" + this.NumeroDeCuenta, Application.StartupPath);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            else { 
                DirectoryInfo di = new DirectoryInfo(path);
                x = 36; y = 14; i=0;
                foreach (var image in di.GetFiles()) {
                    AgregarImagen(String.Format(path+@"\{0}",image.Name),x,y,image.Name.Split('.')[0]);
                    x = x+170 + ((int)36.6);
                    
                    i = i+ 1;
                    if (i == 4) { 
                        y = y + 185 + 14;
                        x = 36;
                        i = 0;
                    }
                }
            }


        }

        private void Button_AgregarFotos_Click(object sender, EventArgs e)
        {
            OpenFileDialog result =new OpenFileDialog();
            if (result.ShowDialog()==DialogResult.OK) {
                try {
                    string fileName = result.FileName;
                    byte[] file = System.IO.File.ReadAllBytes(fileName);
                    Console.WriteLine("Nombre:"+fileName);
                    Guid Id = Guid.NewGuid();
                    string Name = Id + "." + fileName.Split('.')[fileName.Split('.').Length - 1];
                    string path = String.Format(@"{0}\Fotos\"+this.NumeroDeCuenta, Application.StartupPath);
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    Console.WriteLine("path:" + path + " otro path:" + Application.StartupPath);
                    File.WriteAllBytes(path+"\\"+Name,file);
                    //pictureBox.Image = Image.FromFile(path);
                    AgregarImagen((path+"\\"+Name), x, y,Id.ToString());
                    x = x + 170 + ((int)36.6);
                    i = i + 1;
                    if (i == 4)
                    {
                        y = y + 185 + 14;
                        x = 36;
                        i = 0;
                    }

                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                
            }
            
            //System.IO.File.WriteAllBytes();
            
        }
        public void AgregarImagen(string file,int x ,int y,string Name) {
            Panel panel = new System.Windows.Forms.Panel();
            Bunifu.Framework.UI.BunifuImageButton Button_Close = new Bunifu.Framework.UI.BunifuImageButton();
            PictureBox pictureBox = new System.Windows.Forms.PictureBox();
            panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(Button_Close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox)).BeginInit();
            this.panel_Galeria.Controls.Add(panel);

            // 
            // panel
            // 
            panel.Controls.Add(Button_Close);
            panel.Controls.Add(pictureBox);
            panel.Location = new System.Drawing.Point(x, y);
            //panel.Name = "panel";
            panel.Size = new System.Drawing.Size(170, 185);
            panel.TabIndex = 0;
            // 
            // Button_Close
            // 
            Button_Close.BackColor = System.Drawing.Color.Firebrick;
            Button_Close.Image = global::Monitoreo_360.Properties.Resources.Delete_96px;
            Button_Close.ImageActive = null;
            Button_Close.Location = new System.Drawing.Point(152, 0);
            //Button_Close.Name = "Button_Close";
            Button_Close.Size = new System.Drawing.Size(18, 18);
            Button_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            Button_Close.TabIndex = 1;
            Button_Close.TabStop = false;
            Button_Close.Zoom = 10;
            // 
            // pictureBox
            // 
            pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox.Image = Image.FromFile(file);
            pictureBox.InitialImage = null;
            pictureBox.Location = new System.Drawing.Point(0, 0);
            pictureBox.Name = Name;
            pictureBox.Size = new System.Drawing.Size(170, 185);
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            pictureBox.TabStop = false;
            

            panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(Button_Close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox)).EndInit();
        }
        public void pictureBox_DoubleClick(object sender, EventArgs e) {
            
            string path = String.Format(@"{0}\Fotos\" + this.NumeroDeCuenta, Application.StartupPath);
            PictureBox picture = (PictureBox)sender;
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (var file in di.GetFiles().Where(x=>x.Name.Contains(picture.Name)))
            {
                Process photoViewer = new Process();
                photoViewer.StartInfo.FileName = file.FullName;
                photoViewer.Start();
            }
            
        }

    }
}

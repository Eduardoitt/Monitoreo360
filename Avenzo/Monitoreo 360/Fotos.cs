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
using System.Net;
using Monitoreo_360.Models;
using MetroFramework;

namespace Monitoreo_360
{
    public partial class Fotos : MetroFramework.Forms.MetroForm
    {
        private string NumeroDeCuenta;
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        private string strServer = "avenzo.mx", strUser = "avenzopagina4", strPassword = "Teclado01!", strFileNameLocal = "", strPathFTP = "";
        string rutacompleta = "";
        private delegate void CargarImagenesDL();
        public Fotos(string NumeroDeCuenta)
        {
            InitializeComponent();
            this.NumeroDeCuenta = NumeroDeCuenta;

            var path = (from f in db.FotosCliente
                        join c in db.Clientes on f.IdCliente equals c.IdCliente
                        where c.NumeroDeCuenta == NumeroDeCuenta
                        select new
                        {
                            f.IdFotoCliente,
                            f.IdCliente,
                            f.RutaFoto,
                            f.Nombre
                        }).ToList();

            foreach (var image in path)
            {
                //Descarga las imagenes en una carpeta local
                string strFileNameLocal = "FotosDescarga/" + NumeroDeCuenta + "/" + image.Nombre;
                if (!Directory.Exists("FotosDescarga/" + NumeroDeCuenta))
                    Directory.CreateDirectory("FotosDescarga/" + NumeroDeCuenta);
                Download(image.RutaFoto, strFileNameLocal);

                //Carga las imagenes en el panel
                string cargar = String.Format(@"{0}\FotosDescarga\" + this.NumeroDeCuenta , Application.StartupPath);
                AgregarImagen(String.Format(cargar+@"\{0}",image.Nombre), image.Nombre);
            }
        }
        //Agrega las imagenes en el panel
        public void AgregarImagen(string file, string Name)
        {
            Panel panel = new System.Windows.Forms.Panel();
            System.Windows.Forms.Button Button_Close = new System.Windows.Forms.Button();
            PictureBox pictureBox = new System.Windows.Forms.PictureBox();
            panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox)).BeginInit();
            this.flowLayoutPanel1.Controls.Add(panel);

            // 
            // panel
            // 
            panel.Controls.Add(Button_Close);
            
            panel.Size = new System.Drawing.Size(170, 185);
            panel.TabIndex = 0;
            // 
            // Button_Close
            // 
            Button_Close.BackColor = System.Drawing.Color.Firebrick;
            Button_Close.Image = global::Monitoreo_360.Properties.Resources.Delete_96px;
            Button_Close.Location = new System.Drawing.Point(152, 0);
            Button_Close.Name = "Button_Close";
            Button_Close.Size = new System.Drawing.Size(18, 18);
            Button_Close.TabIndex = 1;
            Button_Close.TabStop = false;

            // 
            // pictureBox
            // 
            using (FileStream strm = new FileStream(file,FileMode.Open,FileAccess.Read))
            {
                panel.Controls.Add(pictureBox);
                pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
                //pictureBox.Image = Image.FromFile(file);
                pictureBox.Image = Image.FromStream(strm);
                pictureBox.InitialImage = null;
                pictureBox.Location = new System.Drawing.Point(0, 0);
                pictureBox.Name = Name;
                pictureBox.Height = 100;
                pictureBox.Width = 185;
                pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox.TabIndex = 0;
                pictureBox.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
                pictureBox.TabStop = false;
                ((System.ComponentModel.ISupportInitialize)(pictureBox)).EndInit();
                strm.Dispose();
            }
                


            panel.ResumeLayout(false);

            
        }

        //Elimina las imagenes de la carpeta al cerra la ventana
        private void Fotos_FormClosed(object sender, FormClosedEventArgs e)
        {
            var path = (from f in db.FotosCliente
                        join c in db.Clientes on f.IdCliente equals c.IdCliente
                        where c.NumeroDeCuenta == NumeroDeCuenta
                        select new
                        {
                            f.IdFotoCliente,
                            f.IdCliente,
                            f.RutaFoto,
                            f.Nombre
                        }).ToList();
            foreach (var image in path)
            {
                string pathdelete = String.Format(@"{0}\FotosDescarga\" + this.NumeroDeCuenta+"\\"+image.Nombre, Application.StartupPath);
                File.Delete(pathdelete);
            }
        }

        //Sube las imagenes al servidor
        public bool SubirFotos(string strFileNameLocal, string strPathFTP)
        {
            try
            {
                FtpWebRequest ftpRequest;

                // Crea el objeto de conexión del servidor FTP
                string filename = Path.Combine(strPathFTP + "/", Path.GetFileName(strFileNameLocal));
                ftpRequest = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("ftp://{0}/{1}", strServer, filename)));
                rutacompleta = string.Format("ftp://{0}/{1}", strServer, filename);
                // Asigna las credenciales 
                ftpRequest.Credentials = new NetworkCredential(strUser, strPassword);
                // Asigna las propiedades
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                ftpRequest.UsePassive = true;
                ftpRequest.UseBinary = true;
                ftpRequest.KeepAlive = false;
                byte[] fileContents;
                fileContents = File.ReadAllBytes(filename);

                ftpRequest.ContentLength = fileContents.Length;

                using (Stream requestStream = ftpRequest.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                }

                using (FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse())
                {
                    Console.WriteLine($"Se cargo la imagen, status {response.StatusDescription}");
                }
                return true;
            }
            catch (WebException e)
            {
                String status = ((FtpWebResponse)e.Response).StatusDescription;
                return false;
            }
        }

        //Guarda la imagen en la bd
        private void Button_AgregarFotos_Click(object sender, EventArgs e)
        {
            OpenFileDialog result = new OpenFileDialog();
            result.Filter = "Archivos jpg(*.jpg)|*.jpg|Archivos png(*.png)|*.png";
            result.FilterIndex = 1;
            result.RestoreDirectory = true;

            if (result.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    /******************************************** Sube imagen a servidor ftp ************************************************************/
                    string fileName = result.FileName;
                    byte[] file = System.IO.File.ReadAllBytes(fileName);
                    Console.WriteLine("Nombre:" + fileName);
                    Guid Id = Guid.NewGuid();
                    string Name = Id + "." + fileName.Split('.')[fileName.Split('.').Length - 1];
                    string path = String.Format("Fotos/" + this.NumeroDeCuenta);
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    File.WriteAllBytes(path + "\\" + Name, file);
                    bool respuesta =SubirFotos(Name, path);

                    /************************************************************************************************************************************/
                    /****************************************** ingreso a la base de datos **************************************************************/
                    if( respuesta == true)
                    {

                        Guid? IdCliente = new Guid();
                        Models.Clientes Client = db.Clientes.Where(x => x.NumeroDeCuenta == NumeroDeCuenta).FirstOrDefault();
                        IdCliente = Client.IdCliente;
                        db.InsertClienteFoto(Id, IdCliente, rutacompleta, Name, "ftp://avenzo.mx/Fotos/" + NumeroDeCuenta + "/");
                        AgregarDeNuevo(Name);
                        string pathdelete2 = String.Format(@"{0}/"+path+"/"+Name, Application.StartupPath);
                        File.Delete(pathdelete2);
                        //File.Delete(@"\Users\crist\OneDrive\Escritorio\Proyecto\Monitoreo360\Avenzo\Monitoreo 360\bin\Debug\" + path + "\\" + Name);
                        rutacompleta = string.Empty;

                        MetroMessageBox.Show(this, "Se guardo exitosamento la foto", "Foto agregada", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "No se pudo guardar la imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }
        public void AgregarDeNuevo(string Name)
        {
            try
            {

                var path = (from f in db.FotosCliente
                            join c in db.Clientes on f.IdCliente equals c.IdCliente
                            where c.NumeroDeCuenta == NumeroDeCuenta && f.Nombre==Name
                            select new
                            {
                                f.IdFotoCliente,
                                f.IdCliente,
                                f.RutaFoto,
                                f.Nombre
                            }).FirstOrDefault();


                string strFileNameLocal = "FotosDescarga/" + NumeroDeCuenta + "/" + path.Nombre;
                if (!Directory.Exists("FotosDescarga/" + NumeroDeCuenta))
                    Directory.CreateDirectory("FotosDescarga/" + NumeroDeCuenta);
                Download(path.RutaFoto, strFileNameLocal);
                string cargar = String.Format(@"{0}\FotosDescarga\" + this.NumeroDeCuenta, Application.StartupPath);
                AgregarImagen(String.Format(cargar + @"\{0}", path.Nombre), path.Nombre);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void Download(string strFileNameFTP, string strFileNameLocal)
        {
            
            FtpWebRequest ftpRequest;
            //Crea el objeto de conexión del servidor FTP
            ftpRequest = (FtpWebRequest)WebRequest.Create(string.Format(strFileNameFTP));
            // Asigna las credenciales
            ftpRequest.Credentials = new NetworkCredential(strUser, strPassword);
            // Asigna las propiedades
            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
            ftpRequest.UsePassive = true;
            ftpRequest.UseBinary = true;
            ftpRequest.KeepAlive = false;
            // Descarga el archivo y lo graba
            /* cuando cargo una nueva imagen me marca error de que no se puede acceder a la ruta porque esta ciendo utilizado por otro porceso*/
            using (FileStream stmFile = File.OpenWrite(strFileNameLocal))
            { // Obtiene el stream sobre la comunicación FTP
                using (Stream responseStream = ((FtpWebResponse)ftpRequest.GetResponse()).GetResponseStream())
                {
                    int cnstIntLengthBuffer = 10240;
                    byte[] arrBytBuffer = new byte[cnstIntLengthBuffer];
                    int intRead;

                    // Lee los datos del stream y los graba en el archivo
                    while ((intRead = responseStream.Read(arrBytBuffer, 0, cnstIntLengthBuffer)) != 0)
                        stmFile.Write(arrBytBuffer, 0, intRead);
                    // Cierra el stream FTP	
                    responseStream.Close();
                }
                // Cierra el archivo de salida
                
                stmFile.Flush();
                stmFile.Close();
                stmFile.Dispose();

            }
        }

        public void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            //Al dar doble click abre la foto seleccionada en un visor de windows
            string path = String.Format(@"{0}\Fotos\" + this.NumeroDeCuenta, Application.StartupPath);
            PictureBox picture = (PictureBox)sender;
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (var file in di.GetFiles().Where(x => x.Name.Contains(picture.Name)))
            {
                Process photoViewer = new Process();
                photoViewer.StartInfo.FileName = file.FullName;
                photoViewer.Start();
            }

        }

    }
}

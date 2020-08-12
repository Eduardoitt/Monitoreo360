using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework;
using System.Windows.Forms;
using Monitoreo_360.Models;

namespace Monitoreo_360
{
    public partial class Direccion : MetroFramework.Forms.MetroForm
    {
        Guid IdUsuario = new Guid();
        Models.Clientes cliente;
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        List<Estados> Estados =new List<Estados>();
        List<Municipios> Municipio = new List<Municipios>();
        public Direccion(Guid IdCliente, Guid IdUsuario)
        {
            InitializeComponent();

            List<Estados> estados = db.Estados.Where(x=>x.c_Pais== "MEX").ToList();
            /*List<Ciudad> ciudades = db.Ciudad.ToList();
            comboBox_Ciudad.Items.AddRange(ciudades.Select(x => x.Ciudad1).ToArray());*/
            //comboBox_Estado.Items.AddRange(estados.Select(x => x.NombreEstado).ToArray());            
            this.IdUsuario = IdUsuario;
            this.cliente = db.Clientes.Where(x => x.IdCliente == IdCliente).FirstOrDefault();
            this.Textbox_Colonia.Text = cliente.Colonia;
            this.Textbox_Calle.Text = cliente.Calle;
            this.Textbox_NoInterior.Text = cliente.NoInterior;
            this.Textbox_NoExterior.Text = cliente.NoExterior;
            this.Textbox_CodigoPostal.Text = cliente.CodigoPostal;
            this.Textbox_Referencias.Text = cliente.Referencias;
            this.Textbox_Color.Text = cliente.ColorEstablecimiento;
            this.Textbox_EntreCalles.Text = cliente.EntreCalles;
            this.Textbox_Google.Text = cliente.GoogleMaps;
            //comboBox_Estado.SelectedItem = cliente.Estado;
            Data();
            comboBox_Ciudad.SelectedItem = cliente.Ciudad;
            if (cliente.GoogleMaps != null)
            {
                webBrowser.ScriptErrorsSuppressed = true;
                //this.webBrowser.Url = new Uri(cliente.GoogleMaps);
                this.webBrowser.Navigate(new Uri(cliente.GoogleMaps));               
            }
               
        }
        async void Data()
        {
            await Task.Run(() =>
            {
                getData();
            });
        }
        private bool getData() {
            Estados = db.Estados.ToList();
            setEstados();
            return true;
        }
        public void setEstados()
        {
            if (this.comboBox_Estado.InvokeRequired)
            {
                this.comboBox_Estado.Invoke(new MethodInvoker(delegate
                {
                    this.comboBox_Estado.DataSource = Estados;
                    this.comboBox_Estado.ValueMember = "c_Estados";
                    this.comboBox_Estado.DisplayMember = "NombreEstado";
                }));
            }
        }
        private void Button_Guardar_Click(object sender, EventArgs e)
        {
            this.webBrowser.Url = new Uri(this.Textbox_Google.Text);
            db.UpdateClientes(cliente.IdCliente, cliente.IdProveedor, cliente.NumeroDeCuenta, cliente.NumeroTelefonoAlarma,
                cliente.PalabraClave, cliente.PalabraClaveSilenciosa, cliente.Nombres, cliente.ApellidoPaterno, cliente.ApellidoMaterno,
                this.Textbox_Calle.Text, this.Textbox_NoInterior.Text, this.Textbox_NoExterior.Text, this.Textbox_Colonia.Text, this.Textbox_CodigoPostal.Text, this.Textbox_Referencias.Text,
                this.Textbox_Color.Text, this.Textbox_EntreCalles.Text, this.Textbox_Google.Text, "", cliente.Telefono, cliente.TelefonoTrabajo,
                cliente.TelefonoCelular, cliente.Email, cliente.Foto, this.comboBox_Estado.SelectedValue.ToString(), cliente.Pais, this.comboBox_Ciudad.SelectedValue.ToString(), cliente.TipoAfilacion,
                cliente.NumeroPatrocinador, cliente.FechaNacimiento, cliente.LugarNacimiento, cliente.Sexo, cliente.EstadoCivil, cliente.Profesion,
                cliente.CURP, cliente.RFC, cliente.NumCtaPago, cliente.ClaveBancaria, cliente.Banco, cliente.NumeroCLABE, cliente.Beneficiario, cliente.FechaCreacion, IdUsuario, true, cliente.IdUsuario);
            MetroFramework.MetroMessageBox.Show(this,"Se ha Guardado correctamente", "",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {            
            Fotos form = new Fotos(this.cliente.NumeroDeCuenta);
            form.ShowDialog();
        }

        private void comboBox_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = comboBox_Estado.SelectedValue.ToString();
            Municipio = db.Municipios.Where(x=> x.c_Estado==value).ToList();
            this.comboBox_Ciudad.DataSource=Municipio;
            this.comboBox_Ciudad.ValueMember = "c_Estado";
            this.comboBox_Ciudad.DisplayMember = "Descripcion";

        }
    }
}

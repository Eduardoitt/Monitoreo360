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
            Data();
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
            db.UpdateDireccion(cliente.IdCliente, Textbox_Colonia.Text.Trim(), Textbox_Calle.Text.Trim(), Textbox_NoInterior.Text.Trim(),
                Textbox_NoExterior.Text.Trim(), Textbox_CodigoPostal.Text.Trim(), Textbox_Referencias.Text.Trim(), Textbox_Color.Text.Trim(),
                Textbox_EntreCalles.Text.Trim(), Textbox_Google.Text.Trim(),comboBox_Estado.SelectedValue.ToString(),
                comboBox_Ciudad.SelectedValue.ToString());

            MetroMessageBox.Show(this,"Se ha Guardado correctamente", "",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
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

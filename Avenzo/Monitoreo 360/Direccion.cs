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
        public Direccion(Guid IdCliente, Guid IdUsuario)
        {
            InitializeComponent();

            List<Estados> estados = db.Estados.Where(x=>x.c_Pais== "MEX").ToList();
            /*List<Ciudad> ciudades = db.Ciudad.ToList();
            comboBox_Ciudad.Items.AddRange(ciudades.Select(x => x.Ciudad1).ToArray());*/
            comboBox_Estado.Items.AddRange(estados.Select(x => x.NombreEstado).ToArray());            
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
            comboBox_Estado.SelectedItem = cliente.Estado;
            comboBox_Ciudad.SelectedItem = cliente.Ciudad;
            if(cliente.GoogleMaps!=null)
                this.webBrowser.Url = new Uri(cliente.GoogleMaps);
        }

        private void Button_Guardar_Click(object sender, EventArgs e)
        {
            this.webBrowser.Url = new Uri(this.Textbox_Google.Text);
            db.UpdateClientes(cliente.IdCliente, cliente.IdProveedor, cliente.NumeroDeCuenta, cliente.NumeroTelefonoAlarma,
                cliente.PalabraClave, cliente.PalabraClaveSilenciosa, cliente.Nombres, cliente.ApellidoPaterno, cliente.ApellidoMaterno,
                this.Textbox_Calle.Text, this.Textbox_NoInterior.Text, this.Textbox_NoExterior.Text, this.Textbox_Colonia.Text, this.Textbox_CodigoPostal.Text, this.Textbox_Referencias.Text,
                this.Textbox_Color.Text, this.Textbox_EntreCalles.Text, this.Textbox_Google.Text, "", cliente.Telefono, cliente.TelefonoTrabajo,
                cliente.TelefonoCelular, cliente.Email, cliente.Foto, this.comboBox_Estado.SelectedItem.ToString(), cliente.Pais, this.comboBox_Ciudad.SelectedItem.ToString(), cliente.TipoAfilacion,
                cliente.NumeroPatrocinador, cliente.FechaNacimiento, cliente.LugarNacimiento, cliente.Sexo, cliente.EstadoCivil, cliente.Profesion,
                cliente.CURP, cliente.RFC, cliente.NumCtaPago, cliente.ClaveBancaria, cliente.Banco, cliente.NumeroCLABE, cliente.Beneficiario, cliente.FechaCreacion, IdUsuario, true, cliente.IdUsuario);
            MetroFramework.MetroMessageBox.Show(this,"Se ha Guardado correctamente", "",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {            
            Fotos form = new Fotos(this.cliente.NumeroDeCuenta);
            form.ShowDialog();
        }
    }
}

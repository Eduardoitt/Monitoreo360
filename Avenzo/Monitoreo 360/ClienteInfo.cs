using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Google.Apis.Auth.OAuth2;
using Monitoreo_360.Models;
namespace Monitoreo_360
{
    public partial class ClienteInfo : MetroFramework.Forms.MetroForm
    {
        private AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        private Guid IdIncidente;
        Models.Clientes cliente = new Models.Clientes();
        public ClienteInfo()
        {
            InitializeComponent();
        }
        public void setInfo(Models.Clientes cliente)
        {            
            this.cliente = cliente;
            textBox_TelefonoAlarma.Text = cliente.NumeroTelefonoAlarma;
            textBox_Telefono.Text = cliente.Telefono;
            textBox_Cliente.Text = cliente.Nombres + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
            textBox_Direccion.Text = "Colonia " + cliente.Colonia + ", Calle " + cliente.Calle + " No Interior " + cliente.NoInterior + " No Exterior " + cliente.NoExterior + "\n Entre calles:" + cliente.EntreCalles + ", Color de Establecimiento:" + cliente.ColorEstablecimiento;
            textBox_Estado.Text = cliente.Estado;
            textBox_Ciudad.Text = cliente.Ciudad;
            textBox_Correo.Text = cliente.Email;
            textBox_Pais.Text = cliente.Pais;
            textBox_PalabraClave.Text = cliente.PalabraClave;
            textBox_Fecha.Text = cliente.FechaCreacion.ToString();            
            List<GetClienteContactos_Result> contactos = db.GetClienteContactos(2, cliente.IdCliente).ToList();
            foreach (var contacto in contactos.OrderBy(x=>x.Prioridad)) {
                var n = dataGridView_Contactos.Rows.Add();
                this.dataGridView_Contactos.Rows[n].Cells[0].Value = contacto.Id;
                this.dataGridView_Contactos.Rows[n].Cells[1].Value = contacto.Prioridad;
                this.dataGridView_Contactos.Rows[n].Cells[2].Value = contacto.Nombre;
                this.dataGridView_Contactos.Rows[n].Cells[3].Value = "";
                this.dataGridView_Contactos.Rows[n].Cells[4].Value = contacto.Telefono;
            }
        }     

        private void ClienteInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        private void dataGridView_Contactos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.RowIndex >= 0)
            {
                Guid id = Guid.Parse(this.dataGridView_Contactos.Rows[e.RowIndex].Cells[0].Value.ToString());
                ReporteContacto reporteContatcto = new ReporteContacto(IdIncidente, id);
                reporteContatcto.ShowDialog();
            }                     
        }
    }
}

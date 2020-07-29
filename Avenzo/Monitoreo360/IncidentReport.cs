using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace TestApp
{
    public partial class IncidentReport : Form
    {
        AvenzoSeguridad2Entities avenzoDB = new AvenzoSeguridad2Entities();
        Guid clientContactID;
        Guid incidentReportID;
        Guid? clientID;
        IEnumerable<GetInfoContactoByID_Result> results;
        List<GetCatalogoByNombreCatalogo_Result> catalogList;
        List<GetCatalogoByNombreCatalogo_Result> catalog;
        public IncidentReport(Guid incidentID, Guid clientContact)
        {
            InitializeComponent();
            clientContactID = clientContact;
            incidentReportID = incidentID;

        }

        private void IncidentReport_Load(object sender, EventArgs e)
        {
            results = avenzoDB.GetInfoContactoByID(clientContactID).ToList();
            clientID = results.First().IdCliente;

            GetClienteByClientID_Result nombreCliente = avenzoDB.GetClienteByClientID(clientID).First();

            //txtClientName.Text = avenzoDB.GetClienteByClientID(clientID).First().Nombres.ToString();
            txtClientName.Text = nombreCliente.Nombres + " " + nombreCliente.ApellidoPaterno + " " + nombreCliente.ApellidoMaterno;
            txtClientContact.Text = results.First().NombreClienteContacto.ToString();
            txtContactAddress.Text = results.First().DireccionClienteContacto.ToString();
            txtContactPhoneNumber.Text = results.First().TelefonoClienteContacto.ToString();

            catalogList = avenzoDB.GetCatalogoByNombreCatalogo("Estatus").Where(x => x.activo == true).ToList();
            catalog = avenzoDB.GetCatalogoByNombreCatalogo("Estatus").Where(x => x.activo == true).ToList();

            catalogList.InsertRange(catalogList.Count, catalog);

            catalogList.ElementAt(0).Descripcion = "Seleccione un estatus";
            catalogList.ElementAt(0).Valor = 0;

            cbStatus.DataSource = catalogList;

            cbStatus.DisplayMember = "Descripcion";
            cbStatus.ValueMember = "Descripcion";

            cbStatus.SelectedIndex = 0;

            if (avenzoDB.GetIncidentesComentarios(incidentReportID, clientContactID).Count() > 0)
            {
                txtIncidentDescription.Text = avenzoDB.GetIncidentesComentarios(incidentReportID, clientContactID).First().Descripcion;
                cbStatus.SelectedIndex = cbStatus.FindStringExact(avenzoDB.GetIncidentesComentarios(incidentReportID, clientContactID).First().EstatusLlamada);
            }

            //cbStatus.Items.Insert(cbStatus.Items.Count + 1, "Seleccione un estatus.");
            //cbStatus.SelectedIndex = cbStatus.Items.Count + 1;
            //cbStatus.DataSource = catalogs;
            //cbStatus.SelectedIndex = 0;
            
            
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtIncidentDescription.Text == string.Empty)
            {
                MessageBox.Show("Favor de proporcionar una descripción");
                return;
            }

            if (cbStatus.SelectedIndex == 0)
            {
                MessageBox.Show("Favor de indicar un estatus");
                return;
            }

            if (avenzoDB.GetIncidentesComentarios(incidentReportID, clientContactID).Count() > 0)
            {
                avenzoDB.EditIncidentesComentarios(incidentReportID, clientContactID, txtIncidentDescription.Text, cbStatus.SelectedValue.ToString());
                this.Close();
            }
            
            else
            {
                avenzoDB.InsertIncidentesComentarios(incidentReportID, clientContactID, txtIncidentDescription.Text, cbStatus.SelectedValue.ToString(), "avenzoProtect");
                this.Close();
            }
            
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}

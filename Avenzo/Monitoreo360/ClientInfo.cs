using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;

namespace TestApp
{
    public partial class ClientInfo : Form
    {
        string recievedNumberTemp;
        Guid clientID;
        Guid incidentID;
        DateTime manualEnd;
        bool manualModeFlag = false;
        IEnumerable<GetClienteByPhoneNumberOrAccountNumber_Result> results;
        IEnumerable<GetClienteContactosByID_Result> resultsContacts;
        AvenzoSeguridad2Entities avenzoDB = new AvenzoSeguridad2Entities();
        //public ClientInfo()
        //{
        //    InitializeComponent();
        //}
        System.Media.SoundPlayer sound = new System.Media.SoundPlayer();
        public ClientInfo(string recievedNumber)
        {
            InitializeComponent();
            recievedNumberTemp = recievedNumber;
            incidentID = Guid.NewGuid();
            results = avenzoDB.GetClienteByPhoneNumberOrAccountNumber(recievedNumberTemp, null).ToList();

            
            sound.SoundLocation = ConfigurationSettings.AppSettings["alarmSound"];
            sound.Load();
            sound.PlayLooping();
    
            try
            {
                clientID = results.First().IdCliente;
            }
            catch
            {
                MessageBox.Show("Numero de alarma inexistente");
                this.Close();
                this.Dispose();
            }
    
            avenzoDB.InsertIncidentes(incidentID, clientID, "", "", "avenzoProtect");

        }

        public ClientInfo(string recievedNumber,DateTime dateStart, DateTime dateEnd,string manualMode)
        {
            InitializeComponent();
            incidentID = Guid.NewGuid();
            manualEnd = dateEnd;
            results = avenzoDB.GetClienteByPhoneNumberOrAccountNumber(recievedNumber,null).ToList();
            manualModeFlag = true;

            sound.SoundLocation = ConfigurationSettings.AppSettings["alarmSound"];
            sound.Load();
            sound.PlayLooping();

            try
            {
                clientID = results.First().IdCliente;
            }
            catch
            {
                sound.Stop();
                MessageBox.Show("Numero de alarma inexistente");
                this.Close();
            }
           

            avenzoDB.InsertIncidentesManuales(incidentID, clientID, "",dateStart ,"", "avenzoProtect");


        }


        private void ClientInfo_Load(object sender, EventArgs e)
        {
           
            //resultsTemp = 
            //    avenzoDB.Clientes.Select(x => x).Where(y=>y.TelefonoCliente.Equals(recievedNumberTemp));
            txtAlarmPhoneNumber.Text = results.First().NumeroTelefonoAlarma;
            txtClientTelephoneNumber.Text = results.First().Telefono;
            txtCity.Text = results.First().Ciudad;
            txtClientAddress.Text = "Calle: " + results.First().Calle + " Número Exterior:" + results.First().NoExterior + " Número Interior: " + results.First().NoInterior + " Colonia: " + results.First().Colonia + " Ciudad: " + results.First().Ciudad + " CP: " + results.First().CodigoPostal;
            txtClientName.Text = results.First().Nombres + " " + results.First().ApellidoPaterno + " " + results.First().ApellidoMaterno;
            txtClientSince.Text = results.First().FechaCreacion.ToString();
            txtCountry.Text = results.First().Pais;
            txtCodeWord.Text = results.First().PalabraClave;
            txtSilentCodeWord.Text = results.First().PalabraClaveSilenciosa;
            txtClientEmail.Text = results.First().Email;
            txtState.Text = results.First().Estado;
            txtCatalogo.Text = avenzoDB.GetCatalogo(results.First().TipoAfilacion,1).First().Nombre;
            resultsContacts = avenzoDB.GetClienteContactosByID(clientID);//.OrderBy(x => x.PrioridadContacto);
            //DataTable dt = resultsContacts.ToDataTable();
            gvEmergencyContacts.DataSource = resultsContacts;

            gvEmergencyContacts.Columns["IdClienteContacto"].Visible = false;
            gvEmergencyContacts.Columns["IdCliente"].Visible = false;
            gvEmergencyContacts.Columns["FechaCreacion"].Visible = false;
            gvEmergencyContacts.Columns["UsuarioCreacion"].Visible = false;
            gvEmergencyContacts.Columns["NumeroTelefonoAlarma"].HeaderText = "Número de la Alarma";
            gvEmergencyContacts.Columns["NombreClienteContacto"].HeaderText = "Nombre del Contacto";
            gvEmergencyContacts.Columns["DireccionClienteContacto"].HeaderText = "Dirección del Contacto";
            gvEmergencyContacts.Columns["TelefonoClienteContacto"].HeaderText = "Teléfono del Contacto";
            gvEmergencyContacts.Columns["PrioridadContacto"].HeaderText = "Prioridad";

        }


        private void btnCloseIncident_Click(object sender, EventArgs e)
        {
            if (txtAgentsComments.Text == string.Empty)
            {
                MessageBox.Show("Favor de proporcionar comentarios");
                return;
            }
            else
            {
                if (manualModeFlag == false)
                {
                    avenzoDB.CloseIncidentes(incidentID, txtAgentsComments.Text);
                }
                else 
                {
                    avenzoDB.CloseIncidentesManual(incidentID, txtAgentsComments.Text,manualEnd);
                }
                avenzoDB.CloseIncidentesComentarios(incidentID);
                this.Close();
            }
        }

        private void gvEmergencyContacts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Guid contactID = new Guid(gvEmergencyContacts.Rows[e.RowIndex].Cells["IdClienteContacto"].Value.ToString());

            IncidentReport incidentReportWindow = new IncidentReport(incidentID, contactID);
            incidentReportWindow.ShowDialog();
            
        }

        private void pbClientPhoto_Paint(object sender, PaintEventArgs e)
        {
            Rectangle borderRect = e.ClipRectangle;

            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(192, 37, 30), 2),borderRect);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            sound.Stop();
            sound.Dispose();
        }

    }

}

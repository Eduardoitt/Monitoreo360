using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;

namespace TestApp
{
    public partial class ManualCall : Form
    {
        AvenzoSeguridad2Entities avenzoDB = new AvenzoSeguridad2Entities();
        Guid clientContactID;
        Guid incidentReportID;
        Guid clientID;
        IEnumerable<GetInfoContactoByID_Result> results;
        List<GetCatalogo_Result> catalogList;
        List<GetCatalogo_Result> catalog;
        public ManualCall()
        {
            InitializeComponent();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            
            DateTime temp;
            DateTime StartDate=DTStart.Value;
            DateTime EndDate=DTEND.Value;
           /* if (DateTime.TryParse(txtStartDate.Text, out temp)&&DateTime.TryParse(txtEndDate.Text, out temp))
            {*/
                try
                {

                    ClientInfo manualClient = new ClientInfo(txtAlarmNumber.Text ,StartDate, EndDate, "Manual");
                    manualClient.Show();
                    this.Close();
                }
                catch(Exception Ex)
                {
                    Console.WriteLine("Error:"+Ex.Message);
                    return;
                }
            /*}
            else 
            {
                MessageBox.Show("Favor de proporcionar una fecha valida");
                return;
                
            }*/
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}

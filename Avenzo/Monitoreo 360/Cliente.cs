using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monitoreo_360.Models;
using System.Threading;
using MetroFramework;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp;
using FireSharp.Response;

namespace Monitoreo_360
{
    public partial class Cliente : MetroFramework.Forms.MetroForm
    {
        
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        delegate void setDataList(Models.Clientes cliente);
        delegate void setVisibleGridView(bool visible);
        Guid IdUsuario;
        public Cliente(Guid IdUsuario)
        {
            this.IdUsuario = IdUsuario;
            
            InitializeComponent();
            Data();
            

        }
        async void Data() {
            await Task.Run(() => {
               var finallyDB= getData();
                if (finallyDB)
                    setVisibleDataGridView(true);
               
            });
        }
        public bool  getData() {
            List<Models.Clientes> clientes = new List<Models.Clientes>();
            Guid prove = Guid.Parse("9b13afbb-1455-483e-84d5-cf339dc7ff16");
            clientes = db.Clientes.Where(x => x.IdProveedor == prove).OrderBy(x => x.Nombres).ToList();
            int n = 0;
            foreach (var cliente in clientes)
            {

                setDataGridView(cliente);
            }            
            return true;       
        }
        public void setVisibleDataGridView(bool visible) {
            if (dataGridView_Clientes.InvokeRequired) {
                setVisibleGridView d =new setVisibleGridView(setVisibleDataGridView);
                this.Invoke(d, new object[] { visible});
            }
            else { 
                dataGridView_Clientes.Visible = visible ;
                metroProgressSpinner.Visible = !visible;
            }
        }
        public void setDataGridView(Models.Clientes cliente)
        {
            if (dataGridView_Clientes.InvokeRequired)
            {
                setDataList d = new setDataList(setDataGridView);
                this.Invoke(d, new object[] { cliente });
            }
            else
            {
                var n = this.dataGridView_Clientes.Rows.Add();
                dataGridView_Clientes.Rows[n].Cells[0].Value = cliente.IdCliente;
                dataGridView_Clientes.Rows[n].Cells[1].Value = cliente.NumeroDeCuenta;
                dataGridView_Clientes.Rows[n].Cells[2].Value = cliente.Nombres;
                dataGridView_Clientes.Rows[n].Cells[3].Value = cliente.ApellidoPaterno;
                dataGridView_Clientes.Rows[n].Cells[4].Value = cliente.ApellidoMaterno;
                dataGridView_Clientes.Rows[n].Cells[6].Value = cliente.NumeroTelefonoAlarma;
                dataGridView_Clientes.Rows[n].Cells[5].Value = cliente.Telefono;
                dataGridView_Clientes.Rows[n].Cells[7].Value = cliente.Email;
                //                dataGridView_Clientes.Rows[n].Cells[9].Nam
                //dataGridView_Clientes.Rows[n].Cells[8].Value = "Editar";
            }
        }
        private void metroTextBox_Filter_TextChanged(object sender, EventArgs e)
        {

            // dataGridView_Clientes.Refresh();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {

        }

        private async void dataGridView_Clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                ClienteEdit CE = new ClienteEdit(Guid.Parse(dataGridView_Clientes.Rows[e.RowIndex].Cells[0].Value.ToString()),this.IdUsuario);                
                CE.ShowDialog();
                
                /*IFirebaseConfig config = new FirebaseConfig
                {
                    AuthSecret = "y9qo73rzWLMhKRHqAsgXpbO53XvE1GK0tf0Pm9O2",
                    BasePath = "https://monitoreo-360.firebaseio.com/"
                };
                IFirebaseClient client = new FirebaseClient(config);
                DateTime now = DateTime.Now;
                Random r = new Random();
                int aleatorio = r.Next(0, 10);
                var todo = new Alertas
                {
                    Activo = true,
                    CodigoDeAlarma = "BH",
                    Color = 2,
                    Fecha = now.Year+"-"+now.Month+"-"+now.Day+" "+now.Hour+":"+now.Minute+":"+now.Second+"."+now.Millisecond,
                    FechaRecibido ="",
                    Id= aleatorio,
                    Recibido=false,
                    Sensor="001",
                    Usuario="001",
                    UsuarioCreacion="001"
                };
                SetResponse response = await client.SetAsync("Alertas/20172017/"+ aleatorio, todo);
                Alertas result = response.ResultAs<Alertas>();*/
                //Guid Id = Guid.Parse(senderGrid.Name);
                //TODO - Button Clicked - Execute Code Here
            }
        }

        private void dataGridView_Clientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            new ClienteEdit(Guid.Parse(dataGridView_Clientes.Rows[e.RowIndex].Cells[0].Value.ToString()), IdUsuario).ShowDialog();
        }
    }
  

}

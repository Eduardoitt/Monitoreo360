using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace Monitoreo_360
{
    public partial class Clientes : UserControl
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        delegate void setDataList(Model.Clientes cliente);
        delegate void setVisibleGridView(bool visible);
        Guid prove = Guid.Parse("9b13afbb-1455-483e-84d5-cf339dc7ff16");
        public Clientes()
        {
            InitializeComponent();
            this.ProgressBar.Value = 5;
            Data();
        }

        async void Data()
        {
            await Task.Run(() => {
                var finallyDB = getData();
                if (finallyDB)
                    setVisibleDataGridView(true);

            });
        }
        public bool getData()
        {
            List<Model.Clientes> clientes = new List<Model.Clientes>();
            Guid prove = Guid.Parse("9b13afbb-1455-483e-84d5-cf339dc7ff16");
            clientes = db.Clientes.Where(x => x.IdProveedor == prove).OrderBy(x => x.Nombres).ToList();
            //this.ProgressBar.MaximumValue = clientes.Count() + 5;
            foreach (var cliente in clientes)
            {

                setDataGridView(cliente);
            }
            return true;
        }

        public void setVisibleDataGridView(bool visible)
        {
            if (DataGrid_Clientes.InvokeRequired)
            {
                setVisibleGridView d = new setVisibleGridView(setVisibleDataGridView);
                this.Invoke(d, new object[] { visible });
            }
            else
            {
                DataGrid_Clientes.Visible = visible;
                ProgressBar.Visible = !visible;
            }
        }
        public void setDataGridView(Model.Clientes cliente)
        {
            if (DataGrid_Clientes.InvokeRequired)
            {
                setDataList d = new setDataList(setDataGridView);
                this.Invoke(d, new object[] { cliente });
            }
            else
            {
                //var n = this.DataGrid_Clientes.Rows.Add();
                //this.ProgressBar.Value += 1;
                //DataGrid_Clientes.Rows[n].Cells[0].Value = cliente.IdCliente;
                //DataGrid_Clientes.Rows[n].Cells[1].Value = cliente.NumeroDeCuenta;
                //DataGrid_Clientes.Rows[n].Cells[2].Value = cliente.Nombres;
                //DataGrid_Clientes.Rows[n].Cells[3].Value = cliente.ApellidoPaterno;
                //DataGrid_Clientes.Rows[n].Cells[4].Value = cliente.ApellidoMaterno;                
                //DataGrid_Clientes.Rows[n].Cells[5].Value = cliente.Telefono;
                //DataGrid_Clientes.Rows[n].Cells[6].Value = cliente.Email;
                //DataGrid_Clientes.Rows[n].Cells[7].Value = cliente.NumeroTelefonoAlarma;
                
                //                dataGridView_Clientes.Rows[n].Cells[9].Nam
                //dataGridView_Clientes.Rows[n].Cells[8].Value = "Editar";
            }
        }

        private void DataGrid_Clientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
           // new ClienteEdit(Guid.Parse(DataGrid_Clientes.Rows[e.RowIndex].Cells[0].Value.ToString()), Guid.Parse("8bead89f-b0ca-4ca9-9268-4de6c727e3a2")).ShowDialog();
        }
    }
}

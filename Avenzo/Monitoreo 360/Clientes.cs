using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monitoreo_360.Models;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace Monitoreo_360
{
    public partial class Clientes : UserControl
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        delegate void setDataList(Models.Clientes cliente);
        delegate void setVisibleGridView(bool visible);
        delegate void setpreviewValue(int max);
        Guid prove = Guid.Parse("9b13afbb-1455-483e-84d5-cf339dc7ff16");
        public Clientes()
        {
            InitializeComponent();

            this.ProgressBar.Minimum = 5;
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
            List<Models.Clientes> clientes = new List<Models.Clientes>();
            Guid prove = Guid.Parse("9b13afbb-1455-483e-84d5-cf339dc7ff16");
            clientes = db.Clientes.Where(x => x.IdProveedor == prove).OrderBy(x => x.Nombres).ToList();


            //ProgressBar.Maximum = clientes.Count() + 5;
            int max = clientes.Count() + 5;
            setMaximum(max);
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

        public void setMaximum(int max)
        {
            if (DataGrid_Clientes.InvokeRequired)
            {
                setpreviewValue d = new setpreviewValue(setMaximum);
                this.Invoke(d, new object[] { max });
            }
            else
            {
                ProgressBar.Maximum = max;
            }
        }
        public void setDataGridView(Models.Clientes cliente)
        {

            if (DataGrid_Clientes.InvokeRequired)
            {
                setDataList d = new setDataList(setDataGridView);
                this.Invoke(d, new object[] { cliente });
            }
            else
            {
                var n = DataGrid_Clientes.Rows.Add();
                this.ProgressBar.Value += 1;
                DataGrid_Clientes.Rows[n].Cells[0].Value = cliente.IdCliente;
                DataGrid_Clientes.Rows[n].Cells[1].Value = cliente.NumeroDeCuenta;
                DataGrid_Clientes.Rows[n].Cells[2].Value = cliente.Nombres;
                DataGrid_Clientes.Rows[n].Cells[3].Value = cliente.ApellidoPaterno;
                DataGrid_Clientes.Rows[n].Cells[4].Value = cliente.ApellidoMaterno;
                DataGrid_Clientes.Rows[n].Cells[5].Value = cliente.Telefono;
                DataGrid_Clientes.Rows[n].Cells[6].Value = cliente.Email;
                DataGrid_Clientes.Rows[n].Cells[7].Value = cliente.NumeroTelefonoAlarma;
  
            }
        }

        private void DataGrid_Clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;
            new ClienteEdit(Guid.Parse(DataGrid_Clientes.Rows[e.RowIndex].Cells[0].Value.ToString()), Guid.Parse("8bead89f-b0ca-4ca9-9268-4de6c727e3a2")).ShowDialog();
        }
         

    }
}

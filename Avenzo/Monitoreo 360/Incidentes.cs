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
using System.Globalization;

namespace Monitoreo_360
{
    public partial class Incidentes : UserControl
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        delegate void setDataList(Model.Incidentes incidente);
        delegate void setVisibleGridView(bool visible);
        Guid prove = Guid.Parse("9b13afbb-1455-483e-84d5-cf339dc7ff16");
        public Incidentes()
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
            List<Model.Incidentes> incidentes = new List<Model.Incidentes>();
            incidentes = db.Incidentes.Where(x => x.Activo==true).ToList();
            this.ProgressBar.MaximumValue = incidentes.Count() + 5;
            foreach (var incidente in incidentes)
            {

                setDataGridView(incidente);
            }
            return true;
        }
        public void setVisibleDataGridView(bool visible)
        {
            if (DataGrid_Incidentes.InvokeRequired)
            {
                setVisibleGridView d = new setVisibleGridView(setVisibleDataGridView);
                this.Invoke(d, new object[] { visible });
            }
            else
            {
                DataGrid_Incidentes.Visible = visible;
                ProgressBar.Visible = !visible;
            }
        }
        public void setDataGridView(Model.Incidentes incidente)
        {
            if (DataGrid_Incidentes.InvokeRequired)
            {
                setDataList d = new setDataList(setDataGridView);
                this.Invoke(d, new object[] { incidente });
            }
            else
            {
                Model.Clientes cliente = db.Clientes.Where(x => x.IdCliente == incidente.IdCliente).FirstOrDefault();
                CultureInfo CI = new CultureInfo("es-MX");
                Model.LogMonitoreo360 Log = db.LogMonitoreo360.Where(x => x.Id == incidente.IdLog).FirstOrDefault();
                string report = Log.Log.Substring(66, Log.Log.Length - 66);
                string eventos = "";
                foreach (var evento in report.Split('-')[1].Split('/'))
                {
                    if (!evento.Contains("ri"))
                        eventos = eventos + " " + evento.Substring(0, 2);
                }
                var n = this.DataGrid_Incidentes.Rows.Add();
                this.ProgressBar.Value += 1;
                DataGrid_Incidentes.Rows[n].Cells[0].Value = incidente.Id;
                DataGrid_Incidentes.Rows[n].Cells[1].Value = cliente.Nombres + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
                DataGrid_Incidentes.Rows[n].Cells[2].Value = eventos;
                DataGrid_Incidentes.Rows[n].Cells[3].Value = incidente.FechaHoraInicio.ToString("dddd dd MMMM yyyy hh:mm:ss tt", CI);
                if (incidente.FechaHoraFin != null)
                    DataGrid_Incidentes.Rows[n].Cells[4].Value = ((DateTime)incidente.FechaHoraFin).ToString("dddd dd MMMM yyyy hh:mm:ss tt", CI);
                DataGrid_Incidentes.Rows[n].Cells[5].Value =  string.IsNullOrEmpty(incidente.Estatus) ? "Sin Seguimiento" : incidente.Estatus;
                
            }
        }

        private void DataGrid_Incidentes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Guid id = Guid.Parse(this.DataGrid_Incidentes.Rows[e.RowIndex].Cells[0].Value.ToString());
            Model.Incidentes Modelincidente = db.Incidentes.Where(model => model.Id == id).FirstOrDefault();
            Incidente incidente = new Incidente(Modelincidente);
            incidente.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
namespace Monitoreo_360
{
    public partial class Incidentes_ : MetroFramework.Forms.MetroForm
    {
        private Guid IdUsuario;
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        public Incidentes_()
        {
            InitializeComponent();
        }
        public void setInfo(Guid IdUsuario) {
            this.IdUsuario = IdUsuario;
            List<Model.Incidentes> Incidentes = db.Incidentes.Where(x => x.Activo == true).ToList();
            foreach (var Incidente in Incidentes) {
                Model.Clientes cliente = db.Clientes.Where(x => x.IdCliente == Incidente.IdCliente).FirstOrDefault();
                CultureInfo CI = new CultureInfo("es-MX");
                Model.LogMonitoreo360 Log = db.LogMonitoreo360.Where(x=>x.Id==Incidente.IdLog).FirstOrDefault();
                var n = Grid.Rows.Add();
                string report = Log.Log.Substring(66, Log.Log.Length - 66);
                string eventos = "";
                foreach (var evento in report.Split('-')[1].Split('/')) {
                    if(!evento.Contains("ri"))
                        eventos = eventos +" "+ evento.Substring(0,2);
                }
                
                Grid.Rows[n].Cells[0].Value = Incidente.Id;
                Grid.Rows[n].Cells[1].Value = cliente.Nombres + " "+cliente.ApellidoPaterno+" " + cliente.ApellidoMaterno;
                Grid.Rows[n].Cells[2].Value = eventos;
                Grid.Rows[n].Cells[3].Value = Incidente.FechaHoraInicio.ToString("dddd dd MMMM yyyy hh:mm:ss tt", CI);
                if (Incidente.FechaHoraFin != null)                
                    Grid.Rows[n].Cells[4].Value = ((DateTime)Incidente.FechaHoraFin).ToString("dddd dd MMMM yyyy hh:mm:ss tt", CI);
                Grid.Rows[n].Cells[5].Value = Incidente.Estatus == null?"Sin Seguimiento":Incidente.Estatus ;
            }
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Guid id = Guid.Parse(this.Grid.Rows[e.RowIndex].Cells[0].Value.ToString());
            Model.Incidentes Modelincidente=db.Incidentes.Where(model => model.Id == id).FirstOrDefault();
            Incidente incidente = new Incidente(Modelincidente);
            incidente.ShowDialog();
            
        }
    }
}

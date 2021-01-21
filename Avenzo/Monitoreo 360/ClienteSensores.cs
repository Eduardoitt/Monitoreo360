using MetroFramework;
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

namespace Monitoreo_360
{
    public partial class ClienteSensores : MetroFramework.Forms.MetroForm
    {
        private int RowIndex;
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        private Guid IdCliente;
        private Guid IdUsuario;
        public ClienteSensores(Guid IdUsuario)
        {
            InitializeComponent();
            this.IdUsuario = IdUsuario;
        }

        private void eliminarSensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MetroMessageBox.Show(this, "¿Estas seguro de eliminar el Sensor?", "Eliminar Sensor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Guid Id = Guid.Parse(this.dataGridView_Sensores.Rows[RowIndex].Cells[0].Value.ToString());                
                this.dataGridView_Sensores.Rows.Remove(this.dataGridView_Sensores.Rows[RowIndex]);
                db.DeleteSensores(Id, 0);
            }
        }

        private void dataGridView_Sensores_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Right) {
                int currentMouseOverRow = dataGridView_Sensores.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    RowIndex = currentMouseOverRow;
                    this.contextMenuStrip_Sensor.Show(dataGridView_Sensores, new Point(e.X, e.Y));
                }
            }
        }
        public void setInfo(Guid IdCliente)
        {
            this.IdCliente = IdCliente;
            List<GetSensores_Result> sensores = db.GetSensores(IdCliente, 2).ToList();
            int index = 0;
            foreach (var sensor in sensores) {
                index = this.dataGridView_Sensores.Rows.Add();
                this.dataGridView_Sensores.Rows[index].Cells[0].Value = sensor.Id;
                this.dataGridView_Sensores.Rows[index].Cells[1].Value = sensor.NumeroDeSensor;
                this.dataGridView_Sensores.Rows[index].Cells[2].Value = sensor.TipoSensor;
                this.dataGridView_Sensores.Rows[index].Cells[3].Value = sensor.Ubicacion;
            }
        }

        private void dataGridView_Sensores_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            Guid Id;
            string Numero = "";
            string TipoSensor = "";
            string Ubicacion = "";

            bool TS = false, U = false,N=false;

            if (this.dataGridView_Sensores.Rows[e.RowIndex].Cells[0].Value == null)
            {
                Id = Guid.NewGuid();
                dataGridView_Sensores.Rows[e.RowIndex].Cells[0].Value = Id;
            }
            else
            {
                Id = Guid.Parse(dataGridView_Sensores.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            if (dataGridView_Sensores.Rows[e.RowIndex].Cells[1].Value != null)
            {
                Numero = dataGridView_Sensores.Rows[e.RowIndex].Cells[1].Value.ToString();
                N = true;
            }
            else
            {
                N = false;
                dataGridView_Sensores.Rows[e.RowIndex].Cells[1].ErrorText = "Ingresa numero de sensor";
            }
            if (dataGridView_Sensores.Rows[e.RowIndex].Cells[2].Value != null)
            {
                TipoSensor = dataGridView_Sensores.Rows[e.RowIndex].Cells[2].Value.ToString();
                TS = true;
            }
            else
            {
                dataGridView_Sensores.Rows[e.RowIndex].Cells[2].ErrorText = "Escribe un tipo de sensor";
                TS = false;
            }
            if (dataGridView_Sensores.Rows[e.RowIndex].Cells[3].Value != null)
            {
                U = true;
                Ubicacion = dataGridView_Sensores.Rows[e.RowIndex].Cells[3].Value.ToString();
                dataGridView_Sensores.Rows[e.RowIndex].Cells[3].ErrorText = null;
            }
            else
            {
                U = false;
                dataGridView_Sensores.Rows[e.RowIndex].Cells[3].ErrorText = "Ingresa Ubicacion del sensor";
            }
            if (U && TS && N)
            {
                try
                {
                    db.InsertSensores(Id, IdCliente,Numero,TipoSensor,Ubicacion,  DateTime.Now, IdUsuario, true);
                }
                catch (Exception ex)
                {
                    db.UpdateSensores(Id, IdCliente,Numero,TipoSensor,Ubicacion, DateTime.Now, IdUsuario, true);
                }
            }
        }
    }
}

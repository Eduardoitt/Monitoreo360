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
    public partial class ReporteContacto : MetroFramework.Forms.MetroForm
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        Guid IdIncidente;
        Guid IdContacto;
        DateTime inicio;
        private Guid IdUsuario;
        public ReporteContacto(Guid IdIncidente,Guid IdContacto,Guid IdUsuario)
        {
            InitializeComponent();
            inicio = DateTime.Now;
            this.IdContacto = IdContacto;
            this.IdIncidente = IdIncidente;
            this.IdUsuario = IdUsuario;
        }

        private void metroButton_Guardar_Click(object sender, EventArgs e)
        {
            db.InsertReporteLlamada(Guid.NewGuid(), IdIncidente, IdContacto, metroTextBox_Comentarios.Text, inicio, DateTime.Now, metroComboBox_Llamada.Text, metroComboBox_Estatus.Text, true, DateTime.Now, IdUsuario);
            this.Close();
        }
    }
}

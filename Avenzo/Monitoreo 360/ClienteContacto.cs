using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using Monitoreo_360.Models;

namespace Monitoreo_360
{
    public partial class ClienteContacto : MetroFramework.Forms.MetroForm
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        private Guid IdCliente;
        private int RowIndex;
        private Guid IdUsuario;
        public ClienteContacto(Guid IdCliente, Guid IdUsuario)
        {
            InitializeComponent();
            this.IdCliente = IdCliente;
            this.IdUsuario = IdUsuario;
            List<GetClienteContactos_Result> contactos= db.GetClienteContactos(2, IdCliente).ToList();
            int n;
            foreach (var contacto in contactos.OrderBy(x=>x.Prioridad)) {
                n = metroGrid_Contactos.Rows.Add();
                metroGrid_Contactos.Rows[n].Cells[0].Value = contacto.Id;
                metroGrid_Contactos.Rows[n].Cells[1].Value = contacto.Nombre;
                metroGrid_Contactos.Rows[n].Cells[2].Value = contacto.Telefono;
               // metroGrid_Contactos.Rows[n].Cells[3].Value = "";
                metroGrid_Contactos.Rows[n].Cells[3].Value = contacto.Prioridad;
            }
        }

        private void metroGrid1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Guid Id;
            string Phone = "";
            string Relationship = "";
            int Priority = 0;
            string Name = "";
            bool N = false, R = false,P=false,PR=false;
            
            if (metroGrid_Contactos.Rows[e.RowIndex].Cells[0].Value==null) {
                Id = Guid.NewGuid();
                metroGrid_Contactos.Rows[e.RowIndex].Cells[0].Value = Id;
            }
            else
            {
                Id=Guid.Parse(metroGrid_Contactos.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            //Nombre
            if (metroGrid_Contactos.Rows[e.RowIndex].Cells[1].Value!=null) {                
                Name = metroGrid_Contactos.Rows[e.RowIndex].Cells[1].Value.ToString();               
                N = true;
            }
            else {             
                metroGrid_Contactos.Rows[e.RowIndex].Cells[1].ErrorText = "Escribe un Nombre";
                N = false;
            }
            //Telefono
            if (metroGrid_Contactos.Rows[e.RowIndex].Cells[2].Value != null)
            {
                P = true;
                Phone = metroGrid_Contactos.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            else
            {
                P = false;
                metroGrid_Contactos.Rows[e.RowIndex].Cells[2].ErrorText = "Escribe un numero de telefono";
            }
            //Prioridad
            if (metroGrid_Contactos.Rows[e.RowIndex].Cells[3].EditedFormattedValue != null && metroGrid_Contactos.Rows[e.RowIndex].Cells[3].EditedFormattedValue !="")
            {
                PR = true;
                Priority = int.Parse(metroGrid_Contactos.Rows[e.RowIndex].Cells[3].EditedFormattedValue.ToString());
            }
            else {
                PR = false;
                metroGrid_Contactos.Rows[e.RowIndex].Cells[3].ErrorText = "Escribe la prioridad";
            }
            if (N &&  P && PR)
            {
                try {
                    db.InsertClienteContacto(Id, IdCliente, Name, "", Phone, Priority, DateTime.Now, IdUsuario, true);
                } catch (Exception ex)
                {
                    db.UpdateClienteContactos(Id, IdCliente, Name,"", Phone, Priority, DateTime.Now, IdUsuario, true);
                }
            }
        }

        private void metroGrid_Contactos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Right)
            {                
                int currentMouseOverRow = metroGrid_Contactos.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow>=0) {
                    RowIndex = currentMouseOverRow;
                    this.contextMenuStrip_Contactos.Show(metroGrid_Contactos, new Point(e.X, e.Y));
                }
                
            }
        }

        private void eliminarContactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MetroMessageBox.Show(this, "¿Estas seguro de eliminar el Contacto?", "Eliminar Contacto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Guid Id=Guid.Parse(this.metroGrid_Contactos.Rows[RowIndex].Cells[0].Value.ToString());
                db.DeleteClienteContactos(0, Id);
                this.metroGrid_Contactos.Rows.Remove(this.metroGrid_Contactos.Rows[RowIndex]);
            }
        }
    }
}

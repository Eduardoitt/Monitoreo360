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

namespace Monitoreo_360
{
    public partial class Usuarios : UserControl
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        delegate void setDataList(Models.Usuarios usuario);
        delegate void setVisibleGridView(bool visible);
        delegate void setMaximun(int max);
        public Usuarios()
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
            List<Models.Usuarios> usuarios = new List<Models.Usuarios>();

            usuarios = db.Usuarios.OrderBy(x => x.Usuario).ToList();
            //this.ProgressBar.Maximum = usuarios.Count() + 5;
            int max = usuarios.Count() + 5;
            setMaximo(max);
            foreach (var usuario in usuarios)
            {

                setDataGridView(usuario);
            }
            return true;
        }
        public void setVisibleDataGridView(bool visible)
        {
            if (DataGrid_Usuarios.InvokeRequired)
            {
                setVisibleGridView d = new setVisibleGridView(setVisibleDataGridView);
                this.Invoke(d, new object[] { visible });
            }
            else
            {
                DataGrid_Usuarios.Visible = visible;
                ProgressBar.Visible = !visible;
            }
        }
        public void setMaximo(int max)
        {
            if (DataGrid_Usuarios.InvokeRequired)
            {
                setMaximun dg = new setMaximun(setMaximo);
                this.Invoke(dg,new object[] { max});
            }
            else
            {
                ProgressBar.Maximum = max;
            }
        }
        public void setDataGridView(Models.Usuarios usuario)
        {
            if (DataGrid_Usuarios.InvokeRequired)
            {
                setDataList d = new setDataList(setDataGridView);
                this.Invoke(d, new object[] { usuario });
            }
            else
            {
                var n = this.DataGrid_Usuarios.Rows.Add();
                this.ProgressBar.Value += 1;
                DataGrid_Usuarios.Rows[n].Cells[0].Value = usuario.Id;
                DataGrid_Usuarios.Rows[n].Cells[1].Value = usuario.Usuario;
                DataGrid_Usuarios.Rows[n].Cells[2].Value = usuario.TipoUsuario;
                DataGrid_Usuarios.Rows[n].Cells[3].Value = usuario.Roles;
                DataGrid_Usuarios.Rows[n].Cells[4].Value = usuario.Activo;
            }
        }

    }
}

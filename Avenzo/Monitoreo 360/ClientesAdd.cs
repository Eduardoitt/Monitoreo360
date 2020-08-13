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
    public partial class ClientesAdd : MetroFramework.Forms.MetroForm
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        private Guid IdUsuario;
        List<Bancos> bancos = new List<Bancos>();
        public ClientesAdd( Guid IdUsuario)
        {
            this.IdUsuario = IdUsuario;
            InitializeComponent();
        }
        async void Data()
        {
            await Task.Run(() => {
                 getData();
            });     
        }
        public bool getData()
        {
            bancos = db.Bancos.ToList();
            ValBanco();
            return true;
        }

        public void ValBanco()
        {
            if (this.CB_Banco.InvokeRequired)
            {
                this.CB_Banco.Invoke(new MethodInvoker(delegate {
                    this.CB_Banco.DataSource = bancos;
                    this.CB_Banco.ValueMember = "c_Banco";
                    this.CB_Banco.DisplayMember = "Descripcion";
                    
                }));
            }
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            //Aqui hacer el insert
            if (txt_Nombres.Text == "" || txt_Nombres.Text == null)
            {
                MetroMessageBox.Show(this, "El campo Nombre (s) no puede ir vacio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txt_ApPat.Text == "" || txt_ApPat.Text == null)
            {
                MetroMessageBox.Show(this, "El campo Apellido Paterno no puede ir vacio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txt_ApMat.Text == "" || txt_ApMat.Text == null)
            {
                MetroMessageBox.Show(this, "El campo Apellido Materno no puede ir vacio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txt_Sexo.Text == "" || txt_Sexo.Text == null)
            {
                MetroMessageBox.Show(this, "El campo Sexo no puede ir vacio, favor de ingresar Femenino o Masculino", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                Guid IdCliente = Guid.NewGuid();
                DateTime fechaC = DateTime.Now;

                Guid IdProveedor = Guid.Parse("9B13AFBB-1455-483E-84D5-CF339DC7FF16");
                db.InsertClientes(IdCliente, IdProveedor, null, txt_TelAlarma.Text.Trim(), txt_Nombres.Text.Trim(),
                    txt_ApPat.Text.Trim(), txt_ApMat.Text.Trim(), txt_NoCuenta.Text.Trim(), null, null, null, null, null, null, null,
                    null, null, null, null, null, txt_Telefono.Text.Trim(), txt_Telefono.Text.Trim(), txt_TelCelular.Text.Trim(), txt_Correo.Text.Trim(),
                    null, null, null, null, null, txt_NumPat.Text, DT_FechaNac.Value.ToString(), txt_LugNac.Text, txt_Sexo.Text, txt_EstadoCivil.Text,
                    txt_Profesion.Text, txt_CURP.Text.Trim(), txt_RFC.Text.Trim(), CB_Banco.SelectedValue.ToString(), txt_NumCatPago.Text,
                    txt_ClaveBanc.Text.Trim(), txt_NumClave.Text, txt_Beneficiario.Text,fechaC , IdUsuario, true);

                ClientesAdd.ActiveForm.Close();
                MetroMessageBox.Show(this, "El Cliente fue registrado con exito", "Cliente Registrado", MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
        }

        private void ClientesAdd_Shown(object sender, EventArgs e)
        {
            Data();
        }
    }
}

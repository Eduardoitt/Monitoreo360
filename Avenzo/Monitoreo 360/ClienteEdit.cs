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
    public partial class ClienteEdit : MetroFramework.Forms.MetroForm
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        Models.Clientes cliente = new Models.Clientes();
        Guid Id = new Guid();
        Guid IdUsuario = Guid.NewGuid();
        List<Bancos> bancos = new List<Bancos>();
        List<Catalogos> catalogo = new List<Catalogos>();
        delegate void setCliente();
        delegate void setVisiblePanel();
        public ClienteEdit(Guid Id,Guid IdUsuario)
        {
            this.Id = Id;
            this.IdUsuario=IdUsuario;
            InitializeComponent();
           
            
        }
        async void Data() {
            await Task.Run(() => {
                var finallyDB = getData();
                if (finallyDB)
                    setPanel();
            });
        }
        public void setPanel() {
            if (metroPanel.InvokeRequired) {
                setVisiblePanel d = new setVisiblePanel(setPanel);
                this.Invoke(d);
            }
            else
            {
                this.metroPanel.Visible = true;
                this.metroProgressSpinner.Visible = false;
            }
        }
        public bool getData()
        {
            bancos = db.Bancos.ToList();
            catalogo = db.Catalogos.ToList();
            cliente = db.Clientes.Where(x => x.IdCliente == Id).FirstOrDefault();
            setData();
            return true;
        }

        public void setData() {
            
            setTextBoxValue(this.TextBox_NumeroDeCuenta, cliente.NumeroDeCuenta);
            setTextBoxValue(this.TextBox_Nombre, cliente.Nombres);
            setTextBoxValue(this.TextBox_ApellidoPaterno, cliente.ApellidoPaterno);
            setTextBoxValue(this.TextBox_ApellidoMaterno, cliente.ApellidoMaterno);
            setComboBoxAfiliacionValue(cliente.TipoAfilacion);
            setTextBoxValue(this.TextBox_Profesion, cliente.Profesion);
            setTextBoxValue(this.TextBox_Email, cliente.Email);
            setTextBoxValue(this.TextBox_EstadoCivil, cliente.EstadoCivil);
            setTextBoxValue(this.TextBox_Celular, cliente.TelefonoCelular);
            setTextBoxValue(this.TextBox_TelefonoTrabajo, cliente.TelefonoTrabajo);
            setTextBoxValue(this.TextBox_TelefonoCasa, cliente.Telefono);
            setTextBoxValue(this.TextBox_Profesion, cliente.LugarNacimiento);
            if(cliente.FechaNacimiento!=null)
                setDateTimeValue(this.metroDateTime_FechaNacimiento, DateTime.Parse(cliente.FechaNacimiento));
            setComboBoxSexoValue(cliente.Sexo);
            setTextBoxValue(this.TextBox_CURP, cliente.CURP);
            setTextBoxValue(this.TextBox_RFC, cliente.RFC);
            setTextBoxValue(this.TextBox_ClaveBancaria, cliente.ClaveBancaria);
            setTextBoxValue(this.TextBox_NumCTAPago, cliente.NumCtaPago);
            setTextBoxValue(this.TextBox_Beneficiario, cliente.Beneficiario);            
            setComboBoxBancoValue(cliente.Banco);            
        }
        //Bunifu.Framework.UI.BunifuMaterialTextbox field 
        public void setTextBoxValue(System.Windows.Forms.TextBox field , string value) {
            if (field.InvokeRequired) {
                field.Invoke(new MethodInvoker(delegate{ field.Text = value; }));
            }
        }
        public void setDateTimeValue(MetroFramework.Controls.MetroDateTime field, DateTime value)
        {
            if (field.InvokeRequired)
            {
                field.Invoke(new MethodInvoker(delegate { field.Value = value; }));
            }
        }

        public void setComboBoxAfiliacionValue(Guid? value) {
            if (this.metroComboBox_Afiliacion.InvokeRequired)
            {
                this.metroComboBox_Afiliacion.Invoke(new MethodInvoker(delegate {
                    foreach (var c in catalogo)
                        this.metroComboBox_Afiliacion.Items.Add(c.Descripcion);
                    if(db.Catalogos.Where(x => x.IdCatalogo == value).Any())
                        this.metroComboBox_Afiliacion.Text = db.Catalogos.Where(x => x.IdCatalogo == value).FirstOrDefault().Descripcion;
                }));
            }
        }

        public void setComboBoxSexoValue(string value)
        {
            if (this.metroComboBox_Sexo.InvokeRequired)
            {
                this.metroComboBox_Sexo.Invoke(new MethodInvoker(delegate {                    
                    this.metroComboBox_Sexo.Text = value;
                }));
            }
        }
        public void setComboBoxBancoValue(string value)
        {
            if (this.metroComboBox_Banco.InvokeRequired)
            {
                this.metroComboBox_Banco.Invoke(new MethodInvoker(delegate {
                    foreach (var b in bancos)
                        this.metroComboBox_Banco.Items.Add(b.Descripcion);
                    if (value != null)
                        this.metroComboBox_Banco.Text = db.Bancos.Where(x => x.c_Banco == value).FirstOrDefault().Descripcion; 
                }));
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton_Contactos_Click(object sender, EventArgs e)
        {
            ClienteContacto form = new ClienteContacto(cliente.IdCliente);
            //form.MdiParent = this.MdiParent;
            form.Text = "Editar Contactos de "+cliente.Nombres+" "+cliente.ApellidoPaterno+" "+cliente.ApellidoMaterno;
            form.ShowDialog();
        }

        private void metroButton_Usuario_Click(object sender, EventArgs e)
        {
            
            ClienteAccesos accesos = new ClienteAccesos(this);            
            //accesos.MdiParent = this.MdiParent;
            accesos.Text="Accesos para "+ cliente.Nombres + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
            accesos.setInfoAsync(cliente.IdCliente);
            accesos.ShowDialog();            
        }

        private void metroButton_Ubicacion_Click(object sender, EventArgs e)
        {
            Direccion form = new Direccion(this.Id,this.IdUsuario);
            form.ShowDialog();
        }

        private void metroButton_Sensores_Click(object sender, EventArgs e)
        {
            ClienteSensores sensores = new ClienteSensores();
            sensores.setInfo(cliente.IdCliente);
            sensores.ShowDialog();

        }

        private void metroButton_Horario_Click(object sender, EventArgs e)
        {
            HorarioOperacion form = new HorarioOperacion(this.IdUsuario);
            form.setInfo(this.Id);
            form.ShowDialog();
        }

        private void ClienteEdit_Shown(object sender, EventArgs e)
        {
            Data();
        }
    }
}

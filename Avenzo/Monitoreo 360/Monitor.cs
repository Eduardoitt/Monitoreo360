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
    public partial class Monitor : UserControl
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        delegate void setDataList(Model.Clientes cliente);
        delegate void setVisiblePanel(bool visible);
        private Guid prove = Guid.Parse("9b13afbb-1455-483e-84d5-cf339dc7ff16");
        private int width = 0;
        private int ClientesRow = 0;
        private int x = 5; int y = 5;
        private int count = 0;
        public Monitor()
        {
            InitializeComponent();
            this.ProgressBar.Value = 5;
        }
        public async void Data()
        {
            await Task.Run(() => {
                width = this.panel.Width;
                ClientesRow = ((int)(width / 35));
                x = 5;
                y = 5;
                count = 0;
                var finallyDB = getData();
                if (finallyDB)
                    setVisibleDataPanel(true);

            });
        }

        public bool getData()
        {
            Guid prove = Guid.Parse("9b13afbb-1455-483e-84d5-cf339dc7ff16");
            List<Model.Clientes> clientes = new List<Model.Clientes>();
            clientes = db.Clientes.Where(model => model.Activo == true && !string.IsNullOrEmpty(model.NumeroTelefonoAlarma) && !string.IsNullOrEmpty(model.NumeroDeCuenta) && model.IdProveedor == prove).ToList();
            this.ProgressBar.MaximumValue = clientes.Count() + 5;
            foreach (var cliente in clientes)
            {
                setDataPanel(cliente);
            }
            return true;
        }
        public void setVisibleDataPanel(bool visible)
        {
            if (panel.InvokeRequired)
            {
                setVisiblePanel d = new setVisiblePanel(setVisibleDataPanel);
                this.Invoke(d, new object[] { visible });
            }
            else
            {
                this.panel.Visible = visible;
                ProgressBar.Visible = !visible;
            }
        }

        public void setDataPanel(Model.Clientes cliente)
        {
            if (panel.InvokeRequired)
            {
                setDataList d = new setDataList(setDataPanel);
                this.Invoke(d, new object[] { cliente });
            }
            else
            {                
                this.ProgressBar.Value += 1;
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monitor_));
                Button buttonStatus = new Button();
                buttonStatus.BackColor = System.Drawing.Color.LightGray;
                buttonStatus.Location = new System.Drawing.Point(x, y);
                buttonStatus.Name = cliente.NumeroDeCuenta;
                buttonStatus.FlatStyle = FlatStyle.Flat;
                buttonStatus.Font = new System.Drawing.Font("Century Gothic", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                buttonStatus.Size = new System.Drawing.Size(30, 30);                
                buttonStatus.TabIndex = 3;
                buttonStatus.TabStop = false;
                buttonStatus.Click += new EventHandler(buttonStatus_Click);
                this.panel.Controls.Add(buttonStatus);
                this.panel.Location = new System.Drawing.Point(20, 60);
                this.panel.Name = "panel_" + cliente.NumeroDeCuenta;
                this.panel.TabIndex = 1;
                List<LogMonitoreo360> logs = db.LogMonitoreo360.Where(model => cliente.NumeroDeCuenta.Contains(model.Log.Substring(61, 4)) && cliente.NumeroTelefonoAlarma.Contains(model.Log.Substring(54, 6).Replace("-", ""))).ToList();
                foreach (var log in logs.OrderBy(model => model.FechaCreacion))
                {
                    string report = log.Log.Substring(66, log.Log.Length - 66);
                    string[] eventos = report.Split('-')[1].Split('/');
                    if (eventos.Count() > 1)
                    {
                        List<CodigoEventos> CodigosEventos = db.CodigoEventos.ToList();
                        foreach (var evento in eventos)
                        {
                            if (evento.Substring(0, 2).Contains("OP"))
                            {
                                buttonStatus.BackColor = System.Drawing.Color.SeaGreen;
                            }
                            else if (evento.Substring(0, 2).Contains("CL"))
                            {
                                buttonStatus.BackColor = System.Drawing.Color.GreenYellow;
                            }
                            else if (evento.Substring(0, 2).Contains("CR"))
                            {
                                buttonStatus.BackColor = System.Drawing.Color.IndianRed;
                            }
                            else if (evento.Substring(0, 2).Contains("OR"))
                            {
                                buttonStatus.BackColor = System.Drawing.Color.BlueViolet;
                            }
                        }
                    }
                }
                x = x + 35;
                count = count + 1;
                if ((x + 30) > width)
                {
                    y = y + 35;
                    x = 5;
                    count = 0;
                }
            }
        }        
        private void buttonStatus_Click(object sender, EventArgs e)
        {
            Button button = ((Button)sender);
            Model.Clientes cliente = db.Clientes.Where(x => x.NumeroDeCuenta == button.Name).FirstOrDefault();
            ClienteInfo form = new ClienteInfo();
            form.Text = "Cliente " + cliente.Nombres + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
            form.setInfo(cliente);
            form.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Monitor : Form
    {
        AvenzoSeguridad2Entities avenzoDB = new AvenzoSeguridad2Entities();
        int x, y;
        List<MyEllipse> ellipses = new List<MyEllipse>();
        MyEllipse ellipse;
        //public Monitor()
        //{
        //    InitializeComponent();
        //}

        private void Monitor_Load(object sender, EventArgs e)
        {
            AddCustomersSquares();

        }

        private void AddCustomersSquares()
        {
            List<GetClientesMonitoreo_Result> clientesMonitoreo = new List<GetClientesMonitoreo_Result>();
            clientesMonitoreo = avenzoDB.GetClientesMonitoreo().Where(x=>x.NumeroDeCuenta!=null).ToList();

            x = -48; y = 4;
            int maxX = (int)this.Size.Width;
            int maxY = (int)this.Size.Height;
            int growSizeX = 52;
            int growSizeY = 52;
            int i = 0;

            foreach (GetClientesMonitoreo_Result cliente in clientesMonitoreo)
            {
                if (x + growSizeX >= maxX-51)
                {
                    x = 4;

                    if (y + growSizeY >= maxY)
                        return;
                    else
                        y = y + growSizeY;
                }
                else
                    x = x + growSizeX;

                
                Button btnCliente = new Button();
                btnCliente.Name = "btnCliente" + (string)cliente.NumeroDeCuenta;
                btnCliente.Text = (string)cliente.NumeroDeCuenta.Substring(0, 4) + "\n" + (string)cliente.NumeroDeCuenta.Substring(4, 4);
                btnCliente.TextAlign = ContentAlignment.MiddleCenter;
                btnCliente.Size = new Size(52, 52);
                btnCliente.Left = x;
                btnCliente.Top = y;
                btnCliente.BackColor = Color.Yellow;
                btnCliente.Click += new EventHandler(btnCliente_Click);
                this.Controls.Add(btnCliente);
                i++;


                //ellipse = new MyEllipse(x, y);
                //ellipses.Add(ellipse);
            }
            Invalidate();
        }

        void btnCliente_Click(object sender, EventArgs e)
        {

            Button btnCliente = (Button)Controls.Find(((Button)sender).Name.ToString(), true).FirstOrDefault();
            string NumeroDeCuenta = ((Button)sender).Name.ToString().Replace("btnCliente","");
            GetClientes_Result Cliente;
            btnCliente.Text = btnCliente.Text.Replace("\n", "");
            if (btnCliente != null)
            {
                Cliente = avenzoDB.GetClientes(null,string.Empty,true,0).Where(x=>x.NumeroDeCuenta==NumeroDeCuenta).First();
                ClientInfo IncidentReport = new ClientInfo(Cliente.NumeroTelefonoAlarma);
                IncidentReport.Show();


            }
        }

        private void Monitor_Paint(object sender, PaintEventArgs e)
        {

        }



        public Monitor()
        {
            InitializeComponent();
            this.MouseClick += new MouseEventHandler(Monitor_MouseClick);

        }

        void Monitor_MouseClick(object sender, MouseEventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //for (int i = 0; i <= ellipses.Count; i++)
            //{
            //    //Graphics g = e.Graphics;
            //    MyEllipse item = ellipses.ToArray()[0];

                
                
            //}

            int i = 0;

            foreach (MyEllipse item in ellipses)
            {
                //Graphics g = e.Graphics;
                ////MyEllipse ellipse= ellipses.Peek();
                //item.Draw(g, item.x, item.y);
                ////item.Draw(g, 20, 20);


                //Button btnCliente = new Button();
                //btnCliente.Name = "btnCliente" + i.ToString();
                //btnCliente.Text = i.ToString();
                //btnCliente.TextAlign = ContentAlignment.MiddleCenter;
                //btnCliente.Size = new Size(52, 52);
                //btnCliente.Left = item.x;
                //btnCliente.Top = item.y;
                //this.Controls.Add(btnCliente);
                //i++;
            }


        }
    }


    class MyEllipse
    {
        public int x = 0;
        public int y = 0;
        public int diameter = 50;

        //Constructor
        public MyEllipse(int x2, int y2)
        {
            x = x2;
            y = y2;
        }

        public void Draw(Graphics g, int x, int y)
        {
            SolidBrush brush = new SolidBrush(Color.Red);
            g.FillEllipse(brush, x, y, diameter, diameter);
        }
    }
}

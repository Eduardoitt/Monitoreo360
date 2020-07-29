using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using SkypeControl;
using System.Data.SqlClient;
using System.Configuration;



namespace TestApp
{
    public partial class mdiForm2 : Form
    {
        bool ishangup = false;
        string temp = string.Empty;
        
        // Calls.CallsDataTable Calls;
        
        public mdiForm2()
        {
            InitializeComponent();
            aSkype.SkypeAttach += new SkypeAttachHandler(aSkype_SkypeAttach);
            aSkype.SkypeResponse += new SkypeResponseHandler(aSkype_SkypeResponse);
        }
        public void open( string sendNumber)
        {
            ClientInfo clientInfoWindow = new ClientInfo(sendNumber);
            //mdiForm3 frm = new mdiForm3(numeroenviar);
            clientInfoWindow.Show();
            //System.Media.SoundPlayer sound = new System.Media.SoundPlayer();
            //sound.SoundLocation = ConfigurationSettings.AppSettings["alarmSound"];
            //sound.Load();
            //sound.Play();
        }
         void aSkype_SkypeAttach(object theSender, SkypeAttachEventArgs theEventArgs)
        {
            textBox1.AppendText(string.Format("Procesando: {0}\r\n", theEventArgs.AttachStatus));
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();

            textBox1.Text = "";
            aSkype.Conect();
          
        }
       
        public int conta31 = 0;
        public string ssss;
        void aSkype_SkypeResponse(object theSender, SkypeResponseEventArgs theEventArgs)
        {

            
            string texto = string.Empty;
            textBox1.AppendText(string.Format("Respuesta: {0}\r\n", theEventArgs.Response));
            texto = textBox1.Text;
            //words = phrase.Split(default(stringo]), StringSplitOptions.RemoveEmptyEntries);
            //texto.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
            // Split string on spaces.
            // ... This will separate all the words.
            //
            //string[] words = s.Split(' ');
            string[] words = texto.Split(' ');
            int num_cont = 1, num_cont2 = 0, num_read = 0, sqlprint = 0;
            long numero;
            string temp2 = string.Empty;
            foreach (string word in words)
            {
                //string consoleString = Console.ReadLine();
                Console.WriteLine(word);
                //if (word == "PSTN_NUMBER")
                //{
                //    num_cont2 = 1;
                //    ishangup = false;
                //}
                if (word == "CALL")
                {
                    num_cont = 0;

                }
                if (num_cont2 == 1)
                {
                    if (word == "\r\nRespuesta:")
                    // if (word == "ALTER")
                    {
                        lbl_phone.Text = "Sin Numero";
                        num_cont2 = 0;
                        ishangup = false;
                        continue;
                        //break;
                    }
                    
                    else
                    {

                        lbl_phone.Text = word;
                        lbl_phone.Text = lbl_phone.Text.Remove(lbl_phone.Text.LastIndexOf(Environment.NewLine));
                        ssss = lbl_phone.Text;
                       // lbl_phone.Text = lbl_phone.Text.Remove(0, 1);
                       // int length = lbl_phone.Text.Length;
               
                    
                        if (sqlprint == 0)
                        {
                            fn_AddCall();
                            //frm.Show();
                            ishangup = false;
                            textBox1.Text = "";
                            aSkype.Conect();
                            sqlprint++;
                            
                        }
                        num_cont2 = 0;
                    }
                }
                if (word == "PSTN_NUMBER")
                {
                    num_cont2 = 1;
                    ishangup = false;
                    string num = lbl_phone.Text;
                   }

                if (num_cont != 1)
                {
                    bool canConvert = long.TryParse(word, out numero);
                    if (canConvert == true)
                    {
                       
                        // Console.WriteLine("number1 now = {0}", word);
                        lbl_call.Text = word;
                        //aSkype.Command("GET CALL " + lbl_call.Text + "PSTN_NUMBER");
                        num_cont = 1;
                        DateTime time = DateTime.Now;              // Use current time
                        string format = "MMM ddd d HH:mm:ss yyyy";    // Use this format
                        //Console.WriteLine(time.ToString(format));  // Write to console
                        lbl_date.Text = time.ToString(format);
                        num_read++;
                        // if (lbl_call.Text == word)
                        //   aSkype.Command("GET CALL " + lbl_call.Text + "PSTN_NUMBER");
                    }
                    else
                    {
                        if (num_read ==2)
                        {
                            
                            if (ishangup == false)
                            {
                                aSkype.Command("GET CALL " + lbl_call.Text + " PSTN_NUMBER");
                               
                               // aSkype.Command("GET CONTACT " + lbl_call.Text + " PSTN_NUMBER");
                                // call.Status = SKYPEAPILib.SkypeCallProgress.prgFinished;
                                aSkype.Command("alter call " + lbl_call.Text + " hangup");

                                ishangup = true;
                                temp += texto;
                                texto = textBox1.Text;
                                num_read = 0;
                                //textBox1.Text = "";

                                conta31++; 
                                continue;

                                //break;

                            }
                            else
                            {
                                //para colgar la llamada
                                ishangup = false;
                                //mdiForm3 frm = new mdiForm3(numeroenviar);
                                //frm.Show();
                                //numeroenviar = lbl_phone.Text;
                               
                                //textBox1.Text = "";
                                //if (conta >= 1)
                                //{
                                //    ventana.Dispose();

                                //} 
                                
                                break;
                                
                            }

                        }

                        if(conta31>=3)
                        {
                            open(ssss);
                        conta31 = 0;
                        aSkype.Conect();
                        }
                    }
                  
                }
                //fn_AddCall();
               
            }
            
        }

        SkypeProxy aSkype = new SkypeProxy();
        private void button2_Click(object sender, EventArgs e)
        {
            //textBox1.AppendText(string.Format("Command: {0}\r\n", comboBox1.Text));
            //aSkype.Command(comboBox1.Text);
            ManualCall manualCall = new ManualCall();
            manualCall.ShowDialog();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            aSkype.Disconnect();
            aSkype.Command("alter call " + lbl_call.Text + " hangup");
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://share.skype.com/sites/devzone/2006/01/api_reference_for_skype_20_bet.html#Reference");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //aSkype.Command("alter call 106477 hangup");
            aSkype.Command("alter call " + lbl_call.Text + " hangup");
            //Console.WriteLine(aSkype.Command("GET CALL " + lbl_call.Text + "PSTN_NUMBER"));
        }
        // De aqui
        private void fn_AddCall()
        {
           
            SqlConnection sqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["connectionString"]);
            
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("Insert_Call", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdSkypeCall", lbl_call.Text));
                cmd.Parameters.Add(new SqlParameter("@Call", lbl_phone.Text));
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                
            
            }
            catch (Exception)
            {
                sqlConnection.Close();
                //aSkype.Command("alter call " + lbl_call.Text + " hangup");
                aSkype.Command("alter call " + lbl_call.Text + " hangup");
                //throw;
            }
            finally
            {
                sqlConnection.Close();
                aSkype.Command("alter call " + lbl_call.Text + " hangup");
               // aSkype.Disconnect();
               // aSkype.Command("alter call " + lbl_call.Text + " hangup");
            //  aSkype.Disconnect();
              //  textBox1.Text = "";
                
            }
          
            }
        
        // a aqui 
       
        private void mdiForm2_Load(object sender, EventArgs e)
        {
           
            //if (conta31 ==2)
            //                {

            //                    mdiForm3 frm = new mdiForm3(nuevo);
            //                    frm.Show();
            //                }
            textBox1.ResetText();
            aSkype.Conect();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
            this.Close();
        }
    }
}
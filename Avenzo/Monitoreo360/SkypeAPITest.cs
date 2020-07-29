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
    public partial class SkypeAPITest : Form
    {
       // bool ishangup = false;
        string temp = string.Empty;
        // Calls.CallsDataTable Calls;
        public SkypeAPITest()
        {
            InitializeComponent();
            //aSkype.SkypeAttach += new SkypeAttachHandler(aSkype_SkypeAttach);
            //aSkype.SkypeResponse += new SkypeResponseHandler(aSkype_SkypeResponse);
        }

        private void conectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mdiForm2 newMDIChild = new mdiForm2();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void monitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Monitor monitor = new Monitor();
            monitor.WindowState = FormWindowState.Maximized;
            monitor.Show();
        }
        //void aSkype_SkypeAttach(object theSender, SkypeAttachEventArgs theEventArgs)
        //{
        //    textBox1.AppendText(string.Format("Attach: {0}\r\n", theEventArgs.AttachStatus));
        //}
        //void aSkype_SkypeResponse(object theSender, SkypeResponseEventArgs theEventArgs)
        //{
        //    string texto = string.Empty;
        //    textBox1.AppendText(string.Format("Response: {0}\r\n", theEventArgs.Response));
        //    texto = textBox1.Text;
        //    //words = phrase.Split(default(stringo]), StringSplitOptions.RemoveEmptyEntries);
        //    //texto.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
        //    // Split string on spaces.
        //    // ... This will separate all the words.
        //    //
        //    //string[] words = s.Split(' ');
        //    string[] words = texto.Split(' ');
        //    int num_cont = 1, num_cont2 = 0, num_read = 0, sqlprint = 0;
        //    long numero;
        //    string temp2 = string.Empty;
        //    foreach (string word in words)
        //    {
        //        //string consoleString = Console.ReadLine();
        //        Console.WriteLine(word);
        //        //if (word == "PSTN_NUMBER")
        //        //{
        //        //    num_cont2 = 1;
        //        //    ishangup = false;
        //        //}
        //        if (word == "CALL")
        //        {
        //            num_cont = 0;
        //        }
        //        if (num_cont2 == 1)
        //        {
        //            if (word == "\r\nResponse:")
        //            // if (word == "ALTER")
        //            {
        //                lbl_phone.Text = "Sin Numero";
        //                num_cont2 = 0;
        //                ishangup = false;
        //                continue;
        //                //break;
        //            }
        //            else
        //            {   
        //                lbl_phone.Text = word;
        //                lbl_phone.Text = lbl_phone.Text.Remove(lbl_phone.Text.LastIndexOf(Environment.NewLine));
        //                if (lbl_phone.Text == "")
        //                {
        //                    lbl_phone.Text = "Sin Numero";
        //                }
        //                else {
        //                    lbl_phone.Text = lbl_phone.Text.Remove(0, 1);
        //                int length = lbl_phone.Text.Length;
        //                }if (sqlprint == 0)
        //                {
        //                    fn_AddCall();
        //                    ishangup = false;
        //                    textBox1.Text = "";
        //                    aSkype.Conect();
        //                    sqlprint++;
        //                }
        //                num_cont2 = 0;
        //            }
        //        }
        //        if (word == "PSTN_NUMBER")
        //        {
        //            num_cont2 = 1;
        //            ishangup = false;
        //        }
        //        if (num_cont != 1)
        //        {
        //            bool canConvert = long.TryParse(word, out numero);
        //            if (canConvert == true)
        //            {
        //                // Console.WriteLine("number1 now = {0}", word);
        //                lbl_call.Text = word;
        //                //aSkype.Command("GET CALL " + lbl_call.Text + "PSTN_NUMBER");
        //                num_cont = 1;
        //                DateTime time = DateTime.Now;              // Use current time
        //                string format = "MMM ddd d HH:mm:ss yyyy";    // Use this format
        //                //Console.WriteLine(time.ToString(format));  // Write to console
        //                lbl_date.Text = time.ToString(format);
        //                num_read++;
        //                // if (lbl_call.Text == word)
        //                //   aSkype.Command("GET CALL " + lbl_call.Text + "PSTN_NUMBER");
        //            }
        //            else
        //            {
        //                if (num_read == 2)
        //                {
        //                    if (!ishangup)
        //                    {
        //                        aSkype.Command("GET CALL " + lbl_call.Text + " PSTN_NUMBER");
        //                        aSkype.Command("alter call " + lbl_call.Text + " hangup");
        //                        ishangup = true;
        //                        temp += texto;
        //                        texto = textBox1.Text;
        //                        num_read = 0;
        //                        //textBox1.Text = "";
        //                        continue;
        //                        //break;
        //                    }
        //                    else
        //                    {
        //                        ishangup = false;
        //                        //textBox1.Text = "";
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //        //fn_AddCall();
        //    }
        //}
        //SkypeProxy aSkype = new SkypeProxy();
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    textBox1.Text = "";
        //    aSkype.Conect();
        //}
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    textBox1.AppendText(string.Format("Command: {0}\r\n", comboBox1.Text));
        //    aSkype.Command(comboBox1.Text);
        //}
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    aSkype.Disconnect();
        //}
        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    System.Diagnostics.Process.Start(@"http://share.skype.com/sites/devzone/2006/01/api_reference_for_skype_20_bet.html#Reference");
        //}
        //private void button4_Click(object sender, EventArgs e)
        //{
        //    //aSkype.Command("alter call 106477 hangup");
        //    aSkype.Command("alter call " + lbl_call.Text + " hangup");
        //    //Console.WriteLine(aSkype.Command("GET CALL " + lbl_call.Text + "PSTN_NUMBER"));
        //}
        //private void fn_AddCall()
        //{
        //    //Form2 newMDIChild = new Form2();
        //    //newMDIChild.MdiParent = this;
        //    //newMDIChild.Show();
        //    SqlConnection sqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["connectionString"]);
        //    try
        //    {
        //        sqlConnection.Open();
        //        SqlCommand cmd = new SqlCommand("Insert_Call", sqlConnection);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(new SqlParameter("@IdSkypeCall", lbl_call.Text));
        //        cmd.Parameters.Add(new SqlParameter("@Call", lbl_phone.Text));
        //        //cmd.Parameters.Add(new SqlParameter("@CreateDate", lbl_date.Text));
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception)
        //    {
        //        //throw;
        //        sqlConnection.Close();
        //        aSkype.Conect();
        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //    }
        //}
        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    textBox1.Text = "";
        //    aSkype.Conect();
        //}
    }
}
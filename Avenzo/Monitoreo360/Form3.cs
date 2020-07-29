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
    public partial class mdiForm3 : Form
    {
        
        public mdiForm3()
        {
            InitializeComponent();
        }
        public mdiForm3(string num)
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            string error = string.Empty;
            if (lblNumCliente.Text == "numero")
            {
                num = num.Replace("+", "");
                lblNumCliente.Text = num;
                dt = fn_SelectNumerosIncidenteCliente(lblNumCliente.Text, out error);
                if (dt ==null){

                    if (error.Length > 0)
                    {
                        MessageBox.Show(error);
                    }else{
                        MessageBox.Show("No se encontraron numeros de telefono a reportar para el cliente "+num);
                    }
                    return;
                }
                foreach (DataRow dr in dt.Rows)
                {
                    chcboxListaNumerosIncidencia.Items.Add(dr["TelefonoReportar"].ToString() + " | " + dr["NombreTelefonoReportar"].ToString());
                   //chcboxListaNumerosIncidencia.Items.Add(dr["NombreTelefonoReportar"].ToString());
                     
                }
            }
        }
        mdiForm2 fr = new mdiForm2();
    
        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
            //fn_AddDatos();
        }
        //private void fn_AddDatos()
        //{
           
        //    SqlConnection sqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["connectionString"]);
        //    int categoria = 0;
        //    int delegacion = 0;
        //    //string NumeroReporta;
        //    categoria = int.Parse(cmbCategoria.SelectedValue.ToString());
        //    delegacion = int.Parse(cmbDelegacion.SelectedValue.ToString());
        //    //string numeroreporta = chcboxListaNumerosIncidencia.SelectedItem.ToString();
        //    //string[] separar;
        //    //string numeroReporta;
        //    //string NombreReporta;
        //    //separar = numeroreporta.Split('|');
        //    //numeroReporta = separar[0].Trim();
        //    //NombreReporta = separar[1].Trim();

            
        //    //NumeroReporta=chcboxListaNumerosIncidencia.SelectedIndex.ToString();
        //    try
        //    {
        //        sqlConnection.Open();
        //        SqlCommand cmd = new SqlCommand("Insert_HistorialMonitoreo", sqlConnection);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(new SqlParameter("@TelefonoCliente", lblNumCliente.Text));
        //        cmd.Parameters.Add(new SqlParameter("@Comentarios", txtComentarios.Text));
        //        cmd.Parameters.Add(new SqlParameter("@TipoDeAlerta",categoria));
        //        cmd.Parameters.Add(new SqlParameter("@Delegacion", delegacion));
        //        cmd.Parameters.Add(new SqlParameter("@UsuarioCreo", lblMiUsuario.Text));
        //        //cmd.Parameters.Add(new SqlParameter("@NumeroReporta", numeroReporta));
        //        cmd.ExecuteNonQuery();

        //        sqlConnection.Close();
                

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //    }
        //}
        private int insert_Datos()
        {
            Int32 newIdInsidencia = 0;
            SqlConnection sqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["connectionString"]);
            int categoria = 0;
            int delegacion = 0;
            //string NumeroReporta;
            categoria = int.Parse(cmbCategoria.SelectedValue.ToString());
            delegacion = int.Parse(cmbDelegacion.SelectedValue.ToString());
            //string numeroreporta = chcboxListaNumerosIncidencia.SelectedItem.ToString();
            //string[] separar;
            //string numeroReporta;
            //string NombreReporta;
            //separar = numeroreporta.Split('|');
            //numeroReporta = separar[0].Trim();
            //NombreReporta = separar[1].Trim();


            //NumeroReporta=chcboxListaNumerosIncidencia.SelectedIndex.ToString();
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("Insert_HistorialMonitoreo", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TelefonoCliente", lblNumCliente.Text));
                cmd.Parameters.Add(new SqlParameter("@Comentarios", txtComentarios.Text));
                cmd.Parameters.Add(new SqlParameter("@TipoDeAlerta", categoria));
                cmd.Parameters.Add(new SqlParameter("@Delegacion", delegacion));
                cmd.Parameters.Add(new SqlParameter("@UsuarioCreo", lblMiUsuario.Text));
                //cmd.Parameters.Add(new SqlParameter("@NumeroReporta", numeroReporta));
                cmd.ExecuteNonQuery();
                newIdInsidencia = (Int32)cmd.ExecuteScalar();
                sqlConnection.Close();
                if (newIdInsidencia == 0) { return 0; }
                else if (newIdInsidencia <= 0) { return 0; }
                else if (newIdInsidencia <= 0) { return 0; }
                else { return newIdInsidencia; }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return (int)newIdInsidencia;
        }
        private DataTable fn_SelectNumerosIncidenteCliente(string numCliente,out string error)
        {
            
            error = string.Empty;
            SqlConnection sqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["connectionString"]);
            DataSet ds = new DataSet();
            
            SqlDataAdapter da = new SqlDataAdapter();
           
            try
            {

                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("Select_TelefonosDeIncidencia", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TelefonoCliente", numCliente));

                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                
                
                if (ds == null) {

                    return null;
                }
                else if (ds.Tables.Count <= 0) { return null; }
                else if (ds.Tables[0].Rows.Count <= 0) { return null; }
                else { return ds.Tables[0]; }
                }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }

        }
        private void fn_SelectCategoria()
        {

            SqlConnection sqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["connectionString"]);


            
            string var1 = "Tipo de Alerta";
            try
            {
              
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("Select_Catalogos", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Tipo", var1));
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                this.cmbCategoria.DataSource = dt;

                this.cmbCategoria.DisplayMember = "Nombre";

                this.cmbCategoria.ValueMember = "IdCatalogo";

              
            }
            catch (Exception ex)
            {
                throw ex;
          
            }
            finally
            {
                sqlConnection.Close();
            }

        }
        private void fn_SelectDelegacion()
        {

            SqlConnection sqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["connectionString"]);



            string var1 = "Delegacion";
            try
            {

                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("Select_Catalogos", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Tipo", var1));
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                this.cmbDelegacion.DataSource = dt;

                this.cmbDelegacion.DisplayMember = "Nombre";

                this.cmbDelegacion.ValueMember = "IdCatalogo";


            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                sqlConnection.Close();
            }

        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void mdiForm3_Load(object sender, EventArgs e)
        {
            fn_SelectCategoria();
            fn_SelectDelegacion();
            int idInsidente = insert_Datos();
            lblid.Text = idInsidente.ToString();
            //fn_AddDatos();
            //if (chcboxListaNumerosIncidencia.SelectedValue() == true)
            //{
            //    Form4 FR = new Form4(chcboxListaNumerosIncidencia.SelectedItem.ToString());
            //    FR.Show();

            //}
        }

        private void chcboxListaNumerosIncidencia_Click(object sender, EventArgs e)
        {
            int index=chcboxListaNumerosIncidencia.SelectedIndex;
            if(index<=-1){
                return;

            }
            //mandar informacion a la venta
            chcboxListaNumerosIncidencia.SetItemCheckState(index,CheckState.Checked);
            Form4 FR = new Form4(chcboxListaNumerosIncidencia.SelectedItem.ToString(),lblNumCliente.Text,lblid.Text);
            FR.ShowDialog();
        }
    }
}

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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public Form4(string NombreNumero,string NumCliente,string IDIncidencia)
        {
            InitializeComponent();
            NumeroCliente2=NumCliente;
            IdIncidencia=IDIncidencia;
            string[] separar;
            separar = NombreNumero.Split('|');
            lblNumeroReporta.Text = separar[0].Trim();
            lblNombreReporta.Text = separar[1].Trim();
            string numero = lblNumeroReporta.Text;
            DataTable dt = new DataTable();
            string error = string.Empty;
            dt = EsCelular(numero, out error);
                if (dt ==null){

                    if (error.Length > 0)
                    {
                        MessageBox.Show(error);
                    }else{
                        MessageBox.Show("No se encontraron numeros de telefono a reportar para el cliente "+numero);
                    }
                    return;
                } 
            foreach (DataRow dr in dt.Rows)
                {
                   
                   string sino;
                   string comentario;
                    sino = (dr["EsCelular"].ToString());
                    if (sino == "True")
                    { lblSiNo.Text = "Si."; }
                    else if(sino =="False") { lblSiNo.Text = "No"; }
                    comentario = (dr["Comentarios"].ToString());
                    lblComentarioReporta.Text = comentario;
                }
        }
        public string NumeroCliente2;
        public string IdIncidencia;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            fn_AddDatos();
        }
        private void fn_AddDatos()
        {

            //.lbl_phone.Text; 
            SqlConnection sqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["connectionString"]);
            
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("Insert_TelefonosDeIncidenciaHistorial", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", IdIncidencia));
                cmd.Parameters.Add(new SqlParameter("@TelefonoCliente", NumeroCliente2));
                cmd.Parameters.Add(new SqlParameter("@TelefonoReportar", lblNumeroReporta.Text));
                cmd.Parameters.Add(new SqlParameter("@Comentarios", txtComentarios.Text));
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        private DataTable EsCelular(string numero,out string error)
        {
            error = string.Empty;
            SqlConnection sqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["connectionString"]);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {

                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select_Celular", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TelefonoReportar", numero));
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds == null)
                {
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

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }
    }
}

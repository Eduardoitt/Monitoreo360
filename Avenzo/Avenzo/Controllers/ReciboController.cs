using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
namespace Avenzo.Controllers
{
    public class ReciboController : Controller
    {
        // GET: Recibo
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        public ActionResult Index()
        {
            List<Clientes> clientes = db.GetClientes(null,true,0).ToList();
            return PartialView("_NuevoRecibo",clientes);
        }
        [HttpGet]
        public ActionResult Download()
        { /*
            string Nombre = "";
        string RFC = "";
        Dictionary<string, string> conceptos = new Dictionary<string, string>();
        List<Clientes> Clientes;
        //List<buscarCliente_Result> Clientes;  Comentado por Charlie, 14/Mar/2017, Se cambio a Clientes_ALT
        //Clientes clientes;
        string direccion = "|||";
        float Total = 0;
        Nombre = NombreCliente.ToUpper();
            conceptos["cantidad"] = "";
            conceptos["unidad"] = "";
            conceptos["descripcion"] = "";
            conceptos["valorUnitario"] = "";
            conceptos["importe"] = "";
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("es-MX");
        DateTime time = DateTime.Now;
            if (Mensualidad)
            {
                if (String.IsNullOrEmpty(IdCliente))
                {
                    //Clientes = db.buscarCliente(NombreCliente.Replace(' ', '-')).ToList();    Comentado por Charlie, 14/Mar/2017, Se cambio a Clientes_ALT
                    Clientes = db.GetClientes(Guid.Parse(IdCliente),string.Empty, true,1).ToList();
    }
                else
                {
                    //Clientes = db.buscarCliente(IdCliente).ToList();          Comentado por Charlie, 14/Mar/2017, Se cambio a Clientes_ALT
                    Clientes = db.GetClientes(null,String.Empty, true,0).Where(x => (x.Nombres + x.ApellidoPaterno + x.ApellidoMaterno).Trim().ToUpper() == NombreCliente.Trim().ToUpper()).ToList();
}
Nombre = NombreCliente.Replace('-', ' ');
                conceptos["cantidad"] = "1";
                conceptos["unidad"] = "1";
                conceptos["descripcion"] = "Mensualidad de " + time.ToString("MMMM", ci) + " del " + time.ToString("yyyy", ci);
                foreach (var item in Clientes)
                {
                    double valorPaquete = db.Catalogos.Where(x => x.Tipo == "Paquete" && x.IdCatalogo == item.TipoAfilacion).Select(x => x.Valor).FirstOrDefault().Value;
                    //if (item.Mensualidad != null) {
                    if (valorPaquete!=null)
                    {
                        double mensualidad =valorPaquete;
conceptos["valorUnitario"] = "" + ((double)(mensualidad / 1.16)).ToString("f2");
conceptos["importe"] = "" + ((double)(mensualidad / 1.16)).ToString("f2");
Total = (float)mensualidad;
                        RFC = item.RFC;
                        direccion = item.Calle + " " + item.NoExterior + " " + item.NoInterior + " Col." + item.Colonia;
                        //direccion = item.DireccionCliente;                        
                    }
                }
                string server = Server.MapPath("~/Content/Recibos");
string imagen = Server.MapPath("~/Images/Avenzo_Institucional_Color.png");
byte[] PDF = CFDI.CrearRecibo(Nombre, RFC, conceptos, direccion, server, Total, Leyenda, imagen, moneda);
                return File(PDF, "application/pdf", "RECIBO_" + Nombre.Trim() + ".PDF");
            }
            else
            {
                //Clientes = db.buscarCliente(NombreCliente.Replace(' ', '-')).ToList();
                if (String.IsNullOrEmpty(IdCliente))
                {
                    Clientes = db.GetCliente_ALT(String.Empty, true).Where(x => (x.Nombres + x.ApellidoPaterno + x.ApellidoMaterno).Trim().ToUpper() == NombreCliente.Trim().ToUpper()).ToList();
                    //Clientes = db.buscarCliente(NombreCliente.Replace(' ', '-')).ToList();
                }
                else
                {
                    Clientes = db.GetCliente_ALT(IdCliente, true).ToList();
                }
                foreach (var item in Clientes)
                {
                    RFC = item.RFC;
                    direccion = item.Calle + " " + item.NoExterior + " " + item.NoInterior + " Col." + item.Colonia;
                    //direccion = item.DireccionCliente;
                }
                string[] ca = Cantidad[0].Split(',');
string[] u = Unidad[0].Split(',');
string[] co = Concepto[0].Split(',');
string[] p = Precio[0].Split(',');

                for (var i = 0; i <= CantidadConceptos; i++)
                {
                    string cantidad = ca[i].Replace("\"", "").Replace("[", "").Replace("]", "");
string unidad = u[i].Replace("\"", "").Replace("[", "").Replace("]", "");
string concepto = co[i].Replace("\"", "").Replace("[", "").Replace("]", "");
string precio = p[i].Replace("\"", "").Replace("[", "").Replace("]", "");
conceptos["cantidad"] = conceptos["cantidad"] + "" + float.Parse(cantidad).ToString("f2") + "\n";
                    conceptos["unidad"] = conceptos["unidad"] + "" + unidad + "\n";
                    conceptos["descripcion"] = conceptos["descripcion"] + concepto + "\n";
                    conceptos["valorUnitario"] = conceptos["valorUnitario"] + "$ " + (float.Parse(precio) / 1.16).ToString("f2") + "\n";
                    conceptos["importe"] = conceptos["importe"] + "$ " + (float.Parse(precio) / 1.16).ToString("f2") + "\n";
                    Total = Total + float.Parse(precio);
                }
                string server = Server.MapPath("~/Content/Recibos");
string imagen = Server.MapPath("~/Images/Avenzo_Institucional_Color.png");
byte[] PDF = CFDI.CrearRecibo(Nombre, RFC, conceptos, direccion, server, Total, Leyenda, imagen, moneda);
                return File(PDF, "application/pdf", "RECIBO_" + Nombre.Trim() + ".PDF");*/

            return null;
        }
    }
}
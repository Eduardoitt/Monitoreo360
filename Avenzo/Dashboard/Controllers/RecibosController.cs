using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Dashboard.Tools;
using Ionic.Zip;
using System.IO;

namespace Dashboard.Controllers
{
    public class RecibosController : Controller
    {

        // GET: Recibos
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Authorize]
        public ActionResult _PanelRecibos() {
            ReciboView model = new ReciboView();
            model.moneda = new List<string>();
            model.moneda.Add("MXN");
            model.moneda.Add("USD");
            model.conceptos = new List<ReciboView.Concepto>();
            model.mes = new List<string>();
            DateTime InicioMeses = DateTime.Now.AddMonths(-6);
            DateTime FinalMeses = DateTime.Now.AddMonths(6);
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("es-MX");
            Usuarios usuario = db.Usuarios.Where(x=>x.Usuario==User.Identity.Name).First();
            for (DateTime date = InicioMeses; date.Date <= FinalMeses.Date; date = date.AddMonths(1))
            {

                model.mes.Add(ci.TextInfo.ToTitleCase(date.ToString("MMMM", ci))+ " del " + date.ToString("yyyy",ci));
            }
            
            if (User.IsInRole("Admin"))
            {
                model.pac = db.GetPAC(null, 0).ToList();                
                model.clientes = db.GetClientes(null, true, 0).ToList();
            }
            else
            {
                model.pac = db.GetPAC(null, 0).Where(x => x.UsuarioCreacion == usuario.Id).ToList();
                model.clientes = db.GetClientes(null, true, 0).Where(x => x.UsuarioCreacion ==usuario.Id).ToList();
            }            
            return View(model);
        }

        
        [HttpGet]
        public ActionResult Descarga(ReciboView recibo)
        {
            byte[] pdf;
            int count = 0;
            try {
                string Nombre = recibo.nombreCompleto;
                byte[] Logo;
                string direccion = "";
                string RFC = "";
                string Mes=recibo.mes.FirstOrDefault();
                string server = Server.MapPath("~/Content/Recibos");
                Dictionary<string, string> conceptos = new Dictionary<string, string>();
                Guid id = recibo.proveedor;
                GetPAC_Result pac = db.GetPAC(id, 1).First();                
                if (recibo.mensualidad=="on")
                {
                    using (ZipFile zip = new ZipFile())
                    {
                        MemoryStream memory = new MemoryStream();
                        List<Clientes> clientes = db.GetClientes(null,true,0).OrderBy(x=>x.Colonia).ToList();                        
                        foreach (var cliente in clientes)
                        {
                            Nombre = cliente.Nombres + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
                            string calle = cliente.Calle == null || cliente.Calle == "" ? "" : cliente.Calle,
                                noExterior = cliente.NoExterior == null || cliente.NoExterior == "" ? "" : cliente.NoExterior,
                                NoInterior = cliente.NoInterior == null || cliente.NoInterior == "" ? "" : cliente.NoInterior,
                                Colonia= cliente.Colonia == null || cliente.Colonia == "" ? "" : cliente.Colonia;
                            direccion = Colonia+", "+calle + " " + noExterior + " " + NoInterior+"\n"+cliente.Ciudad+","+cliente.Estado;
                            RFC = cliente.RFC == null || cliente.RFC == "" ? "" : cliente.RFC;                                                                              
                                Logo = System.IO.File.ReadAllBytes(Server.MapPath("~/Images/Avenzo_Logo_Header.png"));
                            string cantidad = "1";
                            string unidad = "1";
                            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("es-MX");
                            DateTime time = DateTime.Now.AddMonths(1);
                            string concepto = "Mensualidad de " + time.ToString("MMMM", ci)+" " +time.ToString("yyyy", ci);
                            Catalogos catalogo = db.Catalogos.Where(x => x.IdCatalogo == cliente.TipoAfilacion).FirstOrDefault();
                            string precio = catalogo==null?"0.00":catalogo.Valor.Value.ToString("f2");
                            conceptos["cantidad"] = float.Parse(cantidad).ToString("f2") + "\n";
                            conceptos["unidad"] = unidad + "\n";
                            conceptos["descripcion"] = concepto + "\n";
                            conceptos["valorUnitario"] = "$ " + (float.Parse(precio) / 1.16).ToString("f2") + "\n";
                            conceptos["importe"] ="$ " + (float.Parse(precio) / 1.16).ToString("f2") + "\n";
                            float Total =float.Parse(precio);
                            pdf = PDF.CrearRecibo(Nombre, RFC, conceptos, direccion, server, Total, true, Logo, "MXN",Mes);
                            MemoryStream tempPDF = new MemoryStream(pdf);
                            zip.AddEntry(count+"_Recibo_" +Nombre.Replace(" ","_")+".pdf", tempPDF);
                            count++;
                        }
                        zip.Save(memory);
                        memory.Seek(0, SeekOrigin.Begin);
                        return File(memory, "application/zip", "Recibos_"+ ".zip");
                    }
                }else
                {
                    Guid IdCliente = recibo.id;
                    List<Clientes> Clientes = db.GetClientes(IdCliente, true,1).ToList();
                    if (Clientes.Count > 0)
                    {
                        string calle = Clientes.First().Calle == null || Clientes.First().Calle == "" ? "" : Clientes.First().Calle,
                            noExterior = Clientes.First().NoExterior == null || Clientes.First().NoExterior == "" ? "" : Clientes.First().NoExterior,
                            NoInterior = Clientes.First().NoInterior == null || Clientes.First().NoInterior == "" ? "" : Clientes.First().NoInterior,
                            Colonia = Clientes.First().Colonia == null || Clientes.First().Colonia == "" ? "" : Clientes.First().Colonia;
                            direccion = Colonia+","+calle + " " + noExterior + " " + NoInterior+"\nTelefono: "+Clientes.First().Telefono;
                        RFC = Clientes.First().RFC == null || Clientes.First().RFC == "" ? "" : Clientes.First().RFC;
                        if (User.IsInRole("Admin"))
                        {
                            Guid Id = recibo.proveedor;
                            GetPAC_Result PAC = db.GetPAC(Id, 1).First();
                            Logo = null;
                            if (Logo == null)                            
                                Logo = System.IO.File.ReadAllBytes(Server.MapPath("~/Images/Avenzo_Logo_Header.png"));                            
                        }
                        else
                        {
                            GetPAC_Result PAC = db.GetPAC(Clientes.First().IdProveedor, 1).First();
                            Logo = null;
                            if (Logo == null)                         
                                Logo = System.IO.File.ReadAllBytes(Server.MapPath("~/Images/Avenzo_Logo_Header.png"));
                            
                        }
                    }
                    else
                        Logo = System.IO.File.ReadAllBytes(Server.MapPath("~/Images/Avenzo_Logo_Header.png"));
                    float Total = 0;
                    conceptos["cantidad"] = "";
                    conceptos["unidad"] = "";
                    conceptos["descripcion"] = "";
                    conceptos["valorUnitario"] = "";
                    conceptos["importe"] = "";                    
                    DateTime time = DateTime.Now;
                    foreach(var concepto in recibo.conceptos)
                    {
                        string cantidad = concepto.cantidad.ToString("f2");
                        string unidad = concepto.unidad;
                        string descripcion =concepto.descripcion;
                        string precio = concepto.precio.ToString("f2");
                        conceptos["cantidad"] = conceptos["cantidad"] + "" + float.Parse(cantidad).ToString("f2") + "\n";
                        conceptos["unidad"] = conceptos["unidad"] + "" + unidad + "\n";
                        conceptos["descripcion"] = conceptos["descripcion"] + descripcion + "\n";
                        conceptos["valorUnitario"] = conceptos["valorUnitario"] + "$ " + (float.Parse(precio) / 1.16).ToString("f2") + "\n";
                        conceptos["importe"] = conceptos["importe"] + "$ " + (float.Parse(precio) / 1.16).ToString("f2") + "\n";
                        Total = Total + float.Parse(precio);
                    }
                    bool leyenda = recibo.leyenda == "on" ? true : false;
                    string Moneda = recibo.moneda.First(); ;
                    pdf = PDF.CrearRecibo(Nombre, RFC, conceptos, direccion, server, Total, leyenda, Logo, Moneda,"");                
                    return File(pdf, "application/pdf", "RECIBO.PDF");
                }
            }
            catch (Exception ex) {
                return Json(new {error=ex.InnerException+", Count:"+count,Message=ex.Message},JsonRequestBehavior.AllowGet);
            }
            
           
        }
       
        [HttpGet]
        public ActionResult DescargaTodosLosRecibos()
        {
            int counter = 0;
            Dictionary<string, string> conceptos = new Dictionary<string, string>();            
            string imagen = Server.MapPath("~/Images/Avenzo_Institucional_Color.png");
           

            StreamReader sr = new StreamReader("C:\\Users\\Ivan\\Desktop\\Recibos.csv");

            //Read the first line of text
            string line = sr.ReadLine();

            //Continue to read until you reach end of file
          
            try {
                while (line != null)
                {
                    //write the lie to console window
                    string[] r = line.Split(',');
                    //Clientes clientes = db.Clientes.Where(x=>r[0].Equals(x.Nombres+" "+x.ApellidoPaterno+" "+x.ApellidoMaterno)).FirstOrDefault();
                    string Nombre = r[0];
                    string concepto = r[1];
                    conceptos["cantidad"] = "1";
                    conceptos["unidad"] = "1";
                    conceptos["descripcion"] = concepto;
                    float precio = float.Parse(r[2]);
                    conceptos["valorUnitario"] = "$ " + (precio).ToString("f2");
                    conceptos["importe"] = "$ " + (precio).ToString("f2");
                    byte[] by = PDF.CrearRecibo(Nombre,"",conceptos,"","", precio, true, System.IO.File.ReadAllBytes(imagen), "MXN",r[1].Split(' ')[1]);
                    System.IO.File.WriteAllBytes(@"C:\Users\Ivan\Desktop\noviembre\Recibo_" + counter + ".pdf", by);
                    counter++;
                    //Read the next line
                    line = sr.ReadLine();
                }
                /*foreach (var item in  clientes)
                {
                    
                    float Total = 0;
                    System.Console.WriteLine(item.Nombres);
                    string Nombre = item.Nombres + " " + item.ApellidoPaterno + " " + item.ApellidoMaterno;
                    string concepto = "Mensualidad De Julio 2017";
                    conceptos["cantidad"] = "1";
                    conceptos["unidad"] = "1";
                    conceptos["descripcion"] = concepto;
                    if (item.TipoAfilacion!=null)
                    {
                        Guid id = (Guid)item.TipoAfilacion;
                        float precio =(float) db.Catalogos.Where(x => x.IdCatalogo == id).First().Valor;
                        conceptos["valorUnitario"] = "$ " + (precio).ToString("f2");
                        conceptos["importe"] = "$ " + (precio).ToString("f2");
                        Total = Total + precio;

                        byte[] by = PDF.CrearRecibo(Nombre, item.RFC, conceptos, item.Colonia + ", " + item.Calle + " " + item.NoExterior + " " + item.CodigoPostal + ", " + item.Ciudad + ", " + item.Pais, "", Total, false, System.IO.File.ReadAllBytes(imagen), "MXN");
                        System.IO.File.WriteAllBytes(@"C:\Users\Ivan\Desktop\Recibos Junio 2017\Recibo_" + counter + ".pdf", by);
                        counter++;

                    }
                    
                }*/
                Console.WriteLine("Numero de Recibos Creados {0}", counter);
                
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return null;
        }
    }
}
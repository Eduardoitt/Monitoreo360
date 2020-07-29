using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.IO;
using Ionic.Zip;
using System.Xml;

namespace Dashboard.Controllers
{
    public class FacturasController : Controller
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult _Panel() {
            List<CFDIForPanel> CFDI = new List<CFDIForPanel>();
            if (User.IsInRole("Admin"))
            {
                CFDI = db.CFDIForPanel.Where(x => x.Tipo == "Factura").ToList();
            }
            else {
                Usuarios usuario = db.Usuarios.Where(x => x.Usuario == User.Identity.Name).First();
                CFDI = db.CFDIForPanel.Where(x => x.Tipo == "Factura" && x.UsuarioCreacion == usuario.Id).ToList();
            }
            return PartialView(CFDI);
        }
        [HttpPost]
        public ActionResult Nuevo(Guid ID)
        {
            return Json(new { error="none"},JsonRequestBehavior.AllowGet);
        }
        public List<AdeudosInstalaciones> ListaAdeudos(Guid IdFactura) {
            AdeudosInstalaciones Adeudo = db.AdeudosInstalaciones.Where(x => x.Id == IdFactura).FirstOrDefault();
            List<AdeudosInstalaciones> Adeudos = new List<AdeudosInstalaciones>();
            if (Adeudo.IdPaquete != null)
            {
                List<AdeudosInstalaciones> AdeudosTEMP = db.AdeudosInstalaciones.Where(x => x.IdPaquete == Adeudo.IdPaquete).ToList();
                foreach (var adeudo in AdeudosTEMP)
                    Adeudos.Add(adeudo);
            }
            else
                Adeudos.Add(Adeudo);
            return Adeudos;
        }
        public void GuardarInformacion(RVCFDI33.GeneraCFDI objCfdi,Clientes Clientes,List<AdeudosInstalaciones> Adeudos,GetPAC_Result PAC,string Ruta,string NombreArchivo,
            int Folio,string Moneda,byte[] Logo,double Total,string FormaDePago,string MetodoPago,string CantidadPDF,string ConceptoPDF,
            string ValorUnitarioPDF,string ImportePDF,string UnidadPDF) {
            Usuarios usuario = db.Usuarios.Where(x => x.Usuario == User.Identity.Name).FirstOrDefault();
            System.IO.File.WriteAllText(Ruta + "\\" + NombreArchivo + ".xml", objCfdi.XmlTimbrado);
            byte[] XML = System.IO.File.ReadAllBytes(Ruta + "\\" + NombreArchivo + ".xml");
            foreach (var adeudo in Adeudos)
                db.InsertCFDIPorOperacion(Guid.NewGuid(),null, adeudo.Id, Guid.Parse(objCfdi.UUID));
            db.InsertCFDI(Guid.Parse(objCfdi.UUID), "Factura",Folio, XML, "~/Facturas/" + PAC.RFC + "/Facturas/" + NombreArchivo, Clientes.IdCliente, null, PAC.Id, false, DateTime.Now, usuario.Id);
            int TimbresUsados = 1;
            
            TimbresUsados = usuario.TimbresUsados + 1;
            db.UpdateUsuarios(usuario.Id, usuario.Usuario, usuario.Contraseña, usuario.TipoUsuario, usuario.Roles, usuario.Activo, usuario.Timbres, TimbresUsados, usuario.TimbresCancelados,usuario.PrimeraVez);
            string Domicilio = Clientes.Calle + " " + Clientes.NoExterior + " " + Clientes.Colonia + " C.P " + Clientes.CodigoPostal + " " + Clientes.Ciudad + "," + Clientes.Estado + " " + Clientes.Pais;
            double TotalImpuestosRetenidos = Total - (Total / 1.16);
            Tools.PDF.CrearFactura(Ruta + "\\", NombreArchivo, Moneda, Logo, objCfdi, PAC.RFC, PAC.Nombre, PAC.RegimenFiscal, Clientes.RFC, "22210"
                , Domicilio, FormaDePago, MetodoPago, Total.ToString("f2"), TotalImpuestosRetenidos.ToString("f2"), float.Parse((Total / 1.16) + "").ToString("f2"),
                CantidadPDF, ConceptoPDF, ValorUnitarioPDF, ImportePDF, UnidadPDF);
            if (Adeudos.FirstOrDefault().RequiereEnvio == true && !string.IsNullOrEmpty(Clientes.Email))
            {
                CFDI CFDI = db.GetCFDI(Guid.Parse(objCfdi.UUID), 1).First();
                Helpers.Correo.EnviarFactura(Clientes.Email, NombreArchivo, "http://facturacion.avenzo.mx/Facturas/Descargar", Server.MapPath("~/Tools/plantilla_facturas.html"), CFDI);
            }
        }
        [Authorize]
        public ActionResult Facturar(Guid IdFactura)
        {
            try
            {
                List<CFDIPorOperacion> CFDIs = db.CFDIPorOperacion.Where(x => x.IdAdeudosInstalaciones == IdFactura).ToList();
                bool isExist = false;
                foreach (var CFDI in CFDIs) {
                    if (db.CFDI.Where(x => x.Id == CFDI.IdCFDI).FirstOrDefault().Cancelado==false)
                    {
                        isExist = true;
                    }
                }
                if (!isExist)
                {
                    List<AdeudosInstalaciones> Adeudos = ListaAdeudos(IdFactura);
                    RVCFDI33.GeneraCFDI objCfdi = new RVCFDI33.GeneraCFDI();
                    bool pagado = true;
                    double Total = 0;
                    Guid IdCliente = new Guid();
                    byte[] Logo;
                    string Moneda = "MXN", FormaDePago = "01", TipoCambio = "1",MetodoDePago= "PUE",UsoCFDI="G03";
                    foreach (var adeudo in Adeudos)
                    {
                        if (adeudo.Pagado == false)
                            pagado = false;
                        List<MonitoreoIngresos> Operaciones = db.GetMonitoreoIngreso(0, null).Where(x => x.IdAdeudo == adeudo.Id).OrderBy(x => x.FechaCreacion).ToList();
                        foreach (var Operacion in Operaciones)
                        {
                            double total = (double)(Operacion.Cargos + (Operacion.CargosUSD * Operacion.TipoCambio));
                            Moneda = Operacion.Moneda.Trim();

                            var TC = Operacion.TipoCambio;
                            TipoCambio = TC.Value == 0 || TC == null ? "" : TC.Value.ToString("f2");
                        }
                        FormaDePago = Operaciones.First().FormaDePago;
                        MetodoDePago = Operaciones.First().MetodoDePago;
                        UsoCFDI = Operaciones.First().UsoCFDI;
                        Total = Total + adeudo.Total;
                        IdCliente = (Guid)adeudo.IdCliente;
                    }
                    if (pagado == true)
                    {
                        GetPAC_Result PAC = db.GetPAC(Adeudos.First().IdProveedor, 1).First();
                        int Folio = 1;
                        var TempFolio = db.CFDI.Where(x => x.IdProveedor == PAC.Id).Max(x => x.Folio);
                        if (TempFolio != null)
                            Folio = db.CFDI.Where(x => x.IdProveedor == PAC.Id).Max(x => x.Folio).Value + 1;
                        string Path = Server.MapPath("~/"),
                            Certificado = Server.MapPath("~/Certificados/" + PAC.RFC + "/" + PAC.RFC + ".cer"),
                            Llave = Server.MapPath("~/Certificados/" + PAC.RFC + "/" + PAC.RFC + ".key"),
                            Factura = Path + "Facturas\\" + PAC.RFC + "\\Facturas";
                        Clientes Clientes = db.Clientes.Where(x => x.IdCliente == IdCliente).First();
                        Logo = null;
                        if (Logo == null)
                            Logo = System.IO.File.ReadAllBytes(Server.MapPath("~/Images/Avenzo_Logo_Header.png"));
                        objCfdi.agregarCertificado(Certificado);                        
                        objCfdi.agregarComprobante33("B", Folio.ToString(), DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"), FormaDePago, "",Total / 1.16, 0, Moneda, TipoCambio=="1.00"?"1":TipoCambio, Total, "I", MetodoDePago, "22210", "");
                        objCfdi.agregarEmisor(PAC.RFC.Trim(), PAC.Nombre, PAC.RegimenFiscal.Trim());
                        objCfdi.agregarReceptor(Clientes.RFC, Clientes.Nombres + " " + Clientes.ApellidoPaterno + " " + Clientes.ApellidoMaterno.TrimEnd(), "", "", UsoCFDI);
                        string ConceptoPDF = "", CantidadPDF = "", ValorUnitarioPDF = "", ImportePDF = "", UnidadPDF = "";
                        foreach (var adeudo in Adeudos)
                        {
                            string ClaveProServ = adeudo.ClaveProdServ, NoIdentificacion = "1", ClaveUnidad = adeudo.Unidad, Concepto = adeudo.Concepto;
                            double Cantidad = (double)adeudo.Cantidad, ValorUnitario = (adeudo.Total / 1.16) / Cantidad, Importe = adeudo.Total / 1.16;
                            objCfdi.agregarConcepto(ClaveProServ, NoIdentificacion, Cantidad, ClaveUnidad, "Elemento", Concepto, ValorUnitario, Importe, 0.00);
                            ConceptoPDF += Concepto + "\n";
                            CantidadPDF += Cantidad.ToString("f2") + "\n";
                            ValorUnitarioPDF += (ValorUnitario).ToString("f2") + "\n";
                            ImportePDF += Importe.ToString("f2") + "\n";
                            UnidadPDF += ClaveUnidad + "\n";
                            objCfdi.agregarImpuestoConceptoTraslado(adeudo.Total / 1.16, "002", "Tasa", 0.160000, adeudo.Total - (adeudo.Total / 1.16));
                        }
                        objCfdi.agregarImpuestos(0, Total - (Total / 1.16));
                        objCfdi.agregarTraslado("002", "Tasa", 0.160000, Total - (Total / 1.16));
                        objCfdi.GeneraXML(Llave, PAC.ContrasenaLlave);
                        string Xml = objCfdi.Xml.Replace("Sello=\"\"", "Sello=\"" + objCfdi.SelloEmisor + "\"");
                        string Nombre = PAC.RFC + "_" + Folio + "_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year;
                        System.IO.File.WriteAllText(Factura + "\\" + Nombre + "_SinTimbrar.xml", Xml);
                        //XmlDocument myXmlDocument = new XmlDocument();
                        objCfdi.TimbrarCfdiArchivo(Factura + "\\" + Nombre + "_SinTimbrar.xml", PAC.Usuario, PAC.Contrasena, "http://generacfdi.com.mx/rvltimbrado/service1.asmx", Factura, Nombre, true);
                        if (objCfdi.MensajeError == "")
                        {
                            GuardarInformacion(objCfdi, Clientes, Adeudos, PAC, Factura, Nombre, Folio, Moneda,
                                Logo, Total, FormaDePago, MetodoDePago, CantidadPDF, ConceptoPDF, ValorUnitarioPDF, ImportePDF, UnidadPDF);                            
                            return Json(new { error = "none", IdFactura = objCfdi.UUID }, JsonRequestBehavior.AllowGet);
                        }
                        else
                            return Json(new { error = "Error Al faturar", Message = objCfdi.MensajeError }, JsonRequestBehavior.AllowGet);
                    }
                    else
                        return Json(new { error = "No estan Pagado Todos Los Conceptos" }, JsonRequestBehavior.AllowGet);
                }
                else return Json(new { error = "" }, JsonRequestBehavior.AllowGet);                
            }
            catch (Exception Ex)
            {
                return Json(new { error=Ex.InnerException,Message=Ex.Message}, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult Descargar(Guid Id)
        {            
            CFDI Factura = db.GetCFDI(Id,1).First();
            byte[] XML;
            PAC PAC = db.PAC.Where(x => x.Id == Factura.IdProveedor).FirstOrDefault();
            if (Factura.Cancelado == true)
            {
                try {
                    XML = System.IO.File.ReadAllBytes(Server.MapPath("~/Facturas/" + PAC.RFC + "/Cancelaciones")+ "/Cancelacion_" + Factura.Folio + ".xml");
                } catch (Exception ex) {
                    XML = Factura.XML;
                }
                
                MemoryStream xml = new MemoryStream(XML);
                using (ZipFile zip = new ZipFile())
                {
                    MemoryStream memory = new MemoryStream();
                    zip.AddEntry("Factura_Cancelada_" + DateTime.Now.ToString("MM_dd_yyyy") + ".xml", xml);                    
                    zip.Save(memory);
                    memory.Seek(0, SeekOrigin.Begin);
                    return File(memory, "application/zip", "Factura.zip");
                }                    
            }
            else { 
                XML = Factura.XML;
                byte[] PDF = System.IO.File.ReadAllBytes(Server.MapPath(Factura.Ruta)+ ".pdf");
                MemoryStream xml = new MemoryStream(XML);
                MemoryStream pdf = new MemoryStream(PDF);
                using (ZipFile zip = new ZipFile())
                {
                    MemoryStream memory = new MemoryStream();
                    zip.AddEntry("Factura_"+Factura.Folio+"_"+DateTime.Now.ToString("MM_dd_yyyy")+".xml", xml);
                    zip.AddEntry("Factura_"+Factura.Folio+"_" + DateTime.Now.ToString("MM_dd_yyyy") + ".pdf", pdf);
                    zip.Save(memory);
                    memory.Seek(0, SeekOrigin.Begin);
                    return File(memory, "application/zip", "Factura.zip");
                }
            }
        }
        [HttpGet]
        [Authorize]
        public ActionResult Cancelar(Guid Id)
        {
            try {
                CFDI Factura = db.GetCFDI(Id, 1).FirstOrDefault();
                GetPAC_Result PAC = db.GetPAC(null, 0).Where(x => x.Id == Factura.IdProveedor).First();
                RVCFDI33.RVCancelacion.Cancelacion Cancelar = new RVCFDI33.RVCancelacion.Cancelacion();
                string Certificado = Server.MapPath("~/Certificados/" + PAC.RFC + "/" + PAC.RFC + ".cer"),
                    Llave = Server.MapPath("~/Certificados/" + PAC.RFC + "/" + PAC.RFC + ".key"),
                    Cancelacion = Server.MapPath("~/Facturas/" + PAC.RFC + "/Cancelaciones");
                string cadenaCancelacion = Cancelar.crearXMLCancelacionCadena(Certificado, Llave, PAC.ContrasenaLlave, Factura.Id.ToString());
                if (Cancelar.MensajeDeError == "")
                {
                    //Cancelar.enviarCancelacionCadena(cadenaCancelacion, PAC.RFC, PAC.Contrasena, "http://generacfdi.com.mx/rvltimbrado/service1.asmx");
                    if (Cancelar.CodigoDeError == 0)
                    {
                        if (!System.IO.Directory.Exists(Cancelacion))
                            System.IO.Directory.CreateDirectory(Cancelacion);
                        System.IO.File.WriteAllText(Cancelacion + "\\Cancelacion_" + Factura.Folio + ".xml", cadenaCancelacion);
                        db.UpdateCFDI(Id, Factura.Tipo, Factura.Folio, Factura.XML, Factura.Ruta, Factura.IdCliente, Factura.IdEmpleado, Factura.IdProveedor, true);
                        return Json(new { error = false }, JsonRequestBehavior.AllowGet);
                    }
                    else
                        return Json(new { error = "Error Al enviar la Cadena De Cancelacion", Message = Cancelar.MensajeDeError }, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(new { error = "Error Al hacer la Cadena De Cancelacion", Message = Cancelar.MensajeDeError }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) {
                return Json(new { error = "error", Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            
        }
        [HttpGet]
        public ActionResult Complemento(string Folios, string Complemento,string FechaPago,string FormaPago) {
            try {
                RVCFDI33.GeneraCFDI objCfdi = new RVCFDI33.GeneraCFDI();
                RVCFDI33.GeneraCFDI LeerObjCfdi = new RVCFDI33.GeneraCFDI();
                int PrimerFolio = int.Parse(Folios.Split(',')[0]);
                CFDI Factura = db.CFDI.Where(x => x.Folio == PrimerFolio).First();
                GetPAC_Result Proveedor = db.GetPAC(Factura.IdProveedor, 1).First();
                Clientes cliente = db.Clientes.Where(x => x.IdCliente == Factura.IdCliente).First();
                Usuarios usuario = db.Usuarios.Where(x => x.Usuario == User.Identity.Name).FirstOrDefault();
                string Certificado = Server.MapPath("~/Certificados/" + Proveedor.RFC + "/" + Proveedor.RFC + ".cer");
                string Llave = Server.MapPath("~/Certificados/" + Proveedor.RFC + "/" + Proveedor.RFC + ".key");                
                string Domicilio = cliente.Calle + " " + cliente.NoExterior + " " + cliente.Colonia + " C.P " + cliente.CodigoPostal + " " + cliente.Ciudad + "," + cliente.Estado + " " + cliente.Pais;
                System.IO.File.WriteAllBytes(Server.MapPath(Factura.Ruta) + ".xml", Factura.XML);
                objCfdi.agregarCertificado(Certificado);
                int Folio = 0;
                double total = 0;
                string Moneda="";
                double TipoCambio = 1;

                objCfdi.agregarComprobante33("P", Folio.ToString(), System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"), "", "", 0, 0, "XXX", "", 0, "P", "", "22230", "");
                objCfdi.agregarEmisor(Proveedor.RFC, Proveedor.Nombre.Trim(), Proveedor.RegimenFiscal);
                objCfdi.agregarReceptor(cliente.RFC, cliente.Nombres + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno, "", "", "P01");                //                    
                objCfdi.agregarConcepto("84111506", "", 1, "ACT", "", "Pago", 0, 0, 0);

                foreach (string folioStr in Folios.Split(',')) 
                {
                    Folio= int.Parse(folioStr);
                    Factura = db.CFDI.Where(x => x.Folio == Folio).First();
                    string XMLTimbrado = System.IO.File.ReadAllText(Server.MapPath(Factura.Ruta) + ".xml");
                    
                    Moneda = LeerObjCfdi.LeerValorXML(XMLTimbrado, "Moneda", "Comprobante");
                    
                    if (LeerObjCfdi.LeerValorXML(XMLTimbrado, "TipoCambio", "Comprobante") != "")
                        double.TryParse(LeerObjCfdi.LeerValorXML(XMLTimbrado, "TipoCambio", "Comprobante"), out TipoCambio);
                    total = total+ double.Parse(objCfdi.LeerValorXML(XMLTimbrado, "Total", "Comprobante"));
                    double totalIndividual=double.Parse(objCfdi.LeerValorXML(XMLTimbrado, "Total", "Comprobante"));
                    objCfdi.agregarPago10(FechaPago, FormaPago, Moneda, TipoCambio, totalIndividual, "01", "", "", "", "", "", "", "", "", "");
                    objCfdi.agregarPago10DoctoRelacionado(Factura.Id.ToString(), "B", folioStr, objCfdi.LeerValorXML(XMLTimbrado, "Moneda", "Comprobante"), 0, "PPD", 1, totalIndividual, totalIndividual, 0);

                }
                
                string path = Server.MapPath("~/Facturas/" + Proveedor.RFC + "/Complementos");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                Folio = ((int)db.CFDI.Where(x => x.Tipo == Complemento).Max(x => x.Folio)) + 1;
                
                switch (Complemento)
                {
                    case "Pago10":
                        
                                             
                        //"2018-09-11T12:42:47"
                        break;
                }
                string NombreArchivo = Proveedor.RFC + "_" + Folio + "_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year;

                objCfdi.GeneraXML(Llave, Proveedor.ContrasenaLlave);
                System.IO.File.WriteAllText(path + "//" + NombreArchivo + "_SinTimbrar.xml", objCfdi.Xml);
                objCfdi.TimbrarCfdiArchivo(path + "\\" + NombreArchivo + "_SinTimbrar.xml", Proveedor.Usuario, Proveedor.Contrasena, "http://generacfdi.com.mx/rvltimbrado/service1.asmx", path, NombreArchivo, true);
                if (objCfdi.MensajeError == "")
                {
                    byte[] Logo = System.IO.File.ReadAllBytes(Server.MapPath("~/Images/Avenzo_Logo_Header.png"));
                    System.IO.File.WriteAllText(path + "\\" + NombreArchivo + ".xml", objCfdi.XmlTimbrado);
                    db.InsertCFDI(Guid.Parse(objCfdi.UUID), "Pago10", Folio, System.IO.File.ReadAllBytes(path + "//" + NombreArchivo + ".xml"), "~/Facturas/" + Proveedor.RFC + "/Complementos/" + NombreArchivo + ".xml", cliente.IdCliente, null, Proveedor.Id, false, DateTime.Now,Guid.Parse("8BEAD89F-B0CA-4CA9-9268-4DE6C727E3A2"));

                    Tools.PDF.ComplementoPago10(path + "\\", NombreArchivo, "XXX", Logo, objCfdi, Proveedor.RFC, Proveedor.Nombre, Proveedor.RegimenFiscal, cliente.RFC, "22210"
                    , Domicilio, FechaPago, FormaPago, Moneda, TipoCambio.ToString("f2"), total.ToString("f2"), "01", Factura.Id.ToString(), "B", Factura.Folio.ToString(), Moneda, "PPD", "1", total.ToString("f2"), total.ToString("f2"), "0");


                    return Json(new { error = false }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { error = true, Message = objCfdi.MensajeError }, JsonRequestBehavior.AllowGet);
                }
            } catch (Exception ex) {
                return Json(new { error=true,Message=ex.Message},JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Model;
using System.Threading.Tasks;
using System.IO;
using tagcode.xml;
using System.Net;
using Dashboard.Tools;
using Ionic.Zip;
using System.Security.Cryptography.X509Certificates;


namespace Dashboard.Controllers
{
    public class CertificadosController : Controller
    {

        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        // GET: Certificados
        [Authorize]                
        public ActionResult Index()
        {
            return PartialView();            
        }
        [HttpGet]
        public ActionResult _PanelCertificados()
        {
            List<PACForPanel> pacs;
            if (User.IsInRole("Admin"))
                pacs = db.PACForPanel.ToList();
            else
            {
                Usuarios Usuario = db.Usuarios.Where(x => x.Usuario == User.Identity.Name).First();
                pacs = db.PACForPanel.Where(x => x.UsuarioCreacion == Usuario.Id).ToList();
            }
            return PartialView(pacs);
        }
        
        public ActionResult Editar(Guid TempId)
        {            
            CertificadosView view = new CertificadosView();
            view.PAC= db.GetPAC(TempId, 1).First();
            view.ClaveProdServ = db.ClaveProdServ.ToList();
            view.ClaveProdServPorClase = db.GetClaveProdServClase(string.Empty, 0).ToList();
            ViewBag.Regimen = db.RegimenFiscal.ToList();
            return PartialView("_Editar",view);
        }
        public ActionResult Nuevo()
        {
            try
            {
                CertificadosView view = new CertificadosView();
                view.ClaveProdServ = db.ClaveProdServ.Take(10).ToList();
                view.ClaveProdServPorClase = db.GetClaveProdServClase(string.Empty, 0).ToList();
                ViewBag.Regimen = db.RegimenFiscal.ToList();
                return PartialView("_Nuevo", view);
            }
            catch (Exception ex)
            {
                return Redirect("/Error/Index?Error="+500+"&Message="+ex.Message);
            }
            
        }
        
        public ActionResult Eliminar(Guid id){
            try{
                
                db.DeletePAC(id,0);
                return Json(new {error=false}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex){
                return Json(new { error=ex.InnerException,Message=ex.Message}, JsonRequestBehavior.AllowGet);
            }
            
        }
        public ActionResult Descargar(Guid id)
        {
            GetPAC_Result pac = db.GetPAC(id, 1).First();
            byte[] Cer = pac.Certificado;
            byte[] Key = pac.Llave;
            MemoryStream Certificado = new MemoryStream(Cer);
            MemoryStream Llave = new MemoryStream(Key);
            using (ZipFile zip = new ZipFile())
            {
                
                MemoryStream memory = new MemoryStream();
                zip.AddEntry("certificado.cer", Certificado);
                zip.AddEntry("llave.key", Llave);
                zip.Save(memory);
                memory.Seek(0, SeekOrigin.Begin);
                return File(memory, "application/zip", pac.RFC + ".zip");
            }            
        }
        
        [HttpPost]
        public ActionResult Editar(GetPAC_Result pac)
        {
            GetPAC_Result old = db.GetPAC(pac.Id, 1).First();
            try {
               /* db.UpdatePAC(pac.Id, pac.RFC, old.Usuario, old.Contrasena, pac.ContrasenaLlave, pac.Nombre, pac.CURP, 
                    pac.PersonaMoral, old.Llave, pac.RegimenFiscal, pac.RegistroPatronal, pac.RfcPatronOrigen, 
                    old.Certificado,old.FechaVigenciaIncio,old.FechaVigenciaFinal,old.UsuarioCreacion,old.FechaCreacion,old.Logo);*/
                string PATH = Server.MapPath("~/Certificados/" + pac.RFC);
                if (!System.IO.Directory.Exists(PATH))
                    System.IO.Directory.CreateDirectory(PATH);
                System.IO.File.WriteAllBytes(PATH+"/"+pac.RFC+".cer", old.Certificado);
                System.IO.File.WriteAllBytes(PATH + "/" + pac.RFC + ".key", old.Llave);
            } catch (Exception ex){
                return Json(new {error=ex.InnerException,Message=ex.Message },JsonRequestBehavior.AllowGet);
            }
            return Json(new {error="none" },JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Nuevo(Guid id, string RFC,string RazonSocial,string CURP,bool Persona,
            string RegimenFiscal, string contraseña,string RegistroPatronal,string RfcPatronOrigen,
            string LugarExpedicion,string ClaveProdServs)
        {
            try
            {
                byte[] cer = null;
                byte[] llave = null;
                byte[] logo = null;
                string PathLogo = "";
                Usuarios usuario = db.Usuarios.Where(x => x.Usuario == User.Identity.Name).FirstOrDefault();
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        var stream = fileContent.InputStream;
                        var fileName = Path.GetFileName(fileContent.FileName);
                        if (file.Contains("llave"))
                        {
                            llave = new byte[fileContent.ContentLength];
                            llave = StreamHelper.ReadToEnd(fileContent.InputStream);
                        }
                        if (file.Contains("certificado"))
                        {
                            cer = new byte[fileContent.ContentLength];
                            cer = StreamHelper.ReadToEnd(fileContent.InputStream);
                        }
                        if (file.Contains("logo"))
                        {
                            logo = new byte[fileContent.ContentLength];
                            logo = StreamHelper.ReadToEnd(fileContent.InputStream);
                            Guid NombreLogo = Guid.NewGuid();
                            PathLogo = Server.MapPath("~/Images/Certificados/" + NombreLogo + fileContent.ContentType);
                            System.IO.File.WriteAllBytes(PathLogo,logo);
                        }
                    }
                }
                X509Certificate2 Certificado = new X509Certificate2(cer);
                if (Certificado.NotBefore > DateTime.Now)
                    return Json(new { error = "error",Message="Todavia no Puedes Faturar hasra el "+Certificado.NotBefore.Day+"/"+Certificado.NotBefore.Month+"/"+Certificado.NotBefore.Year }, JsonRequestBehavior.AllowGet);
                else if (Certificado.NotAfter < DateTime.Now)
                    return Json(new {error="error",Message="Ya se ha caducado el certificado"}, JsonRequestBehavior.AllowGet);
                List<GetPAC_Result> pac = db.GetPAC(null, 0).ToList();
                bool exist=false;                
                foreach (var item in pac) {
                    if (item.RFC==RFC) {
                        exist = true;
                        id = item.Id;
                    }
                }
                if(!exist)
                    db.InsertPAC(id,RFC,RFC,RFC+"-010", RazonSocial, CURP, 
                        Persona, llave, cer, contraseña, RegimenFiscal,
                        RegistroPatronal,RfcPatronOrigen, PathLogo, LugarExpedicion,Certificado.NotBefore,  
                        Certificado.NotAfter, usuario.Id, DateTime.Now, true);
                else
                {
                    db.UpdatePAC(id, RFC,RFC,RFC+"-010", RazonSocial, CURP,
                       Persona, llave, cer,contraseña, RegimenFiscal,
                       RegistroPatronal,RfcPatronOrigen, logo, LugarExpedicion, Certificado.NotBefore, 
                       Certificado.NotAfter,true);
                }
                
                foreach(string claveServProd in ClaveProdServs.Split(','))
                {
                    db.InsertClaveProdServPorPAC(Guid.NewGuid(),id,claveServProd,usuario.Id,DateTime.Now);

                }
                string PATH = "~/Certificados/" + RFC;
                if (!System.IO.Directory.Exists(Server.MapPath(PATH)))
                    System.IO.Directory.CreateDirectory(Server.MapPath(PATH));
                if (!System.IO.Directory.Exists(Server.MapPath("~/Facturas/" + RFC)))
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/Facturas/"+RFC));
                System.IO.Directory.CreateDirectory(Server.MapPath("~/Facturas/" + RFC+ "/Cancelaciones"));
                System.IO.Directory.CreateDirectory(Server.MapPath("~/Facturas/" + RFC + "/Facturas"));
                System.IO.Directory.CreateDirectory(Server.MapPath("~/Facturas/" + RFC + "/Nominas"));
                System.IO.File.WriteAllBytes(Server.MapPath(PATH + "/" + RFC + ".cer"), cer);
                System.IO.File.WriteAllBytes(Server.MapPath(PATH + "/" + RFC + ".key"), llave);
                /*WsEnrola.Service1SoapClient obj = new WsEnrola.Service1SoapClient();
                WsEnrola.WSEnrolaResponse etc = new WsEnrola.WSEnrolaResponse();
                etc = obj.AgregarUsuario("ABG1512109U1", "ABG1512109U1", "ABG1512109U1-010", RFC,RFC, RFC + "-010", RazonSocial,"", WsEnrola.TipoUsuario.Cliente);*/
                /*if (etc.Estado == 0) {
                    obj.AgregarTimbres("ABG1512109U1", "ABG1512109U1", "ABG1512109U1-010", RFC, RFC, 10);*/
                    return Json(new { error = "none", id = id }, JsonRequestBehavior.AllowGet);
                /*} else if (etc.Estado==309) {
                    return Json(new { error = "none",id= id }, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(new { error = "Error", Message = etc.MensajeDeError }, JsonRequestBehavior.AllowGet);*/
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { error = ex.InnerException, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }            
        }

        [HttpPost]
        public ActionResult UpdateFile(Guid Id)
        {
            try
            {
                byte[] cer = new byte[3072];
                byte[] llave = new byte[3072]; ;
                byte[] logo = new byte[3072];
                GetPAC_Result pac = db.GetPAC(Id,1).First();
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        var stream = fileContent.InputStream;
                        var fileName = Path.GetFileName(fileContent.FileName);
                        if (file.Contains("llave"))
                        {
                            llave = new byte[fileContent.ContentLength];
                            llave = StreamHelper.ReadToEnd(fileContent.InputStream);
                            string Key = Server.MapPath("~/Certificados/" + pac.RFC + "/" + pac.RFC + ".key");
                            System.IO.File.WriteAllBytes(Key, llave);
                        }
                        if (file.Contains("certificado"))
                        {
                            cer = new byte[fileContent.ContentLength];
                            cer = StreamHelper.ReadToEnd(fileContent.InputStream);
                            string Cer = Server.MapPath("~/Certificados/" + pac.RFC + "/" + pac.RFC + ".cer");
                            System.IO.File.WriteAllBytes(Cer, cer);
                        }
                        if (file.Contains("logo"))
                        {
                            logo = new byte[fileContent.ContentLength];
                            logo = StreamHelper.ReadToEnd(fileContent.InputStream);
                        }
                    }
                }
                if (llave == null)                
                    llave = pac.Llave;
                
                if (cer == null)                
                    cer = pac.Certificado;

                if (logo == null)
                    logo = null;
                X509Certificate2 Certificado = new X509Certificate2(cer);
               /* db.UpdatePAC(Id,pac.RFC,pac.Usuario,pac.Contrasena,pac.ContrasenaLlave,pac.Nombre,pac.CURP,pac.PersonaMoral,llave,pac.RegimenFiscal,
                    pac.RegistroPatronal,pac.RfcPatronOrigen,cer,Certificado.NotBefore,Certificado.NotAfter,pac.UsuarioCreacion,pac.FechaCreacion,logo);*/
                
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { error = ex.InnerException, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { error = "none" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GuardarClaveProdServ(string ClaveProdServ,Guid IdPAC)
        {
            string[] ClaveProdServs = ClaveProdServ.Split(',');
            Usuarios usuario = db.Usuarios.Where(x => x.Usuario == User.Identity.Name).FirstOrDefault();
            List<ClaveProdServPorPAC> ClaveProdServPorPAC = db.ClaveProdServPorPAC.Where(x=>x.IdPAC==usuario.Id).ToList();
            foreach (string Clase in ClaveProdServs)
            {
                Guid Id = Guid.NewGuid();
                if (!ClaveProdServPorPAC.Where(x => x.Clase==Clase).Any())
                    db.InsertClaveProdServPorPAC(Id, IdPAC, Clase, usuario.Id, DateTime.Now);
            }
            foreach (var item in ClaveProdServPorPAC)
            {
                if (!ClaveProdServs.Contains(item.Clase))
                    db.DeleteClaveProdServPorPAC(item.Id);
            }

            return Json(new { }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ComprobarLlave(Guid Id)
        {

            Utils util = new Utils();
            GetPAC_Result pac = db.GetPAC(Id, 1).FirstOrDefault();
            string Cer = Server.MapPath("~/Certificados/" + pac.RFC + "/" + pac.RFC + ".cer");
            string Key = Server.MapPath("~/Certificados/" + pac.RFC + "/" + pac.RFC + ".key");
            string Dir= Server.MapPath("~/Facturas/" + pac.RFC);
            string Factura = Dir + "/Facturas/Prueba.xml";            
            RVCFDI33.GeneraCFDI objCfdi = new RVCFDI33.GeneraCFDI();
            objCfdi.agregarCertificado(Cer);
            objCfdi.agregarComprobante33("A", "6172", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"), "01", "", 1, 0, "MXN", "1", 1.16, "I", "PUE", "39300", "");
            objCfdi.agregarEmisor(pac.RFC, pac.Nombre, pac.RegimenFiscal.Trim());
            objCfdi.agregarReceptor("XAXX010101000", "Cliente general", "", "", "P01");
            objCfdi.agregarConcepto("01010101", "1", 1.00, "EA", "Pieza", "Producto Generica", 1.00, 1.00, 0.00);            
            objCfdi.agregarImpuestoConceptoTraslado(1, "002", "Tasa", 0.160000, 0.16);
            objCfdi.agregarImpuestos(0, 0.16);
            objCfdi.agregarTraslado("002", "Tasa", 0.160000, 0.16);
            objCfdi.GeneraXML(Key, pac.ContrasenaLlave);
            if (objCfdi.MensajeError != "")
                return Json(new { error = "Error", Message = objCfdi.MensajeError }, JsonRequestBehavior.AllowGet);
            string XML = objCfdi.Xml.Replace("Sello=\"\"", "Sello=\"" + objCfdi.SelloEmisor + "\"").Replace(",", ".");
            System.IO.File.WriteAllText(Factura, XML);
            objCfdi.TimbrarCfdiArchivo(Factura, pac.Usuario, pac.Contrasena, "http://generacfdi.com.mx/rvltimbrado/service1.asmx", Factura.Replace("Prueba.xml", ""), "Timbrado", true);
            if (objCfdi.MensajeError == "")            {
                
                RVCFDI33.RVCancelacion.Cancelacion obj = new RVCFDI33.RVCancelacion.Cancelacion();                
                string cadenaCancelacion = obj.crearXMLCancelacionCadena(Cer, Key, pac.ContrasenaLlave, objCfdi.UUID);
                if (obj.MensajeDeError == "")
                {
                    obj.enviarCancelacionCadena(cadenaCancelacion, pac.RFC, pac.Contrasena, "http://generacfdi.com.mx/rvltimbrado/service1.asmx",true);
                    if (obj.CodigoDeError == 0)
                        return Json(new { error = "none", Message = "Se Timbro Correctamente" }, JsonRequestBehavior.AllowGet);
                    else
                        return Json(new { error = "error", Message = obj.CodigoDeError }, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(new { error = "error", Message = obj.MensajeDeError }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { error = "error", Message = objCfdi.MensajeError }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult VerificarRFC(string RFC)
        {
            bool valido = false;
            if (db.PAC.Where(x => x.RFC == RFC).Any())
                valido = false;
            else valido = true;
            return Json(new { Valido = valido },JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ClaveProdServ(string data="",int Opcion=1)
        {
            
            if(Opcion==1)
            {
                /*Clave = db.GetClaveProdServClase(string.Empty, 0)
                    .Where(x=>x.Tipo==data)
                    .GroupBy(x => x.Division)
                    .ToList();*/
                var item = 00;
                return Json(new { ClaveProdServ = item},JsonRequestBehavior.AllowGet);
                              
            }
            else if (Opcion == 2)
            {
                /*Clave = db.GetClaveProdServClase(string.Empty, 0)
                    .Where(x => x.Division == data)
                    .GroupBy(x => x.Grupo)
                    .ToList();*/
            }
            else if (Opcion == 3)
            {
              /*  Clave = db.GetClaveProdServClase(data, 1)
                    .ToList();*/
            }
            return Json(new { ClaveProdServ = 3}, JsonRequestBehavior.AllowGet);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.IO;

namespace Avenzo.Controllers
{
    public class ConfiguracionController : Controller
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        // GET: Configuracion
        [Authorize]
        public ActionResult Index()
        {
           List<GetPAC_Result>pacs=db.GetPAC(null,0).ToList();
            return View(pacs);
        }
        [Authorize]
        [HttpGet]
        public ActionResult key(Guid id) {
            byte[] llave = db.GetPAC(id, 1).First().Llave;
            return File(llave, "application/pkcs8", "llave.key");
        }
        [Authorize]
        [HttpGet]
        public ActionResult cer(Guid id) {
            byte[] cer = db.GetPAC(id, 1).First().Certificado;
            return File(cer, "application/pkix-cert", "certificado.cer");
        }
        [Authorize]
        [HttpGet]
        public ActionResult Editar(Guid id)
        {
            GetPAC_Result pacs = db.GetPAC(id,1).First();
            ViewBag.RegimenFiscal = db.RegimenFiscal.ToList();
            return PartialView("_EditarPAC",pacs);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Editar(FormCollection form) {

            try {
                
                //byte[] llave=null;
                //byte[] certificado = null;
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        // get a stream
                        var stream = fileContent.InputStream;
                        // and optionally write the file to disk
                        var fileName = Path.GetFileName(file);
                        var path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                        using (var fileStream = System.IO.File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                        }
                    }
                }
               // GetPAC_Result PAC = db.GetPAC(id, 1).First();
                //db.UpdatePAC(id,form["RFC"],PAC.Usuario,PAC.Contrasena,form["ContraseñaLlave"],form["Nombre"],form["CURP"],PersonaMoral,llave,form["RegimenFiscal"],form[""],form[""],certificado,User.Identity.Name,PAC.FechaCreacion,Activo);
                return Json(new {error="none" },JsonRequestBehavior.AllowGet);
            } catch (Exception ex) {
                return Json(new {error=ex.InnerException,Message=ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [Authorize]
        [HttpGet]
        public ActionResult Nuevo()
        {
            ViewBag.RegimenFiscal = db.RegimenFiscal.ToList();
            return PartialView("_NuevoPAC");
        }
    }
}
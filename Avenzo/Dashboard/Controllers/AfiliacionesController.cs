using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
namespace Dashboard.Controllers
{
    public class AfiliacionesController : Controller
    {
        // GET: Afiliaciones
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        public ActionResult Index()
        {
            List<Catalogos> Catalogos = db.Catalogos.ToList();
            return View(Catalogos);
        }
        public ActionResult Editar(Guid Id)
        {
            Catalogos catalogo = db.Catalogos.Where(x => x.IdCatalogo == Id).First();
            return PartialView(catalogo);
        }
        public ActionResult Nuevo()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Nuevo(Catalogos catalogo)
        {
            try {
                /*db.InsertCatalagos(catalogo.IdCatalogo,catalogo.Tipo,catalogo.Descripcion,catalogo.Descripcion,catalogo.Valor,
                    catalogo.Cantidad,catalogo.FechaLimiteInicio,catalogo.FechaLimiteFinal,DateTime.Now,User.Identity.Name,true);
            */}
            catch (Exception ex) {
                return Json(new {error=ex.InnerException,Message=ex.Message }, JsonRequestBehavior.AllowGet);
            }
            
            return Json(new {error="none"},JsonRequestBehavior.AllowGet);
        }
        public ActionResult Eliminar(Guid id)
        {
            try {
                //db.DeleteCatalogo(id, 0);
                return Json(new {error="none"},JsonRequestBehavior.AllowGet);
            } catch (Exception ex) {
                return Json(new {error=ex.InnerException,Message=ex.Message },JsonRequestBehavior.AllowGet);
            }
        }
    }
}
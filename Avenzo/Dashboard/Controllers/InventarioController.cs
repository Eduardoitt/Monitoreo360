using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
namespace Dashboard.Controllers
{
    public class InventarioController : Controller
    {
        // GET: Inventario
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Service()
        {
            List<GetInventario_Result> inventario = db.GetInventario().Where(x=>x.Cantidad>0).ToList();
            return Json(new { Item = inventario },JsonRequestBehavior.AllowGet);
        }
    }
}
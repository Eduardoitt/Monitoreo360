using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Avenzo.Controllers
{
    public class SolucionesSeguridadController : Controller
    {
        // GET: SolucionesSeguridad
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MonitoreoAvenzo()
        {
            return View();
        }
        public ActionResult AvenzoSecuritySystem() {
            return View();
        }
        
    }
}
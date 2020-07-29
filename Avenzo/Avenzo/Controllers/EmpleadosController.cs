using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
namespace Avenzo.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        public ActionResult Index()
        {
            List<Empleados> Empleado = db.GetEmpleados(0, null).ToList();
            return View(Empleado);
        }
    }
}
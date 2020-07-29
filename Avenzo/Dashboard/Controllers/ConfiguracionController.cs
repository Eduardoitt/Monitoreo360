using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
namespace Dashboard.Controllers
{
    public class ConfiguracionController : Controller
    {
        // GET: Configuracion
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        public ActionResult Index()
        {
            ConfiguracionView configuracion = new ConfiguracionView();
            configuracion.Usuario = db.Usuarios.Where(x=>x.Usuario==User.Identity.Name).First();
            if (configuracion.Usuario.TipoUsuario == "Cliente")
            {
                configuracion.Clientes = db.GetClientes(null, true, 0).Where(x => x.IdUsuario == configuracion.Usuario.Id).FirstOrDefault();
            }
            else {
                configuracion.Empleados = db.Empleados.Where(x => x.IdUsuario == configuracion.Usuario.Id).FirstOrDefault();
            }
            return PartialView(configuracion);
        }
    }
}
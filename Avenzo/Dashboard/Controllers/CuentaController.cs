using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
namespace Dashboard.Controllers
{
    public class CuentaController : Controller
    {
        // GET: Cuenta
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult FormularioRecuperar() {
            if (User.Identity.IsAuthenticated)
                return Redirect("/");
            else
                return PartialView();
        }
        [HttpGet]
        public ActionResult Recuperar() {
            if (User.Identity.IsAuthenticated)
                return Redirect("/");
            else
                return View();
        }
        [HttpGet]
        public ActionResult FormularioCambiarContraseña() {
            if (User.Identity.IsAuthenticated)
                return Redirect("/");
            else
                return PartialView();
        }
        [HttpGet]
        public ActionResult CambiarContraseña() {
            if (User.Identity.IsAuthenticated)
                return Redirect("/");
            else
                return View();
        }
        [HttpPost]
        public ActionResult Recuperar(string Correo)
        {
            try {
                Usuarios usuario = db.Usuarios.Where(x => x.Usuario == Correo).First();
                Clientes Cliente = db.Clientes.Where(x => x.IdUsuario == usuario.Id).FirstOrDefault();
                if (Cliente != null)
                {
                    Helpers.Correo.EnviarContraseña(Correo, usuario.Id, Cliente.Nombres + " " + Cliente.ApellidoPaterno + " " + Cliente.ApellidoMaterno, usuario.Contraseña, "http://avenzo.mx/Usuario/CambiarContraseña", Server.MapPath("~/Tools/plantilla_contraseña.html"));
                }
                else {
                    Empleados empleado = db.Empleados.Where(x => x.IdUsuario == usuario.Id).FirstOrDefault();
                    Helpers.Correo.EnviarContraseña(Correo, usuario.Id, empleado.Nombre + " " + empleado.ApellidoPaterno + " " + empleado.ApellidoMaterno, usuario.Contraseña, "http://avenzo.mx/Usuario/CambiarContraseña", Server.MapPath("~/Tools/plantilla_contraseña.html"));
                }
                
                return Json(new { error = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) {
                return Json(new { error = true, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }            
        }
        [HttpPost]
        public ActionResult CambiarContraseña(FormCollection form) {
            if (User.Identity.IsAuthenticated)
                return Redirect("/");
            else
                return View();
        }
        [HttpPost]
        public ActionResult VerificarCorreo(string correo)
        {
            bool isReady = db.Usuarios.Where(x => x.Usuario == correo).Any();
            return Json(new { Disponible = !isReady }, JsonRequestBehavior.AllowGet);
        }
    }
}
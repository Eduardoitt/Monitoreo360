using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
namespace Avenzo.Controllers
{
    public class ContactoController : Controller
    {
        // GET: Contacto
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Enviar(ContactoView Contacto) {
            try {
                Tools.Correo.EnviarContacto(Contacto.Nombres,Contacto.ApellidoPaterno,Contacto.ApellidoMaterno,Contacto.Sexo,
                    Contacto.Departamento,Contacto.Correo,Contacto.Telefono,Contacto.Mensaje, Server.MapPath("~/Views/Contacto/plantilla.html"));
                return View("Enviado");
            } catch (Exception ex) {
                ViewBag.Error = "Ocurrior un Error:"+ex.Message;
                ViewBag.Message = ex.InnerException;
                return View("Error");
            }
        }
    }
}
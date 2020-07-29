using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(int error=0,string Message="")
        {
            if (User.Identity.IsAuthenticated)
            {
                switch (error)
                {
                    case 505:
                        ViewBag.Title = "Ocurrio un error inesperado";
                        ViewBag.Description = "Esto es muy vergonzoso, esperemos que no vuelva a pasar ..";
                        ViewBag.Message = Message;
                        break;

                    case 404:
                        ViewBag.Title = "Página no encontrada";
                        ViewBag.Description = "La URL que está intentando ingresar no existe";
                        ViewBag.Message = Message;
                        break;
                    default:
                        ViewBag.Title = "Error en la pagina";
                        ViewBag.Description ="Algo salio muy mal :( ..";
                        ViewBag.Message = Message;
                        break;
                }
                //Response.RedirectLocation = "/Error?error="+error;
                return Json(new {error=true,Message=Message,Description= "Algo salio muy mal :( .." },JsonRequestBehavior.AllowGet);                
            }else
            {
                switch (error)
                {
                    case 505:
                        ViewBag.Title = "Ocurrio un error inesperado";
                        ViewBag.Description = "Esto es muy vergonzoso, esperemos que no vuelva a pasar ..";
                        break;

                    case 404:
                        ViewBag.Title = "Página no encontrada";
                        ViewBag.Description = "La URL que está intentando ingresar no existe";
                        break;
                    default:
                        ViewBag.Title = "Página no encontrada";
                        ViewBag.Description = "Algo salio muy mal :( ..";
                        break;
                }
                return View();
            }
            
        }
    }
}
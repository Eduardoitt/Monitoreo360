using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Helpers;
using Model;
namespace Dashboard.Controllers
{
    public class LoginController : Controller
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        // GET: Login
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return Redirect("/");
            else
                return View();
        }
        [HttpGet]
        public ActionResult FormularioLogin() {
            if (User.Identity.IsAuthenticated)
                return Redirect("/");
            else
                return PartialView();
        }        
        [HttpPost]        
        public ActionResult LogIn(Login User, string ReturnUrl="")
        {
            try
            {
                string decodedUrl = "";
                if (!string.IsNullOrEmpty(ReturnUrl)) { 
                    decodedUrl = Server.UrlDecode(ReturnUrl);
                }
                bool Auth = Membership.ValidateUser(User.UserName, SHA1.Encode(User.Password));
                if (Auth)
                {
                    FormsAuthentication.RedirectFromLoginPage(User.UserName, false);
                    if (Url.IsLocalUrl(decodedUrl))
                        return Redirect(decodedUrl);
                    else
                        return RedirectToAction("index", "Home");
                }
                else
                {
                    return Json(new { error = true }, JsonRequestBehavior.AllowGet);
                }
                
            }
            catch (Exception ex) {
                return Json(new {error=true,Message=ex.Message },JsonRequestBehavior.AllowGet);
            }            
        }
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
        public ActionResult FormularioRegistrar() {
            if (User.Identity.IsAuthenticated) {
                return Redirect("/");
            } else
                return PartialView();
        }
        public ActionResult Registrarse() {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }else
            return View();

        }
        [HttpPost]
        public ActionResult Registrarse(RegistrarseView form) {
            FormsAuthentication.RedirectFromLoginPage(form.Correo,true);
            Guid IdUsuario = Guid.NewGuid();
            db.InsertUsuario(IdUsuario, form.Correo, SHA1.Encode(form.Contraseña), "Cliente", "Cliente", true, 10, 0, 0,true);
            db.InsertClientes(Guid.NewGuid(),Guid.Parse("9b13afbb-1455-483e-84d5-cf339dc7ff16"),IdUsuario,null,form.Nombres,
                form.ApellidoPaterno,form.ApellidoMaterno,null,null,
                null,null,null,null,null,null,
                null,null,null,null,null,null,null,
                "México",null,null,null,form.FechaNacimiento,null,Guid.NewGuid(),
                null,null,null,null,null,null,
                null,null,null,null,null,null,
                null,DateTime.Now, null,true);
            return Redirect("/");
        }

    }
}
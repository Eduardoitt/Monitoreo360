using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Model;
using Helpers;

namespace Avenzo.Controllers
{
    public class UsuarioController : Controller
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        // GET: Usuario
        [Authorize]
        public ActionResult Index()
        {
            Usuarios usuario = db.Usuarios.Where(x => x.Usuario==User.Identity.Name).FirstOrDefault();
            Clientes clientes = db.GetClientes(null,true,0).Where(x=>x.IdUsuario==usuario.Id).FirstOrDefault();
            if (clientes == null)
            {
                Empleados empleado = db.GetEmpleados(0,null).Where(x=>x.IdUsuario==usuario.Id).FirstOrDefault();
                ViewBag.Nombre = empleado.Nombre;
                ViewBag.ApellidoPaterno = empleado.ApellidoPaterno;
                ViewBag.ApellidoMaterno = empleado.ApellidoMaterno;
                ViewBag.Pais = "Mexico";
                ViewBag.Telefono = empleado.Telefono;
                
            }
            else {
                ViewBag.Nombre = clientes.Nombres;
                ViewBag.ApellidoPaterno = clientes.ApellidoPaterno;
                ViewBag.ApellidoMaterno = clientes.ApellidoMaterno;
                ViewBag.Pais = clientes.Pais;
                ViewBag.Telefono = clientes.Telefono;
                ViewBag.Sexo = clientes.Sexo;
            }
            
            return View();
        }
        [HttpGet]       
        public ActionResult Login() {
            if (HttpContext.User.Identity.IsAuthenticated)            
                return Redirect("/Usuario");            
            if (Session["Recupero"] ==null)            
                ViewBag.Recuperar = false;            
            else ViewBag.Recuperar = true;
            Session.Remove("Recupero");
            ViewBag.returnUrl=Request.Params["returnUrl"];
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login User,string returnUrl) {            
            string decodedUrl = "";
            if (!string.IsNullOrEmpty(returnUrl))
                decodedUrl = Server.UrlDecode(returnUrl);

            if (Membership.ValidateUser(User.UserName,Helpers.SHA1.Encode(User.Password)))
            {
                FormsAuthentication.RedirectFromLoginPage(User.UserName,false);
                if (Url.IsLocalUrl(decodedUrl))                
                    return Json(new { error=false, url=decodedUrl },JsonRequestBehavior.AllowGet);                
                else                
                    return Json(new { error=false},JsonRequestBehavior.AllowGet);
            }
            return Json(new {error=true },JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Recuperar() {
            return View();
        }
        [HttpPost]
        public ActionResult Recuperar(FormCollection form) {
            try {
                string Email = form["Correo"];
                bool Empleados = db.Empleados.Where(x => x.Email == Email).Any();
                bool Clientes = db.Clientes.Where(x => x.Email == Email).Any();
                if (Empleados)
                {
                    Empleados em = db.Empleados.Where(x => x.Email == Email).First();
                    Usuarios us = db.Usuarios.Where(x => x.Id == em.IdUsuario).First();
                    Tools.Correo.EnviarContraseña(em.Email,(Guid)us.Id,em.Nombre+" "+em.ApellidoPaterno+" "+em.ApellidoMaterno,us.Contraseña,"http://avenzo.mx/Usuario/CambiarContraseña",Server.MapPath("~/Views/Email/plantilla.html"));
                    return View("Completado");
                }
                else if (Clientes)
                {
                    Clientes em = db.Clientes.Where(x => x.Email == Email).First();
                    Usuarios us = db.Usuarios.Where(x => x.Id == em.IdUsuario).First();
                    Tools.Correo.EnviarContraseña(em.Email, (Guid)us.Id, em.Nombres + " " + em.ApellidoPaterno + " " + em.ApellidoMaterno, us.Contraseña, "http://avenzo.mx/Usuario/CambiarContraseña", Server.MapPath("~/Views/Email/plantilla.html"));
                    return View("Completado");
                }
                else {
                    ViewBag.Message = "No se encontro el correo electronico";
                    return View("Error");
                }
            } catch (Exception ex) {
                ViewBag.Message = ex.Message;
                return View("Error");
            }
            
        }        
        [HttpGet]
        public ActionResult CambiarContraseña(string IdTemp,string Q) {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                Guid iD = Guid.Parse(IdTemp);
                string P = Q;
                if (db.Usuarios.Where(x => x.Id == iD && x.Contraseña == P).Any())
                {
                    ViewBag.Id = iD;
                    return View();
                }
                else
                    return Redirect("/");
            }
            else
                return Redirect("/");
                
        }
        [HttpPost]
        public ActionResult CambiarContraseña(FormCollection form) {
            Guid id = Guid.Parse(form["id"]);
            string pass = Helpers.SHA1.Encode(form["Contraseña"]);

            Usuarios us = db.Usuarios.Where(x => x.Id == id).First();
            db.UpdateUsuarios(id, us.Usuario, pass, us.TipoUsuario, us.Roles, true, us.Timbres, us.TimbresUsados, us.TimbresCancelados,us.PrimeraVez);
            //FormsAuthentication.RedirectFromLoginPage(us.Usuario, false);
            Session["Recupero"] = true;
            //db.Updat(id,us.Usuario,Helpers.SHA1.Encode(pass),us.TipoUsuario,us.Roles,us.Activo);
            return Redirect("/Usuario/Login");
        }
        [HttpGet]
        public ActionResult Registrar() {
            if (!HttpContext.User.Identity.IsAuthenticated) {
                ViewBag.Pais = db.Pais.ToList();
                ViewBag.Ciudad = db.Ciudad.ToList();
                ViewBag.Estado = db.Estados.ToList().Where(x => x.c_Pais == "MEX" && x.NombreEstado.Contains("Baja"));
                ViewBag.Bancos = db.Bancos.ToList();
                ViewBag.PAC = db.GetPAC(null, 0);
                ViewBag.Usuarios = db.Usuarios.ToList();
                ViewBag.TipoAfiliacion = db.Catalogos
                    .Where(x => x.Nombre == "Paquete");
                List<Clientes> clientes = db.Clientes.Where(x => x.Email != null && !x.Email.Contains("n/a") && x.Email != string.Empty).ToList();
                List<Empleados> empleados = db.Empleados.Where(x => x.Email != null && !x.Email.Contains("n/a") && x.Email != string.Empty).ToList();
                ViewBag.Email1 = clientes;
                ViewBag.Email = empleados;
                return View();
            } else
                return Redirect("/"); 
            
        }
        [HttpPost]
        public ActionResult RegistrarUsuario(FormCollection form) {
            try
            {
                string Correo = form["correo"],Contraseña=form["password"];
                Clientes cliente = db.GetClientes(null, true, 0).Where(x => x.Email ==Correo).FirstOrDefault();
                Guid id = Guid.NewGuid();
                db.InsertUsuario(id,Correo,SHA1.Encode(Contraseña),"Cliente","Cliente",true,10,0,0,true);
                /*db.UpdateClientes(cliente.IdCliente,cliente.IdProveedor,cliente.NumeroDeCuenta,cliente.NumeroTelefonoAlarma,
                    cliente.PalabraClave,cliente.PalabraClaveSilenciosa,cliente.Nombres,cliente.ApellidoPaterno,cliente.ApellidoMaterno,
                    cliente.Calle,cliente.NoInterior,cliente.NoExterior,cliente.Colonia,cliente.CodigoPostal,cliente.Telefono,
                    cliente.TelefonoTrabajo,cliente.TelefonoCelular,cliente.Email,cliente.Foto,cliente.Estado,cliente.Pais,cliente.Ciudad,
                    cliente.IdProveedor,cliente.NumeroPatrocinador,cliente.FechaNacimiento,cliente.LugarNacimiento,cliente.Sexo,
                    cliente.EstadoCivil,cliente.Profesion,cliente.CURP,cliente.RFC,cliente.NumCtaPago,cliente.ClaveBancaria,cliente.Banco,
                    cliente.NumeroCLABE,cliente.Beneficiario,cliente.FechaCreacion,"Pagina Avenzo",true,id);*/
                FormsAuthentication.RedirectFromLoginPage(Correo, false);
                return Redirect("/");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrio un error";
                ViewBag.Message = ex.Message;
                return View("Error");
            }
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Inicio");
        }
        [HttpPost]
        public ActionResult VerificarCorreo(string correo) {            
            bool isReady =  db.Usuarios.Where(x=>x.Usuario==correo).Any();
            return Json(new { Disponible = !isReady }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult VerificarCliente(string correo) {
            bool isExist = db.Clientes.Where(x => x.Email == correo).Any();
            return Json(new {Existe=isExist },JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult RegistrarCliente(FormCollection form) {
            string Correo = form["Correo"],Nombres=form["Nombres"],ApellidoPaterno=form["ApellidoPaterno"],ApellidoMaterno=form["ApellidoMaterno"],
                Sexo=form["Sexo"], contraseña=form["contraseña"], repeatContraseña=form["repeatContraseña"], Telefono=form["Telefono"],
                Pais=form["Pais"], Estado=form["Estado"], Ciudad=form["Ciudad"];
            Guid IdUsuario = Guid.NewGuid();
            Guid IdCliente = Guid.NewGuid();
            Guid IdProveedor = Guid.Parse("9B13AFBB-1455-483E-84D5-CF339DC7FF16");
            string FechaNacimiento =form["FechaNacimiento"];
            db.InsertUsuario(IdUsuario,Correo,SHA1.Encode(contraseña),"Cliente","Cliente",true,10,0,0,true);
            db.InsertClientes(IdCliente,IdProveedor,IdUsuario,null,Nombres,
                ApellidoPaterno,ApellidoMaterno,null,null,null,
                null,null,null,null,null,Telefono,null,null,null,null,null,null,
                null,null,null,null,Estado,Pais,null,
                null,null,null,null,null,null,
                null,null,null,null,null,null,
                null,null,null,true);
            FormsAuthentication.RedirectFromLoginPage(Correo, false);
            return Redirect("/");
        }
        [HttpPost]
        public ActionResult VerficarContraseña(Guid IdTemp,string Q)
        {
            string pass = Helpers.SHA1.Encode(Q);
            var usuario = db.Usuarios.Where(x=>x.Id==IdTemp&x.Contraseña== pass).Any();
            return Json(new { valido=!usuario},JsonRequestBehavior.AllowGet);
        }
        
        
    }
}
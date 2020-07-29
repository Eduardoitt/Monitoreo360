using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.Web.Security;

namespace Avenzo.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        [Authorize]
        public ActionResult Index()
        {
            List<Clientes> Clientes;
            if (User.IsInRole("Admin"))
                Clientes = db.GetClientes(null, true,0).ToList();
            else{
                Usuarios usuario = db.Usuarios.Where(x=>x.Usuario==User.Identity.Name).FirstOrDefault();
                List<Empleados> empleado = db.GetEmpleados(0, null).Where(x => x.IdUsuario == usuario.Id).ToList();
                if (empleado.Count>0)
                    Clientes = db.GetClientes(null, true,0).Where(x => x.IdProveedor == empleado.First().IdProveedor).ToList();
                else
                {
                    Clientes cliente = db.GetClientes(null, true,0).Where(x=>x.IdUsuario==usuario.Id).First();
                    Clientes = db.GetClientes(null,true,0).Where(x => x.IdProveedor == cliente.IdProveedor).ToList();
                }
            }
            return View(Clientes);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Editar(string TempId)
        {
            ViewBag.Pais = db.Pais.ToList();
            ViewBag.Ciudad = db.Ciudad.ToList();
            ViewBag.Estados = db.Estados.ToList().Where(x => x.c_Pais == "MEX" && x.NombreEstado.Contains("Baja"));
            ViewBag.Bancos = db.Bancos.ToList();
            /*bool Cliente = db.Clientes.Where(x => x.IUsuario == User.Identity.Name).Any();
            if (Cliente)
                ViewBag.PAC = db.GetPAC(null, 0).Where(x=>x.Id==db.Clientes_ALT.Where(yx=>yx.Usuario==User.Identity.Name).First().IdProveedor);
            else*/
            ViewBag.PAC = db.GetPAC(null, 0).ToList();
            ViewBag.TipoAfiliacion = db.Catalogos
                .Where(x => x.Tipo == "Paquete");
            Clientes cliente = db.GetClientes(Guid.Parse(TempId),true,1).First();            
            return PartialView("_Editar",cliente);
        }
        [HttpPost]
        public ActionResult Editar(FormCollection form) {
            try {
                /*db.UpdateClientes(Guid.Parse(form["idCliente"]),Guid.Parse(form["PAC"]), form["TelefonoAlarma"], form["PalabraClave"], form["PalabraClaveSilenciosa"], form["Nombres"], form["ApellidoPaterno"], form["ApellidoMaterno"],
                    form["Calle"], form["NoInterior"], form["NoExterior"], form["Colonia"], form["CodigoPostal"], form["TelefonoCasa"], form["TelefonoTrabajo"], form["TelefonoCelular"], form["Correo"], null, form["Estado"],
                    form["Pais"], form["Ciudad"], form["TipoAfilacion"], form["CorreoPatrocinador"], form["FechaNacimiento"], form["LugarNacimiento"], form["Sexo"], form["EstadoCivil"], form["Profecion"], form["CURP"], form["RFC"],
                    form["CuentaBancaria"], form["banco"], form["CLABE"], form["Beneficiario"], DateTime.Parse(form["FechaCreacion"]),form["UsuarioCreacion"], true,form["Usuario"]);*/
                return Json(new { error = "none" }, JsonRequestBehavior.AllowGet);
            } catch (Exception ex) {
                return Json(new {error=ex.InnerException,Message=ex.Message },JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Eliminar(string id) {
            try {
                db.DeleteClientes(Guid.Parse(id),0);
                return Json(new {error="none" }, JsonRequestBehavior.AllowGet);
            } catch (Exception ex) {
                return Json(new {error=ex.InnerException,Message=ex.Message}, JsonRequestBehavior.AllowGet);
            }            
        }
        [Authorize]
        [HttpGet]
        public ActionResult Nuevo() {
            ViewBag.Pais = db.Pais.ToList();
            ViewBag.Ciudad = db.Ciudad.ToList();
            ViewBag.Estado = db.Estados.ToList().Where(x => x.c_Pais == "MEX" && x.NombreEstado.Contains("Baja"));
            ViewBag.Bancos = db.Bancos.ToList();
            ViewBag.PAC = db.GetPAC(null,0);
            ViewBag.TipoAfiliacion = db.Catalogos
                .Where(x => x.Tipo == "Paquete");
            return PartialView("_Nuevo");
        }
        
        [HttpPost]
        public ActionResult Nuevo(FormCollection form)
        {
            try {
                Guid id = Guid.NewGuid();
                /*db.InsertCliente_ALT(Guid.Parse(form["PAC"]), form["TelefonoAlarma"], form["PalabraClave"], form["PalabraClaveSilenciosa"], form["Nombres"], form["ApellidoPaterno"], form["ApellidoMaterno"], 
                    form["Calle"], form["NoInterior"], form["NoExterior"], form["Colonia"], form["CodigoPostal"], form["TelefonoCasa"], form["TelefonoTrabajo"], form["TelefonoCelular"], form["Correo"],null, form["Estado"], 
                    form["Pais"], form["Ciudad"], form["TipoAfilacion"], form["CorreoPatrocinador"], form["FechaNacimiento"], form["LugarNacimiento"], form["Sexo"], form["EstadoCivil"], form["Profecion"], form["CURP"], form["RFC"], 
                    form["banco"], form["CuentaBancaria"], form["CLABE"], form["Beneficiario"],DateTime.Now, User.Identity.Name, true,null,id);*/
                return Json(new {error="none" },JsonRequestBehavior.AllowGet);
            } catch (Exception ex) {
                return Json(new { error = ex.InnerException,Message=ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Detalles(string TempId) {
            List<Clientes> cliente = db.GetClientes(Guid.Parse(TempId), true,0).ToList();
            return PartialView("_Detalles",cliente);
        }
    }
}
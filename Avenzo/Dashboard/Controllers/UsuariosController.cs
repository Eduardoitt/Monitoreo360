using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Helpers;
namespace Dashboard.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        public ActionResult Index()
        {            
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult _Panel() {
            List<Usuarios> usuarios = db.Usuarios.ToList();
            return View(usuarios);
        }
        [Authorize]
        [HttpGet]
        public ActionResult VerificarTimbres(Guid IdTemp) {
            Usuarios usuario = db.Usuarios.Where(x => x.Id == IdTemp).FirstOrDefault();
            bool timbres;
            if (usuario.Roles.Contains("Admin")) {
                timbres =false;
            }else
            {
                if (usuario.TimbresUsados >= usuario.Timbres)
                    timbres = true;
                else timbres = false;
            }
            return Json(new { error= timbres,Timbres=(usuario.Timbres-usuario.TimbresUsados) },JsonRequestBehavior.AllowGet) ;
        }
        public ActionResult _FaltaTimbres() {
            Usuarios usuario = db.Usuarios.Where(x => x.Usuario ==User.Identity.Name).FirstOrDefault();
            Clientes cliente = db.Clientes.Where(x=>x.IdUsuario==usuario.Id).FirstOrDefault();
            if(cliente!=null)
                ViewBag.Nombre = cliente.Nombres + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
            else
            {
                Empleados empleado = db.Empleados.Where(x => x.IdUsuario == usuario.Id).FirstOrDefault();
                ViewBag.Nombre = empleado.Nombre + " " + empleado.ApellidoPaterno + " " + empleado.ApellidoMaterno;
            }
            return PartialView();
        }
        [HttpGet]
        [Authorize]
        public ActionResult Editar(Guid IdTemp) {
            Usuarios usuario = db.Usuarios.Where(x => x.Id == IdTemp).FirstOrDefault();
            return PartialView(usuario);
        }
       
        [HttpPost]               
        [Authorize]
        public ActionResult Editar(Guid Id,string Usuario,int Timbres,string Contraseña,string Permisos,bool Activo) {
            try {
                Usuarios usuario = db.Usuarios.Where(x => x.Id == Id).FirstOrDefault();
                string contraseña = Contraseña == "" || Contraseña == null ? usuario.Contraseña : Helpers.SHA1.Encode(Contraseña);
                int timbres = Timbres +  usuario.TimbresUsados;//-10 + 10 =-20   10 0=10
                db.UpdateUsuarios(Id, Usuario, contraseña, usuario.TipoUsuario, Permisos, Activo,timbres, usuario.TimbresUsados, usuario.TimbresCancelados, true);
                return Json(new { error = false }, JsonRequestBehavior.AllowGet);
            } catch (Exception ex) {
                return Json(new {error=true,Message=ex.Message},JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Nuevo() {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Nuevo(string Tipo,string Permiso,Guid Id,string Usuario,int Timbres,string Contrasena) {
            try
            {
                Guid IdUsuario = Guid.NewGuid();
                if (Tipo == "Cliente")
                {
                    Clientes cliente = db.GetClientes(Id, true, 1).First();
                   /* db.UpdateClientes(Id, cliente.IdProveedor, cliente.NumeroDeCuenta, cliente.NumeroTelefonoAlarma,
                        cliente.PalabraClave, cliente.PalabraClaveSilenciosa, cliente.Nombres, cliente.ApellidoPaterno, cliente.ApellidoMaterno,
                        cliente.Calle, cliente.NoInterior, cliente.NoExterior, cliente.Colonia, cliente.CodigoPostal, cliente.Telefono,
                        cliente.TelefonoTrabajo, cliente.TelefonoCelular, Usuario, cliente.Foto, cliente.Estado, cliente.Pais, cliente.Ciudad,
                        cliente.TipoAfilacion, cliente.NumeroPatrocinador, cliente.FechaNacimiento, cliente.LugarNacimiento, cliente.Sexo,
                        cliente.EstadoCivil, cliente.Profesion, cliente.CURP, cliente.RFC, cliente.NumCtaPago, cliente.ClaveBancaria, cliente.Banco,
                        cliente.NumeroCLABE, cliente.Beneficiario, cliente.FechaCreacion, cliente.UsuarioCreacion, true, IdUsuario);*/
                }
                else {
                    Empleados empleado = db.GetEmpleados(0,null).Where(x=>x.Id==Id).First();
                    db.UpdateEmpleado(empleado.Id,empleado.NoEmpleado, empleado.IdProveedor,empleado.Nombre,empleado.ApellidoMaterno,
                        empleado.ApellidoPaterno,IdUsuario,Usuario,empleado.FechaNacimiento,empleado.FechaInicioRelLaboral,
                        empleado.RFC,empleado.CURP,empleado.HuellaDactilar,empleado.Foto,empleado.INE,empleado.NumeroSeguridadSocial,
                        empleado.Departamento,empleado.Direccion,empleado.Puesto,empleado.RiesgoPuesto,empleado.TipoContrato,empleado.TipoJornada,
                        empleado.SalarioDiario,empleado.Banco,empleado.CuentaBancaria,empleado.ClaveEntFed,empleado.GradoEstudios,empleado.Telefono,
                        empleado.TelefonoEmergencia,empleado.Firma,empleado.TipoSangre,empleado.CUIP,empleado.NumeroDeLicencia,empleado.NumeroDeAutorizacion,
                       empleado.IdPlantilla,true);
                }
                db.InsertUsuario(IdUsuario,Usuario,Helpers.SHA1.Encode(Contrasena),Tipo,Permiso,true,Timbres,0,0,true);
            }
            catch (Exception ex)
            {
                return Json(new {error=true,Message=ex.Message },JsonRequestBehavior.AllowGet);
            }                
            return Json(new {error=false },JsonRequestBehavior.AllowGet);
        }
    }
}
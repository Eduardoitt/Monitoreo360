using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.Globalization;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace Dashboard.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return PartialView();
        }
        [Authorize]
        [HttpGet]
        public ActionResult _PanelClientes() {
            Usuarios usuario = db.Usuarios.Where(x => x.Usuario == User.Identity.Name).First();
            List<ClientesForPanel> Clientes = new List<ClientesForPanel>();
            if (User.IsInRole("Admin"))
                Clientes = db.ClientesForPanel.OrderBy(x=>x.Nombre).ToList();
            else            
                Clientes = db.ClientesForPanel.Where(x => x.UsuarioCreacion == usuario.Id).OrderBy(x=>x.Nombre).ToList();
            
            return PartialView(Clientes);
        }

        
        [Authorize]
        [HttpGet]
        public ActionResult Editar(string TempId)
        {
            ViewBag.Pais = db.Pais.ToList();
            ViewBag.Ciudad = db.Ciudad.ToList();
            ViewBag.Estados = db.Estados.ToList().Where(x => x.c_Pais == "MEX" && x.NombreEstado.Contains("Baja"));
            ViewBag.Bancos = db.Bancos.ToList();
            Usuarios usuario = db.Usuarios.Where(x=>x.Usuario==User.Identity.Name).First();

            if (usuario.Roles.Contains("Admin")) {
                ViewBag.PAC = db.GetPAC(null, 0);

            }else {
                Clientes clientes = db.Clientes.Where(x => x.IdUsuario == usuario.Id).First();
                ViewBag.PAC = db.GetPAC(null, 0).Where(x=>x.Id==clientes.IdProveedor);
            }


            ViewBag.TipoAfiliacion = db.Catalogos.Where(x => x.Tipo != "Creditos"
              && x.Activo == true
              && x.FechaLimiteInicio <= DateTime.Now
              && x.FechaLimiteFinal >= DateTime.Now).ToList();
            Guid Id = Guid.Parse(TempId);
            Clientes cliente = db.GetClientes(Id,true,1).First();
            return PartialView("_Editar", cliente);
        }
        [HttpPost]
        public ActionResult Eliminar(Guid id)
        {
            try
            {
                Clientes cliente = db.Clientes.Where(x => x.Activo == true && x.IdCliente == id).First();
                Usuarios usuarios = db.Usuarios.Where(x=>x.Id==cliente.IdUsuario).FirstOrDefault();
                db.DeleteClientes(id,0);
                if(usuarios!=null)
                    db.UpdateUsuarios(usuarios.Id, usuarios.Usuario, usuarios.Contraseña, usuarios.TipoUsuario, usuarios.Roles, false, usuarios.Timbres, usuarios.TimbresUsados, usuarios.TimbresCancelados,usuarios.PrimeraVez);                
                return Json(new { error = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.InnerException, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [Authorize]
        [HttpGet]
        public ActionResult Nuevo()
        {
            ViewBag.Pais = db.Pais.ToList();
            ViewBag.Ciudad = db.Ciudad.ToList();
            ViewBag.Estado = db.Estados.ToList().Where(x => x.c_Pais == "MEX" && x.NombreEstado.Contains("Baja"));
            ViewBag.Bancos = db.Bancos.ToList();
            Usuarios usuario = db.Usuarios.Where(x => x.Usuario == User.Identity.Name).First();
            if(User.IsInRole("Admin"))
                ViewBag.PAC = db.GetPAC(null, 0);
            else
                ViewBag.PAC = db.GetPAC(null, 0).Where(x=>x.UsuarioCreacion==usuario.Id);
            ViewBag.TipoAfiliacion = db.Catalogos.Where(x => x.Tipo != "Creditos" 
                && x.Activo == true
                /*&& x.FechaLimiteInicio<=DateTime.Now
                && (x.FechaLimiteFinal>=DateTime.Now)*/).ToList();
            return PartialView("_Nuevo");
        }
        [HttpPost]
        public ActionResult Nuevo(Clientes  cliente)
        {
            try
            {
                Usuarios usuario = db.Usuarios.Where(x=>x.Usuario==User.Identity.Name).First();
                Guid id = cliente.IdCliente;
                string NumeroTelefonoAlarma = cliente.NumeroTelefonoAlarma == null ?"":cliente.NumeroTelefonoAlarma.Replace("-", "").Replace(" ", ""),
                    NumeroDeCuenta = cliente.NumeroDeCuenta == null ? "" : cliente.NumeroDeCuenta.Replace("-", ""),
                    TelefonoCelular = cliente.TelefonoCelular == null ? "" : cliente.TelefonoCelular.Replace("-", "").Replace(" ", "").Replace(")","").Replace("(",""),
                    TelefonoTrabajo = cliente.TelefonoTrabajo == null ? "" : cliente.TelefonoTrabajo.Replace("-", "").Replace(" ", "").Replace(")", "").Replace("(", ""),
                    Telefono = cliente.Telefono == null ? "" : cliente.Telefono.Replace("-", "").Replace(" ", "").Replace(")", "").Replace("(", "");
                db.InsertClientes(id,cliente.IdProveedor,null,NumeroTelefonoAlarma, cliente.Nombres,
                    cliente.ApellidoPaterno, cliente.ApellidoMaterno, NumeroDeCuenta, cliente.PalabraClave, cliente.PalabraClaveSilenciosa,
                    cliente.Calle, cliente.NoInterior, cliente.NoExterior, cliente.Colonia, cliente.CodigoPostal,cliente.Referencias,
                    cliente.ColorEstablecimiento,cliente.EntreCalles,cliente.GoogleMaps,cliente.Descripcion,Telefono, TelefonoTrabajo, 
                    TelefonoCelular, cliente.Email, null, cliente.Estado, cliente.Pais, cliente.Ciudad,cliente.TipoAfilacion, 
                    cliente.NumeroPatrocinador, cliente.FechaNacimiento, cliente.LugarNacimiento, cliente.Sexo,cliente.EstadoCivil, cliente.Profesion, 
                    cliente.CURP, cliente.RFC, cliente.Banco,cliente.NumCtaPago, cliente.ClaveBancaria,cliente.NumeroCLABE,
                    cliente.Beneficiario,DateTime.Now, usuario.Id, true);
                return Json(new { error = "none" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.InnerException, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [Authorize]
        [HttpPost]
        public ActionResult Editar(Clientes cliente)
        {
            try {
                Usuarios usuario = db.Usuarios.Where(x=>x.Usuario==User.Identity.Name).First();
                
                db.UpdateClientes(cliente.IdCliente,cliente.IdProveedor,cliente.NumeroDeCuenta.Replace("-",""),cliente.NumeroTelefonoAlarma.Replace("(","").Replace("-","").Replace(")","").Replace(" ",""),
                    cliente.PalabraClave,cliente.PalabraClaveSilenciosa,cliente.Nombres,cliente.ApellidoPaterno,cliente.ApellidoMaterno,
                    cliente.Calle,cliente.NoInterior,cliente.NoExterior,cliente.Colonia,cliente.CodigoPostal, null, 
                    null, null, null, null, cliente.Telefono,cliente.TelefonoTrabajo,
                    cliente.TelefonoCelular,cliente.Email,null,cliente.Estado,cliente.Pais,cliente.Ciudad, cliente.TipoAfilacion,
                    cliente.NumeroPatrocinador,cliente.FechaNacimiento,cliente.LugarNacimiento,cliente.Sexo,cliente.EstadoCivil,cliente.Profesion,
                    cliente.CURP,cliente.RFC,cliente.NumCtaPago,cliente.ClaveBancaria,cliente.Banco, cliente.NumeroCLABE,
                    cliente.Beneficiario,cliente.FechaCreacion,usuario.Id,true,cliente.IdUsuario);
            } catch (Exception ex)
            {
                return Json(new { error = ex.InnerException,Message=ex.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { error="none"},JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Service(string IdProveedor,string IdClientes)
        {
            try {
                Usuarios usuario = db.Usuarios.Where(x => x.Usuario == User.Identity.Name).First();
                List<Clientes> clientes=new List<Clientes>();
                if (IdClientes == string.Empty || IdClientes == null)
                    if(User.IsInRole("Admin"))
                        clientes = db.GetClientes(null, true, 0).ToList();
                    else if(User.IsInRole("Cliente"))
                        clientes = db.GetClientes(null, true, 0).Where(x=>x.UsuarioCreacion==usuario.Id).ToList();
                    else
                    clientes = db.GetClientes(Guid.Parse(IdClientes),  true, 1).ToList();
                              
                return Json(new { clientes = clientes.Select(x => new {
                    x.Activo,
                    x.ApellidoMaterno,
                    x.ApellidoPaterno,
                    x.Banco,
                    x.Beneficiario,
                    x.Calle,
                    x.Ciudad,
                    x.ClaveBancaria,
                    x.CodigoPostal,
                    x.Colonia,
                    x.CURP,
                    x.Email,
                    x.Estado,
                    x.EstadoCivil,
                    x.FechaCreacion,
                    x.FechaNacimiento,
                    x.Foto,
                    x.IdCliente,
                    x.IdProveedor,
                    x.IdUsuario,
                    x.LugarNacimiento,
                    x.NoExterior,
                    x.NoInterior,
                    x.Nombres,
                    x.NumCtaPago,
                    x.NumeroCLABE,
                    x.NumeroDeCuenta,
                    x.NumeroPatrocinador,
                    x.NumeroTelefonoAlarma,
                    x.Pais,
                    x.PalabraClave,
                    x.PalabraClaveSilenciosa,
                    x.Profesion,
                    x.RFC,
                    x.Sexo,
                    x.Telefono,
                    x.TelefonoCelular,
                    x.TelefonoTrabajo,
                    x.TipoAfilacion,
                    x.UsuarioCreacion
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) {
                return Json(new { error=ex.InnerException,Message=ex.Message});
            }
            
        }
    }
}
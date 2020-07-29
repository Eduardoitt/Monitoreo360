using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
namespace Dashboard.Controllers
{
    public class AdeudosController : Controller
    {

        // GET: Adeudos
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View();            
        }
        [Authorize]
        [HttpGet]
        public ActionResult _PanelAdeudos() {
            Usuarios usuario = db.Usuarios.Where(x => x.Usuario == User.Identity.Name).First();
            List<AdeudosForPanel> Adeudos = new List<AdeudosForPanel>();
            /*Adeudos ingresos = new Adeudos();
            ingresos.Facturas = db.GetCFDI(null, 0).ToList();
            ingresos.Proveedores = db.GetPAC(null, 0).ToList();
            ingresos.adeudos = db.GetAdeudosInstalaciones(null, null, 0).ToList();
            ingresos.FacturasPorAdeudo = db.GetCFDIPorOperacion(null, 0).ToList();
            ingresos.Clientes = db.GetClientes(null, true, 0).ToList();
            ingresos.ingresos = db.GetMonitoreoIngreso(0, null).OrderBy(x => x.FechaCreacion).ToList();*/
            if (User.IsInRole("Admin")) {
                Adeudos = db.AdeudosForPanel.OrderByDescending(x=>x.FechaCreacion).ToList();                
            }else
            {
                Adeudos = db.AdeudosForPanel.Where(x=>x.UsuarioCreacion==usuario.Id).OrderByDescending(x => x.FechaCreacion).ToList();
            }
            return PartialView(Adeudos);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Service(Guid IdCliente)
        {
            List<AdeudosInstalaciones> Adeudos = new List<AdeudosInstalaciones>();
            Usuarios usuario = db.Usuarios.Where(x=>x.Usuario==User.Identity.Name).First();
            if (User.IsInRole("Admin"))
                Adeudos = db.GetAdeudosInstalaciones(null, IdCliente, 2).ToList();
            else
                Adeudos = db.GetAdeudosInstalaciones(null, IdCliente, 2).Where(x=>x.UsuarioCreacion==usuario.Id).ToList();
            List<MonitoreoIngresos> Temp = db.GetMonitoreoIngreso(0,null).Where(x=>x.Activo==true).ToList();
            List<MonitoreoIngresos> Ingresos=new List<MonitoreoIngresos>();
            foreach(var Adeudo in Adeudos)            
                foreach (var Ingreso in Temp)                
                    if (Ingreso.IdAdeudo == Adeudo.Id)                
                        Ingresos.Add(Ingreso);
            return Json(new { Adeudos = Adeudos.Select(x => new {
                x.Id,
                x.IdCliente }),
                Ingresos = Ingresos.Select(x => new {
                    x.IdAdeudo,
                    x.Cargos,
                    x.CargosUSD,
                    x.Comentario,
                    x.MetodoDePago,
                    FechaCreacion=x.FechaCreacion.ToString("MM/dd/yyyy"),
                    x.Moneda,
                    x.TipoCambio,
                    x.UsuarioCreacion }) }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [Authorize]
        public ActionResult SelecionDeFactura(Guid IdAdeudo){
            Adeudos Adeudo = new Adeudos();
            Adeudo.adeudos = db.GetAdeudosInstalaciones(IdAdeudo, null, 1).ToList();
            Adeudo.Clientes = db.GetClientes(Adeudo.adeudos.First().IdCliente,true,1).ToList();
            Guid IdProveedor = (Guid)Adeudo.adeudos.First().IdProveedor;
            Adeudo.Proveedores = db.GetPAC(IdProveedor,1).ToList();
            string R = Adeudo.Proveedores.First().RegimenFiscal.Trim();
            List<RegimenFiscal> Regimen = db.RegimenFiscal.Where(x => x.c_RegimenFiscal.Trim() ==R ).ToList();
            ViewBag.RegimenFiscal = Regimen.First().Descripcion;
            
            return PartialView("_Confirmar",Adeudo);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Eliminar(Guid id)
        {
            try
            {
                AdeudosInstalaciones AdeudosInstalaciones = db.GetAdeudosInstalaciones(null, null, 0).Where(x => x.Id == id).FirstOrDefault();
                List<MonitoreoIngresos> MonitoreoIngresos = db.GetMonitoreoIngreso(0, null).Where(x => x.IdAdeudo == AdeudosInstalaciones.Id).ToList();
                int Opcion = User.IsInRole("Admin")==true?1:0;
                db.DeleteAdeudosInstalaciones(Opcion, AdeudosInstalaciones.Id);
                foreach (var item in MonitoreoIngresos)
                {
                    db.DeleteMonitoreoIngresos(item.Id, Opcion);
                }
                return Json(new { error = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error=true,Message=ex.Message},JsonRequestBehavior.AllowGet);
            }
            
            
        }
    }
}
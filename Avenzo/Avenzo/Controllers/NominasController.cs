using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace Avenzo.Controllers
{
    public class NominasController : Controller
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        [Authorize]
        public ActionResult Index() {
            /*Nomina nominas = new Nomina();
            nominas.Empleados = db.getEmpleado(0,null).ToList();
            nominas.PAC = db.GetPAC(null,0).ToList();            
            nominas.Nominas = db.GetNominaHistorial(0).ToList();*/
            return View();
        }
        [Authorize]
        public ActionResult Nuevo() {
            /*Nomina nominas = new Nomina();
            nominas.Empleados = db.getEmpleado(0, null).ToList();
            nominas.PAC = db.GetPAC(null, 0).ToList();*/
            ViewBag.TipoRegimenList = db.Regimen.ToList();
            ViewBag.PeriodicidadPagoList = db.PeriodicidadPago.ToList();
            ViewBag.NominasList = db.Nominas.ToList();
            ViewBag.TipoHorasList = db.Horas.ToList();
            ViewBag.PercepcionesList = db.Percepciones.ToList();
            ViewBag.TipoDeduccionList = db.Deducciones.ToList();
            ViewBag.TipoOtroPagoList = db.OtrosPagos.ToList();
            ViewBag.TipoIncapacidadList = db.Incapacidades.ToList();
            return PartialView("_Nuevo");
        }
        [HttpPost]
        public ActionResult Nuevo(FormCollection form) {
            try {
                DateTime hoy = DateTime.Now;
                string UsuarioCreacion = User.Identity.Name;
                /*string Serie = "A";
                int Folio = 1;*/
                int CantidadPercepciones = int.Parse(form["CantidadPercepciones"]);
                string Percepciones = "";
                for (int i=0; i<=CantidadPercepciones; i++) {
                    Percepciones += "_";
                }
                Guid IdNominaHistorial = Guid.Parse(form["IdNominaHistorial"]);
                Guid PAC = Guid.Parse(form["PAC"]);
                int NoEmpleado = int.Parse(form["Empleados"]);
                string Regimen = form["Regimen"];
                string CondigoPostal = form["CodigoPostal"];
                string PeriodicidadPago = form["PeriodicidadDePago"];
                string TipoNomina = form["TipoNomina"];
                /*.InsertNominaHistorial(IdNominaHistorial,PAC,NoEmpleado,Folio,form["Regimen"],"MXN",PeriodicidadPago,Serie, CondigoPostal, TipoNomina,
                    hoy,UsuarioCreacion,false);*/
                return Json(new { error = "none" }, JsonRequestBehavior.AllowGet);
            } catch (Exception ex) {
                return Json(new { error =ex.InnerException,Message=ex.Message}, JsonRequestBehavior.AllowGet);
            }
            
        }
        [HttpPost]
        public ActionResult Eliminar() {

            return Json(new {error="none"},JsonRequestBehavior.AllowGet);
        }
    }
}

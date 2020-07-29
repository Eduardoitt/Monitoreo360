using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.Globalization;

namespace Dashboard.Controllers
{
    
    public class HomeController : Controller
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            /*Guid Id = Guid.Parse("A0F64794-2AED-4C5F-9EB7-F4CEF19F76E3");
            GetPAC_Result pac = db.GetPAC(Id, 1).FirstOrDefault();
            byte[] logo = null;
            if (!string.IsNullOrWhiteSpace(pac.Logo))
                logo = System.IO.File.ReadAllBytes(pac.Logo);
            byte[] cer = System.IO.File.ReadAllBytes(@"E:\Users\Ivan\CSD_RAMA5708018Z3_20190919112311\00001000000501430648.cer");
            byte[] key = System.IO.File.ReadAllBytes(@"E:\Users\Ivan\CSD_RAMA5708018Z3_20190919112311\CSD_UNIDAD_RAMA5708018Z3_20190919_112259.key");
            db.UpdatePAC(Id, pac.RFC, pac.Usuario, pac.Contrasena, pac.Nombre, pac.CURP,
                pac.PersonaMoral, key, cer, pac.ContrasenaLlave, pac.RegimenFiscal,
                pac.RegistroPatronal, pac.RfcPatronOrigen, logo, pac.LugarExpedicion, pac.FechaVigenciaIncio,
                pac.FechaVigenciaFinal, true);
            string PATH = "~/Certificados/" + pac.RFC;
            if (!System.IO.Directory.Exists(Server.MapPath(PATH)))
                System.IO.Directory.CreateDirectory(Server.MapPath(PATH));
            if (!System.IO.Directory.Exists(Server.MapPath("~/Facturas/" + pac.RFC)))
                System.IO.Directory.CreateDirectory(Server.MapPath("~/Facturas/" + pac.RFC));
            System.IO.Directory.CreateDirectory(Server.MapPath("~/Facturas/" + pac.RFC + "/Cancelaciones"));
            System.IO.Directory.CreateDirectory(Server.MapPath("~/Facturas/" + pac.RFC + "/Facturas"));
            System.IO.Directory.CreateDirectory(Server.MapPath("~/Facturas/" + pac.RFC + "/Nominas"));
            System.IO.File.WriteAllBytes(Server.MapPath(PATH + "/" + pac.RFC + ".cer"), cer);
            System.IO.File.WriteAllBytes(Server.MapPath(PATH + "/" + pac.RFC + ".key"), key);
            */

            ViewBag.PrimeraVez = db.Usuarios.Where(x => x.Usuario == User.Identity.Name).FirstOrDefault().PrimeraVez;
           return PartialView();
        }
        [Authorize]
        [HttpGet]
        public ActionResult _PanelDashboard() {
            
            List<MonitoreoIngresos> ingresos = new List<MonitoreoIngresos>();
            ViewBag.Mes = DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-MX"));
            List<string> Meses = new List<string>();
            DateTime InicioMeses = DateTime.Parse("1/01/"+DateTime.Now.Year);
            DateTime FinalMeses = DateTime.Now;
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("es-MX");
            for (DateTime date = InicioMeses; date.Date <= FinalMeses.Date; date = date.AddMonths(1))
            {

                Meses.Add(ci.TextInfo.ToTitleCase(date.ToString("MMMM", ci)) + " del " + date.ToString("yyyy", ci));
            }
            ViewBag.Meses = Meses;
            if (User.IsInRole("Admin"))
            {
                ViewBag.Contratados = 5000;
                ViewBag.Emitidos = db.CFDI.Count()+345;
                double Ingresos = (double)db.GetMonitoreoIngreso(0, null).Where(x=>DateTime.Now.Year==x.FechaCreacion.Year&&x.FechaCreacion.Month==DateTime.Now.Month).Sum(x => x.Cargos + (x.CargosUSD * x.TipoCambio));
                double Egresos = (double)db.GetMonitoreoIngreso(0, null).Where(x => DateTime.Now.Year == x.FechaCreacion.Year && x.FechaCreacion.Month == DateTime.Now.Month).Sum(x => x.Abonos + (x.AbonosUSD * x.TipoCambio));
                ViewBag.Ingresos = Ingresos.ToString("C2", CultureInfo.CreateSpecificCulture("es-MX"));
                ViewBag.Egresos = Egresos.ToString("C2", CultureInfo.CreateSpecificCulture("es-MX"));
                ingresos = db.GetMonitoreoIngreso(0, null).Where(x => DateTime.Now.Year == x.FechaCreacion.Year && x.FechaCreacion.Month == DateTime.Now.Month).ToList();
            }
            else
            {
                Usuarios usuario = db.Usuarios.Where(x => x.Usuario == User.Identity.Name).FirstOrDefault();
                ViewBag.Contratados = usuario.Timbres;
                ViewBag.Emitidos = usuario.TimbresUsados;
                double Ingresos = (double)db.GetMonitoreoIngreso(0, null).Where(x=>x.UsuarioCreacion== usuario.Id).Where(x => DateTime.Now.Year == x.FechaCreacion.Year && x.FechaCreacion.Month == DateTime.Now.Month).Sum(x => x.Cargos + (x.CargosUSD * x.TipoCambio));
                double Egresos = (double)db.GetMonitoreoIngreso(0, null).Where(x => x.UsuarioCreacion == usuario.Id).Where(x => DateTime.Now.Year == x.FechaCreacion.Year && x.FechaCreacion.Month == DateTime.Now.Month).Sum(x => x.Abonos + (x.AbonosUSD * x.TipoCambio));
                ViewBag.Ingresos = Ingresos.ToString("C2", CultureInfo.CreateSpecificCulture("es-MX"));
                ViewBag.Egresos = Egresos.ToString("C2", CultureInfo.CreateSpecificCulture("es-MX"));
                ingresos = db.GetMonitoreoIngreso(0, null).Where(x => x.UsuarioCreacion == usuario.Id).Where(x => DateTime.Now.Year == x.FechaCreacion.Year && x.FechaCreacion.Month == DateTime.Now.Month).ToList();
            }
            return View(ingresos);
        }
        [HttpGet]
        public ActionResult _Wizard() {
            Usuarios usuario = db.Usuarios.Where(x => x.Usuario == User.Identity.Name).FirstOrDefault();
            PrimeraConfig config = new PrimeraConfig();
            config.ClaveProdServ = db.ClaveProdServ.ToList();
            //config.ClaveProdServPorPAC = db.GetClaveProdServPorPAC(usuario.Id).ToList();
            return PartialView("_PrimeraVez", config);
        }
        [HttpGet]
        public ActionResult actualizarUsuario()
        {
            Usuarios Usuario = db.Usuarios.Where(x => x.Usuario == User.Identity.Name).FirstOrDefault();
            db.UpdateUsuarios(Usuario.Id,Usuario.Usuario,Usuario.Contraseña,Usuario.TipoUsuario,Usuario.Roles,true,Usuario.Timbres,Usuario.TimbresUsados,Usuario.TimbresCancelados,false);
            return Json(new { },JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Ingresos(string Mes)
        {
            try {
                DateTime Meses = DateTime.Parse(Mes);
                List<MonitoreoIngresos> ingresos = new List<MonitoreoIngresos>();
                List<CFDI> CFDI = new List<CFDI>();
                Usuarios usuario = db.Usuarios.Where(x => x.Usuario == User.Identity.Name).First();
                if (User.IsInRole("Admin"))
                {
                    ingresos = db.MonitoreoIngresos.Where(x => Meses.Year == x.FechaCreacion.Year && x.FechaCreacion.Month == Meses.Month).ToList();
                    CFDI = db.CFDI.Where(x => x.FechaCreacion.Month == DateTime.Now.Month && x.FechaCreacion.Year == DateTime.Now.Year).ToList();
                }
                else {
                    ingresos = db.MonitoreoIngresos.Where(x => Meses.Year == x.FechaCreacion.Year && x.FechaCreacion.Month == Meses.Month && x.UsuarioCreacion == usuario.Id).ToList();
                    CFDI = db.CFDI.Where(x => x.FechaCreacion.Month == DateTime.Now.Month && x.FechaCreacion.Year == DateTime.Now.Year && x.UsuarioCreacion==usuario.Id).ToList();
                }
                
                return Json(new
                {
                    data = ingresos.Select(x => new {
                        x.Abonos,
                        x.AbonosUSD,
                        x.Activo,
                        x.Cargos,
                        x.CargosUSD,
                        x.Comentario,
                        x.FechaCreacion,
                        x.Id,
                        x.IdAdeudo,
                        x.IdNominaHistorial,
                        x.MetodoDePago,
                        x.Moneda,
                        x.NominaHistorial,
                        x.TipoCambio,
                        x.UsuarioCreacion
                    }),
                    cfdi = CFDI.Select(x=>new {
                        x.Cancelado,
                        x.FechaCreacion,
                        x.Folio,
                        x.Id,
                        x.IdCliente,
                        x.IdEmpleado,
                        x.Tipo,
                        x.UsuarioCreacion                        
                    })
                }, JsonRequestBehavior.AllowGet);
            } catch (Exception ex)
            {
                return Json(new {error=true,Message=ex.Message },JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}
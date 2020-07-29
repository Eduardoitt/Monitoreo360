using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Helpers;
using System.IO;

namespace Dashboard.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View();  
        }
        [HttpGet]
        public ActionResult _PanelEmpleados()
        {
            Guid IdUsuario = db.Usuarios.Where(x => x.Usuario == User.Identity.Name).FirstOrDefault().Id;
            int Opcion = User.IsInRole("Admin") == true ? 0 : 2;
            List<EmpleadosForPanel> Empleados = User.IsInRole("Admin") == true ? db.EmpleadosForPanel.ToList() : db.EmpleadosForPanel.Where(x => x.UsuarioCreacion == IdUsuario).ToList();
            return PartialView(Empleados);
        }
        [HttpGet]
        public ActionResult Editar(Guid IdTemp)
        {
            EmpleadoView Empleado = new EmpleadoView();
            Empleado.Bancos = db.Bancos.ToList();
            Empleado.Contratos = db.Contratos.ToList();
            Empleado.Deducciones = db.Deducciones.ToList();
            Empleado.Estados = db.Estados.OrderBy(x => x.NombreEstado).ToList();
            Empleado.Empleado = db.GetEmpleados(1,IdTemp).FirstOrDefault();
            Empleado.Horas = db.Horas.ToList();
            Empleado.Incapacidad = db.Incapacidades.ToList();
            Empleado.Jornadas = db.Jornadas.ToList();
            Empleado.Nomina = db.Nominas.ToList();
            Empleado.NominaHistorial = db.NominaHistorial.Where(x => x.Id == Empleado.Empleado.IdPlantilla).FirstOrDefault();
            if (Empleado.NominaHistorial!=null) {
                Empleado.NominaPercepciones = db.NominaPercepciones.Where(x => x.Id == Empleado.NominaHistorial.IdPercepciones).FirstOrDefault();
                Empleado.NominaPercepcion = db.NominaPercepcion.Where(x => x.IdPercepciones == Empleado.NominaPercepciones.Id).ToList();
                Empleado.JubilacionPensionRetiro = db.NominaJubilacionPensionRetiro.Where(x => x.Id == Empleado.NominaPercepciones.IdJubilacionPensionRetiro).FirstOrDefault();
                Empleado.SeparacionIndemnizacion = db.NominaSeparacionIndemnizacion.Where(x => x.Id == Empleado.NominaPercepciones.IdSeparacionIndemnizacion).FirstOrDefault();
                List<NominaHorasExtras> NominaHorasExtras = db.NominaHorasExtras.ToList();
                Empleado.NominaHorasExtras = new List<Model.NominaHorasExtras>();
                foreach (var percepcion in Empleado.NominaPercepcion)
                {
                    foreach (var HorasExtras in NominaHorasExtras.Where(x => x.IdPercepcion == percepcion.Id))
                    {
                        Empleado.NominaHorasExtras.Add(HorasExtras);
                    }
                }
                Empleado.NominaDeducion = db.NominaDeduccion.Where(x => x.IdNominaHistorial == Empleado.NominaHistorial.Id).ToList();
                Empleado.NominaIncapacidad = db.NominaIncapacidad.Where(x => x.IdNominaHistorial == Empleado.NominaHistorial.Id).ToList();
                Empleado.NominaOtroPago = db.NominaOtrosPago.Where(x => x.IdNominaHistorial == Empleado.NominaHistorial.Id).ToList();
            }
            Empleado.OtrosPagos = db.OtrosPagos.ToList();
            Empleado.PAC = db.GetPAC(null, 0).ToList();
            Empleado.Percepciones = db.Percepciones.ToList();
            Empleado.PeriodicidadPago = db.PeriodicidadPago.ToList();
            Empleado.Regimen = db.Regimen.ToList();
            Empleado.RiesgoPuesto = db.RiesgoPuesto.ToList();            
            return PartialView(Empleado);
        }
        [HttpPost]
        public ActionResult Editar(EmpleadoView empleado)
        {
            try {
                db.UpdateEmpleado(empleado.Empleado.Id,empleado.Empleado.NoEmpleado, empleado.Empleado.IdProveedor, empleado.Empleado.Nombre, empleado.Empleado.ApellidoMaterno, 
                    empleado.Empleado.ApellidoPaterno,empleado.Empleado.IdUsuario,empleado.Empleado.Email, empleado.Empleado.FechaNacimiento, empleado.Empleado.FechaInicioRelLaboral,
                    empleado.Empleado.RFC, empleado.Empleado.CURP,empleado.Empleado.HuellaDactilar, empleado.Empleado.Foto, empleado.Empleado.INE, empleado.Empleado.NumeroSeguridadSocial, 
                    empleado.Empleado.Departamento, empleado.Empleado.Direccion,empleado.Empleado.Puesto, empleado.Empleado.RiesgoPuesto, empleado.Empleado.TipoContrato.Trim(), empleado.Empleado.TipoJornada, 
                    empleado.Empleado.SalarioDiario, empleado.Empleado.Banco,empleado.Empleado.CuentaBancaria, empleado.Empleado.ClaveEntFed, empleado.Empleado.GradoEstudios, empleado.Empleado.Telefono, 
                    empleado.Empleado.TelefonoEmergencia, empleado.Empleado.Firma,empleado.Empleado.TipoSangre, empleado.Empleado.CUIP, empleado.Empleado.NumeroDeLicencia, empleado.Empleado.NumeroDeAutorizacion,
                    empleado.NominaHistorial.Id,true);
                NominaHistorial NominaHistorial = db.NominaHistorial.Where(x => x.Id == empleado.NominaHistorial.Id).FirstOrDefault();
                NominaPercepciones NominaPercepciones = db.NominaPercepciones.Where(x => x.Id == NominaHistorial.IdPercepciones).FirstOrDefault();
                NominaJubilacionPensionRetiro NominaJubilacionPensionRetiro = db.NominaJubilacionPensionRetiro.Where(x => x.Id == NominaPercepciones.IdJubilacionPensionRetiro).FirstOrDefault();
                NominaSeparacionIndemnizacion NominaSeparacionIndemnizacion = db.NominaSeparacionIndemnizacion.Where(x => x.Id == NominaPercepciones.IdJubilacionPensionRetiro).FirstOrDefault();
                List<NominaPercepcion> NominaPercepcion = db.NominaPercepcion.Where(x => x.IdPercepciones == NominaPercepciones.Id).ToList();
                List<NominaDeduccion> NominaDeduccion = db.NominaDeduccion.Where(x=>x.IdNominaHistorial==NominaHistorial.Id).ToList();
                List<NominaIncapacidad> NominaIncapacidad = db.NominaIncapacidad.Where(x=>x.IdNominaHistorial==NominaHistorial.Id).ToList();
                List<NominaOtrosPago> NominaOtrosPagos = db.NominaOtrosPago.Where(x=>x.IdNominaHistorial==NominaHistorial.Id).ToList();
                Guid IdUsuario = db.Usuarios.Where(x=>x.Usuario==User.Identity.Name).First().Id;
                if (empleado.JubilacionPensionRetiro == null)
                {
                    if (NominaJubilacionPensionRetiro != null) {
                        //Delete Jubilacion Pension Retiro & Update NominaPercepciones
                        db.DeleteNominaJubilacionPensionRetiro(NominaJubilacionPensionRetiro.Id);
                        db.UpdateNominaPercepciones(NominaPercepciones.Id,NominaSeparacionIndemnizacion.Id,null);
                    }
                }
                else {
                    if (NominaJubilacionPensionRetiro!=null) {
                        //Update Jubilacion Pension Retirol
                        db.UpdateNominaJubilacionPensionRetiro(empleado.JubilacionPensionRetiro.Id,empleado.JubilacionPensionRetiro.TotalUnaExhibicion,empleado.JubilacionPensionRetiro.TotalParcialidad,empleado.JubilacionPensionRetiro.MontoDiario,
                            empleado.JubilacionPensionRetiro.IngresoAcumulable,empleado.JubilacionPensionRetiro.IngresoNoAcumulable);
                    } else {
                        //Insert Jubilacion Pension Retiro & Update NominaPercepciones
                        NominaPercepciones Percepciones = db.NominaPercepciones.Where(x => x.Id == NominaHistorial.IdPercepciones).FirstOrDefault();
                        db.InsertNominaJubilacionPensionRetiro(empleado.JubilacionPensionRetiro.Id,empleado.JubilacionPensionRetiro.TotalUnaExhibicion,empleado.JubilacionPensionRetiro.TotalParcialidad,empleado.JubilacionPensionRetiro.MontoDiario,empleado.JubilacionPensionRetiro.IngresoAcumulable,empleado.JubilacionPensionRetiro.IngresoNoAcumulable,DateTime.Now,IdUsuario);
                        db.UpdateNominaPercepciones(Percepciones.Id,Percepciones.IdSeparacionIndemnizacion,empleado.JubilacionPensionRetiro.Id);
                    }
                }
                if (empleado.SeparacionIndemnizacion == null)
                {
                    if (NominaSeparacionIndemnizacion != null)
                    {
                        //Delete SeparacionIndemnizacion & Update NominaPercepciones
                        NominaPercepciones Percepciones = db.NominaPercepciones.Where(x => x.Id == NominaHistorial.IdPercepciones).FirstOrDefault();
                        db.DeleteNominaSeparacionIndemnizacion(NominaSeparacionIndemnizacion.Id);
                        db.UpdateNominaPercepciones(Percepciones.Id,null,Percepciones.IdJubilacionPensionRetiro);
                    }
                }
                else
                {
                    if (NominaSeparacionIndemnizacion != null)
                    {
                        //Update SeparacionIndemnizacion
                        db.UpdateNominaSeparacionIndemnizacion(empleado.SeparacionIndemnizacion.Id,empleado.SeparacionIndemnizacion.TotalPagado,empleado.SeparacionIndemnizacion.NumAñosServicio,
                            empleado.SeparacionIndemnizacion.UltimoSueldoMensOrd,empleado.SeparacionIndemnizacion.IngresoAcumulable,empleado.SeparacionIndemnizacion.IngresoNoAcumulable);
                    }
                    else
                    {
                        //Insert SeparacionIndemnizacion & Update NominaPercepciones
                        db.InsertNominaSeparacionIndemnizacion(empleado.SeparacionIndemnizacion.Id,empleado.SeparacionIndemnizacion.TotalPagado,empleado.SeparacionIndemnizacion.NumAñosServicio,
                            empleado.SeparacionIndemnizacion.UltimoSueldoMensOrd,empleado.SeparacionIndemnizacion.IngresoAcumulable,empleado.SeparacionIndemnizacion.IngresoNoAcumulable,DateTime.Now,IdUsuario);
                        db.UpdateNominaPercepciones(NominaPercepciones.Id, empleado.SeparacionIndemnizacion.Id, NominaPercepciones.IdJubilacionPensionRetiro);
                    }
                }

                foreach (var percepcion in empleado.NominaPercepcion) {
                    if (NominaPercepcion.Where(x => x.Id == percepcion.Id).Any())
                    {
                        List<NominaHorasExtras> HorasExtras = db.NominaHorasExtras.Where(x=>x.IdPercepcion== percepcion.Id).ToList();
                        foreach (var HoraExtra in empleado.NominaHorasExtras.Where(x=>x.IdPercepcion==percepcion.Id)) {
                            if (HorasExtras.Where(x=>x.Id==HoraExtra.Id).Any()) {
                                //Update NominaHorasExtras
                                db.UpdateNominaHorasExtras(HoraExtra.Id,HoraExtra.Dias,HoraExtra.Tipos,HoraExtra.HorasExtras,HoraExtra.ImportePagado);
                            }
                            else {
                                //Insert NominaHorasExtras
                                db.InsertNominaHorasExtras(HoraExtra.Id,HoraExtra.IdPercepcion,HoraExtra.Dias,HoraExtra.Tipos,HoraExtra.HorasExtras,HoraExtra.ImportePagado,DateTime.Now,IdUsuario);
                            }
                        }
                        foreach (var HoraExtra in HorasExtras) {
                            if (!empleado.NominaHorasExtras.Where(x=>x.Id==HoraExtra.Id).Any()) {
                                //Delete Nomina HoraExtra
                                db.DeleteNominaHorasExtras(HoraExtra.Id);
                            }
                        }
                        //Update NominaPercepcion
                        db.UpdateNominaPercepcion(percepcion.Id,percepcion.Tipo,percepcion.Clave,percepcion.Concepto,percepcion.ImporteExcento,percepcion.ImporteGravado,percepcion.ValorMercado,percepcion.PrecioOrtorgarse);
                    }
                    else {
                        //Inset NominaPercepcion
                        db.InsertNominaPercepcion(percepcion.Id,percepcion.IdPercepciones,percepcion.Tipo,percepcion.Clave,percepcion.Concepto,percepcion.ImporteExcento,percepcion.ImporteGravado,percepcion.ValorMercado,percepcion.PrecioOrtorgarse,DateTime.Now,IdUsuario);
                    }
                }
                foreach (var percepcion in NominaPercepcion) {
                    if (!empleado.NominaPercepcion.Where(x=>x.Id==percepcion.Id).Any()) {
                        List<NominaHorasExtras> HorasExtras = db.NominaHorasExtras.Where(x => x.IdPercepcion == percepcion.Id).ToList();
                        foreach (var HoraExtra in HorasExtras) {
                            //Delete NominaHorasExtras
                            db.DeleteNominaHorasExtras(HoraExtra.Id);
                        }
                        //Delete NominaPercecion                     
                        db.DeleteNominaPercepcion(percepcion.Id);   
                    }
                }
                foreach (var deduccion in empleado.NominaDeducion) {
                    if (NominaDeduccion.Where(x => x.Id == deduccion.Id).Any())
                    {
                        //Update NominaDeduccion
                        db.UpdateNominaDeduccion(deduccion.Id,deduccion.Tipo,deduccion.Clave,deduccion.Concepto,deduccion.Importe);
                    }
                    else {
                        //Insert Deduccion
                        db.InsertNominaDeduccion(deduccion.Id,NominaHistorial.Id,deduccion.Tipo,deduccion.Concepto,deduccion.Importe,IdUsuario,DateTime.Now);
                    }
                }
                foreach (var deduccion in NominaDeduccion) {
                    if (!empleado.NominaDeducion.Where(x=>x.Id==deduccion.Id).Any()) {
                        //Delete deduccion
                        db.DeleteNominaDeduccion(deduccion.Id);
                    }
                }

                foreach (var incapacidad in empleado.NominaIncapacidad)
                {
                    if (NominaIncapacidad.Where(x => x.Id == incapacidad.Id).Any())
                    {
                        //Update NominaIncapacidad
                        db.UpdateNominaIncapacidad(incapacidad.Id,incapacidad.DiasIncapacidad,incapacidad.Tipo,incapacidad.Importe);
                    }
                    else
                    {
                        //Insert NominaIncapacidad
                        db.InsertNominaIncapacidad(incapacidad.Id,NominaHistorial.Id,incapacidad.Tipo,incapacidad.DiasIncapacidad,incapacidad.Importe,IdUsuario,DateTime.Now);
                    }
                }
                foreach (var incapacidad in NominaIncapacidad)
                {
                    if (!empleado.NominaIncapacidad.Where(x => x.Id == incapacidad.Id).Any())
                    {
                        //Delete NominaIncapacidad
                        db.DeleteNominaIncapacidad(incapacidad.Id);
                    }
                }

                foreach (var OtroPago in empleado.NominaOtroPago)
                {
                    if (NominaOtrosPagos.Where(x => x.Id == OtroPago.Id).Any())
                    {
                        //Update NominaOtrosPagos
                        db.UpdateNominaOtrosPago(OtroPago.Id,OtroPago.Tipo,OtroPago.Clave,OtroPago.Concepto,OtroPago.Importe,OtroPago.SubsidioCausado,OtroPago.SaldoAFavor,OtroPago.Año,OtroPago.RemanenteSalFav);
                    }
                    else
                    {
                        //Insert NominaOtrosPagos
                        db.InsertNominaOtrosPagos(OtroPago.Id,OtroPago.IdNominaHistorial,OtroPago.Tipo,OtroPago.Importe,OtroPago.Concepto,OtroPago.SubsidioCausado,OtroPago.SaldoAFavor,OtroPago.Año,OtroPago.RemanenteSalFav);
                    }
                }
                foreach (var OtroPago in NominaOtrosPagos)
                {
                    if (!empleado.NominaOtroPago.Where(x => x.Id == OtroPago.Id).Any())
                    {
                        //Delete NominaOtrosPagos
                        db.DeleteNominaOtrosPago(OtroPago.Id);
                    }
                }

                return Json(new { error = false}, JsonRequestBehavior.AllowGet);
            } catch (Exception ex) {
                return Json(new { error = ex.InnerException,Message=ex.Message}, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Nuevo()
        {
            
            EmpleadoView Empleado = new EmpleadoView();
            Empleado.Bancos = db.Bancos.ToList();
            Empleado.Contratos = db.Contratos.ToList();
            Empleado.Deducciones = db.Deducciones.ToList();
            Empleado.Estados = db.Estados.OrderBy(x => x.NombreEstado).ToList();
            Empleado.Horas = db.Horas.ToList();
            Empleado.Incapacidad = db.Incapacidades.ToList();
            Empleado.Jornadas = db.Jornadas.ToList();            
            Empleado.Nomina = db.Nominas.ToList();
            Empleado.NominaPercepciones = new NominaPercepciones();
            Empleado.OtrosPagos = db.OtrosPagos.ToList();
            Empleado.PAC = db.GetPAC(null, 0).ToList();
            Empleado.Percepciones = db.Percepciones.ToList();
            Empleado.PeriodicidadPago = db.PeriodicidadPago.ToList();
            Empleado.Regimen = db.Regimen.ToList();
            Empleado.RiesgoPuesto = db.RiesgoPuesto.ToList();
            return View(Empleado);
        }
        [HttpPost]
        public ActionResult Nuevo(EmpleadoView empleado,HttpPostedFileBase Foto) {
            try
            { 
                Guid IdUsuario = db.Usuarios.Where(x=>x.Usuario==User.Identity.Name).FirstOrDefault().Id;
                Guid IdPlantilla = Guid.NewGuid(),PercepcionesId=Guid.NewGuid();

                byte[] Photo = null;
                if(Foto!=null)
                    Photo=Helpers.StreamHelper.HttpPostedFileBaseToByte(Foto);
                var filename=Path.GetFileName(Foto.FileName);
                var ext = Path.GetExtension(Foto.FileName);
                int NoEmpleado = 1;
                if(db.Empleados.Where(x=>x.IdProveedor==empleado.Empleado.IdProveedor).Count()>0)
                    NoEmpleado = db.Empleados.Where(x => x.IdProveedor == empleado.Empleado.IdProveedor).Max(x => x.NoEmpleado) + 1;
                db.InsertEmpleados(empleado.Empleado.Id,NoEmpleado, empleado.Empleado.IdProveedor, empleado.Empleado.Nombre, empleado.Empleado.ApellidoMaterno,
                    empleado.Empleado.ApellidoPaterno,null, empleado.Empleado.Email, empleado.Empleado.FechaNacimiento, empleado.Empleado.FechaInicioRelLaboral, 
                    empleado.Empleado.RFC, empleado.Empleado.CURP, empleado.Empleado.HuellaDactilar,null, empleado.Empleado.INE, empleado.Empleado.NumeroSeguridadSocial, 
                    empleado.Empleado.Departamento, empleado.Empleado.Direccion,empleado.Empleado.Puesto, empleado.Empleado.RiesgoPuesto, empleado.Empleado.TipoContrato, empleado.Empleado.TipoJornada, 
                    empleado.Empleado.SalarioDiario, empleado.Empleado.Banco, empleado.Empleado.CuentaBancaria, empleado.Empleado.ClaveEntFed, empleado.Empleado.GradoEstudios, 
                    empleado.Empleado.Telefono, empleado.Empleado.TelefonoEmergencia, empleado.Empleado.Firma,empleado.Empleado.TipoSangre, empleado.Empleado.CUIP, empleado.Empleado.NumeroDeLicencia, empleado.Empleado.NumeroDeAutorizacion, 
                    IdPlantilla, true,IdUsuario, DateTime.Now);
                
                db.InsertNominaHistorial(IdPlantilla, empleado.Empleado.IdProveedor, empleado.Empleado.Id, empleado.NominaHistorial.TipoNomina,DateTime.Now, 
                    DateTime.Now, DateTime.Now, 0,empleado.NominaHistorial.TipoRegimen, "MXN",
                    empleado.NominaHistorial.PeriodicidadPago,empleado.NominaHistorial.LugarExpedicion, PercepcionesId, DateTime.Now, User.Identity.Name);
                if (empleado.NominaPercepciones == null)                
                    db.InsertNominaPercepciones(PercepcionesId, null, null, DateTime.Now, IdUsuario);
                
                else
                {                    
                    
                    if (empleado.JubilacionPensionRetiro!=null) 
                        db.InsertNominaJubilacionPensionRetiro(empleado.JubilacionPensionRetiro.Id, empleado.JubilacionPensionRetiro.TotalUnaExhibicion, empleado.JubilacionPensionRetiro.TotalParcialidad, empleado.JubilacionPensionRetiro.MontoDiario,
                        empleado.JubilacionPensionRetiro.IngresoAcumulable, empleado.JubilacionPensionRetiro.IngresoNoAcumulable, DateTime.Now, IdUsuario);
                    
                    if (empleado.SeparacionIndemnizacion!=null)                    
                        db.InsertNominaSeparacionIndemnizacion(empleado.SeparacionIndemnizacion.Id, empleado.SeparacionIndemnizacion.TotalPagado, empleado.SeparacionIndemnizacion.NumAñosServicio, empleado.SeparacionIndemnizacion.UltimoSueldoMensOrd,
                        empleado.SeparacionIndemnizacion.IngresoAcumulable, empleado.SeparacionIndemnizacion.IngresoNoAcumulable, DateTime.Now, IdUsuario);
                    db.InsertNominaPercepciones(PercepcionesId, empleado.NominaPercepciones.IdSeparacionIndemnizacion, empleado.NominaPercepciones.IdJubilacionPensionRetiro, DateTime.Now, IdUsuario);
                }
                foreach (var percepcion in empleado.NominaPercepcion)
                {
                    db.InsertNominaPercepcion(percepcion.Id,PercepcionesId,percepcion.Tipo,percepcion.Clave,percepcion.Concepto,percepcion.ImporteExcento,
                        percepcion.ImporteGravado,percepcion.ValorMercado,percepcion.PrecioOrtorgarse,DateTime.Now,IdUsuario);
                    if (empleado.NominaHorasExtras!=null) {
                        foreach (var horasExtras in empleado.NominaHorasExtras.Where(x => x.IdPercepcion == percepcion.Id))
                        {
                            db.InsertNominaHorasExtras(horasExtras.Id, percepcion.Id, horasExtras.Dias, horasExtras.Tipos, horasExtras.HorasExtras, horasExtras.ImportePagado, DateTime.Now, IdUsuario);
                        }
                    }                    
                }
                if(empleado.NominaDeducion!=null)
                    foreach (var deduccion in empleado.NominaDeducion) {
                        db.InsertNominaDeduccion(deduccion.Id,IdPlantilla,deduccion.Tipo,deduccion.Concepto,deduccion.Importe,IdUsuario,DateTime.Now);
                    }
                if(empleado.NominaIncapacidad!=null)
                    foreach (var incapacidad in empleado.NominaIncapacidad) {
                        db.InsertNominaIncapacidad(Guid.NewGuid(),IdPlantilla,incapacidad.Tipo,incapacidad.DiasIncapacidad,incapacidad.Importe,IdUsuario,DateTime.Now);
                    }
                if(empleado.NominaOtroPago!=null)
                    foreach (var otroPago in empleado.NominaOtroPago) {
                        db.InsertNominaOtrosPagos(Guid.NewGuid(),IdPlantilla,otroPago.Tipo,otroPago.Importe,otroPago.Concepto,otroPago.SubsidioCausado,otroPago.SaldoAFavor,otroPago.Año,otroPago.RemanenteSalFav);
                    }               
                return Json(new {error=false},JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) {
                return Json(new { error = true, Description=ex.InnerException, Message=ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Eliminar(Guid Id) {
            Empleados empleado = db.GetEmpleados(1, Id).FirstOrDefault();
            try {                
                db.DeleteEmpleado(0, Id);
                //NominaHistorial NominaHistorial=db.NominaHistorial.Where(x=>x.Id==empleado.)
                return Json(new { error = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) {
                return Json(new { error=true,Messsage=ex.Message},JsonRequestBehavior.AllowGet);
            }
            
        }
        public ActionResult Service(string id) {
            List<Empleados> Empleados = new List<Empleados>();
            if (string.Empty == id || id == null)
                Empleados = db.Empleados.ToList();

            else
            {
                Guid IdEmpleado = Guid.Parse(id);
                Empleados = db.Empleados.Where(x=>x.Id==IdEmpleado).ToList();
            }


            return Json(new { Empleados = Empleados.Select(x => new {
                x.Activo,
                x.ApellidoMaterno,
                x.ApellidoPaterno,
                x.Banco,
                x.ClaveEntFed,
                x.CuentaBancaria,
                x.CUIP,
                x.CURP,
                x.Departamento,
                x.Direccion,
                x.Email,
                x.FechaCreacion,
                FechaInicioRelLaboral =  x.FechaInicioRelLaboral.Value.ToString("MM/dd/yyyy"),
                x.FechaNacimiento,
                x.GradoEstudios,                
                x.Id,
                x.IdProveedor,
                x.IdUsuario,
                x.INE,
                x.NoEmpleado,
                x.Nombre,
                x.NumeroDeAutorizacion,
                x.NumeroDeLicencia,
                x.NumeroSeguridadSocial,
                x.Puesto,
                x.RFC,
                x.RiesgoPuesto,
                x.SalarioDiario,
                x.Telefono,
                x.TelefonoEmergencia,
                x.TipoContrato,
                x.TipoJornada,
                x.TipoSangre,
                x.UsuarioCreacion                
            })},JsonRequestBehavior.AllowGet);
        }
    }
}
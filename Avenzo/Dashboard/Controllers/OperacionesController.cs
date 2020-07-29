using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Dashboard.Tools;
using System.Web.Script.Serialization;

namespace Dashboard.Controllers
{
    
    public class OperacionesController : Controller
    {
        // GET: Operaciones
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {   
                return View();            
        }
        public ActionResult _PanelOperaciones()
        {
            Usuarios usuario = db.Usuarios.Where(x => x.Usuario == User.Identity.Name).First();
            Ingresos ingresos = new Ingresos();
            if (User.IsInRole("Admin"))
            {
                ingresos.Clientes = db.GetClientes(null, true, 0).ToList();
                //ingresos.Facturas = db.GetCFDI(null, 0).ToList();
                ingresos.ingresos = db.GetMonitoreoIngreso(0, null).OrderByDescending(x => x.FechaCreacion).ToList();
                ingresos.Proveedores = db.GetPAC(null, 0).ToList();
                ingresos.Adeudos = db.GetAdeudosInstalaciones(null, null, 0).ToList();
            }
            else
            {
                ingresos.Clientes = db.GetClientes(null, true, 0).Where(x => x.UsuarioCreacion ==usuario.Id).ToList();
                //ingresos.Facturas = db.GetCFDI(null, 0).ToList();
                ingresos.ingresos = db.GetMonitoreoIngreso(0, null).Where(x => x.UsuarioCreacion == usuario.Id).OrderByDescending(x => x.FechaCreacion).ToList();
                ingresos.Proveedores = db.GetPAC(null, 0).ToList();
                ingresos.Adeudos = db.GetAdeudosInstalaciones(null, null, 0).ToList();
            }
            
            ViewBag.FormaPago = db.FormaDePago.ToList();
            return PartialView(ingresos);
        }
       
        [HttpPost]
        public ActionResult Eliminar(Guid id)
        {
            try {
                db.DeleteMonitoreoIngresos(id,1);
                return Json(new {error=false }, JsonRequestBehavior.AllowGet);
            } catch (Exception ex) {
                return Json(new {error=ex.InnerException,Message=ex.Message }, JsonRequestBehavior.AllowGet);
            }            
        }
        [HttpGet]
        public ActionResult Nuevo()
        {
            return PartialView("_Nuevo");
        }
        [HttpGet]
        public ActionResult _Ingreso()
        {
            
            Ingresos ingresos = new Ingresos();
            string RFC = "";
            if (User.IsInRole("Admin"))
            {
                ingresos.Proveedores = db.GetPAC(null, 0).ToList();
                ingresos.Clientes = db.GetClientes(null, true,0).ToList();
                ingresos.Adeudos = db.GetAdeudosInstalaciones(null, null, 0).ToList();

            }
            else
            {
                Usuarios usuario = db.Usuarios.Where(x => x.Usuario == User.Identity.Name).First();                
                Empleados Empleado = db.Empleados.Where(x=>x.IdUsuario==usuario.Id).First();
                if (Empleado != null) {                 
                    RFC = Empleado.RFC;
                    ingresos.Adeudos = db.GetAdeudosInstalaciones(null,Empleado.Id,2).ToList();
                }
                else
                {
                    Clientes Cliente = db.Clientes.Where(x => x.IdUsuario == usuario.Id).First();
                    RFC = db.Clientes.Where(x => x.IdUsuario == usuario.Id).First().RFC;
                    ingresos.Adeudos = db.GetAdeudosInstalaciones(null, Cliente.IdCliente,2).ToList();
                }
                
                ingresos.Proveedores = db.GetPAC(null, 0).Where(x => x.RFC == RFC).ToList();
                ingresos.Clientes = db.GetClientes(null, true,0).Where(x => x.UsuarioCreacion==usuario.Id).ToList();
            }
            ViewBag.UsoCFDI = db.UsoCFDI.ToList();
            ViewBag.Acesores = db.GetEmpleadosByPuesto("Asesor").ToList();
            ViewBag.MetodoDePago = db.MetodosDePago.ToList();
            ViewBag.FormaDePago = db.FormaDePago.ToList();
            ViewBag.Estados = db.Estados.Where(x=>x.c_Pais=="MEX").ToList();

            return PartialView("_Ingreso", ingresos);
        }
        [HttpPost]
        public ActionResult _Ingreso(FormCollection form)
        {
            try
            {
                Clientes cliente = new Clientes();
                Guid IdFactura = Guid.Parse(form["IdFactura"]);
                Guid IdProveedor = Guid.Parse(form["PAC"]);                                               
                Guid IdAcesor = Guid.Parse(form["Asesor"]);
                Guid IdUsuario = Guid.NewGuid();
                Guid IdMensualidad = Guid.NewGuid();
                Usuarios usuario = db.Usuarios.Where(x => x.Usuario == User.Identity.Name).FirstOrDefault();
                string Moneda = form["Moneda"],Nombres=form["Nombres"],Email=form["Email"];
                string Calle= form["Calle"], 
                    NoInterior= form["NoInterior"], 
                    NoExterior= form["NoExterior"], 
                    Colonia= form["Colonia"], 
                    CodigoPostal= form["CodigoPostal"], 
                    Telefono= form["Telefono"], 
                    Estado= form["Estado"], 
                    Pais= form["Pais"], 
                    Ciudad=form["Ciudad"], 
                    RFC=form["RFC"],
                    NumCtaPago= form["NumCtaPago"],
                    MetodoPago=form["MetodoPago"],
                    FormaPago= form["FormaPago"],
                    UsoCFDI=form["UsoCFDI"];
                if (form["id"] == "" || form["id"] == null)
                {
                    cliente.IdCliente = Guid.NewGuid();
                    DateTime date = DateTime.Now;
                    int Index = date.Year.ToString().Length - 2;
                    int Cantidad = db.Clientes.Count();
                    while (Cantidad > 9999)                    
                        Cantidad = Cantidad - 9999;
                    //string NumeroDeCuenta = null;//date.Year.ToString().Substring(Index) + date.Month.ToString("D2") + Cantidad.ToString("D4");
                    //db.InsertUsuario(IdUsuario,RFC,SHA1.Encode(RFC),"Cliente","Client",true,10,0,0);  
                   /* db.InsertClientes(cliente.IdCliente, IdProveedor,IdUsuario, null, Nombres, 
                        null, null,null,null,null,
                        Calle, NoInterior, NoExterior, Colonia, CodigoPostal,Telefono, 
                        null, null,Email, null, Estado, Pais, Ciudad,
                        null, null,null, null, null, 
                        null, null, null, RFC,null,NumCtaPago, null,
                        null,null, DateTime.Now, User.Identity.Name,true);*/
                }
                else
                {
                    Guid id = Guid.Parse(form["id"]);
                    cliente = db.GetClientes(id, true, 1).FirstOrDefault();
                    /*db.UpdateClientes(cliente.IdCliente, cliente.IdProveedor,cliente.NumeroDeCuenta, cliente.NumeroTelefonoAlarma, 
                        cliente.PalabraClave, cliente.PalabraClaveSilenciosa, cliente.Nombres, cliente.ApellidoPaterno, cliente.ApellidoMaterno, 
                        Calle, NoInterior, NoExterior,Colonia, CodigoPostal, Telefono,
                        cliente.TelefonoTrabajo, cliente.TelefonoCelular, cliente.Email, cliente.Foto, Estado, Pais, Ciudad, 
                        cliente.TipoAfilacion, cliente.NumeroPatrocinador, cliente.FechaNacimiento, cliente.LugarNacimiento,cliente.Sexo, 
                        cliente.EstadoCivil, cliente.Profesion, cliente.CURP, RFC, NumCtaPago, cliente.ClaveBancaria, cliente.Banco, 
                        cliente.NumeroCLABE,cliente.Beneficiario,cliente.FechaCreacion, cliente.UsuarioCreacion, true,cliente.IdUsuario);*/
                }
                float TipoCambio = 0;
                if (form["TipoCambio"] != "")
                    TipoCambio = float.Parse(form["TipoCambio"]);
                string Adeudo=form["Adeudo"];
                if (Adeudo == "0")
                {
                    IdFactura=InsertarAdeudo(form, TipoCambio, IdAcesor, IdProveedor, cliente,IdFactura);
                }else
                {                    
                    Guid IdAdeudo = Guid.Parse(Adeudo);
                    Guid IdMonitoreoIngreso = Guid.Parse(form["IdCargo"]);
                    float Cargo = float.Parse(form["Cargos"]);
                    Cargo = Moneda.Contains("MXN") ? Cargo : Cargo * TipoCambio;
                    double Ingresos =(double) db.GetMonitoreoIngreso(0, null).Where(x => x.IdAdeudo == IdAdeudo).Sum(x => x.Cargos+(x.CargosUSD*x.TipoCambio));
                    AdeudosInstalaciones AdeudosInstalacion = db.GetAdeudosInstalaciones(IdAdeudo,null,1).FirstOrDefault();
                    double Total = AdeudosInstalacion.Total - (Ingresos+Cargo);
                    bool Pagado = Total <= 0;
                    bool Envio = form["Envio"] == "on" ? true : false;         
                    db.UpdateAdeudosInstalaciones(IdAdeudo, AdeudosInstalacion.IdProveedor, AdeudosInstalacion.IdCliente,null,AdeudosInstalacion.FechaContrato, 
                        AdeudosInstalacion.PagoComision, AdeudosInstalacion.FechaPago,AdeudosInstalacion.IdAcessor, AdeudosInstalacion.IdMensualidad, AdeudosInstalacion.Cantidad, AdeudosInstalacion.Concepto, 
                        AdeudosInstalacion.Descripcion, AdeudosInstalacion.Unidad, AdeudosInstalacion.Total,AdeudosInstalacion.ClaveProdServ,AdeudosInstalacion.FechaInstalacion, AdeudosInstalacion.IdInstalador,
                        AdeudosInstalacion.Comentarios,AdeudosInstalacion.Anticipo, Pagado, AdeudosInstalacion.Instalacion, AdeudosInstalacion.RequiereFacturacion, 
                        AdeudosInstalacion.RequiereFacturacion,Envio, AdeudosInstalacion.RevisoRobot, AdeudosInstalacion.Activo);
                    
                    if (form["Moneda"].Contains("MXN"))
                        db.InsertMonitoreoIngresos(IdMonitoreoIngreso,IdAdeudo,null,Cargo,0,0,0, MetodoPago,FormaPago, UsoCFDI, usuario.Id, TipoCambio,form["Moneda"].Trim(),form["Comentario"],DateTime.Now,true);
                    else
                        db.InsertMonitoreoIngresos(IdMonitoreoIngreso,IdAdeudo,null,0,0,Cargo,0,MetodoPago, FormaPago, UsoCFDI, usuario.Id,TipoCambio,form["Moneda"],form["Comentario"],DateTime.Now,true);
                }
                return Json(new { error = "none",UUID=IdFactura}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.InnerException, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public Guid InsertarAdeudo(FormCollection form,float TipoCambio,Guid IdAcesor,Guid IdProveedor,Clientes cliente,Guid IdFactura)
        {
            Usuarios usuario = db.Usuarios.Where(x=>x.Usuario==User.Identity.Name).First();
            Guid IdPaquete = Guid.NewGuid();
            Guid IdAdeudoIngreso = new Guid();
            double Total = 0;
            for (int i = 0; i < int.Parse(form["CantidadConceptos"]); i++)
            {
                string Cantidad = form["Cantidad" + i],
                    Concepto = form["Concepto" + i],
                    Descripcion = form["Descripcion" + i],
                    Unidad = form["Unidad" + i],
                    Comentario = form["Comentario"],
                    Cargo = form["Cargo" + i],
                    valorUnitario = form["ValorUnitario" + i],
                    MetodoPago=form["MetodoPago"],
                    FormaPago=form["FormaPago"],
                    UsoCFDI=form["UsoCFDI"];
                Total = double.Parse(Cantidad)*double.Parse(valorUnitario);
                bool Facturacion;
                IdAdeudoIngreso = Guid.NewGuid();               
                string IdConceoncepto = form["IdConcepto" + i] == string.Empty || form["IdConcepto" + i] == null?Guid.NewGuid().ToString(): form["IdConcepto" + i];
                string ClaveProdServ = form["ClaveProdServ"+i];
                ClaveProdServ clave = db.ClaveProdServ.Where(x => x.c_ClaveProdServ == ClaveProdServ).FirstOrDefault();
                Guid IdMonitoreoIngreso = Guid.Parse(IdConceoncepto);
                bool Pagado = !(((float.Parse(valorUnitario)*float.Parse(Cantidad)) - float.Parse(Cargo)) >0);
                if (form["Facturar"] == "on")
                    Facturacion = true;
                else
                    Facturacion = false;
                bool Envio = form["Envio"] == "on" ? true : false;
                db.InsertAdeudosInstalacion(IdAdeudoIngreso, IdProveedor, cliente.IdCliente, null, null,
                    IdAcesor, IdPaquete, null, int.Parse(Cantidad), Concepto, Descripcion,
                    Unidad, Total, clave.c_ClaveProdServ, null, IdAcesor,
                    Comentario, double.Parse(Cargo), Pagado, false, Facturacion,
                    false, Envio, false,DateTime.Now, usuario.Id, true);
                if (form["Moneda"].Contains("MXN"))
                    db.InsertMonitoreoIngresos(IdMonitoreoIngreso,IdAdeudoIngreso,null, double.Parse(Cargo), 0,
                        0, 0, MetodoPago,FormaPago, UsoCFDI, usuario.Id, TipoCambio, form["Moneda"], 
                        Comentario, DateTime.Now,true);
                else
                    db.InsertMonitoreoIngresos(IdMonitoreoIngreso, IdAdeudoIngreso,null, 0, 0,
                        double.Parse(Cargo), 0,MetodoPago,FormaPago, UsoCFDI, usuario.Id, TipoCambio, form["Moneda"],
                        Comentario, DateTime.Now,true);                
            }
            return IdAdeudoIngreso;
        }
        public ActionResult ClaveProdServ(Guid IdPac) {
            
           List<ClaveProdServ> ClavePorPac = db.GetClaveProdServPorPAC(IdPac).ToList();           
           // var serializer = ClaveProdServ.ConvertAll(x => Convert.ToString(x.Descripcion));
           
            return Json(new {ClaveProdServ= ClavePorPac },JsonRequestBehavior.AllowGet);
        }
        
    }

}
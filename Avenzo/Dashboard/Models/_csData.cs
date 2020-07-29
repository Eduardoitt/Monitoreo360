using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    
    partial class _csData {       

    }
    public enum Roles
    {
        Cliente,
        Admin
    }
    public enum TipoUsuario
    {
        Empleado,
        Cliente
    }
    public class NominaView {
        public List<GetPAC_Result> PAC { get; set; }
        public List<Empleados> Empleados {get;set;}
        public List<NominaHistorial> Nominas { get; set; }
    }
    public class Ingresos
    {
        public List<MonitoreoIngresos> ingresos { get; set; }
        public List<CFDI> Facturas { get; set; }
        public List<Clientes> Clientes { get; set; }
        public List<GetPAC_Result> Proveedores { get; set; }
        public List<AdeudosInstalaciones> Adeudos { get; set; }
        
    }
    public class Adeudos
    {
        public List<MonitoreoIngresos> ingresos { get; set; }
        public List<CFDI> Facturas { get; set; }
        public List<Clientes> Clientes { get; set; }
        public List<GetPAC_Result> Proveedores { get; set; }
        public List<AdeudosInstalaciones> adeudos { get; set; }
        public List<CFDIPorOperacion> FacturasPorAdeudo { get; set;}
    }
    public class ConfiguracionView
    {
        public Clientes Clientes { get; set; }
        public Empleados Empleados { get; set; }
        public Usuarios Usuario { get; set; }
    }
    public class EmpleadoView
    {
        public List<Bancos> Bancos { get; set; }
        public List<Contratos> Contratos { get; set; }
        public List<Deducciones> Deducciones { get; set; }
        public Empleados Empleado { get; set; }
        public List<Estados> Estados { get; set; }
        public List<Horas> Horas { get; set; }
        public List<Jornadas> Jornadas { get; set; }
        public List<GetPAC_Result> PAC { get; set; }
        public List<PeriodicidadPago> PeriodicidadPago { get; set; }
        public List<Incapacidades> Incapacidad { get; set; }
        [Display(Name = "Tipo de Percepcion")]
        public List<Percepciones> Percepciones { get; set; }
        public List<RiesgoPuesto> RiesgoPuesto { get; set; }
        public List<OtrosPagos> OtrosPagos { get; set; }
        public Usuarios Usuario { get; set; }
        public NominaHistorial NominaHistorial { get; set; }
        public NominaPercepciones NominaPercepciones { get; set; }
        public List<NominaPercepcion> NominaPercepcion { get; set; }
        public List<NominaHorasExtras> NominaHorasExtras { get; set; }
        public NominaJubilacionPensionRetiro JubilacionPensionRetiro { get; set; }
        public NominaSeparacionIndemnizacion SeparacionIndemnizacion { get; set; }
        public List<NominaDeduccion> NominaDeducion { get; set; }
        public List<NominaIncapacidad> NominaIncapacidad { get; set; }
        public List<NominaOtrosPago> NominaOtroPago { get; set; }        
        public List<Nominas> Nomina { get; set; }
        public List<Regimen> Regimen { get; set; }
    }
   

}
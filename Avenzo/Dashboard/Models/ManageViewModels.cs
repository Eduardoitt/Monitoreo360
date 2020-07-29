using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.Owin.Security;
using System;

namespace Model
{
    
    public class ReciboView
    {
        public partial class Concepto
        {

            [Display(Name = "Cantidad")]
            public int cantidad { get; set; }
            [Display(Name = "Unidad")]
            public string unidad { get; set; }
            [Display(Name = "Concepto")]
            public string descripcion { get; set; }
            [Display(Name = "Precio")]
            public float precio { get; set; }
            public Concepto() {}
            public Concepto(int cantidad, string unidad, string descripcion, float precio)
            {
                this.cantidad = cantidad;
                this.unidad = unidad;
                this.descripcion = descripcion;
                this.precio = precio;
            }
        }
        public Guid id { get; set; }
        [Required]
        [Display(Name ="Nombre Completo")]
        public string nombreCompleto { get; set; }
        [Required]
        [Display(Name = "Moneda")]
        public List<string> moneda { get; set; }
        [Display(Name = "Leyenda de Garantia")]
        public string leyenda { get; set; }        
        public List<GetPAC_Result> pac { set; get; }
        public List<Clientes> clientes { get; set; }
        [Display(Name ="Mes")]
        public  List<string> mes { get; set; }        
        public List<Concepto> conceptos { get; set; }        
        public string mensualidad { get; set; }
        [Display(Name = "Compañia")]
        public Guid proveedor { get; set; }

    }
    /*public class NominaView
    {
        [Required]
        [Display(Name = "Compañia")]
        public List<GetPAC_Result> PAC { get; set; }
        public List<Contratos> Contratos { get; set; }
        public List<Jornadas> Jornadas { get; set; }
        public List<RiesgoPuesto> RiesgoPuesto { get; set; }
        public List<ClaveProdServ> ClaveProdServ { get; set; }
        public List<Estados> Estados { get; set; }
        public List<Horas> Horas { get; set; }
        public List<PeriodicidadPago> PeriodicidadPago { get; set; }
        public List<Deducciones> Deducciones { get; set; }
        public List<OtrosPagos> OtrosPagos { get; set; }
        
    }*/
    /*public class EmpleadoView {
        public List<Bancos> Bancos { get; set; }
        public List<Contratos> Contratos { get; set; }
        public Empleados Empleado { get; set; }
        public List<Estados> Estados { get; set; }
        public List<Horas> Horas { get; set; }
        public List<Jornadas> Jornadas { get; set; }
        public List<GetPAC_Result> PAC { get; set; }
        public List<PeriodicidadPago> PeriodicidadPago {get;set;}
        public List<Percepciones> Percepciones { get; set; }
        public List<RiesgoPuesto> RiesgoPuesto { get; set; }
        public Usuarios Usuario { get; set; }

    }*/
    public class RegistrarseView
    {
        
        [Required]
        [Display(Name = "Nombre(s)")]
        public string Nombres { get; set; }
        [Display(Name ="Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        [Required]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }
        [Required]
        [Display(Name = "Correo electrónico")]
        public string Correo { get; set; }
        [Required]
        [Display(Name ="Contraseña")]
        public string Contraseña { get; set; }
        [Display(Name ="Fecha de Nacimiento")]
        public string FechaNacimiento { get; set; }
        
    }
    public class PrimeraConfig
    {
        public List<ClaveProdServ> ClaveProdServ { get; set; }
        public List<ClaveProdServPorPAC> ClaveProdServPorPAC { get; set; }
    }
    public class CertificadosView
    {
        public GetPAC_Result PAC { get; set; }
        public List<ClaveProdServ> ClaveProdServ { get; set; }
        public List<ClaveProdServPorPAC> ClaveProdServPorPAC { get; set; }
        public List<GetClaveProdServClase_Result> ClaveProdServPorClase { get; set; }
    }
    

}
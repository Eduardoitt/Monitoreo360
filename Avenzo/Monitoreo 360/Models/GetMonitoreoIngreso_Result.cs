//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Monitoreo_360.Models
{
    using System;
    
    public partial class GetMonitoreoIngreso_Result
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> IdAdeudo { get; set; }
        public Nullable<System.Guid> IdNominaHistorial { get; set; }
        public string c_ClaveProdServ { get; set; }
        public int Cantidad { get; set; }
        public string c_ClaveUnidad { get; set; }
        public string Concepto { get; set; }
        public string Descripcion { get; set; }
        public double Cargos { get; set; }
        public double Abonos { get; set; }
        public Nullable<bool> Activo { get; set; }
        public System.Guid UsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
    }
}

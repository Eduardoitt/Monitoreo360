//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
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

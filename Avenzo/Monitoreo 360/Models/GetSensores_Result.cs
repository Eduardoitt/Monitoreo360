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
    
    public partial class GetSensores_Result
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> IdCliente { get; set; }
        public string NumeroDeSensor { get; set; }
        public string TipoSensor { get; set; }
        public string Ubicacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<System.Guid> UsuarioCreacion { get; set; }
        public Nullable<bool> Activo { get; set; }
    }
}

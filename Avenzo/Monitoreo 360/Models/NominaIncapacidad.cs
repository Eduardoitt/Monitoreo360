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
    using System.Collections.Generic;
    
    public partial class NominaIncapacidad
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> IdNominaHistorial { get; set; }
        public Nullable<double> DiasIncapacidad { get; set; }
        public string Tipo { get; set; }
        public Nullable<double> Importe { get; set; }
        public Nullable<System.Guid> UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
    
        public virtual Incapacidades Incapacidades { get; set; }
        public virtual NominaHistorial NominaHistorial { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}

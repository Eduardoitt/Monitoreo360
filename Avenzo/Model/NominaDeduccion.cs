//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class NominaDeduccion
    {
        public System.Guid Id { get; set; }
        public System.Guid IdNominaHistorial { get; set; }
        public string Tipo { get; set; }
        public string Clave { get; set; }
        public string Concepto { get; set; }
        public double Importe { get; set; }
        public Nullable<System.Guid> UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
    
        public virtual Deducciones Deducciones { get; set; }
        public virtual Deducciones Deducciones1 { get; set; }
        public virtual NominaHistorial NominaHistorial { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
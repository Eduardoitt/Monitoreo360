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
    
    public partial class CFDIEnDeuda
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> IdPAC { get; set; }
        public Nullable<System.Guid> IdCFDI { get; set; }
        public bool Pagado { get; set; }
        public Nullable<System.DateTime> FechaPago { get; set; }
        public System.Guid UsuarioCreacion { get; set; }
        public System.Guid FechaCreacion { get; set; }
    
        public virtual PAC PAC { get; set; }
        public virtual CFDI CFDI { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}

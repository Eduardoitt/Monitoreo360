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
    
    public partial class CarritoCompras
    {
        public System.Guid Id { get; set; }
        public System.Guid IdCliente { get; set; }
        public System.Guid IdCatalogo { get; set; }
        public Nullable<System.Guid> IdInstalacion { get; set; }
        public bool Activo { get; set; }
        public System.DateTime FechaCreacion { get; set; }
    }
}

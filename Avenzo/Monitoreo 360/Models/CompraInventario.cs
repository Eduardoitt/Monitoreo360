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
    
    public partial class CompraInventario
    {
        public System.Guid IdCompraInventario { get; set; }
        public Nullable<System.Guid> IdCompra { get; set; }
        public Nullable<System.Guid> IdDispositivo { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<decimal> Monto { get; set; }
    }
}

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
    
    public partial class FotosCliente
    {
        public System.Guid IdFotoCliente { get; set; }
        public Nullable<System.Guid> IdCliente { get; set; }
        public byte[] RutaFoto { get; set; }
    
        public virtual Clientes Clientes { get; set; }
    }
}

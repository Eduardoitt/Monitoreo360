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
    
    public partial class DispositivosAsignados
    {
        public System.Guid IdDispositivoAsignado { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<System.DateTime> FechaAsignacion { get; set; }
        public Nullable<System.Guid> IdDispositivo { get; set; }
        public Nullable<System.Guid> IdEmpleado { get; set; }
    }
}

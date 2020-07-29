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
    
    public partial class Incidentes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Incidentes()
        {
            this.ReporteLlamada = new HashSet<ReporteLlamada>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid IdCliente { get; set; }
        public Nullable<System.Guid> IdLog { get; set; }
        public string Comentarios { get; set; }
        public System.DateTime FechaHoraInicio { get; set; }
        public Nullable<System.DateTime> FechaHoraFin { get; set; }
        public string Estatus { get; set; }
        public bool Activo { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public System.Guid UsuarioCreacion { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual Incidentes Incidentes1 { get; set; }
        public virtual Incidentes Incidentes2 { get; set; }
        public virtual LogMonitoreo360 LogMonitoreo360 { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReporteLlamada> ReporteLlamada { get; set; }
    }
}

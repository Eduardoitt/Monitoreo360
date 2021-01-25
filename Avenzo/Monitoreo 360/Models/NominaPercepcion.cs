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
    using System.Collections.Generic;
    
    public partial class NominaPercepcion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NominaPercepcion()
        {
            this.NominaHorasExtras = new HashSet<NominaHorasExtras>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid IdPercepciones { get; set; }
        public string Tipo { get; set; }
        public string Clave { get; set; }
        public string Concepto { get; set; }
        public Nullable<double> ImporteExcento { get; set; }
        public Nullable<double> ImporteGravado { get; set; }
        public Nullable<double> ValorMercado { get; set; }
        public Nullable<double> PrecioOrtorgarse { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<System.Guid> UsuarioCreacion { get; set; }
    
        public virtual Percepciones Percepciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NominaHorasExtras> NominaHorasExtras { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}

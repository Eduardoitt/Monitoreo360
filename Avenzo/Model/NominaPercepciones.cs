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
    
    public partial class NominaPercepciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NominaPercepciones()
        {
            this.NominaHistorial = new HashSet<NominaHistorial>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> IdSeparacionIndemnizacion { get; set; }
        public Nullable<System.Guid> IdJubilacionPensionRetiro { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<System.Guid> UsuarioCreacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NominaHistorial> NominaHistorial { get; set; }
        public virtual NominaJubilacionPensionRetiro NominaJubilacionPensionRetiro { get; set; }
        public virtual NominaSeparacionIndemnizacion NominaSeparacionIndemnizacion { get; set; }
    }
}

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
    
    public partial class NominaSeparacionIndemnizacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NominaSeparacionIndemnizacion()
        {
            this.NominaPercepciones = new HashSet<NominaPercepciones>();
        }
    
        public System.Guid Id { get; set; }
        public double TotalPagado { get; set; }
        public int NumAñosServicio { get; set; }
        public double UltimoSueldoMensOrd { get; set; }
        public double IngresoAcumulable { get; set; }
        public double IngresoNoAcumulable { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public System.Guid UsuarioCreacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NominaPercepciones> NominaPercepciones { get; set; }
    }
}

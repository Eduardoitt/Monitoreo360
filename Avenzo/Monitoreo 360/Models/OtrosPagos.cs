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
    
    public partial class OtrosPagos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OtrosPagos()
        {
            this.NominaOtrosPago = new HashSet<NominaOtrosPago>();
            this.NominaOtrosPago1 = new HashSet<NominaOtrosPago>();
        }
    
        public string c_TipoOtroPago { get; set; }
        public string Descripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NominaOtrosPago> NominaOtrosPago { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NominaOtrosPago> NominaOtrosPago1 { get; set; }
    }
}

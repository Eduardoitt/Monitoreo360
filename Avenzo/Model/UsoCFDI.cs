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
    
    public partial class UsoCFDI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsoCFDI()
        {
            this.MonitoreoIngresos = new HashSet<MonitoreoIngresos>();
        }
    
        public string c_UsoCFDI { get; set; }
        public string Descripcion { get; set; }
        public bool Fisica { get; set; }
        public bool Moral { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonitoreoIngresos> MonitoreoIngresos { get; set; }
    }
}

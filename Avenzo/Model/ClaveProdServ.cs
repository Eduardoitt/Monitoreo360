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
    
    public partial class ClaveProdServ
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClaveProdServ()
        {
            this.ClaveProdServHistorial = new HashSet<ClaveProdServHistorial>();
        }
    
        public string c_ClaveProdServ { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string Division { get; set; }
        public string Grupo { get; set; }
        public string Clase { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClaveProdServHistorial> ClaveProdServHistorial { get; set; }
    }
}

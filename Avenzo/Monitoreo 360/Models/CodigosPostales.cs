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
    
    public partial class CodigosPostales
    {
        public string CodigoPostal { get; set; }
        public string c_Estados { get; set; }
        public string Municipio { get; set; }
        public string Localidad { get; set; }
    
        public virtual Estados Estados { get; set; }
    }
}

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
    
    public partial class ClaveProdServPorPAC
    {
        public System.Guid Id { get; set; }
        public System.Guid IdPAC { get; set; }
        public string Clase { get; set; }
        public System.Guid UsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
    
        public virtual PAC PAC { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}

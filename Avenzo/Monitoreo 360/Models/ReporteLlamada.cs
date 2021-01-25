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
    
    public partial class ReporteLlamada
    {
        public System.Guid Id { get; set; }
        public System.Guid IdIncidente { get; set; }
        public System.Guid IdClienteContacto { get; set; }
        public string Comentarios { get; set; }
        public System.DateTime FechaHoraInicio { get; set; }
        public Nullable<System.DateTime> FechaHoraFin { get; set; }
        public string Llamada { get; set; }
        public string Estatus { get; set; }
        public bool Activo { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public System.Guid UsuarioCreacion { get; set; }
    
        public virtual ClienteContactos ClienteContactos { get; set; }
        public virtual Incidentes Incidentes { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}

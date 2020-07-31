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
    
        public virtual Usuarios Usuarios { get; set; }
        public virtual ClienteContactos ClienteContactos { get; set; }
        public virtual Incidentes Incidentes { get; set; }
    }
}
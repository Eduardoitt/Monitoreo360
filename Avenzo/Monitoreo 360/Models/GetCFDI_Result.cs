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
    
    public partial class GetCFDI_Result
    {
        public System.Guid Id { get; set; }
        public string Tipo { get; set; }
        public Nullable<int> Folio { get; set; }
        public string XML { get; set; }
        public string Ruta { get; set; }
        public Nullable<System.Guid> IdCliente { get; set; }
        public Nullable<System.Guid> IdEmpleado { get; set; }
        public System.Guid IdProveedor { get; set; }
        public bool Cancelado { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.Guid> UsuarioCreacion { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dashboard.Models
{
    using System;
    
    public partial class GetCFDI_Result
    {
        public System.Guid Id { get; set; }
        public string Tipo { get; set; }
        public Nullable<int> Folio { get; set; }
        public byte[] XML { get; set; }
        public string Ruta { get; set; }
        public Nullable<System.Guid> IdCliente { get; set; }
        public Nullable<System.Guid> IdProveedor { get; set; }
        public bool Cancelado { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
    }
}

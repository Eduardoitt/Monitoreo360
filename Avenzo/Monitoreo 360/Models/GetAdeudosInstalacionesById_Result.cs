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
    
    public partial class GetAdeudosInstalacionesById_Result
    {
        public System.Guid Id { get; set; }
        public System.Guid IdProveedor { get; set; }
        public System.Guid IdCliente { get; set; }
        public Nullable<System.Guid> IdPaquete { get; set; }
        public string c_FormaPago { get; set; }
        public string c_MetodoPago { get; set; }
        public string c_UsoCFDI { get; set; }
        public string c_Moneda { get; set; }
        public Nullable<double> IVA { get; set; }
        public Nullable<double> TipoCambio { get; set; }
        public Nullable<System.DateTime> FechaPago { get; set; }
        public double Total { get; set; }
        public Nullable<System.DateTime> FechaInstalacion { get; set; }
        public string Comentarios { get; set; }
        public bool Pagado { get; set; }
        public Nullable<bool> RequiereFacturacion { get; set; }
        public Nullable<bool> RequiereCorreo { get; set; }
        public Nullable<bool> Activo { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.Guid> UsuarioCreacion { get; set; }
    }
}

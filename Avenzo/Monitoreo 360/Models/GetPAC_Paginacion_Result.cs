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
    
    public partial class GetPAC_Paginacion_Result
    {
        public System.Guid Id { get; set; }
        public string RFC { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string CURP { get; set; }
        public Nullable<bool> PersonaMoral { get; set; }
        public byte[] Llave { get; set; }
        public byte[] Certificado { get; set; }
        public string ContrasenaLlave { get; set; }
        public string RegimenFiscal { get; set; }
        public string RegistroPatronal { get; set; }
        public string RfcPatronOrigen { get; set; }
        public string Logo { get; set; }
        public string LugarExpedicion { get; set; }
        public Nullable<System.DateTime> FechaVigenciaIncio { get; set; }
        public Nullable<System.DateTime> FechaVigenciaFinal { get; set; }
        public string Leyenda { get; set; }
        public Nullable<double> IVA { get; set; }
        public Nullable<System.Guid> UsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
    }
}
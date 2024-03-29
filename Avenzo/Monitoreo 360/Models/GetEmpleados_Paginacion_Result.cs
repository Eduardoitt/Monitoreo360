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
    
    public partial class GetEmpleados_Paginacion_Result
    {
        public System.Guid Id { get; set; }
        public int NoEmpleado { get; set; }
        public Nullable<System.Guid> IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string ApellidoMaterno { get; set; }
        public string ApellidoPaterno { get; set; }
        public Nullable<System.Guid> IdUsuario { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public Nullable<System.DateTime> FechaInicioRelLaboral { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public byte[] HuellaDactilar { get; set; }
        public string Foto { get; set; }
        public string INE { get; set; }
        public string NumeroSeguridadSocial { get; set; }
        public string Departamento { get; set; }
        public string Direccion { get; set; }
        public string Puesto { get; set; }
        public string RiesgoPuesto { get; set; }
        public string TipoContrato { get; set; }
        public string TipoJornada { get; set; }
        public string TipoRegimen { get; set; }
        public Nullable<double> SalarioDiario { get; set; }
        public Nullable<double> DiasPagados { get; set; }
        public string PeriodicidadPago { get; set; }
        public string LugarExpedicion { get; set; }
        public string TipoNomina { get; set; }
        public string Banco { get; set; }
        public string ClaveEntFed { get; set; }
        public string GradoEstudios { get; set; }
        public string Telefono { get; set; }
        public string TelefonoEmergencia { get; set; }
        public byte[] Firma { get; set; }
        public string TipoSangre { get; set; }
        public string CUIP { get; set; }
        public string NumeroDeLicencia { get; set; }
        public string NumeroDeAutorizacion { get; set; }
        public Nullable<bool> Activo { get; set; }
        public System.Guid UsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
    }
}

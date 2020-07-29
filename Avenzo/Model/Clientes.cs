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
    
    public partial class Clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clientes()
        {
            this.AdeudosInstalaciones = new HashSet<AdeudosInstalaciones>();
            this.CFDI = new HashSet<CFDI>();
            this.CFDIEnDeuda = new HashSet<CFDIEnDeuda>();
            this.Sensores = new HashSet<Sensores>();
            this.ClienteContactos = new HashSet<ClienteContactos>();
            this.HorarioOperaciones = new HashSet<HorarioOperaciones>();
            this.Incidentes = new HashSet<Incidentes>();
        }
    
        public System.Guid IdCliente { get; set; }
        public Nullable<System.Guid> IdProveedor { get; set; }
        public Nullable<System.Guid> IdUsuario { get; set; }
        public string NumeroTelefonoAlarma { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NumeroDeCuenta { get; set; }
        public string PalabraClave { get; set; }
        public string PalabraClaveSilenciosa { get; set; }
        public string Calle { get; set; }
        public string NoInterior { get; set; }
        public string NoExterior { get; set; }
        public string Colonia { get; set; }
        public string CodigoPostal { get; set; }
        public string Referencias { get; set; }
        public string ColorEstablecimiento { get; set; }
        public string EntreCalles { get; set; }
        public string GoogleMaps { get; set; }
        public string Descripcion { get; set; }
        public string Telefono { get; set; }
        public string TelefonoTrabajo { get; set; }
        public string TelefonoCelular { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public Nullable<System.Guid> TipoAfilacion { get; set; }
        public string NumeroPatrocinador { get; set; }
        public string FechaNacimiento { get; set; }
        public string LugarNacimiento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Profesion { get; set; }
        public string CURP { get; set; }
        public string RFC { get; set; }
        public string Banco { get; set; }
        public string NumCtaPago { get; set; }
        public string ClaveBancaria { get; set; }
        public string NumeroCLABE { get; set; }
        public string Beneficiario { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.Guid> UsuarioCreacion { get; set; }
        public bool Activo { get; set; }
    
        public virtual Bancos Bancos { get; set; }
        public virtual PAC PAC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdeudosInstalaciones> AdeudosInstalaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CFDI> CFDI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CFDIEnDeuda> CFDIEnDeuda { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        public virtual Usuarios Usuarios1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sensores> Sensores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClienteContactos> ClienteContactos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HorarioOperaciones> HorarioOperaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Incidentes> Incidentes { get; set; }
    }
}

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
    
    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            this.AdeudosInstalaciones = new HashSet<AdeudosInstalaciones>();
            this.CFDI = new HashSet<CFDI>();
            this.CFDIEnDeuda = new HashSet<CFDIEnDeuda>();
            this.ClaveProdServHistorial = new HashSet<ClaveProdServHistorial>();
            this.ClaveProdServPorPAC = new HashSet<ClaveProdServPorPAC>();
            this.Clientes = new HashSet<Clientes>();
            this.Clientes1 = new HashSet<Clientes>();
            this.Empleados = new HashSet<Empleados>();
            this.LogMonitoreo360 = new HashSet<LogMonitoreo360>();
            this.MonitoreoIngresos = new HashSet<MonitoreoIngresos>();
            this.NominaDeduccion = new HashSet<NominaDeduccion>();
            this.NominaHorasExtras = new HashSet<NominaHorasExtras>();
            this.NominaIncapacidad = new HashSet<NominaIncapacidad>();
            this.NominaOtrosPago = new HashSet<NominaOtrosPago>();
            this.NominaPercepcion = new HashSet<NominaPercepcion>();
            this.ReporteLlamada = new HashSet<ReporteLlamada>();
            this.Sensores = new HashSet<Sensores>();
            this.ClienteContactos = new HashSet<ClienteContactos>();
            this.HorarioOperaciones = new HashSet<HorarioOperaciones>();
            this.Incidentes = new HashSet<Incidentes>();
        }
    
        public System.Guid Id { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string TipoUsuario { get; set; }
        public string Roles { get; set; }
        public bool Activo { get; set; }
        public int Timbres { get; set; }
        public int TimbresUsados { get; set; }
        public int TimbresCancelados { get; set; }
        public bool PrimeraVez { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdeudosInstalaciones> AdeudosInstalaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CFDI> CFDI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CFDIEnDeuda> CFDIEnDeuda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClaveProdServHistorial> ClaveProdServHistorial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClaveProdServPorPAC> ClaveProdServPorPAC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clientes> Clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clientes> Clientes1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Empleados> Empleados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LogMonitoreo360> LogMonitoreo360 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonitoreoIngresos> MonitoreoIngresos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NominaDeduccion> NominaDeduccion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NominaHorasExtras> NominaHorasExtras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NominaIncapacidad> NominaIncapacidad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NominaOtrosPago> NominaOtrosPago { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NominaPercepcion> NominaPercepcion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReporteLlamada> ReporteLlamada { get; set; }
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

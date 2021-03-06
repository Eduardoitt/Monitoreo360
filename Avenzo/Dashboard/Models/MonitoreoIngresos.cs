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
    using System.Collections.Generic;
    
    public partial class MonitoreoIngresos
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> IdAdeudo { get; set; }
        public Nullable<System.Guid> IdNominaHistorial { get; set; }
        public Nullable<double> Cargos { get; set; }
        public Nullable<double> Abonos { get; set; }
        public Nullable<double> CargosUSD { get; set; }
        public Nullable<double> AbonosUSD { get; set; }
        public Nullable<double> TipoCambio { get; set; }
        public string MetodoDePago { get; set; }
        public string Moneda { get; set; }
        public string Comentario { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<bool> Activo { get; set; }
    
        public virtual NominaHistorial NominaHistorial { get; set; }
        public virtual AdeudosInstalaciones AdeudosInstalaciones { get; set; }
    }
}

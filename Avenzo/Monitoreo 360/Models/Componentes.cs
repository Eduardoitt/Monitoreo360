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
    
    public partial class Componentes
    {
        public System.Guid IdComponente { get; set; }
        public string Nombre { get; set; }
        public int Costo { get; set; }
        public bool EsComponenteArduino { get; set; }
        public Nullable<System.DateTime> FechaInstalacion { get; set; }
        public Nullable<System.DateTime> FechaMantenimiento { get; set; }
        public string UsuarioInstalo { get; set; }
        public string UsuarioMantenimiento { get; set; }
    }
}

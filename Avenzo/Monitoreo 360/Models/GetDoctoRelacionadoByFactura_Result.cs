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
    
    public partial class GetDoctoRelacionadoByFactura_Result
    {
        public Nullable<System.Guid> IdDocumento { get; set; }
        public string Serie { get; set; }
        public Nullable<int> Folio { get; set; }
        public string MonedaDR { get; set; }
        public string MetodoDePagoDR { get; set; }
        public Nullable<double> ImpSaldoAnt { get; set; }
        public Nullable<double> ImpPagado { get; set; }
        public Nullable<double> ImpSaldoInsoluto { get; set; }
    }
}

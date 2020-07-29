using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    
    partial class _csData {       

    }
    public class ContactoView {
        
        [Display(Name = "Nombre(s):")]
        public string Nombres { get; set; }
        [Display(Name = "Apellido Paterno:")]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno:")]
        public string ApellidoMaterno { get; set; }        
        [Display(Name = "Sexo:")]
        public string Sexo { get; set; }        
        [Display(Name = "Departamento:")]
        public string Departamento { get; set; }        
        [Display(Name = "Correo electrónico:")]
        public string Correo { get; set; }        
        [Display(Name = "Numero de telefono:")]
        public string Telefono { get; set; }        
        [Display(Name = "Mensaje:")]
        public string Mensaje { get; set; }
    }
    public class UsuarioView
    {
        public Clientes clientes { get; set; }
        public Empleados empleado { get; set; }
    }
    /*public class Nomina {
        public List<GetPAC_Result> PAC { get; set; }
        public List<Empleados> Empleados {get;set;}
        public List<GetNominaHistorial_Result> Nominas { get; set; }
    }
    public class Ingresos
    {
        public List<GetIngresos_Result> ingresos { get; set; }
        public List<GetFactura_Result> Facturas { get; set; }
        public List<Clientes> clientes { get; set; }
        public List<GetPAC_Result> Proveedores { get; set; }
    }*/

}
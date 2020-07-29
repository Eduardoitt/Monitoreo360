using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model
{
    public class Login
    {
        AvenzoSeguridadEntities db = new AvenzoSeguridadEntities();
        [Required]
        [Display(Name = "Dirección de correo electrónico")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]        
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recordar contraseña")]
        public bool RememberMe { get; set; }
    }
}
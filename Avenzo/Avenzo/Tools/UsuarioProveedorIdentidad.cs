using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Model;

namespace Avenzo.Tools
{
    class UsuarioProveedorIdentidad : MembershipUser
    {
        public string Usuario { set; get; }
        public string Rol { set; get; }
        
        public UsuarioProveedorIdentidad(Usuarios usuario) {
            this.Usuario = usuario.Usuario;
            this.Rol = usuario.Roles;
         
        }
    }
}

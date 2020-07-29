using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace Avenzo.Tools
{
    public class ProveedorIdentidad : IIdentity
    {
        public IIdentity Identity { get; set; }
        public String Usuario { get; set; }        
        public string Name { get { return String.Format("{0}", Usuario); } }        
        public string AuthenticationType { get { return Identity.AuthenticationType; } }
        public bool IsAuthenticated { get { return Identity.IsAuthenticated; } }        
        public ProveedorIdentidad(IIdentity Identity) {
            this.Identity = Identity;
            var usuario = (UsuarioProveedorIdentidad)Membership.GetUser();
            this.Usuario = usuario.Usuario;
            
        }
    }
}
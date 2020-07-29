using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace Avenzo.Tools
{
    public class PrincipalPersonalidado : IPrincipal
    {   
        
        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            return false;
        }
        public PrincipalPersonalidado(ProveedorIdentidad proveedoridentidad) {
            Identity = proveedoridentidad;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Model;

namespace Avenzo
{
    public class MyRoleProvider : RoleProvider
    {
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            // throw new NotImplementedException();
            using (AvenzoSeguridadEntities objContext = new AvenzoSeguridadEntities())
            {
                var objUser = objContext.Usuarios.Where(x => x.Usuario == username).FirstOrDefault();
                if (objUser != null)
                {
                    var code = objUser.Roles;
                    return new[] { code };
                }
            }
            return null;
        }

        //public override string[] GetRolesForUser(string username)
        //{
        //    // throw new NotImplementedException();
        //    using (AvenzoSeguridadEntities objContext = new AvenzoSeguridadEntities())
        //    {
        //        var objUser = objContext.Clientes.FirstOrDefault(x => x.Email == username);
        //        if (objUser == null)
        //        {
        //            var objUser2 = objContext.Empleados.FirstOrDefault(x => x.Usuario == username);
        //            if (objUser2 == null)
        //            {
        //                return null;
        //            }
        //            else
        //            {
        //                var code = objContext.Empleados.Where(x => x.Usuario == username).Single().PermisoUsuario;
        //                return new[] { code };
        //            }
        //        }
        //        else
        //        {
        //            // string[] ret = objUser.TipoUsuario.Select(x => x.NombreTipoUsuario).ToArray();
        //            var code = objContext.Clientes.Where(x => x.Email == username).Single().PermisoUsuario;
        //            return new[] { code };
        //        }
        //    }
        //}

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
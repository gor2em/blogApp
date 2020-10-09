using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using bloga.Models.Entity;
namespace bloga.App_Classes
{

    public class CustomRoleProvider : RoleProvider
    {
       

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
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
            blogaDBEntities bdg = new blogaDBEntities();
            if (!string.IsNullOrEmpty(username))
            {
                user u = bdg.users.FirstOrDefault(x => x.USERNAME == username);
                if (u != null)
                {
                    return u.user_role == null ? new string[] { } : u.user_role.Select(x => x.role).Select(x => x.ROLENAME).ToArray();
                }

            }
            return new string[] { };
        }

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
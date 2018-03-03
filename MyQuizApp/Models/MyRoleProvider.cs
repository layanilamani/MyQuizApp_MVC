using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MyQuizApp.Models
{
    public class MyRoleProvider:RoleProvider
    {
        MyQuizAppEntities db = new MyQuizAppEntities();
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            foreach (var un in usernames)
            {
                var user = db.Users.First(u => u.Email == un);

                if(user!=null)
                {
                    var rolename =  roleNames[0];
                    var usertype = db.UserTypes.First(ut => ut.Name == rolename);
                    user.UserType = usertype;
                }

                db.SaveChanges();
            }
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
             UserType ut = new UserType();
            ut.Name = roleName;

            db.UserTypes.Add(ut);
            db.SaveChanges();
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
            return db.UserTypes.Select(ut=> ut.Name).ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {

            return db.UserTypes.Where(ut => ut.Users.FirstOrDefault().Name == username).Select(ut => ut.Name).ToArray();

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
           return db.UserTypes.Any(ut => ut.Name == roleName);
        }
    }
}

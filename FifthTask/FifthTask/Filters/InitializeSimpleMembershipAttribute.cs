using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using System.Collections.Generic;
using FifthTask.Models;

namespace FifthTask.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<UsersContext>(null);

                try
                {
                    using (var context = new UsersContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }
                    //first parametr - DefaultConntection
                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                   // this.SeedMembership();
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The Simple Membership database could not be initialized.", ex);
                }
                 
            }
            
          /*  private void SeedMembership() {
               
                SimpleRoleProvider roles = new SimpleRoleProvider();
                SimpleMembershipProvider membership = new SimpleMembershipProvider();
                

                if (!roles.RoleExists("Admin"))
                    roles.CreateRole("Admin");

                if (!roles.RoleExists("User"))
                    roles.CreateRole("User");
                
                
                if (membership.GetUser("Admin", false) == null)
                {
                    membership.CreateUserAndAccount("Admin", "Admin");
                }

                List<string> rolesForUser = new List<string>(roles.GetRolesForUser("Admin"));
                //if (!roles.GetRolesForUser("Admin").Contains("Admin"))
                if (!rolesForUser.Contains("Admin"))
                {
                    roles.AddUsersToRoles(new[] { "Admin" }, new[] { "Admin" });
                } 
            }*/
            

        }








    }
}

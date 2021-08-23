using FA.JustBlog.Core.Model;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using System.Linq;

namespace IdentitySample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //CreateRolesandUsers();
        }

   //     public void CreateRolesandUsers()
   //     {
   //         var db = new ApplicationDbContext();


   //         //populating roles
			//if (db.Roles.Any(x => x.Name == MyConstants.RoleAdmin))
			//{
   //             db.Roles.Add(new IdentityRole(MyConstants.RoleAdmin));
			//}

   //         if (db.Roles.Any(x => x.Name == MyConstants.RoleUser))
   //         {
   //             db.Roles.Add(new IdentityRole(MyConstants.RoleUser));
   //         }

			////populating user
			//if (db.Users.Any(x=>x.UserName=="appadmin"))
			//{
   //             var userStore = new UserStore<ApplicationUser>(db);
   //             var userManager = new ApplicationUserManager(userStore);

   //             var roleStore = new RoleStore<IdentityRole>(db);
   //             var roleManager = new RoleManager<IdentityRole>(roleStore);

   //             var newUser = new ApplicationUser
   //             {
   //                 Email = "appadmin@test.com",
   //                 UserName = "appadmin"
   //             };

   //             userManager.Create(newUser, "applicationadmin");
   //             userManager.AddToRole(newUser.Id, MyConstants.RoleAdmin);
   //             db.SaveChanges();
			//}

   //         if (db.Users.Any(x => x.UserName == "appuser"))
   //         {
   //             var userStore = new UserStore<ApplicationUser>(db);
   //             var userManager = new ApplicationUserManager(userStore);

   //             var roleStore = new RoleStore<IdentityRole>(db);
   //             var roleManager = new RoleManager<IdentityRole>(roleStore);

   //             var newUser = new ApplicationUser
   //             {
   //                 Email = "appuser@test.com",
   //                 UserName = "appuser"
   //             };

   //             userManager.Create(newUser, "applicationuser");
   //             userManager.AddToRole(newUser.Id, MyConstants.RoleUser);
   //             db.SaveChanges();
   //         }
   //     }
    }
}

using TrailerMovieAPI.Core.Application.Enums;
using TrailerMovieAPI.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailerMovieAPI.Infrastructure.Identity.Seeds
{
    public class DefaultAdministratorUser
    {
        public static async Task SeedAsync(UserManager<RestaurantUsers> userManager, RoleManager<IdentityRole> roleManager)
        {
            RestaurantUsers adminUser = new() {
                UserName = "DefaultAdmin",
                Name = "Jean",
                LastName = "Reyes",
                Email = "jreyes@TrailerMovieAPI.com.do",
                Documents = "402-0000000-4",
                EmailConfirmed = true,
                PhoneNumber="+1 809 935 0913",
                PhoneNumberConfirmed = true
            };


            if (userManager.Users.All(u=>u.Id!=adminUser.Id))
            {
                var user = await userManager.FindByEmailAsync(adminUser.Email);

                if (user==null)
                {
                    await userManager.CreateAsync(adminUser,"P@ssw0rd");

                    await userManager.AddToRoleAsync(adminUser,Roles.ADMINISTRATOR.ToString());
                }
            }
            
                   }
    }
}

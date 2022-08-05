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
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<Users> userManager,RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new(Roles.ADMINISTRATOR.ToString()));            


        }
    }
}

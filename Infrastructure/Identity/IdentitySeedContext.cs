using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class IdentitySeedContext
    {
        public static async Task SeedUserAsync(UserManager<AppUser> usermanager)
        {
            if(!usermanager.Users.Any()){
                var user = new AppUser{
                    DisplayName = "Irfan",
                    Email = "irfan@mail.com",
                    UserName = "irfan@gmail.com",
                    Address = new Address{
                        FirstName = "Irfanul",
                        LastName = "Hasan",
                        City = "Chittagong",
                        Street = "Road- 3B",
                        State = "Chittagong",
                        ZipCode = "4350"
                    }
                };

                await usermanager.CreateAsync(user,"Pa$$w0rd");
            }
        }
    }
}
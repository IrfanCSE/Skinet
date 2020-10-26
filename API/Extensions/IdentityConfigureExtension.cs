using Core.Entities.Identity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class IdentityConfigureExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection service)
        {
            var builder = service.AddIdentityCore<AppUser>();
            builder = new IdentityBuilder(builder.UserType,builder.Services);
            builder.AddEntityFrameworkStores<AppIdentityContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();

            service.AddAuthentication();

            return service;
        }
    }
}
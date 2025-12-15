using Microsoft.AspNetCore.Identity;
using Skola.Data.Entities.Identity;
using Skola.Infrastructure.data;
using System.Data;

namespace SkolaAPI.Extensions
{
	public  static class AddIdentityServices
	{
        public static  IServiceCollection AddIdentityService(this IServiceCollection services , IConfiguration configuration)
        {

			services.AddIdentity<User, IdentityRole<int>>(option =>
			{
				// Password settings.
				option.Password.RequireDigit = true;
				option.Password.RequireLowercase = true;
				option.Password.RequireNonAlphanumeric = true;
				option.Password.RequireUppercase = true;
				option.Password.RequiredLength = 6;
				option.Password.RequiredUniqueChars = 1;

				// Lockout settings.
				option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				option.Lockout.MaxFailedAccessAttempts = 5;
				option.Lockout.AllowedForNewUsers = true;

				// User settings.
				option.User.AllowedUserNameCharacters =
				"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
				option.User.RequireUniqueEmail = true;
				option.SignIn.RequireConfirmedEmail = true;

			}).AddEntityFrameworkStores<dbcontext>().AddDefaultTokenProviders();

		     
			return services;

		}
    }
}

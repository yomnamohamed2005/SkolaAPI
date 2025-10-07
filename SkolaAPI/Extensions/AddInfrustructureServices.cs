using Skola.Data.Repositories;
using Skola.Data.Services;
using Skola.Infrastructure.Repositories;
using Skola.Services.Services;
using System.Runtime.CompilerServices;

namespace SkolaAPI.Extensions
{
	public static class AddInfrustructureServices
	{

     public static IServiceCollection AddInfrustructureService(this IServiceCollection services) {

			services.AddScoped<IStudentRepository, StudentRepository>();
			services.AddScoped<IStudentServices, StudentServices>();
			return services;
		}

	}
}

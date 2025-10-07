using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Skola.Core.Behavior;
using Skola.Core.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Core
{
	public static  class Addmodules 
	{
		public static  IServiceCollection Addmodule( this IServiceCollection services)
		{
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
			services.AddAutoMapper(typeof(StudentProfile));

			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

			return services;
		}
	}
}

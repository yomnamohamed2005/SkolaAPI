using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Localization;
using Skola.Data.Repositories;
using Skola.Infrastructure.data;
using Skola.Infrastructure.Repositories;
using SkolaAPI.Extensions;
using Skola.Core;
using Skola.Core.MiddleWares;
using System.Globalization;

namespace SkolaAPI
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			
			builder.Services.AddControllers(); 

			// Swagger
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			// Database
			builder.Services.AddDbContext<dbcontext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});

			// Custom Services
			builder.Services.AddInfrustructureService();
			builder.Services.AddIdentityService(builder.Configuration);

			builder.Services.Addmodule();

			// Localization
			builder.Services.AddLocalization(options =>
			{
				options.ResourcesPath = "";
			});

			builder.Services.Configure<RequestLocalizationOptions>(options =>
			{
				var supportedCultures = new List<CultureInfo>
				{
					new CultureInfo("en-US"),
					new CultureInfo("de-DE"),
					new CultureInfo("fr-FR"),
					new CultureInfo("ar-EG")
				};

				options.DefaultRequestCulture = new RequestCulture("en-US");
				options.SupportedCultures = supportedCultures;
				options.SupportedUICultures = supportedCultures;
			});

			var app = builder.Build();

		
			using (var scope = app.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var loggerFactory = services.GetRequiredService<ILoggerFactory>();

				try
				{
					var dbcontext = services.GetRequiredService<dbcontext>();
					await dbcontext.Database.MigrateAsync();
					await dbcontextseed.SeedAsync(dbcontext);
				}
				catch (Exception ex)
				{
					var logger = loggerFactory.CreateLogger<Program>();
					logger.LogError(ex, "Error occurred during applying migration");
				}
			}

			
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			// Localization
			var locOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
			app.UseRequestLocalization(locOptions.Value);

			// Custom Error Handler
			app.UseMiddleware<ErrorHanndlerMaddleWare>();

			app.UseHttpsRedirection();
			app.UseAuthorization();

			app.MapControllers();
			app.Run();
		}
	}
}


using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using CubicWeight.Lib;
using CubicWeight.Business;
using CubicWeight.Business.Models;
using CubicWeight.Business.Services;

namespace CubicWeight.UI {

	class Program {

		static async Task Main(string[] args) {

			Console.WriteLine();

			try {
				//set configurations
				var configuration = SetConfiguration();

				// Create service collection and configure our services
				var services = ConfigureServices(configuration);

				// Generate a provider
				var serviceProvider = services.BuildServiceProvider();

				ILogger logger = serviceProvider.GetService<ILogger<Program>>();

				var asyncDemoService = serviceProvider.GetService<IAsyncDemo>();
				await asyncDemoService.Run();
			}
			catch (CustomException ex) {
				Console.WriteLine($"Failed to startup, message: {ex.Message}");
			}
			catch (Exception ex) {
				Console.WriteLine($"Unknown exception when staring up!, error: {ex.Message}");
			}
		}

		private static IConfiguration SetConfiguration() {
			IConfiguration configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddEnvironmentVariables()
				.Build();

			return configuration;
		}

		private static IServiceCollection ConfigureServices(IConfiguration configuration) {

			IServiceCollection services = new ServiceCollection();

			services.AddLogging(cfg => cfg.AddConsole());

			//regist dependency injection configurations
			services.Configure<CubicWeightSettings>(configuration.GetSection("CubicWeight"));

			//register dependency injection services
			services.AddTransient<IExceptionFactory, ExceptionFactory>();
			services.AddTransient<IRestApiService, RestApiService>();

			services.AddTransient<IFetchService, FetchService>();
			services.AddTransient<ICubicWeightService, CubicWeightService>();

			services.AddTransient<IAsyncDemo, CubicWeightDemo>();

			return services;
		}
	}
}

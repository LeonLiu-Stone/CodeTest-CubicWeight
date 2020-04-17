using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using CubicWeight.Business.Services;

namespace CubicWeight.Business {

	public class CubicWeightDemo : IAsyncDemo {

		private readonly ILogger _logger;
		private readonly ICubicWeightService _cubicWeightService;

		public CubicWeightDemo(ILogger<CubicWeightDemo> logger, ICubicWeightService cubicWeightService) {
			_logger = logger;
			_cubicWeightService = cubicWeightService;
		}

		public async Task Run() {

			//could get this category from command line when need!
			var category = "Air Conditioners";

			var aveCubicWeight = await _cubicWeightService.GetAverageCubicWeightByCategory(category);

			_logger.LogInformation("");
			_logger.LogInformation($"The average cubic weight of products is {aveCubicWeight}");
		}
	}
}

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using CubicWeight.Lib;
using CubicWeight.Business.Models;

namespace CubicWeight.Business.Services {

	public interface ICubicWeightService {
		float WeightCalculator(Product size);
		Task<float> GetAverageCubicWeightByCategory(string category);
	}

	public class CubicWeightService: ICubicWeightService {

		private readonly ILogger _logger;
		private readonly IExceptionFactory _exceptionFactory;
		private readonly IFetchService _fetchService;
		private readonly CubicWeightSettings _settings;

		public CubicWeightService(
			ILogger<CubicWeightService> logger,
			IExceptionFactory exceptionFactory,
			IFetchService fetchService,
			IOptions<CubicWeightSettings> settings) {
			_logger = logger;
			_exceptionFactory = exceptionFactory;
			_fetchService = fetchService;
			_settings = settings.Value;
		}

		public float WeightCalculator(Product product) {
			_logger.LogInformation($"Matched product: {product.Title}");
			return (product?.Size?.CubicMetres ?? 0) * _settings.ConversionFactor;
		}

		public async Task<float> GetAverageCubicWeightByCategory(string category) {
			var cubicWeights = await _fetchService.GetProductInfoByCategory<float>(WeightCalculator, category);

			if (!(cubicWeights?.Any() ?? false)) {
				_exceptionFactory.GenerateSafeException("No products found in the remote api!");
			}

			return cubicWeights.Average();
		}
	}
}

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using CubicWeight.Lib;
using CubicWeight.Business.Models;

namespace CubicWeight.Business.Services {

	/// <summary>
	/// fetch registration from data source
	/// </summary>
	public interface IFetchService {
		Task<ProductResponse> GetProducts(int index);
		Task<ProductResponse> GetProducts(string endpoint);
		Task<List<T>> GetProductInfoByCategory<T>(Func<Product, T> convertor, string category);
	}

	public class FetchService: IFetchService {

		private readonly ILogger _logger;
		private readonly IRestApiService _restApiService;
		private readonly CubicWeightSettings _settings;

		public FetchService(
			ILogger<FetchService> logger,
			IRestApiService restApiService,
			IOptions<CubicWeightSettings> settings) {
			_logger = logger;
			_restApiService = restApiService;
			_settings = settings.Value;
		}

		public async Task<ProductResponse> GetProducts(int index = 1) {

			index = index < 1 ? 1 : index;
			return await GetProducts($"{_settings.Endpoint}/{index}");
		}

		public async Task<ProductResponse> GetProducts(string endpoint) {

			try {
				_logger.LogInformation($"Fetching products from the endpoint: {endpoint}");
				var url = $"{_settings.ApiUrl}{endpoint}";
				var products = await _restApiService.GetRequestAsync<ProductResponse>(url);
				return products;
			}
			catch (Exception ex) {
				_logger.LogError("Failed to get product from api endpoint", ex);
				return new ProductResponse();
			}
		}

		public async Task<List<T>> GetProductInfoByCategory<T>(Func<Product, T> convertor, string category = "") {

			var infoList = new List<T>();
			var endpoint = $"{_settings.Endpoint}/1";

			while (!string.IsNullOrEmpty(endpoint)) {
				var productResponse = await GetProducts(endpoint);

				if (productResponse == null || productResponse.Objects == null) {
					break;
				}

				endpoint = productResponse.Next;

				var results = productResponse.Objects
					.Where(product => string.IsNullOrEmpty(category) || product.Category == category)
					.Select(product => convertor(product)).ToList();
				infoList.AddRange(results);
			}

			return infoList;
		}
	}
}

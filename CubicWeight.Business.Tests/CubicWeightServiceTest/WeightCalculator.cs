using System;
using Microsoft.Extensions.Options;

using Xunit;

using CubicWeight.Business.Models;
using CubicWeight.Business.Services;

namespace CubicWeight.Business.Tests.CubicWeightServiceTest {

	public class WeightCalculator {

		[Fact]
		public void WhenSizeIsNull_CanReturnZero() {

			//Arrange
			var emptyProduct = new Product();
			var settings = new CubicWeightSettings() {
				ConversionFactor = 250
			};

			var stubILogger = StubHelper.StubILogger<CubicWeightService>();
			var stubIExceptionFactory = StubHelper.StubIExceptionFactory;
			var stubIFetchService = StubHelper.StubIFetchService;

			var testedService = new CubicWeightService(stubILogger.Object,
				stubIExceptionFactory.Object,
				stubIFetchService.Object,
				Options.Create(settings));

			//Act
			var actual = testedService.WeightCalculator(emptyProduct);

			//Assert
			Assert.Equal(0, actual);
		}

		[Fact]
		public void WhenProductIsValid_CanReturnCubicWeight() {

			//Arrange
			var product = FakeModels.TestProduct;
			var settings = new CubicWeightSettings() {
				ConversionFactor = 1
			};

			var stubILogger = StubHelper.StubILogger<CubicWeightService>();
			var stubIExceptionFactory = StubHelper.StubIExceptionFactory;
			var stubIFetchService = StubHelper.StubIFetchService;

			var testedService = new CubicWeightService(stubILogger.Object,
				stubIExceptionFactory.Object,
				stubIFetchService.Object,
				Options.Create(settings));

			//Act
			var actual = testedService.WeightCalculator(product);

			//Assert
			var weight = product.Size.CubicMetres * settings.ConversionFactor;
			Assert.Equal(weight, actual);
		}
	}
}

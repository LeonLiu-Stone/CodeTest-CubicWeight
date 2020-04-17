using System;

namespace CubicWeight.Business.Models {

	public class CubicWeightSettings {

		public string ApiUrl { get; set; }

		public string Endpoint { get; set; }

		public int ConversionFactor { get; set; } = 0;
	}
}

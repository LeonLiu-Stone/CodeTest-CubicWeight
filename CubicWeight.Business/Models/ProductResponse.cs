using System;
using System.Collections.Generic;

namespace CubicWeight.Business.Models {

	public class ProductResponse {

		public List<Product> Objects { get; set; } = new List<Product>();

		public string Next { get; set; } = string.Empty;
	}
}

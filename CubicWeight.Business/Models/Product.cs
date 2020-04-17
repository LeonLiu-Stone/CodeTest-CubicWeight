using System;

namespace CubicWeight.Business.Models {

	public class Product {

		public Product() {
		}

		public Product(string category, string title, float weight, ProductSize size) {
			Category = category;
			Title = title;
			Weight = weight;
			Size = size;
		}

		//set string for now, but maybe an enum
		public string Category { get; set; } = string.Empty;

		public string Title { get; set; } = string.Empty;

		public float? Weight { get; set; } = 0;

		public ProductSize Size { get; set; }
	}
}

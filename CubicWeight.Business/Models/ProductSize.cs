using System;

namespace CubicWeight.Business.Models {

	public class ProductSize {

		public ProductSize() {
		}

		public ProductSize(float width, float length, float height) {
			Width = width;
			Length = length;
			Height = height;
		}

		public float? Width { get; set; } = 0;

		public float? Length { get; set; } = 0;

		public float? Height { get; set; } = 0;

		public float CubicMetres => Width.HasValue && Length.HasValue && Height.HasValue ?
			Width.Value * Length.Value * Height.Value / (100 * 100 * 100) : 0;
	}
}

using System;

using CubicWeight.Business.Models;

namespace CubicWeight.Business.Tests {

	public static class FakeModels {

		public static ProductSize TestProductSize = new ProductSize(15, 13, 1);

		public static Product TestProduct = new Product("Gadgets", "10 Pack Family Car Sticker Decals", 120, TestProductSize);
	}
}

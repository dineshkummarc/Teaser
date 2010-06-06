using System;
using System.Collections.Generic;
using System.Linq;
using Fragile.Core.Services;
using Stable.Core.Domain;

namespace Stable.Core.Services.Impl
{
	public class SecondProductRepository : IProductRepository
	{
		private static readonly IList<Product> _products = new List<Product>();
		private static readonly IList<Manufacturer> _manufacturers = new List<Manufacturer>();

        static SecondProductRepository()
		{
			Reset();
		}

		public static void Reset()
		{
			_products.Clear();
			_manufacturers.Clear();

			var insignia = new Manufacturer
			               {
			               	Id = 1,
			               	Name = "Insignia"
			               };
			var dynex = new Manufacturer
			            {
			            	Id = 2,
			            	Name = "Dynex"
			            };

			_manufacturers.Add(insignia);
			_products.Add(new Product
			              {
			              	Id = 1,
			              	Name = "Insignia® - 26\" Class / 720p / 60Hz / LCD HDTV DVD Combo",
			              	Model = "NS-LDVD26Q-10A",
			              	Sku = "9154764",
			              	Price = 151.11m,
			              	Manufacturer = insignia
			              });
			_products.Add(new Product
			              {
			              	Id = 2,
			              	Name = "Insignia® - 19\" Class / 720p / 60Hz / LCD HDTV",
			              	Model = "NS-L19Q-10A",
			              	Sku = "9182715",
			              	Price = 119.11m,
			              	Manufacturer = insignia
			              });
			_products.Add(new Product
			              {
			              	Id = 3,
			              	Name = "Dynex® - 15\" Class / 720p / 60Hz / LCD HDTV",
			              	Model = "DX-L15-10A",
			              	Sku = "9135376",
			              	Price = 119.11m,
			              	Manufacturer = dynex
			              });
		}

		public IEnumerable<Product> FindAll()
		{
			return _products;
		}

		public Product GetById(int id)
		{
			return _products.First(p => p.Id == id);
		}

		public void Save(Product product)
		{
			// No-op
		}
	}
}
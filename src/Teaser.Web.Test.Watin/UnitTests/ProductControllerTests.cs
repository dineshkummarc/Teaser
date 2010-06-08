using System.Collections.Generic; 
using MbUnit.Framework;
using NBehave.Spec.MbUnit;
using Rhino.Mocks;
using Teaser.Web.Controllers;
using Teaser.Entities;
using Teaser.Web.Models;
using Teaser.DataAccess.Interfaces;
using Teaser.Web.UITests;
using System.Web.Mvc;


namespace Teaser.WebUITests.UnitTests
{
	[TestFixture]
	public class ProductControllerTests : TestBase
	{
		[Test]
		public void Should_add_the_product_list_to_view_data()
		{
			var products = new List<Product> {new Product {Name = "Wii"}};

			var repository = Fake<IProductRepository>();
			repository.Stub(rep => rep.FindAll()).Return(products);
            //stub out rep.FindAll() to return our products
			var controller = new ProductController(repository);

			var result = controller.Index();

            //result.ViewName.ShouldEqual(string.Empty);
            result.ViewData.Model.ShouldEqual(products); 
		}
	}
}
using System;
using System.Linq.Expressions;
using System.Threading;
using MbUnit.Framework;
using NBehave.Spec.MbUnit;
using Teaser.Web.Models;
using WatiN.Core;
using Teaser.Web.Models;
using Teaser.Web.UITests;
using Teaser.Web.Core;

namespace Teaser.Web.Test.Watin.UITests
{
	[TestFixture]
	public class ProductEditTester : WebTestBase
	{
		[Test]
		public void Should_update_product_price_successfully()
		{
            NavigateLink(StableSite.Nav.Products);
			
			Browser.Link(Find.ByText("Edit")).Click();

			ForForm<ProductForm>()
				.WithTextBox(form => form.Price, 389.99m)
				.Save();

			CurrentPageShouldBe(StableSite.Screen.Product.Index);

			ForPage<ProductListModel[]>()
				.FindText(products => products[0].Price, "389.99");
		}

		private FluentTable<TForm> ForPage<TForm>()
		{
			return new FluentTable<TForm>(Browser);
		}
	}

	internal class FluentTable<TForm>
	{
		private readonly IE _browser;

		public FluentTable(IE browser)
		{
			_browser = browser;
		}

		public void FindText<TField>(
			Expression<Func<TForm, TField>> func,
			string expected)
		{
			var spanId = UINameHelper.BuildIdFrom(func);

			var span = _browser.Span(Find.ById(spanId));

			span.Text.ShouldEqual(expected);
		}
	}
}
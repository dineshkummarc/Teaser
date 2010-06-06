using AutoMapper;
using MbUnit.Framework;
using Teaser.Web.Core;

namespace Teaser.WebUITests.UnitTests
{
	[TestFixture]
	public class AutoMapperConfigurationTester
	{
		[Test]
		public void Should_map_dtos_successfully()
		{
			AutoMapperConfiguration.Configure();
			Mapper.AssertConfigurationIsValid();
		}
	}
}
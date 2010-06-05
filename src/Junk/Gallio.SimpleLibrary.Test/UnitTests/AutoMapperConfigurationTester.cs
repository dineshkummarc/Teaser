using AutoMapper;
using MbUnit.Framework;
using Stable.Core.UiCore;

namespace Stable.UITests.UnitTests
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
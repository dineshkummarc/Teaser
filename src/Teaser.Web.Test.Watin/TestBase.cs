using Rhino.Mocks;

namespace Teaser.Web.UITests
{
	public class TestBase
	{
		protected TFake Fake<TFake>() where TFake : class
		{
			return MockRepository.GenerateStub<TFake>();
		}
	}
}
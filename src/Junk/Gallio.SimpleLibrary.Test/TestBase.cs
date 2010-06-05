using Rhino.Mocks;

namespace Stable.UITests
{
	public class TestBase
	{
		protected TFake Fake<TFake>() where TFake : class
		{
			return MockRepository.GenerateStub<TFake>();
		}
	}
}
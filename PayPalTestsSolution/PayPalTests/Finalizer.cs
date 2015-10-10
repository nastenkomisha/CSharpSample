using NUnit.Framework;

namespace PayPalTests
{
    [SetUpFixture]
    public class Finalizer
    {
        [TearDown]
	    public void RunInTheEndOfAll()
	    {
            WebDriverFactory.DismissAll();
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium.Remote;
using PayPalTests.Helpers;

namespace PayPalTests
{
    [TestFixture()]
    public class TestBase
    {
        protected ApplicationManager ApplicationManager;

        [SetUp]
        public void StartApplication()
        {
            string baseUrl = "http://paypal.com";

            System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", "@chromedriver.exe");
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName,"chrome");

            ApplicationManager = new ApplicationManager(capabilities, baseUrl);
        }
    }   
}

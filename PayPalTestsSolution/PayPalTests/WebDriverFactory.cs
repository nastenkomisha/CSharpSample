using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace PayPalTests
{
    public class WebDriverFactory
    {
        private static WebDriverFactory _instance;

        public static IWebDriver GetDriver(ICapabilities capabilities)
        {
            return FactoryInstance.__GetDriver(capabilities);
        }

        public static void DismissDriver(IWebDriver driver)
        {
            FactoryInstance.__DismissDriver(driver);
        }

        public static void DismissAll()
        {
            FactoryInstance.__DismissAll();
        }

        private static WebDriverFactory FactoryInstance => _instance ?? (_instance = new WebDriverFactory());

        // --------------------------------------------------

        private static ThreadLocal<IWebDriver> threadLocalDriver = new ThreadLocal<IWebDriver>();
        private Dictionary<IWebDriver, string> driverToKeyMap = new Dictionary<IWebDriver, string>();

        private IWebDriver __GetDriver(ICapabilities capabilities)
        {
            string newKey = CreateKey(capabilities);

            if (!threadLocalDriver.IsValueCreated)
            {
                CreateNewDriver(capabilities);
            }
            else
            {
                IWebDriver currentDriver = threadLocalDriver.Value;
                string currentKey;
                if (!driverToKeyMap.TryGetValue(currentDriver, out currentKey))
                {
                    // The driver was dismissed
                    CreateNewDriver(capabilities);
                }
                else
                {
                    if (newKey != currentKey)
                    {
                        // A different flavour of WebDriver is required
                        __DismissDriver(currentDriver);
                        CreateNewDriver(capabilities);
                    }
                    else
                    {
                        // Check the browser is alive
                        try
                        {
                            string currentUrl = currentDriver.Url;
                        }
                        catch (WebDriverException)
                        {
                            CreateNewDriver(capabilities);
                        }
                    }
                }
            }
            return threadLocalDriver.Value;
        }

        private void __DismissDriver(IWebDriver driver)
        {
            if (!driverToKeyMap.ContainsKey(driver))
            {
                throw new Exception("The driver is not owned by the factory: " + driver);
            }
            if (driver != threadLocalDriver.Value)
            {
                throw new Exception("The driver does not belong to the current thread: " + driver);
            }
            driver.Quit();
            driverToKeyMap.Remove(driver);
            threadLocalDriver.Dispose();
        }

        private void __DismissAll()
        {
            foreach (IWebDriver driver in new List<IWebDriver>(driverToKeyMap.Keys))
            {
                driver.Quit();
                driverToKeyMap.Remove(driver);
            }
        }

        private static string CreateKey(ICapabilities capabilities)
        {
            return capabilities.ToString();
        }

        private void CreateNewDriver(ICapabilities capabilities)
        {
            string newKey = CreateKey(capabilities);
            IWebDriver driver = CreateLocalDriver(capabilities);
            driverToKeyMap.Add(driver, newKey);
            threadLocalDriver.Value = driver;
        }

        private static IWebDriver CreateLocalDriver(ICapabilities capabilities)
        {
            string browserType = capabilities.BrowserName;
            if (browserType == DesiredCapabilities.Firefox().BrowserName)
            {
                return new FirefoxDriver();
            }
            if (browserType == DesiredCapabilities.InternetExplorer().BrowserName)
            {
                return new InternetExplorerDriver();
            }
            if (browserType == DesiredCapabilities.Chrome().BrowserName)
            {
                return new ChromeDriver();
            }
            throw new Exception("Unrecognized browser type: " + browserType);
        }
    }
}

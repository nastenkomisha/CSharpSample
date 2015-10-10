using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PayPalTests.Pages
{
    public class PageManager
    {
        private readonly IWebDriver _driver;

        public PageManager(ICapabilities capabilities, string baseUrl)
        {
            _driver = WebDriverFactory.GetDriver(capabilities);
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(baseUrl);

            LoginPage = InitElements(new LoginPage(this));
            WelcomePage = InitElements(new WelcomePage(this));
            UserProfilePage = InitElements(new UserProfilePage(this));
            EditAddressPage = InitElements(new EditAddressPage(this));
            ChangePhonePage = InitElements(new ChangePhonePage(this));
            ActivityPage = InitElements(new ActivityPage(this));
        }

        private T InitElements<T>(T page) where T : Page
        {
            PageFactory.InitElements(_driver, page);
            return page;
        }

        public void AcceptApert()
        {
            _driver.SwitchTo().Alert().Accept();
        }

        public WelcomePage WelcomePage { get; set; }

        public LoginPage LoginPage { get; set; }

        public UserProfilePage UserProfilePage { get; set; }

        public EditAddressPage EditAddressPage { get; set; }

        public ChangePhonePage ChangePhonePage { get; set; }

        public ActivityPage ActivityPage { get; set; }

    }
}

using OpenQA.Selenium;
using PayPalTests.Pages;

namespace PayPalTests.Helpers
{
    public class ApplicationManager
    {
        public ApplicationManager(ICapabilities capabilities, string baseUrl)
        {
            Pages = new PageManager(capabilities, baseUrl);
            LoginHelper = new LoginHelper(this);
            UserProfileHelper = new UserProfileHelper(this);
        }

        public LoginHelper LoginHelper { get; set; }

        public UserProfileHelper UserProfileHelper { get; set; }

        public PageManager Pages { get; set; }
    }
}
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PayPalTests.Pages
{
    public class WelcomePage : Page
    {
        public WelcomePage(PageManager pageManager)
            : base(pageManager)
        {
        }

        [FindsBy(How = How.CssSelector, Using = "li.vx_globalNav-listItem_logout")]
        public IWebElement LogoutButton;

        [FindsBy(How = How.CssSelector, Using = "a.vx_globalNav-link_settings")]
        public IWebElement ProfileSettingsButton;

        public bool IsOnThisPage()
        {
            return IsElementDisplayed(LogoutButton);
        }
    }
}

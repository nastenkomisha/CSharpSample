using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PayPalTests.Pages
{
    public class UserProfilePage : Page
    {
        public UserProfilePage(PageManager pageManager)
            : base(pageManager)
        {
        }

        [FindsBy(How = How.CssSelector, Using = "li.logout")]
        public IWebElement LogoutButton;

        [FindsBy(How = How.CssSelector, Using = "div.nameWrapper")]
        public IWebElement Name;

        [FindsBy(How = How.CssSelector, Using = "a[class='edit fill-click']")]
        public IWebElement EditAddressLink;

        [FindsBy(How = How.CssSelector, Using = "ul#js_phones-list a[class*='edit']")]
        public IWebElement ChangePhoneLink;

        [FindsBy(How = How.CssSelector, Using = "a#accountLink")]
        public IWebElement AccountButton;

        [FindsBy(How = How.CssSelector, Using = "a[class*='nemo_globalNavActivityLink'")]
        public IWebElement ActivityTab;

        public bool IsOnThisPage()
        {
            return IsElementDisplayed(Name);
        }
    }
}


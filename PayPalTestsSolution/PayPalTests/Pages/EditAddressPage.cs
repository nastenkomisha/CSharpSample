using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PayPalTests.Pages
{
    public class  EditAddressPage : Page
    {
        public EditAddressPage(PageManager pageManager) : base(pageManager)
        {
        }

        [FindsBy(How = How.CssSelector, Using = "input#street2")]
        public IWebElement MoreAddressInformation;

        [FindsBy(How = How.CssSelector, Using = "input#street1")]
        public IWebElement Street;

        [FindsBy(How = How.CssSelector, Using = "input#city")]
        public IWebElement City;

        [FindsBy(How = How.CssSelector, Using = "input[class*='changeAddress']")]
        public IWebElement ChangeAddressButton;

        public bool IsOnThisPage()
        {
            return IsElementDisplayed(ChangeAddressButton);
        }
    }
}

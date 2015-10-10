using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PayPalTests.Pages
{
    public class LoginPage : Page
    {
        public LoginPage(PageManager pageManager)
            : base(pageManager)
        {
        }

        [FindsBy(How = How.CssSelector, Using = "#email")]
        public IWebElement EmailField;

        [FindsBy(How = How.CssSelector, Using = "a#ul-btn")]
        public IWebElement LoginButton;

        [FindsBy(How = How.CssSelector, Using = "#password")]
        public IWebElement PasswordField;

        [FindsBy(How = How.CssSelector, Using = "#btnLogin")]
        public IWebElement SubmitButton;

        public bool IsOnThisPage()
        {
            return IsElementDisplayed(SubmitButton);
        }
    }
}

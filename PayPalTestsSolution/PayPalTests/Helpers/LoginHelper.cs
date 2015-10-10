using PayPalTests.Model;
using PayPalTests.Pages;

namespace PayPalTests.Helpers
{
    public class LoginHelper
    {
        private PageManager _pages;

        public LoginHelper(ApplicationManager manager)
        {
            _pages = manager.Pages;
        }

        public void Login(AccountData account)
        {
            _pages.LoginPage.LoginButton.Click();
            _pages.LoginPage.EmailField.SendKeys(account.Username);
            _pages.LoginPage.PasswordField.SendKeys(account.Password);
            _pages.LoginPage.SubmitButton.Click();
        }

        public bool IsLoggedIn()
        {
            return _pages.WelcomePage.IsOnThisPage();
        }
    }
}

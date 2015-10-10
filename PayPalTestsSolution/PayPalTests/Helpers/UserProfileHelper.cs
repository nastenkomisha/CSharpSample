using System;
using PayPalTests.Pages;

namespace PayPalTests.Helpers
{
    public class UserProfileHelper
    {
        private readonly PageManager _pages;

        public UserProfileHelper(ApplicationManager manager)
        {
            _pages = manager.Pages;
        }

        public void OpenUserProfile()
        {
            _pages.WelcomePage.ProfileSettingsButton.Click();
        }

        public void ChangeAddress()
        {
            _pages.UserProfilePage.EditAddressLink.Click();
            _pages.EditAddressPage.MoreAddressInformation.Clear();
            _pages.EditAddressPage.MoreAddressInformation.SendKeys(Guid.NewGuid().ToString());
            WaitUntil(TimeSpan.FromSeconds(10), () =>
            {
                _pages.EditAddressPage.ChangeAddressButton.Click();
                _pages.UserProfilePage.AccountButton.Click();
            });
        }

        public void ChangePhone()
        {
            WaitUntil(TimeSpan.FromSeconds(10), () =>
            {
                _pages.UserProfilePage.ChangePhoneLink.Click();
                _pages.ChangePhonePage.PhoneType.Click();
            });
            _pages.ChangePhonePage.WorkOption.Click();
            _pages.ChangePhonePage.PhoneNumber.Clear();
            _pages.ChangePhonePage.PhoneNumber.SendKeys(RandomPhone());
            _pages.ChangePhonePage.ChangeNumberButton.Click();
        }

        public void GetListOfOperations()
        {
            WaitUntil(TimeSpan.FromSeconds(10), () =>
            {
                _pages.UserProfilePage.ActivityTab.Click();
                _pages.ActivityPage.DateDropDown.Click();
            });
            _pages.ActivityPage.StartDate.Click();
            _pages.ActivityPage.StartDate.Clear();
            _pages.ActivityPage.StartDate.SendKeys("01/01/15");
            _pages.ActivityPage.EndDate.Click();
            _pages.ActivityPage.EndDate.Clear();
            _pages.ActivityPage.EndDate.SendKeys("01/15/55");
            _pages.ActivityPage.SaveDatesButton.Click();
            _pages.ActivityPage.ViewButton.Click();
        }

        public bool IsOnUserProfilePage()
        {
            return _pages.UserProfilePage.IsOnThisPage();
        }

        private void WaitUntil(TimeSpan timeout, Action action)
        {
            WaitUntil(timeout, action, exception => { throw exception; });
        }

        private void WaitUntil(TimeSpan timeout, Action action, Action<Exception> actionOnException)
        {
            var repere = DateTime.Now;
            Exception exc = null;
            while (DateTime.Now - repere < timeout)
            {
                try
                {
                    action.Invoke();
                    return;
                }
                catch (Exception e)
                {
                    exc = e;
                }
            }
            actionOnException(exc);
        }

        private string RandomPhone()
        {
            var random = new Random();
            string s = String.Empty;
            for (int i = 0; i < 10; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }
    }
}

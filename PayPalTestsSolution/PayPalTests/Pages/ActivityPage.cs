using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PayPalTests.Pages
{
    public class ActivityPage : Page
    {
        public ActivityPage(PageManager pageManager)
            : base(pageManager)
        {
        }

        [FindsBy(How = How.CssSelector, Using = "div[class*='dateDropdown'")]
        public IWebElement DateDropDown;

        [FindsBy(How = How.CssSelector, Using = "input#startDate")]
        public IWebElement StartDate;

        [FindsBy(How = How.CssSelector, Using = "input#endDate")]
        public IWebElement EndDate;

        [FindsBy(How = How.Name, Using = "saveDates")]
        public IWebElement SaveDatesButton;

        [FindsBy(How = How.Name, Using = "filterSubmit")]
        public IWebElement ViewButton;

        public bool IsOnThisPage()
        {
            return IsElementDisplayed(DateDropDown);
        }
    }
}

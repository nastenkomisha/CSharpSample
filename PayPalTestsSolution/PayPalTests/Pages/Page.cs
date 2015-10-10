using OpenQA.Selenium;

namespace PayPalTests.Pages
{
    public class Page
    {
        private PageManager _pageManager;

        protected Page(PageManager pageManager)
        {
            _pageManager = pageManager;
        }
        protected bool IsElementDisplayed(IWebElement webElement)
        {
            return webElement.Displayed;
        }
    }
}

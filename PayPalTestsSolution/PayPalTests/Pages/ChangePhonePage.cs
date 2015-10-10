using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PayPalTests.Pages
{
    public class  ChangePhonePage : Page
    {
        public ChangePhonePage(PageManager pageManager) : base(pageManager)
        {
        }

        [FindsBy(How = How.Name, Using = "type")]
        public IWebElement PhoneType;

        [FindsBy(How = How.Name, Using = "phoneNumber")]
        public IWebElement PhoneNumber;

        [FindsBy(How = How.CssSelector, Using = "input[class*='changePhone']")]  
        public IWebElement ChangeNumberButton;

        [FindsBy(How = How.CssSelector, Using = "option[value='WORK']")]  
        public IWebElement WorkOption;
        
        public bool IsOnThisPage()
        {
            return IsElementDisplayed(ChangeNumberButton);
        }
    }
}

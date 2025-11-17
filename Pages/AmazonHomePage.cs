using AmazonAutomation.Tests.Data;
using AmazonAutomation.Tests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace AmazonAutomation.Tests.Pages
{
    public class AmazonHomePage : BasePage
    {
        public AmazonHomePage(IWebDriver driver) : base(driver) { }

        
        private IWebElement SearchBox => Driver.FindElement(By.Id("//input[@id='twotabsearchtextbox']"));
        private IWebElement SearchButton => Driver.FindElement(By.Id("nav-search-submit-button"));

        public void GoTo(string url)
        {
            Driver.Url = url;
            Thread.Sleep(2000);
            Driver.Navigate().Refresh();
            
        }

        public void Search(string text)
        {
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(ExpectedConditions.ElementToBeClickable(SearchBox));
            SearchBox.Clear();
            SearchBox.SendKeys(text);
            SearchButton.Click();
        }
    }
}

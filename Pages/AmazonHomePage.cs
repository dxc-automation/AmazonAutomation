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

        
        private By SearchBox => By.Id("twotabsearchtextbox");
        private By SearchButton => By.Id("nav-search-submit-button");
        private By ContinueShoppingButton => By.XPath("//button[normalize-space()='Continue shopping']");

        public void GoTo(string url)
        {
            Driver.Url = url;
            WaitForClickable(ContinueShoppingButton);
            Click(ContinueShoppingButton);
            Thread.Sleep(2000);
            Driver.Navigate().Refresh();
            
        }

        public void Search(string text)
        {
            WaitForClickable(SearchBox);
            Type(SearchBox, text);
            Click(SearchButton);
        }
    }
}

using AmazonAutomation.Tests.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace AmazonAutomation.Tests.Pages
{
    public class BasePage
    {
        protected IWebDriver    Driver;
        public    WebDriverWait Wait;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected string GetText(By locator)
        {
            IWebElement element = Driver.FindElement(locator);
            return element.Text;
        }

        protected IWebElement WaitForElement(By locator)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }


        protected IWebElement WaitForClickable(By locator)
        {
            return Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }


        protected void Click(By locator)
        {
            WaitForClickable(locator).Click();
        }


        protected void Type(By locator, string text)
        {
            var element = WaitForElement(locator);
            element.Clear();
            element.SendKeys(text);
        }


        protected bool IsElementVisible(By locator)
        {
            try
            {
                return WaitForElement(locator).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }


        protected void ScrollTo(By locator)
        {
            var element = WaitForElement(locator);
            var js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }


        protected void JsClick(By locator)
        {
            var element = WaitForClickable(locator);
            var js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].click();", element);
        }
    }
}
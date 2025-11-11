using AmazonAutomation.Tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonAutomation.Tests.Utils
{
    public class CommonMethods : BasePage
    {
        public CommonMethods(IWebDriver driver) : base(driver) {}

        public void WaitUntilElementIsClickable(IWebDriver driver, IWebElement element, int seconds)
        {
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            Wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
    }
}

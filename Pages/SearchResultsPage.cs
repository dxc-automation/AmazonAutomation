using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AmazonAutomation.Tests.Pages
{
    public class SearchResultsPage : BasePage
    {
        public SearchResultsPage(IWebDriver driver) : base(driver) { }

        // Result titles
        private ReadOnlyCollection<IWebElement> ResultTitles => Driver.FindElements(By.XPath("//h2//span"));

        public void ClickFirstExactMatch(string exactTitle)
        {
  
            WaitForClickable(By.XPath("//h2//span"));
            List<string> resultTitles = new List<string>();

            foreach (IWebElement el in ResultTitles)
            {
                string title = el.Text;
                if (title == exactTitle)
                {
                    el.Click();
                    break;
                }
            }
        }
    }
}
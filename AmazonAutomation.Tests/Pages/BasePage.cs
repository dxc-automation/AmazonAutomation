using AmazonAutomation.Tests.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AmazonAutomation.Tests.Pages
{
    public class BasePage
    {
        protected IWebDriver    Driver;
        public    WebDriverWait Wait;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}

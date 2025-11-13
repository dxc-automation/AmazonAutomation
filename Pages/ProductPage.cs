using AmazonAutomation.Tests.Data;
using AmazonAutomation.Tests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;
using System.Threading;

namespace AmazonAutomation.Tests.Pages
{
    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        private IWebElement TitleText => Driver.FindElement(By.Id("productTitle"));
        private IWebElement AddToCartButton => Driver.FindElement(By.Id("add-to-cart-button"));
        private IWebElement HardcoverPriceText => Driver.FindElement(By.XPath("(//span[@class='slot-price'])[3]"));


        public void OpenProductPage(String url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void ChooseHardcoverIfAvailable()
        {
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(ExpectedConditions.ElementToBeClickable(HardcoverPriceText));
            HardcoverPriceText.Click();
        }

        public string GetTitle()
        {
           return TitleText.Text.Trim();
        }

        public void AddToCart()
        { 
            AddToCartButton.Click();
        }
    }
}

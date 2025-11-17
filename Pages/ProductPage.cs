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

        private By TitleText => By.Id("productTitle");
        private By AddToCartButton => By.Id("add-to-cart-button");
        private By HardcoverPriceText => By.XPath("(//span[@class='slot-price'])[3]");


        public void OpenProductPage(String url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void ChooseHardcoverIfAvailable()
        {
            WaitForClickable(HardcoverPriceText);
            Click(HardcoverPriceText);
        }

        public string GetTitle()
        {
           return GetText(TitleText).Trim();
        }

        public void AddToCart()
        { 
            Click(AddToCartButton);
        }
    }
}

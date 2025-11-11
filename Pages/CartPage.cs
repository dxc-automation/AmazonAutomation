using OpenQA.Selenium;
using System;

namespace AmazonAutomation.Tests.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        private IWebElement CartItems => Driver.FindElement(By.Id("sc-active-cart"));

        public bool VerifyProductInCart(string expectedTitle)
        {
            try
            {
                // Try searching cart for item titles
                var titles = Driver.FindElements(By.XPath("//span[@class='a-truncate-cut' or @class='sc-product-title' or contains(@class,'sc-product-title')] | //span[@class='a-list-item']//a/span"));
                foreach (var t in titles)
                {
                    if (t.Text?.IndexOf(expectedTitle, StringComparison.OrdinalIgnoreCase) >= 0)
                        return true;
                }
            }
            catch { }
            return false;
        }
    }
}

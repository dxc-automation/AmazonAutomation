using OpenQA.Selenium;
using System;

namespace AmazonAutomation.Tests.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        private By CartItems => By.Id("sc-active-cart");
        private By Titles => By.XPath("//span[@class='a-truncate-cut' or @class='sc-product-title' or contains(@class,'sc-product-title')] | //span[@class='a-list-item']//a/span");

        public bool VerifyProductInCart(string expectedTitle)
        {
            try
            {
                // Try searching cart for item titles
                var titles = Driver.FindElements(Titles);
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

using AmazonAutomation.Tests.Config;
using AmazonAutomation.Tests.Data;
using AmazonAutomation.Tests.Pages;
using AmazonAutomation.Tests.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading;

namespace AmazonAutomation.Tests
{
    [TestFixture]
    public class AddBookToCartTest : BaseTest
    {

        [Test]
        public void AddFinalEmpire_Hardcover_ToCart()
        {
            Constants.ReadTestData();

            string file    = Path.Combine(Environment.CurrentDirectory, "appsettings.json");

            Reporter.CreateNewTestReport("Add Product To Cart");
            Constants.TestDetails = "<center><b>* * * * * * * *    Add Product To Cart    * * * * * * * *</b></center><br><br>"
                + "<a href='" + file + "'>Test Data</a><br><br>"
                + "<b>Test Case</b><br>"
                + "1. Open https://www.amazon.com<br>"
                + "2. Search for “" + Constants.ProductTile + "”<br>"
                + "3. Select the first product with the exact name of the search<br>"
                + "4. Choose Hardcover<br>"
                + "5. Add the selected product to the cart<br>"
                + "6. Verify that the product was successfully added<br><br>";
      

            var home = new AmazonHomePage(Driver);
            home.GoTo(Constants.BaseUrl);
            home.Search(Constants.ProductTile);

            var results = new SearchResultsPage(Driver);
            results.ClickFirstExactMatch(Constants.ProductTile);

            // switch to new tab if opened
            if (Driver.WindowHandles.Count > 1)
            {
                Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            }

            var products = new ProductPage(Driver);
            products.ChooseHardcoverIfAvailable();
            products.AddToCart();
            products.OpenProductPage(Constants.BaseUrl + "/gp/cart/view.html?ref_=nav_cart");

            var cart = new CartPage(Driver);
            var found = cart.VerifyProductInCart("The Final Empire");
            Assert.IsTrue(found, "Product not found in cart.");
        }
    }
}

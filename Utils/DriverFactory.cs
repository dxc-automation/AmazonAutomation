using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace AmazonAutomation.Tests.Utils
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var browser = ConfigReader.GetString("Browser", "chrome").ToLower();
            if (browser == "chrome")
            {
                var options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                //options.AddArgument("--headless=new");
                options.AddArgument("--incognito");
                return new ChromeDriver(options);
            }
            throw new ArgumentException($"Browser not supported: {browser}");
        }
    }
}

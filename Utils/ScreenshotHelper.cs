using OpenQA.Selenium;
using System;
using System.IO;

namespace AmazonAutomation.Tests.Utils
{
    public static class ScreenshotHelper
    {
        public static string TakeScreenshot(IWebDriver driver, string name)
        {
            try
            {
                var folder = Path.Combine(Directory.GetCurrentDirectory(), ConfigReader.GetString("ScreenshotFolder", "Screenshots"));
                Directory.CreateDirectory(folder);
                var fileName = $"{DateTime.Now:yyyyMMdd_HHmmss}_{name}.png";
                var path = Path.Combine(folder, fileName);
                var ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(path, ScreenshotImageFormat.Png);
                return path;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

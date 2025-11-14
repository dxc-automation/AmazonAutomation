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
                string date = DateTime.Now.ToString("HH_mm_ss");
                var fileName = name + "_" + date + ".png";
                var path = Path.Combine(folder, fileName);
                var ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(path, ScreenshotImageFormat.Png);
                Console.WriteLine(path);
                return path;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}

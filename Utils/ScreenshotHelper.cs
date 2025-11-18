using OpenQA.Selenium;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Xml.Linq;


namespace AmazonAutomation.Tests.Utils
{
    public static class ScreenshotHelper
    {
        private static string date = DateTime.Now.ToString("HH_mm_ss");

        public static string TakeScreenshot(IWebDriver driver, string name)
        {
            try
            {
                var folder = Path.Combine(Directory.GetCurrentDirectory(), ConfigReader.GetString("ScreenshotFolder", "Screenshots"));
                Directory.CreateDirectory(folder);
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

        public static string Capture(IWebDriver driver, string screenShotName)
        {
            var fileName = screenShotName + "_" + date + ".png";
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports\\Screenshots\\" + fileName;
            string localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return localpath;
        }


        public static string ScreenCaptureAsBase64String(IWebDriver driver)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            return screenshot.AsBase64EncodedString;
        }
    }
}

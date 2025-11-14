using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using System;
using System.IO;

namespace AmazonAutomation.Tests.Utils
{
    public class Reporting
    {
        private static ExtentReports _extent;
        private static ExtentSparkReporter _htmlReporter;
        private static string _reportPath;
        public  static ExtentTest _test;

        public static Reporting CreateReporter()
        {
            if (_extent == null)
            {
                string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports\\Report.html";
                string localpath = new Uri(finalpth).LocalPath;

                _htmlReporter = new ExtentSparkReporter(localpath);
                _extent = new ExtentReports();
                _extent.AttachReporter(_htmlReporter);
            }
            return new Reporting();
        }

        public void CreateNewTestReport(string title)
        {
            _test = _extent.CreateTest(title);
        }

        public void AddTestScreenshot(string testName, string screenshotPath, string message)
        {
            if (!string.IsNullOrEmpty(screenshotPath) && File.Exists(screenshotPath))
            {
                _test.AddScreenCaptureFromPath(screenshotPath);
            }
        }

        public void Flush()
        {
            _extent?.Flush();
        }
    }
}

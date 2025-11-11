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
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "Reports");
                Directory.CreateDirectory(folder);
                _reportPath = Path.Combine(folder, $"Report.html");
                _htmlReporter = new ExtentSparkReporter(_reportPath);
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

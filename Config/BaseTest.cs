using NUnit.Framework;
using OpenQA.Selenium;
using System;
using AmazonAutomation.Tests.Utils;
using OpenQA.Selenium.Support.UI;
using AmazonAutomation.Tests.Data;
using static AmazonAutomation.Tests.Utils.Reporting;
using AventStack.ExtentReports;

namespace AmazonAutomation.Tests.Config
{
    [SetUpFixture]
    public class BaseTest
    {
        protected IWebDriver Driver;
        protected Reporting Reporter;
        protected Constants Constants = new Constants();


        [SetUp]
        public void Setup()
        {
            Driver = DriverFactory.CreateDriver();
            Reporter = Reporting.CreateReporter();
            Driver.Manage().Window.Maximize();
        }
    

        [TearDown]
        public void Results()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;
            var path    = ScreenshotHelper.ScreenCaptureAsBase64String(Driver);
            var message = TestContext.CurrentContext.Result.Message;

            switch (outcome)
            {
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    _test.Fail("<pre>" + Constants.TestDetails + message + "</pre>");
                    _test.AddScreenCaptureFromBase64String(path);
                    break;

                case NUnit.Framework.Interfaces.TestStatus.Passed:
                    _test.Pass("<pre>" + Constants.TestDetails + "</pre>");
                    _test.AddScreenCaptureFromBase64String(path);
                    break;
            }    
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Reporter.Flush();
            Driver.Quit();
        }
    }
}

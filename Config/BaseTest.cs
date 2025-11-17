using NUnit.Framework;
using OpenQA.Selenium;
using System;
using AmazonAutomation.Tests.Utils;
using OpenQA.Selenium.Support.UI;
using AmazonAutomation.Tests.Data;
using static AmazonAutomation.Tests.Utils.Reporting;

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
            var path    = ScreenshotHelper.Capture(Driver, TestContext.CurrentContext.Test.Name);
            var message = TestContext.CurrentContext.Result.Message;

            switch (outcome)
            {
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    _test.Fail("<pre>" + Constants.TestDetails + message + "</pre>");
                    Reporter.AddTestScreenshot(Constants.TestName, path, Constants.TestDetails);
                    break;

                case NUnit.Framework.Interfaces.TestStatus.Passed:
                    _test.Pass("<pre>" + Constants.TestDetails + "</pre>");
                    Reporter.AddTestScreenshot(Constants.TestName, path, Constants.TestDetails);
                    Driver.Quit();
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

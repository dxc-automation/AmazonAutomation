using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAutomation.Tests.Config
{
    public class MyTestAction : ITestAction
    {
        public void BeforeTest(ITest test)
        {
            TestContext.WriteLine($"---> Starting test: {test.Name}");

        }

        public void AfterTest(ITest test)
        {
            TestContext.WriteLine($"---> Finished test: {test.Name}");
        }

        public ActionTargets Targets
        {
            get { return ActionTargets.Test; }
        }
    }
}
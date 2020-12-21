using ERCSelenium.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERCSelenium.SUT
{
    [TestClass, DeploymentItem("AutoConfig.xml")]
    public class MasterTestClass
    {
        private Exception ExceptionThrown;
        private bool TestResult = true;

        [TestInitialize]
        public void Initilize()
        {
            App.Initialize<ChromeDriver>(TestContext);
            App.Reporter.DebugLog("Test started.", true, true);
            AutoConfig.Initialize(TestContext);
        }

        public void RunTest(Action test)
        {
            try
            {
                test.Invoke();
            }
            catch (Exception ex)
            {
                TestResult = false;
                ExceptionThrown = ex;
                //throw;
            }
        }

        public TestContext TestContext { get; set; }

        [TestCleanup]
        public void Dispose()
        {
            App.Driver?.Quit();
            App.Reporter.FinishTest(TestResult, ExceptionThrown?.Message);
        }

    }
}

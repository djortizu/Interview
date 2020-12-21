using ERCSelenium.SUT;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ERCSelenium.Tools;
using System.Collections.Generic;
using Selenio.HtmlReporter;

namespace ERCSelenium
{
    [TestClass]
    public class ERCSeleniumTest : MasterTestClass
    {
        [TestMethod]
        public void TestMethod1()
        {
            RunTest(() =>
            {
                App.Reporter.TestDescription = "Navigate to Google and make a search.";
                App.OpenURL();
                App.Google.Search("Youtube");
            });
        }

        [TestMethod]
        public void AutoConfigFileExists()
        {
            RunTest(() =>
            {
                App.Reporter.TestDescription = "Read my XML.";
                App.Reporter.TestStep = "Get deployment directory";
                Assertions.AreEqual(AutoConfig.XmlFilePath, AutoConfig.XmlFilePath, "File paths are not the same.");
                Assertions.AreEqual("", AutoConfig.XmlFilePath, "File paths are not the same.");

            });
        }

        [TestMethod]
        public void TestingVTest()
        {
            RunTest(() =>
            {
                App.Reporter.TestDescription = "Testing Build Pipeline.";
                App.Reporter.TestStep = "Report Test Environment from Run Settings file.";
                App.Reporter.StatusUpdate(AutoConfig.TestEnvironment, true);
            });
        }
    }
}

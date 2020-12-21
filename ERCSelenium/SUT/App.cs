using ERC.Selenium.PageObjects;
using ERCSelenium.PageObjects;
using ERCSelenium.Reporting;
using ERCSelenium.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Selenio.Core.SUT;
using Selenio.HtmlReporter;

namespace ERCSelenium.SUT
{
    public class App : SUTDriver
    {
        public static void Initialize<T>(TestContext context) where T : IWebDriver
        {
            var reporter = new Reporter(new ReportSettingsProvider(), context.TestResultsDirectory, context.FullyQualifiedTestClassName, context.TestName);
            InitDriver<T>(reporter);
            Driver.Manage().Window.Maximize();
        }

        public static Google OpenURL()
        {
            Driver.Url = AutoConfig.AppUrl;
            return Google;
        }

        public static Google Google => GetPage<Google>();

        public static Amazon Amazon => GetPage<Amazon>();
    }
}

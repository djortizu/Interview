using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERC.Selenium.Tools
{
    public static class WebDriverExtensions
    {
        public static void Execute(this IWebDriver driver, string command, params object[] args)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(command, args);
        }

        public static void OpenNewBrowserWindow(this IWebDriver driver)
        {
            driver.Execute("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public static void WaitForActionToComplete(this IWebDriver driver, Func<bool> action, int? timeout = null, int? idleInterval = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout ?? 60))
            {
                PollingInterval = TimeSpan.FromSeconds(idleInterval ?? 1)
            };
            try { wait.Until(d => action.Invoke()); }
            catch (WebDriverTimeoutException) { throw new WebDriverTimeoutException($"Action did not complete after {timeout ?? 60} seconds."); }
        }
    }
}

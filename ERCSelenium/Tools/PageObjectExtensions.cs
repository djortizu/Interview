using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenio.Core.SUT;

namespace ERC.Selenium.Tools
{
    public static class PageObjectExtensions
    {
        public static void WaitForScreenToLoad(this PageObject page, IWebElement element)
        {
            page.Wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
    }
}

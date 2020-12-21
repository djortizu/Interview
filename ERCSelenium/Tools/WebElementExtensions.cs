using ERCSelenium.SUT;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using static ERC.Selenium.Tools.Enums;

namespace ERC.Selenium.Tools
{
    public static class WebElementExtensions
    {
        public static IWebElement GetElement(this ISearchContext context, ByLocator locator, string criteria)
        {
            IWebElement foundElement;
            switch (locator)
            {
                case ByLocator.ClassName:
                    foundElement = context.FindElement(By.ClassName(criteria));
                    break;
                case ByLocator.CssSelector:
                    foundElement = context.FindElement(By.CssSelector(criteria));
                    break;
                case ByLocator.ID:
                    foundElement = context.FindElement(By.Id(criteria));
                    break;
                case ByLocator.TagName:
                    foundElement = context.FindElement(By.TagName(criteria));
                    break;
                case ByLocator.XPath:
                    foundElement = context.FindElement(By.XPath(criteria));
                    break;
                default:
                    throw new ArgumentException("Provided ByLocator is not supported.");
            }
            return foundElement;
        }

        public static IEnumerable<IWebElement> GetElements(this ISearchContext context, ByLocator locator, string criteria)
        {
            IEnumerable<IWebElement> foundElements;
            switch (locator)
            {
                case ByLocator.ClassName:
                    foundElements = context.FindElements(By.ClassName(criteria));
                    break;
                case ByLocator.CssSelector:
                    foundElements = context.FindElements(By.CssSelector(criteria));
                    break;
                case ByLocator.ID:
                    foundElements = context.FindElements(By.Id(criteria));
                    break;
                case ByLocator.TagName:
                    foundElements = context.FindElements(By.TagName(criteria));
                    break;
                case ByLocator.XPath:
                    foundElements = context.FindElements(By.XPath(criteria));
                    break;
                default:
                    throw new ArgumentException("Provided ByLocator is not supported.");
            }
            return foundElements;
        }

        #region Methods that return bool
        public static bool IsEnabled(this IWebElement element)
        {
            try
            {
                return element.Enabled;
            }
            catch
            {
                return false;
            }

        }

        public static bool IsDisplayed(this IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch
            {
                return false;
            }

        }
        #endregion

        #region Methods that return a string
        public static string GetElementValue(this IWebElement element)
        {
            App.Reporter.ReportElementAction(element.ToString(), "GetValue", "", "", true, "");
            return element.GetAttribute("value");
        }

        public static string GetTextFromElement(this IWebElement element)
        {
            App.Reporter.ReportElementAction(element.ToString(), "GetText", "", "", true, "");
            return element.Text;
        }

        public static string GetElementAttribute(this IWebElement element, string attribute)
        {
            App.Reporter.ReportElementAction(element.ToString(), "GetAttribute", attribute, "", true, "");
            return element.GetAttribute(attribute);
        }
        #endregion

        public static IWebElement ScrollIntoView(this IWebElement element)
        {
            try
            {
                App.Driver.Execute("arguments[0].scrollIntoView();", element);
            }
            catch { }

            return element;
        }

        public static void Highlight(this IWebElement element, int flashes = 3)
        {
            element.ScrollIntoView();
            string style = element.GetAttribute("style") ?? "";
            try
            {
                for (int i = 1; i < flashes; i++)
                {
                    App.Driver.Execute("arguments[0].style.border='3px solid red'", element);
                    Thread.Sleep(250);
                    App.Driver.Execute("arguments[0].style.border=''", element);
                }
            }
            catch (Exception e)
            {
                App.Reporter.DebugLog($"Highlight failed. Reason: {e.Message}");
            }
        }

        public static void GiveFocus(this IWebElement element)
        {
            try
            {
                element.SendKeys("");
            }
            catch
            {
                element.ScrollIntoView();
            }
        }

        public static int GetRowCount(this IWebElement element)
        {
            return element.FindElements(By.XPath("./tbody/tr")).Count;
        }
    }
}
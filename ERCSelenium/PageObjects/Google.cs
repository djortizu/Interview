using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Selenio.Core.SUT;
using Selenio.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERCSelenium.PageObjects
{
    public class Google : PageObject
    {
        [WaitForThisElement]
        [FindsBy(How = How.XPath, Using = "//input[@title='Search']")]
        public IWebElement SearchBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='btnK']")]
        public IWebElement SearchButton { get; set; }

        public void Search(string criteria)
        {
            this.WaitForScreen();
            SearchBox.SetText(criteria);
            SearchButton.Click();
        }
    }
}

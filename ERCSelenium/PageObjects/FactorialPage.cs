using ERC.Selenium.Tools;
using ERCSelenium.SUT;
using ERCSelenium.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Selenio.Core.SUT;
using Selenio.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERC.Selenium.PageObjects
{
    public class FactorialPage : PageObject
    {
        [WaitForThisElement]
        [FindsBy(How = How.Id, Using = "number")]
        public IWebElement TextBox { get; set; }

        [FindsBy(How = How.Id, Using = "getFactorial")]
        public IWebElement CalculateBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement ArrowBtn { get; set; }

        [FindsBy(How = How.Id, Using = "//h1[@class='margin-base-vertical']")]
        public IWebElement HeaderText { get; set; }

        [FindsBy(How = How.Id, Using = "resultDiv")]
        public IWebElement ResultMsg { get; set; }

        [FindsBy(How = How.Id, Using = "//a[contains(@href, 'privacy')]")]
        public IWebElement TermsConditions { get; set; }

        [FindsBy(How = How.Id, Using = "//a[contains(@href, 'terms')]")]
        public IWebElement Privacy { get; set; }

        [FindsBy(How = How.Id, Using = "//a[contains(text(), 'Qxf2')]")]
        public IWebElement Qxf2ServicesLink { get; set; }

        #region Methods

        public FactorialPage Open()
        {
            App.Driver.Url = AutoConfig.FactorialUrl;
            this.WaitForScreenToLoad(CalculateBtn);
            return this;
        }

        public FactorialPage CalculateFactorial(int Factorial)
        {
            TextBox.SetText($"{Factorial}");
            CalculateBtn.Click();
            return this;
        }

        public string ObtainResult()
        {
            return ResultMsg.Text;
        }
        #endregion
    }
}

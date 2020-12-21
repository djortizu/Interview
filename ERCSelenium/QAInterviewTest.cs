using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ERCSelenium.SUT;
using ERCSelenium.Tools;

namespace ERC.Selenium
{
    /// <summary>
    /// Summary description for QAInterviewTest
    /// </summary>
    [TestClass]
    public class QAInterviewTest : MasterTestClass
    {
       
        [TestMethod]
        public void TestMethod1()
        {
            RunTest(() =>
            {
                App.Reporter.TestDescription = "Functionality test of the Factorial Calculator page.";
                App.Reporter.TestStep = "Open the Factorial Calculator page.";
                App.FactorialPage.Open();

                App.Reporter.TestStep = "Enter a number to calculate its factorial.";
                App.FactorialPage.CalculateFactorial(5);

                App.Reporter.TestStep = "Validate result of the factorial calculator.";
                Assertions.AreEqual(App.FactorialPage.ObtainResult(), "The factorial of 5 is: 120", "The validation is incorrect. Check the data.");

            });
        }
    }
}

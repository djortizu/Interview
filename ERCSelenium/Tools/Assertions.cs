using ERCSelenium.SUT;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERCSelenium.Tools
{
    public class Assertions
    {
        public static void AreEqual<T>(T expected, T actual, string message)
        {
            try
            {
                Assert.AreEqual<T>(expected, actual, message);
                App.Reporter.ReportAssertion<T>("element", "AreEqual", expected, actual, true, message);
            }
            catch (Exception ex)
            {
                App.Reporter.ReportAssertion<T>("element", "AreEqual", expected, actual, false, ex.Message);
                throw;
            }
        }
    }
}

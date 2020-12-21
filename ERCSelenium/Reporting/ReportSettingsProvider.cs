using Selenio.Core.Reporting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERCSelenium.Reporting
{
    public class ReportSettingsProvider : IReportSettingsProvider
    {
        public string ReportFilesDropDirectory => @"C:\TestResults";

        public ReportSettingsProvider()
        {
            Directory.CreateDirectory(ReportFilesDropDirectory);
        }

        public ReadOnlyCollection<string> GetPageObjectMethodNames()
        {
            return new ReadOnlyCollection<string>(
                new List<string>()
                {

                });
        }

        public ReadOnlyCollection<string> GetWebElementMethodNames()
        {
            return new ReadOnlyCollection<string>(
                new List<string>()
                {
                    "get_TagName",
                    "get_Text",
                    "get_Enabled",
                    "get_Selected",
                    "get_Displayed",
                    "Click",
                    "GetAttribute",
                    "SendKeys",
                    "Submit"
                });
        }
    }
}

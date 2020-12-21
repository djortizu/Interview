using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ERCSelenium.Tools
{
    public class AutoConfig
    {
        private static string xmlFilePath;

        private static string testEnvironment;

        private static string appUrl;

        private static string amazonUrl;

        private static bool isUsingRunSettings;

        public static void Initialize(TestContext context)
        {
            isUsingRunSettings = context.Properties["TestEnvironment"] != null;
            xmlFilePath = $@"{context.DeploymentDirectory}\AutoConfig.xml";
            if (!File.Exists(xmlFilePath))
                throw new FileNotFoundException("AutoConfig file was not found. Please verify that file is listed as deployment item in MasterTestClass and is setup as 'Copy Always' in Properties.");

            testEnvironment = isUsingRunSettings ? context.Properties["TestEnvironment"].ToString() : ReadXMLAppSettings("appSettings", "TestEnvironment");

            appUrl = ReadEnvironmentSettings("AppUrl");
            amazonUrl = ReadEnvironmentSettings("AmazonUrl");
        }

        protected static string ReadEnvironmentSettings(string nodes, bool required = true)
        {
            try
            {
                

                XmlDocument xDoc = new XmlDocument();
                if (File.Exists(xmlFilePath))
                {
                    xDoc.Load(xmlFilePath);
                    if (xDoc.DocumentElement.SelectSingleNode(testEnvironment + "/" + nodes) != null)
                        return xDoc.DocumentElement.SelectSingleNode(testEnvironment + "/" + nodes).InnerText.ToString();
                }
            }
            catch (Exception ex)
            {
                if (required)
                    throw new Exception($"Nodes '{nodes}' not found. There was an error reading file AutoConfig.xml. Details: {ex.Message}");
            }

            return null;
        }

        public static string ReadXMLAppSettings(string option, string key)
        {
            string sValue = "";
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(xmlFilePath);
            try { sValue = xDoc.DocumentElement.SelectSingleNode(option + "/" + key).InnerText.Trim(); }
            catch { sValue = "KEY_NOT_FOUND"; }
            return sValue;
        }

        public static string XmlFilePath => xmlFilePath;

        public static string TestEnvironment => testEnvironment;

        public static string AppUrl => appUrl;

        public static string AmazonUrl => amazonUrl;




    }
}

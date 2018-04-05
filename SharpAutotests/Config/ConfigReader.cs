using SharpAutotests.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace SharpAutotests.Config
{
    class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            XPathItem browser;
            
            string strFileName = System.AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\" + "\\Config\\GlobalConfig.xml";
            var stream = new FileStream(strFileName, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();

            browser = navigator.SelectSingleNode("SharpAutotests/RunSettings/Browser");

            Settings.BrowserType = WebDriverFactory.ReturnBrowserType(browser.Value.ToString());

        }
    }
}

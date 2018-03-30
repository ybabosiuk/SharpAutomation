using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAutotests.Factories
{
    class WebDriverFactory
    {
        public enum BrowserType
        {
            Chrome,
            Firefox,
            IE
        }

        private static readonly IDictionary<BrowserType, IWebDriver> Drivers = new Dictionary<BrowserType, IWebDriver>();

        public static IWebDriver Driver { get; private set; }
    
        public static void InitBrowser(BrowserType browserName)
        {
            switch (browserName)
            {
                case BrowserType.Firefox:
                    if (Driver == null)
                    {
                        Driver = new FirefoxDriver();
                        Drivers.Add(BrowserType.Firefox, Driver);
                    }
                    break;

                case BrowserType.Chrome:
                    if (Driver == null)
                    {
                        Driver = new ChromeDriver();
                        Drivers.Add(BrowserType.Chrome, Driver);
                    }
                    break;
            }
        }

        public static void CloseDriver(BrowserType browserType)
        {
            if (Drivers.ContainsKey(browserType))
            {
                var driver = Drivers[browserType];
                driver.Close();
                driver.Quit();
            }
        }

        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                var driver = Drivers[key];
                driver.Close();
                driver.Quit();
            }
        }
    }
}

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
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();

        public static IWebDriver Driver { get; private set; }
    
        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (Driver == null)
                    {
                        Driver = new FirefoxDriver();
                        Drivers.Add("Firefox", Driver);
                    }
                    break;

                case "Chrome":
                    if (Driver == null)
                    {
                        Driver = new ChromeDriver();
                        Drivers.Add("Chrome", Driver);
                    }
                    break;
            }
        }

        public static void CloseDriver(string browserName)
        {
            if (Drivers.ContainsKey(browserName))
            {
                var driver = Drivers[browserName];
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

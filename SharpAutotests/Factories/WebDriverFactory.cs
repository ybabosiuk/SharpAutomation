using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using SharpAutotests.Config;
using System;
using System.Collections.Generic;

namespace SharpAutotests.Factories
{
    public class WebDriverFactory
    {
        public enum BrowserType
        {
            Chrome,
            Firefox,
            IE,
            RemoteChrome,
            RemoteFirefox
        }

        public static BrowserType ReturnBrowserType(string type)
        {
            switch (type)
            {
                case "Chrome":
                    return BrowserType.Chrome;
                case "Firefox":
                    return BrowserType.Firefox;
                case "IE":
                    return BrowserType.IE;
                case "RemoteChrome":
                    return BrowserType.RemoteChrome;
                case "RemoteFirefox":
                    return BrowserType.RemoteFirefox;
                default:
                    return BrowserType.Chrome;
            }

        }

        private static readonly IDictionary<BrowserType, IWebDriver> Drivers = new Dictionary<BrowserType, IWebDriver>();

        public static IWebDriver Driver { get; private set; }

        public static void InitBrowser(Settings settings)
        {
            switch (settings.BrowserType)
            {
                case BrowserType.Firefox:
                    if (Driver == null)
                    {
                        Driver = new FirefoxDriver();
                        AddToDrivers(BrowserType.Firefox, Driver);
                    }
                    break;

                case BrowserType.Chrome:
                    if (Driver == null)
                    {
                        Driver = new ChromeDriver();
                        AddToDrivers(BrowserType.Chrome, Driver);
                    }
                    break;
                case BrowserType.RemoteChrome:
                    if (Driver == null)
                    {
                        //var caps = new DesiredCapabilities(settings.Browser, settings.BrowserVersion, new Platform(PlatformType.Any));
                        //caps.SetCapability("enableVNC", true);
                        var options = new ChromeOptions
                        {
                            AcceptInsecureCertificates = true
                        };
                        options.AddAdditionalCapability("version", settings.BrowserVersion, true);
                        options.AddAdditionalCapability("platform", "Any", true);
                        options.AddAdditionalCapability("enableVNC", true, true);
                        Driver = new RemoteWebDriver(new Uri(settings.RemoteUri), options);
                        AddToDrivers(BrowserType.RemoteChrome, Driver);
                        var allowsDetection = Driver as IAllowsFileDetection;
                        if (allowsDetection != null)
                        {
                            allowsDetection.FileDetector = new LocalFileDetector();
                        }
                    }
                    break;
                case BrowserType.RemoteFirefox:
                    if (Driver == null)
                    {
                        var options = new FirefoxOptions();
                        options.AddAdditionalCapability("version", settings.BrowserVersion, true);
                        options.AddAdditionalCapability("platform", "Any", true);
                        options.AddAdditionalCapability("enableVNC", true, true);
                        Driver = new RemoteWebDriver(new Uri(settings.RemoteUri), options);
                        AddToDrivers(BrowserType.RemoteFirefox, Driver);
                        var allowsDetection = Driver as IAllowsFileDetection;
                        if (allowsDetection != null)
                        {
                            allowsDetection.FileDetector = new LocalFileDetector();
                        }
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
            Drivers.Clear();
            Driver = null;
        }

        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                var driver = Drivers[key];
                driver.Close();
                driver.Quit();
            }
            Drivers.Clear();
            Driver = null;
        }

        private static void AddToDrivers(BrowserType browserType, IWebDriver driver)
        {
            if (Drivers.ContainsKey(browserType))
            {
                //Do nothing 
            }
            else
            { 
                Drivers.Add(browserType, driver);
            }
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using SharpAutotests.Config;
using System;
using System.Collections.Generic;
using System.Reflection;

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

        public static IWebDriver InitBrowser(Settings settings)
        {
            IWebDriver driver;
            switch (settings.BrowserType)
            {
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                case BrowserType.Chrome:
                default:
                    driver = new ChromeDriver();
                    break;
                case BrowserType.RemoteChrome:
                    var chromeOptions = new ChromeOptions
                    {
                        AcceptInsecureCertificates = true
                    };
                    chromeOptions.AddAdditionalCapability("version", settings.BrowserVersion, true);
                    chromeOptions.AddAdditionalCapability("platform", "Any", true);
                    chromeOptions.AddAdditionalCapability("enableVNC", true, true);
                    driver = new RemoteWebDriver(new Uri(settings.RemoteUri), chromeOptions);
                    DetectFile(driver);
                    // var sessionIdProperty = typeof(RemoteWebDriver).GetProperty("SessionId", BindingFlags.Instance | BindingFlags.NonPublic);
                    //var sessionId = sessionIdProperty.GetValue(driver, null) as SessionId;
                    break;
                case BrowserType.RemoteFirefox:
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddAdditionalCapability("version", settings.BrowserVersion, true);
                    firefoxOptions.AddAdditionalCapability("platform", "Any", true);
                    firefoxOptions.AddAdditionalCapability("enableVNC", true, true);
                    driver = new RemoteWebDriver(new Uri(settings.RemoteUri), firefoxOptions);
                    DetectFile(driver);
                    break;
            }
            return driver;
        }

        public static void CloseDriver(IWebDriver driver)
        {
            driver.Quit();
            driver.Close();
            driver = null;
        }

        private static void DetectFile(IWebDriver driver)
        {
            var allowsDetection = driver as IAllowsFileDetection;
            if (allowsDetection != null)
            {
                allowsDetection.FileDetector = new LocalFileDetector();
            }
        }

        //private static void AddToDrivers(BrowserType browserType, IWebDriver driver)
        //{
        //    //Lock adding Driver to Drivers Dictionary for parallel run
        //    lock(Drivers)
        //        {
        //        if (Drivers.ContainsKey(browserType))
        //        {
        //            //Do nothing 
        //        }
        //        else
        //        {
        //            Drivers.Add(browserType, driver);
        //        }
        //    }
        //}
    }
}

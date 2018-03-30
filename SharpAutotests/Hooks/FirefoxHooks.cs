using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SharpAutotests.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SharpAutotests
{
    [Binding]
    public sealed class FirefoxHooks
    {
        [BeforeScenario("Firefox")]
        public void BeforeScenario()
        {
            WebDriverFactory.InitBrowser(WebDriverFactory.BrowserType.Firefox);
        }

        [AfterFeature("Firefox")]
        public static void AfterFeature()
        {
            WebDriverFactory.CloseDriver(WebDriverFactory.BrowserType.Firefox);
            Init.PageFactory = null;
        }

        [AfterScenario("Firefox")]
        public void AfterScenario()
        {
            WebDriverFactory.CloseDriver(WebDriverFactory.BrowserType.Firefox);
            Init.PageFactory = null;
        }
    }
}

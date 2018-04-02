using SharpAutotests.Config;
using SharpAutotests.Factories;
using SharpAutotests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SharpAutotests.Hooks
{
    [Binding]
    public sealed class BasicHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        public BasicHooks()
        {
            ConfigReader.SetFrameworkSettings();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            WebDriverFactory.InitBrowser(Settings.BrowserType);
            LogHelpers.CreateLogFile();
            Init.PageFactory = new PageObjectFactory(WebDriverFactory.Driver);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            WebDriverFactory.CloseDriver(Settings.BrowserType);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebDriverFactory.CloseDriver(Settings.BrowserType);
            LogHelpers.Close();
        }
    }
}

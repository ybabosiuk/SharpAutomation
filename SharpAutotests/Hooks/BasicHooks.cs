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

        [BeforeScenario]
        public void BeforeScenario()
        {
            ConfigReader.SetFrameworkSettings();
            WebDriverFactory.InitBrowser(Settings.BrowserType);
            LogHelpers.CreateLogFile();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            WebDriverFactory.CloseDriver(Settings.BrowserType);
            Init.PageFactory = null;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebDriverFactory.CloseDriver(Settings.BrowserType);
            Init.PageFactory = null;
        }
    }
}

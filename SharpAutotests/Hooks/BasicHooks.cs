using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
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
    public class BasicHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private readonly IObjectContainer objectContainer;

        private IWebDriver driver;

        public BasicHooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;

           // ConfigReader.SetFrameworkSettings();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //WebDriverFactory.InitBrowser(Settings.BrowserType);
            driver = new FirefoxDriver();
            objectContainer.RegisterInstanceAs<IWebDriver>(this.driver);
            Init.PageFactory = new PageObjectFactory(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}

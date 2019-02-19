using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using SharpAutotests.Config;
using SharpAutotests.Factories;
using SharpAutotests.Utils;
using System;
using System.Drawing;
using System.Drawing.Imaging;
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

           
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var settings = ConfigReader.GetFrameworkSettings();
            WebDriverFactory.InitBrowser(settings);
            driver = WebDriverFactory.Driver;
            driver.Manage().Window.Size = new Size(settings.Width, settings.Height); ;
            objectContainer.RegisterInstanceAs(this.driver);
            Init.PageFactory = new PageObjectFactory(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                var date = DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt");
                BrowserScreenshotTaker.TakeBrowserScreen(driver, date + ".png");
            }
             //driver.Quit();
            driver.Manage().Cookies.DeleteAllCookies();
        }
    }
}

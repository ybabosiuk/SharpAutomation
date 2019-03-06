using BoDi;
using OpenQA.Selenium;
using SharpAutotests.Config;
using SharpAutotests.Factories;
using SharpAutotests.Utils;
using System;
using System.Drawing;
using System.Threading;
using TechTalk.SpecFlow;

namespace SharpAutotests.Hooks
{
    [Binding]
    public sealed class BasicHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private readonly IObjectContainer objectContainer;

        private IWebDriver driver;

        private readonly ScenarioContext scenarioContext;

        public BasicHooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            this.objectContainer = objectContainer;
            this.scenarioContext = scenarioContext ?? throw new ArgumentNullException("scenarioContext");
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
          
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var screensPath = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\" + TestCostants.ScreenShotPath;
            //FilesUtil.DeleteAllFilesFromDir(screensPath);
            var settings = ConfigReader.GetFrameworkSettings();
            objectContainer.RegisterInstanceAs(WebDriverFactory.InitBrowser(settings));
            driver = objectContainer.Resolve<IWebDriver>();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Size = new Size(settings.Width, settings.Height);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (scenarioContext.TestError != null)
            {
                var date = DateTime.Now.ToString("dd_MMMM_hh_mm_ss_ff");
                BrowserScreenshotTaker.TakeBrowserScreen(driver, date + ".png");
            }
            WebDriverFactory.CloseDriver(driver);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
        }
    }
}

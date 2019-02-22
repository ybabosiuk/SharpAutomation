﻿using BoDi;
using OpenQA.Selenium;
using SharpAutotests.Config;
using SharpAutotests.Factories;
using SharpAutotests.Utils;
using System;
using System.Drawing;
using TechTalk.SpecFlow;

namespace SharpAutotests.Hooks
{
    [Binding]
    public class BasicHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private readonly IObjectContainer objectContainer;

        private static IWebDriver driver;

        private readonly ScenarioContext scenarioContext;

        public BasicHooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            this.objectContainer = objectContainer;
            this.scenarioContext = scenarioContext ?? throw new ArgumentNullException("scenarioContext");
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var screensPath = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\" + TestCostants.ScreenShotPath;
            //FilesUtil.DeleteAllFilesFromDir(screensPath);
            var settings = ConfigReader.GetFrameworkSettings();
            WebDriverFactory.InitBrowser(settings);
            driver = WebDriverFactory.Driver;
            driver.Manage().Window.Size = new Size(settings.Width, settings.Height); ;
            objectContainer.RegisterInstanceAs(driver);
            Init.PageFactory = new PageObjectFactory(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (scenarioContext.TestError != null)
            {
                var date = DateTime.Now.ToString("dd_MMMM_hh_mm_ss_ff");
                BrowserScreenshotTaker.TakeBrowserScreen(driver, date + ".png");
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Quit();
        }
    }
}

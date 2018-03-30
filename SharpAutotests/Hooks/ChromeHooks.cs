﻿using OpenQA.Selenium;
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
    public sealed class ChromeHooks
    {
        [BeforeScenario("Chrome")]
        public void BeforeScenario()
        {
            WebDriverFactory.InitBrowser(WebDriverFactory.BrowserType.Chrome);
        }

        [AfterFeature("Chrome")]
        public static void AfterFeature()
        {
            WebDriverFactory.CloseDriver(WebDriverFactory.BrowserType.Chrome);
            Init.PageFactory = null;
        }

        [AfterScenario("Chrome")]
        public void AfterScenario()
        {
            WebDriverFactory.CloseDriver(WebDriverFactory.BrowserType.Chrome);
            Init.PageFactory = null;
        }
    }
}
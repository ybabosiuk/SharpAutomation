using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using SharpAutotests.Config;
using System;

namespace SharpAutotests.Utils
{
    class BrowserScreenshotTaker
    {
        public static void TakeBrowserScreen(IWebDriver driver, string fileName)
        {
            var date = DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt");
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\" + TestCostants.ScreenShotPath;
            System.IO.Directory.CreateDirectory(filePath);
            var screenshot = driver.TakeScreenshot();
            screenshot.SaveAsFile(filePath + date + ".png");
        }
    }
}

using OpenQA.Selenium;
using SharpAutotests.Extensions;
using SharpAutotests.Factories;
using TechTalk.SpecFlow;

namespace SharpAutotests.Pages
{
   public class CommonSteps
    {
        private readonly IWebDriver driver;

        public CommonSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I open '(.*)' url")]
        public void GivenIOpenUrl(string url)
        {
            driver.Url = url;
            WebDriverFactory.Driver.WaitForPageLoaded();
        }

    }
}

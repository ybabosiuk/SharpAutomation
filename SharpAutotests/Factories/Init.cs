using OpenQA.Selenium;

namespace SharpAutotests.Factories
{
    class Init
    {
        public static PageObjectFactory GetPageObject(IWebDriver driver)
        {
            return new PageObjectFactory(driver);
        }

    }
}

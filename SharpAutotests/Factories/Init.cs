using OpenQA.Selenium;

namespace SharpAutotests.Factories
{
    class Init
    {
        public static PageObjectFactory SetPageObjectFactory(IWebDriver driver)
        {
            return new PageObjectFactory(driver);
        }

    }
}

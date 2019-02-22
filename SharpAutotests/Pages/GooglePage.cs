using OpenQA.Selenium;
using SharpAutotests.Extensions;

namespace SharpAutotests.Pages
{
    class GooglePage : BasePage
    {
        private IWebElement SearchField => driver.FindElement(By.CssSelector("input[type='text']"));
        private IWebElement SearchButton => driver.FindElement(By.CssSelector("input[type='submit']"));
        

        string pageUrl = "";

        public void GoTo()
        {
            driver.Url += pageUrl;
        }

        public GooglePage(IWebDriver driver) : base(driver) {}

        public void EnterSearchQuery(string query)
        {
            SearchField.SendKeys(query);
        }

        public void SubmitSearch()
        {
            SearchButton.Click();
        }

       public bool? IsMainElementPresented(string cssLocators)
        {
            return WebElementExtensions.IsElementPresent(driver, By.CssSelector(cssLocators));
        }
    }
}

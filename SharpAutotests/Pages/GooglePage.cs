using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAutotests.Pages
{
    class GooglePage : BaseObject
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


    }
}

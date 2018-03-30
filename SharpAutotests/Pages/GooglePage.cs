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
        public IWebElement searchField => driver.FindElement(By.Id("lst-ib"));
        public IWebElement searchButton => driver.FindElement(By.CssSelector("input.lsb"));

        string pageUrl = "";

        public void GoTo()
        {
            driver.Url += pageUrl;
        }

        public GooglePage(IWebDriver driver) : base(driver) {}

    }
}

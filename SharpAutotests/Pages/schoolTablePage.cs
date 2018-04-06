using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SharpAutotests.Pages
{
    class SchoolTablePage : BaseObject
    {
        public IWebElement Table => driver.FindElement(By.Id("customers"));  

        public SchoolTablePage(IWebDriver driver) : base(driver) {}


    }
}

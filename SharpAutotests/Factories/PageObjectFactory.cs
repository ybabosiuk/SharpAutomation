using OpenQA.Selenium;
using SharpAutotests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAutotests.Factories
{
    class PageObjectFactory
    {
        readonly IWebDriver _driver;

        public PageObjectFactory(IWebDriver driver)
        {
            _driver = driver;
        }

        public T CreateInstance<T>() where T: IPageObject 
        {
            return (T)Activator.CreateInstance(typeof(T), _driver);
        }
    }
}

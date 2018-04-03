using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAutotests.Extensions
{
    public static class WebElementExtensions
    {
    
        public static void SelectDropdownList(this IWebElement element, string value)
        {
            var select = new SelectElement(element);
            select.SelectByText(value);
        }

        public static string GetSelectedDropdown(this IWebElement element)
        {
            var select = new SelectElement(element);
            return select.AllSelectedOptions.First().ToString();
        }

        public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
        {
            var select = new SelectElement(element);
            return select.AllSelectedOptions;
        }

        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
                throw new Exception(string.Format("Element Not Present exception"));
        }

        private static bool IsElementPresent(IWebElement element)
        {
            try
            {
                bool elem = element.Displayed;
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
    }
}

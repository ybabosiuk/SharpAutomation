using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SharpAutotests.Pages
{
    class GoogleSearchResultsPage : BaseObject
    {
        public GoogleSearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        private List<IWebElement> SearchResults => driver.FindElements(By.CssSelector("div.rc")).ToList();
        private IWebElement SearchResult => driver.FindElement(By.Id("ires"));
        private List<IWebElement> ResultSubLinks => driver.FindElements(By.CssSelector("div.osl>a")).ToList();

        public List<string> GetSearchResults()
        {
            var searchResultsText = new List<string>();
            foreach (IWebElement result in SearchResults)
            {
                searchResultsText.Add(result.Text);
            }
            return searchResultsText;
        }

        public int GetSearchResultsCount()
        {
            return SearchResults.Count();
        }

        public bool SearchResultsExists()
        {
            return SearchResult.Displayed;
        }

        public bool IsSubLinkAvaliable(string subLinkText)
        {
            //return driver.FindElement(By.LinkText(subLinkText)).Displayed;
           
           foreach(IWebElement subLink in ResultSubLinks)
            {
               if (subLink.Text == subLinkText)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsLinkWithTextExists(string subLinkText)
        {
            return driver.FindElement(By.LinkText(subLinkText)).Displayed;
        }

    }
}

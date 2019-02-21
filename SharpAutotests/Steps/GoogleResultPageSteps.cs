using SharpAutotests.Factories;
using SharpAutotests.Pages;
using System;
using TechTalk.SpecFlow;
using SharpAutotests.Extensions;
using OpenQA.Selenium;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using SharpAutotests.Steps;

namespace SharpAutotests
{
    [Binding]
    public class GoToGoogleSteps: CommonSteps
    {

       
        private GoogleSearchResultsPage ResultPage = Init.PageFactory.CreateInstance<GoogleSearchResultsPage>();

        public GoToGoogleSteps(IWebDriver driver) : base(driver)
        {
        }

        [Then(@"list with results is not empty")]
        public void ThenListWithResultsIsNotEmpty()
        {
            WebDriverFactory.Driver.WaitForPageLoaded();
            Assert.True(ResultPage.SearchResultsExists());
        }

        [Then(@"I verfiy that a search result contains keyword '(.*)' on Results Page")]
        public void ThenIVerfiyThatASearchResultContainsKeywordOnResultsPage(string searchText)
        {
            var results = ResultPage.GetSearchResults();
            foreach(string result in results)
            {
                Assert.That(result.Contains(searchText), $"{result} don't contains search query {searchText}");
            }
        }

        [Then(@"I verfiy that a search results count to (.*) on Results Page")]
        public void ThenIVerfiyThatASearchResultsCountToOnResultsPage(int resultsCount)
        {
            int actualResultsCount = ResultPage.GetSearchResultsCount();
            Assert.AreEqual(resultsCount, actualResultsCount);
        }

        [Then(@"I verfiy that a first search result contains sublinks on Results Page:")]
        public void ThenIVerfiyThatAFirstSearchResultContainsSublinksOnResultsPage(Table table)
        {
            foreach (var row in table.Rows)
            {
                var expectedLinkText = row["SubLinkText"];
                //Assert.IsTrue(ResultPage.IsSubLinkAvaliable(expectedLinkText));
                
            }
            var subUrlsText = table.CreateSet<SubUrlsText>();
            foreach(var subLink in subUrlsText)
            {
                Assert.IsTrue(ResultPage.IsLinkWithTextExists(subLink.SubLinkText));
            }
           
        }



    }
}

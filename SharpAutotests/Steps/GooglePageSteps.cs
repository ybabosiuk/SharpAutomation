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
    public class GoToGoogleSteps
    {

        private readonly IWebDriver driver;
        private GooglePage GooglePage { get; set; }
        private GoogleSearchResultsPage ResultPage = Init.PageFactory.CreateInstance<GoogleSearchResultsPage>();

        public GoToGoogleSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"user go to Google page")]
        public void GivenUserGoToGooglePage()
        {
            driver.Url = "https://google.com";
        }

        [When(@"I add '(.*)' to search field")]
        public void WhenIAddToSearchField(string searchText)
        {
            WebDriverFactory.Driver.WaitForPageLoaded();
            GooglePage = Init.PageFactory.CreateInstance<GooglePage>();
            GooglePage.EnterSearchQuery(searchText);
        }

        [When(@"I click on Search button")]
        public void WhenIClickOnSearchButton()
        {
            GooglePage.SubmitSearch();
        }

        [Then(@"list with results is not empty")]
        public void ThenListWithResultsIsNotEmpty()
        {
            WebDriverFactory.Driver.WaitForPageLoaded();
            Assert.True(ResultPage.SearchResultsExists());
        }

        [When(@"I search '(.*)' query on Google Page")]
        public void WhenISearchQueryOnGooglePage(string searchText)
        {
            WhenIAddToSearchField(searchText);
            WhenIClickOnSearchButton();
        }

        [Then(@"I verfiy that a search result contains keyword '(.*)' on Results Page")]
        public void ThenIVerfiyThatASearchResultContainsKeywordOnResultsPage(string searchText)
        {
            var results = ResultPage.GetSearchResults();
            foreach(string result in results)
            {
                Assert.That(result.Contains(searchText));
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

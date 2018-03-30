using SharpAutotests.Factories;
using SharpAutotests.Pages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SharpAutotests
{
    [Binding]
    public class GoToGoogleSteps
    {
        private GooglePage GooglePage { get; set; }

        [Given(@"user go to Google page")]
        public void GivenUserGoToGooglePage()
        {
            WebDriverFactory.Driver.Url = "https://google.com";
        }

        [When(@"I add ""(.*)"" to search field")]
        public void WhenIAddToSearchField(string searchText)
        {
            GooglePage = Init.PageFactory.CreateInstance<GooglePage>();
            GooglePage.searchField.SendKeys(searchText);
        }

        [When(@"I click on Search button")]
        public void WhenIClickOnSearchButton()
        {
            Thread.Sleep(1000);
            GooglePage.searchButton.Click();
        }


    }
}

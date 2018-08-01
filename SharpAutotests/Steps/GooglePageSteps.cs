using SharpAutotests.Config;
using SharpAutotests.Factories;
using SharpAutotests.Helpers;
using SharpAutotests.Pages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using SharpAutotests.Extensions;
using OpenQA.Selenium;

namespace SharpAutotests
{
    [Binding]
    public class GoToGoogleSteps
    {

        private readonly IWebDriver driver;
        private GooglePage GooglePage { get; set; }

        public GoToGoogleSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"user go to Google page")]
        public void GivenUserGoToGooglePage()
        {
            driver.Url = "https://google.com";
        }

        [When(@"I add ""(.*)"" to search field")]
        public void WhenIAddToSearchField(string searchText)
        {
            WebDriverFactory.Driver.WaitForPageLoaded();
            GooglePage = Init.PageFactory.CreateInstance<GooglePage>();
            GooglePage.SearchField.SendKeys(searchText);
        }

        [When(@"I click on Search button")]
        public void WhenIClickOnSearchButton()
        {
            Thread.Sleep(1000);
            GooglePage.SearchButton.Click();
        }

        [Then(@"list with results is not empty")]
        public void ThenListWithResultsIsNotEmpty()
        {
            GooglePage.List.AssertElementPresent();
        }

    }
}

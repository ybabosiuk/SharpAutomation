using NUnit.Framework;
using OpenQA.Selenium;
using SharpAutotests.Extensions;
using SharpAutotests.Factories;
using SharpAutotests.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SharpAutotests.Steps
{
    [Binding]
    public class GoogleMainPageSteps : CommonSteps
    {
        public GoogleMainPageSteps(IWebDriver driver) : base(driver) { }

        private GooglePage GooglePage = Init.PageFactory.CreateInstance<GooglePage>();

        [Given(@"user go to Google page")]
        public void GivenUserGoToGooglePage()
        {
            GivenIOpenUrl("https://google.com");
        }

        [When(@"I add '(.*)' to search field")]
        public void WhenIAddToSearchField(string searchText)
        {
            WebDriverFactory.Driver.WaitForPageLoaded();
            GooglePage.EnterSearchQuery(searchText);
        }

        [When(@"I click on Search button")]
        public void WhenIClickOnSearchButton()
        {
            GooglePage.SubmitSearch();
        }


        [When(@"I search '(.*)' query on Google Page")]
        public void WhenISearchQueryOnGooglePage(string searchText)
        {
            WhenIAddToSearchField(searchText);
            WhenIClickOnSearchButton();
        }

        [Then(@"I verify that a main Google page locators are shown")]
        public void ThenIVerifyThatAMainGooglePageLocatorsAreShown(Table table)
        {
            var mainPageElements = table.CreateSet<MainPageElements>();
            foreach (var pageElement in mainPageElements)
            {
                Assert.IsTrue(GooglePage.IsMainElementPresented(pageElement.CssLocators), $"Locator {pageElement.PageElementName} is not present on Main Goole page");
            }
        }




    }
}

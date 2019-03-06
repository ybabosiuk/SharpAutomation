using NUnit.Framework;
using OpenQA.Selenium;
using SharpAutotests.Factories;
using SharpAutotests.Helpers;
using SharpAutotests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SharpAutotests.Steps
{
    [Binding]
    public class W3SchoolsSteps
    {
        private static readonly IWebDriver driver;
        SimpleTableHelper tableHelper;

        public W3SchoolsSteps(IWebDriver driver)
        {
        }

        [Given(@"I go to w3schools page")]
        public void GivenIGoToWschoolsPage()
        {
            driver.Url = "https://www.w3schools.com/html/html_tables.asp";
        }

        [When(@"I get simple table")]
        public void WhenIGetSimpleTable()
        {
            var schoolPage = Init.GetPageObject(driver).CreateInstance<SchoolTablePage>();

            tableHelper = new SimpleTableHelper();
            tableHelper.ReadTable(schoolPage.Table);

        }

        string result;

        [When(@"I pick (.*) row in '(.*)' column")]
        public void WhenIPickRowInColumn(int row, string columnName)
        {
            result = tableHelper.ReadCell(columnName, row);
        }

        [Then(@"text in cell is '(.*)'")]
        public void ThenTextInCellIs(string expectedValue)
        {
            Assert.AreEqual(result, expectedValue);
        }


    }
}
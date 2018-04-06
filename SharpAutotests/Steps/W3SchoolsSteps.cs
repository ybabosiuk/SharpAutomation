using NUnit.Framework;
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
        SimpleTableHelper tableHelper;

        [Given(@"I go to w3schools page")]
        public void GivenIGoToWschoolsPage()
        {
            WebDriverFactory.Driver.Url = "https://www.w3schools.com/html/html_tables.asp";
            LogHelpers.Write("Browser is opened");
        }

        [When(@"I get simple table")]
        public void WhenIGetSimpleTable()
        {
            var schoolPage = Init.PageFactory.CreateInstance<SchoolTablePage>();

            tableHelper = new SimpleTableHelper();
            tableHelper.ReadTable(schoolPage.Table);

        }

        string result;

        [When(@"I pick (.*) row in ""(.*)"" column")]
        public void WhenIPickRowInColumn(int row, string columnName)
        {
            result = tableHelper.ReadCell(columnName, row);
        }

        [Then(@"text in cell is ""(.*)""")]
        public void ThenTextInCellIs(string expectedValue)
        {
            Assert.AreEqual(result, expectedValue);
        }


    }
}
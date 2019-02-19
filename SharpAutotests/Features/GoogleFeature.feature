Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: 1. Go to Google and search some text
    Given user go to Google page
    When I add '<text>' to search field
    And I click on Search button
    Then list with results is not empty
	Examples: 
	| text    |
	| SpecFlow|
	| Cucumber|

Scenario: 2. Search some text in Google and verify search result on Results Page
    Given user go to Google page
    When I search 'SpecFlow' query on Google Page
	Then I verfiy that a search result contains keyword 'SpecFlow' on Results Page

Scenario: 3. Check search results count on Result Page
    Given user go to Google page
    When I search 'SpecFlow' query on Google Page
	Then I verfiy that a search results count to 10 on Results Page

Scenario: 4. Check search results count on Result Page
    Given user go to Google page
    When I search 'SpecFlow' query on Google Page
	Then I verfiy that a first search result contains sublinks on Results Page:
	| SubLinkText                   |
	| Getting Started               |
	| SpecFlow Documentation        |
	| SpecFlow 3 with .Net Core ... |
	| Training                      |
	
	
	
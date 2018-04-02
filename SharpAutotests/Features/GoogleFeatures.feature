Feature: Go to Google

Scenario: Go to Google and add some text
	Given user go to Google page
	When I add "Some cool video" to search field
	And I click on Search button

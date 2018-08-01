Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Go to Google and add some text
    Given user go to Google page
    When I add "Some cool video" to search field
    And I click on Search button
    Then list with results is not empty


Scenario: Go to Google and add some text1
    Given user go to Google page
    When I add "Some cool video" to search field
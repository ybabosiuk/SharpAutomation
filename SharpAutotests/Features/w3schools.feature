Feature: w3schools
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I go to w3schools page
	When I get simple table
	And I pick 3 row in 'Company' column 
	Then text in cell is 'Ernst Handel'




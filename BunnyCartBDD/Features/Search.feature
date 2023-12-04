Feature: Search

Search for a product

@Product_Search
Scenario Outline: Search for products
	Given User will be on the homepage
	When User will type the '<searchtext>' in the searchbox
	* User clicks on enter button
	Then Search results are loaded in the same page with '<searchtext>'
Examples:
	| searchtext |
	| water      |
	| java       |
	| hairgrass  |

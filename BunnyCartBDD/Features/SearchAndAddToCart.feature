Feature: SearchAndAddToCart

Search for a product and add to cart

@E2E_Search_AddToCart
Scenario: 01 Search
	Given User will be on the homepage
	When User will type the '<searchtext>' in the searchbox
	* User clicks on enter button
	Then Search results are loaded in the same page with '<searchtext>'
	* The title should have'<searchtext>'
Examples:
	| searchtext |
	| water      |

@E2E_Search_AddToCart
Scenario Outline: 02 Select a particular product
	When User selects a '<product>'
	Then Product page should be loaded with '<product>'
Examples:
	| product       |
	| Water Poppy   |
	#| Water Lettuce |



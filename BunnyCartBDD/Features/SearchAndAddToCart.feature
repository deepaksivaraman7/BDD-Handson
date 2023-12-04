Feature: SearchAndAddToCart

Search for a product and add to cart

@E2E_Search_AddToCart
Scenario: Search
	Given User will be on the homepage
	When User will type the '<searchtext>' in the searchbox
	* User clicks on enter button
	Then Search results are loaded in the same page with '<searchtext>'

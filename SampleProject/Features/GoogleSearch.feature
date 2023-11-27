Feature: GoogleSearch

To perform search operations on google home page

@tag1
Scenario: To perform search with Google search button
	Given Google Homepage should be loaded
	When Type "hp laptop" in the search text input
	And Click on the Google Search button
	Then The results should be displayed on the next page with title "hp laptop - Google Search"
Scenario: To perform search with I'm feeling lucky button
	Given Google Homepage should be loaded
	When Type "hp laptop" in the search text input
	And Click on the I'm feeling lucky button
	Then The results should be displayed on the next page with title containing "HP Laptops"

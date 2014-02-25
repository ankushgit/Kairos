Feature: Add Opportunity
	As a Sales Manager
	I want to Add Opportunity
	So that we have record of all opportunities

Scenario: Add Valid Opportunity
Given I am on Opportunities Screen
When I click on Create New Button
	And enter valid data on the form
	And click Save button
Then I am on Opportunities Screen
	And the newly added opportunity is listed at the top

Scenario: Add Opportunity without Client
Given I am on Opportunities Screen
When I click on Create New Button
	And enter valid data on the form but leave client field blank
Then the save button should be disabled

# There will be more scenarios required to ensure decent coverage
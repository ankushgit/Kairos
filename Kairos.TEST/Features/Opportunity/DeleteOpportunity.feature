Feature: Delete Opportunity
	As a Sales Manager
	I want to be able to Delete Opportunity
	So that I have up to date records

Scenario: Delete Opportunity
Given I am on Opportunities Screen
When I click on Delete Opportunity link
And I click yes on the Delete Confirmation
Then the opportunity should be deleted

Scenario: Dont Delete Opportunity
Given I am on Opportunities Screen
When I click on Delete Opportunity link
And I click no on the Delete Confirmation
Then the opportunity should not be deleted

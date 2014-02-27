Feature: Edit Opportunity
	As a Sales Manager
	I want to be able to Edit Opportunity
	So that I have up to date record of opportunities

Scenario: View Edit Opportunity Screen
Given I am on Opportunities Screen
When I click Edit Opportunity link
Then the relevant record should be shown in edit mode

Scenario: Edit Opportunity and Save
Given I am on Opportunities Screen
When I click Edit Opportunity link
	And change the opportunity data on the form
	And press save on the edited opportunity
Then I am on Opportunities Screen
	And the edited Opportunity is listed on the screen
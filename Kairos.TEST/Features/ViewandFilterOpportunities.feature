Feature: View and Filter Opportunities
	As a Sales Manager
	I want to View and Filter Opportunities
	So that I can work on them

Scenario: View All Opportunities
Given I am on Opportunities Screen
Then I should see the list of all opportunities

Scenario: Filter Opportunties
Given I am on Opportunities Screen
When I type "private" as the filter criteria
Then I should see 5 opportunities

#There will be more scenarios required to ensure decent coverage

# Features can be written by BA
# But there will be some confusion around who writes Scenarios
# BA's - will be more focussed in covering business scenarios and may miss out on test scenarios
# Testers - can write business and test scenarios but may not be technically competent enough around the "coding" side of it
# Developers - Will be able to handle the coding aspects better and can include the business scenarios provided by BA. 
#			   But coverage can be an issue as they may not be able to envisage all scenarios as good as a tester can.  
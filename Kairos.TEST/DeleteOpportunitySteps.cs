using System;
using TechTalk.SpecFlow;

namespace Kairos.TEST
{
    [Binding]
    public class DeleteOpportunitySteps
    {
        [When(@"I click on Delete Opportunity link")]
public void WhenIClickOnDeleteOpportunityLink()
{
    ScenarioContext.Current.Pending();
}

        [When(@"I click yes on the Delete Confirmation")]
public void WhenIClickYesOnTheDeleteConfirmation()
{
    ScenarioContext.Current.Pending();
}

        [Then(@"the opportunity should be deleted")]
public void ThenTheOpportunityShouldBeDeleted()
{
    ScenarioContext.Current.Pending();
}
    }
}

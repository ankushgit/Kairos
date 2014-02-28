using Kairos.AUTOMATION;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            OpportunityPage.DeleteOpportunity();
        }

        [When(@"I click yes on the Delete Confirmation")]
        public void WhenIClickYesOnTheDeleteConfirmation()
        {
            OpportunityPage.ConfirmDeletion();
        }

        [Then(@"the opportunity should be deleted")]
        public void ThenTheOpportunityShouldBeDeleted()
        {
            Assert.IsTrue(OpportunityPage.OpportunityDeleted, "Delete Opportunity Failed");
        }

        [When(@"I click no on the Delete Confirmation")]
        public void WhenIClickNoOnTheDeleteConfirmation()
        {
            OpportunityPage.CancelDeletion();
            
        }

        [Then(@"the opportunity should not be deleted")]
        public void ThenTheOpportunityShouldNotBeDeleted()
        {
            Assert.IsTrue(!OpportunityPage.OpportunityDeleted, "This opportunity should not have been deleted");
        }

    }
}

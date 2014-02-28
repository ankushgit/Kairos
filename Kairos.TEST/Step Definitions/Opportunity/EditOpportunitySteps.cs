using Kairos.AUTOMATION;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace Kairos.TEST.Step_Definitions
{
    [Binding]
    public class EditOpportunitySteps
    {
        [When(@"I click Edit Opportunity link")]
        public void WhenIClickEditOpportunityLink()
        {
            OpportunityPage.EditOpportunity();
        }

        [When(@"change the opportunity data on the form")]
        public void WhenChangeTheOpportunityDataOnTheForm()
        {
            OpportunityPage.EditData();
        }

        [When(@"press save on the edited opportunity")]
        public void WhenPressSaveOnTheEditedOpportunity()
        {
            OpportunityPage.Save();
        }

        [Then(@"the relevant record should be shown in edit mode")]
        public void ThenTheRelevantRecordShouldBeShownInEditMode()
        {
            Assert.IsTrue(OpportunityPage.ShowingEditedRecord, "Error showing record in edit mode");
        }

        [Then(@"the edited Opportunity is listed on the screen")]
        public void ThenTheEditedOpportunityIsListedOnTheScreen()
        {
            Assert.IsTrue(OpportunityPage.EditedOpportunitySaved, "Error saving edited opportunity");
        }
    }
}

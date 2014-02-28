using Kairos.AUTOMATION;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace Kairos.TEST
{
    [Binding]
    public class AddOpportunitySteps
    {
        [When(@"I click on Create New Button")]
        public void WhenIClickOnCreateNewButton()
        {
            OpportunityPage.CreateNew();
        }

        [When(@"enter valid data on the form")]
        public void WhenEnterValidDataOnTheForm()
        {
            OpportunityPage.FillForm();
        }

        [When(@"click Save button")]
        public void WhenClickSaveButton()
        {
            OpportunityPage.Save();
        }

        [When(@"enter valid data on the form but leave client field blank")]
        public void WhenEnterValidDataOnTheFormButLeaveClientFieldBlank()
        {
            OpportunityPage.FillForm(Fill.NonMandatoryOnly);
        }

        [Then(@"I am on Opportunities Screen")]
        public void ThenIAmOnOpportunitiesScreen()
        {
            Assert.IsTrue(OpportunityPage.IsAt, "Error Navigating back to Opportunity Screen");
        }

        [Then(@"the newly added opportunity is listed at the top")]
        public void ThenTheNewlyAddedOpportunityIsListedAtTheTop()
        {
            Assert.IsTrue(OpportunityPage.OpportunityAdded, "Error in Creating New Opportunity");
        }

        [Then(@"the save button should be disabled")]
        public void ThenTheSaveButtonShouldBeDisabled()
        {
            Assert.IsTrue(OpportunityPage.SaveDisabled, "Test Failed as Save button is Not Disabled");
        }
    }
}

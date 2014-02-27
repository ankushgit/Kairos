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
            ScenarioContext.Current.Pending();
        }

        [When(@"enter valid data on the form")]
        public void WhenEnterValidDataOnTheForm()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"click Save button")]
        public void WhenClickSaveButton()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"enter valid data on the form but leave client field blank")]
        public void WhenEnterValidDataOnTheFormButLeaveClientFieldBlank()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I am on Opportunities Screen")]
        public void ThenIAmOnOpportunitiesScreen()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the newly added opportunity is listed at the top")]
        public void ThenTheNewlyAddedOpportunityIsListedAtTheTop()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the save button should be disabled")]
        public void ThenTheSaveButtonShouldBeDisabled()
        {
            ScenarioContext.Current.Pending();
        }
    }
}

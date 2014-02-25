using System;
using TechTalk.SpecFlow;

namespace Kairos.TEST
{
    [Binding]
    public class ViewAndFilterOpportunitiesSteps
    {
        [Given(@"I am on Opportunities Screen")]
        public void GivenIAmOnOpportunitiesScreen()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I type ""(.*)"" as the filter criteria")]
        public void WhenITypeAsTheFilterCriteria(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should see the list of all opportunities")]
        public void ThenIShouldSeeTheListOfAllOpportunities()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should see (.*) opportunities")]
        public void ThenIShouldSeeOpportunities(int p0)
        {
            ScenarioContext.Current.Pending();
        }

    }
}

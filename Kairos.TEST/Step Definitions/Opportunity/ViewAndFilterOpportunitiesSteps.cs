using Kairos.AUTOMATION;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            OpportunityPage.GoTo();
        }

        [When(@"I type ""(.*)"" as the filter criteria")]
        public void WhenITypeAsTheFilterCriteria(string p0)
        {
            OpportunityPage.EnterFilterCriteria(p0);
        }

        [Then(@"I should see the list of all opportunities")]
        public void ThenIShouldSeeTheListOfAllOpportunities()
        {
            Assert.IsTrue(OpportunityPage.AllOpportunitiesListed,"Error getting all opportunities");
        }

        [Then(@"I should see (.*) opportunities")]
        public void ThenIShouldSeeOpportunities(int p0)
        {
            Assert.IsTrue(OpportunityPage.CountsMatch(p0), "Error Filtering Opportunities");
        }

    }
}

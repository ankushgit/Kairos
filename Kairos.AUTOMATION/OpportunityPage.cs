using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kairos.AUTOMATION
{
    public static class OpportunityPage
    {
        public static void GoTo()
        {            
            Driver.Instance.Navigate().GoToUrl("http://localhost:49768/#/opportunities");
        }

        public static bool AllOpportunitiesListed
        { 
            get 
            {
                /*
                 * Check whether the ID of the top most row listed in the resulting table is 10
                 */
                var element = Driver.Instance.FindElement
                    (By.XPath("/html/body/div/div/div[4]/div/table/tbody/tr[1]/td[1]"));
                return element.Text == "10";
            } 
        }

        public static void EnterFilterCriteria(string filter)
        {
            var element = Driver.Instance.FindElement(By.Name("inputSearch"));
            element.SendKeys(filter);
        }

        public static bool CountsMatch(int targetCount)
        {
            //Find the TBody element of the table
            //and count all the rows within it, they should match
            //the target count.
            var element = Driver.Instance.FindElement(
                By.XPath("/html/body/div/div/div[4]/div/table/tbody"));
            return element.FindElements(By.TagName("tr")).Count == targetCount;
        }
    }
}

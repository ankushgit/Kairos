using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kairos.AUTOMATION
{
    public static class OpportunityPage
    {
        #region ELEMENTS
        private static class AREAS
        {
            public static string TableBody { get { return "/html/body/div/div/div[4]/div/table/tbody"; } }
            public static string Title { get { return "/html/body/div/div/div[1]/div/table/tbody/tr/td[1]/h4"; } }
            public static string FirstRowClient { get { return "/html/body/div/div/div[4]/div/table/tbody/tr[1]/td[2]"; } }
            public static string FirstRowID { get { return "/html/body/div/div/div[4]/div/table/tbody/tr[1]/td[1]"; } }
            public static string DelDialog { get { return "deleteOppDialog"; } }
        }
        private static class INPUTS
        {
            public static string AddClient { get { return "addOppClient"; } }
            public static string AddDescription { get { return "addOppDescription"; } }
            public static string AddSector { get { return "addOppSector"; } }
            public static string AddPrimaryContact { get { return "addOppPrimaryContact"; } }
            public static string AddTelno { get { return "addOppTelno"; } }

            public static string EditClient { get { return "editOppClient"; } }
            public static string EditDescription { get { return "editOppDescription"; } }
            public static string EditSector { get { return "editOppSector"; } }
            public static string EditPrimaryContact { get { return "editOppPrimaryContact"; } }
            public static string EditTelno { get { return "editOppTelno"; } }

            public static string Search { get { return "inputSearch"; } }
        }
        private static class ACTIONS
        {
            public static string SaveOpportunity { get { return "saveOpportunity"; } }
            public static string EditTopMostOpportunity { get {return "/html/body/div/div/div[4]/div/table/tbody/tr[1]/td[6]/a";}}
            public static string CreateNew { get { return "createNew"; } }
            public static string DeleteTopMostOpportunity { get { return "/html/body/div/div/div[4]/div/table/tbody/tr[1]/td[7]/button"; } }

            public static string ConfirmDelete { get { return "confirmDelete"; } }
            public static string CancelDelete { get { return "cancelDelete"; } }
        }
        #endregion

        public static void GoTo()
        {            
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "#/opportunities");
        }

        public static bool AllOpportunitiesListed
        { 
            get 
            {
                /*
                 * Check whether there are more than one rows in the table
                 */
                var element = Driver.Instance.FindElement(
                By.XPath(AREAS.TableBody));
                return element.FindElements(By.TagName("tr")).Count >= 1;
            } 
        }

        public static bool IsAt
        {
            get
            {
                var element = Driver.Instance.FindElement(By.XPath(AREAS.Title));
                return element.Text == "Manage Opportunities";
            }
        }

        public static bool OpportunityAdded
        {
            get
            {                             
                //Stale Element exception here
                var element = Driver.Instance.FindElement(By.XPath(AREAS.FirstRowClient));
                string val = "";
                try 
                { 
                    val = element.Text;
                }
                catch(StaleElementReferenceException)
                {
                    element = Driver.Instance.FindElement(By.XPath(AREAS.FirstRowClient));
                    val = element.Text;
                }
                return val == "Auto Client";
            }
        }

        public static bool SaveDisabled
        {
            get
            {
                var element = Driver.Instance.FindElement(By.Name(ACTIONS.SaveOpportunity));
                return element.GetAttribute("disabled") == "true";
            }
        }

        public static bool ShowingEditedRecord
        {
            get
            {
                var element = Driver.Instance.FindElement(By.Id(INPUTS.EditClient));
                return element.GetAttribute("value") == editClientValue && element.GetAttribute("disabled") == null;
            }
        }

        public static bool EditedOpportunitySaved
        {
            get
            {
                var element = Driver.Instance.FindElement(By.XPath(AREAS.FirstRowClient));
                return element.Text == "Edited Client";
            }
        }

        public static bool OpportunityDeleted
        {
            get
            {                
                Driver.Wait(1000);
                //The wait is included above because the element that is removed from the list
                //once the opportunity is deleted may be inprocess of getting removed when this code
                //is executed... we dont want to select that element so the wait here will let it be removed
                //Stale Element Exception here
                var element = Driver.Instance.FindElement(By.XPath(AREAS.FirstRowID));
                string val = "";
                try
                {
                    val = element.Text;
                }
                catch (StaleElementReferenceException)
                {
                    element = Driver.Instance.FindElement(By.XPath(AREAS.FirstRowID));
                    val = element.Text;
                }
                return val != deleteID.ToString();
            }
        }

        public static void EnterFilterCriteria(string filter)
        {
            var element = Driver.Instance.FindElement(By.Name(INPUTS.Search));
            element.SendKeys(filter);
        }

        public static bool CountsMatch(int targetCount)
        {
            //Find the TBody element of the table
            //and count all the rows within it, they should match
            //the target count.
            var element = Driver.Instance.FindElement(
                By.XPath(AREAS.TableBody));
            return element.FindElements(By.TagName("tr")).Count == targetCount;
        }

        public static void CreateNew()
        {
            var element = Driver.Instance.FindElement(By.Name(ACTIONS.CreateNew));
            element.Click();
        }

        static string editClientValue;
        public static void EditOpportunity()
        {
            var elementClient = Driver.Instance.FindElement(By.XPath(AREAS.FirstRowClient));
            editClientValue = elementClient.Text;
            
            var element = Driver.Instance.FindElement(By.XPath(ACTIONS.EditTopMostOpportunity));
            element.Click();
        }

        public static void FillForm(Fill fields = Fill.All)
        {
            if(fields == Fill.All || fields == Fill.ManadatoryOnly)
            { 
                var clientInput = Driver.Instance.FindElement(By.Id(INPUTS.AddClient));
                clientInput.SendKeys("Auto Client");
            }

            var oppDesc = Driver.Instance.FindElement(By.Id(INPUTS.AddDescription));
            oppDesc.SendKeys("Auto Description");

            var oppSector = Driver.Instance.FindElement(By.Id(INPUTS.AddSector));
            oppSector.SendKeys("Auto Sector");

            var oppPrimaryContact = Driver.Instance.FindElement(By.Id(INPUTS.AddPrimaryContact));
            oppPrimaryContact.SendKeys("Auto Primary Contact");

            var oppTelno = Driver.Instance.FindElement(By.Id(INPUTS.AddTelno));
            oppTelno.SendKeys("Auto 12345");
        }

        public static void EditData()
        {
            var clientInput = Driver.Instance.FindElement(By.Id(INPUTS.EditClient));
            clientInput.Clear();
            clientInput.SendKeys("Edited Client");
            
            var oppDesc = Driver.Instance.FindElement(By.Id(INPUTS.EditDescription));
            oppDesc.Clear();
            oppDesc.SendKeys("Edited Description");

            var oppSector = Driver.Instance.FindElement(By.Id(INPUTS.EditSector));
            oppSector.Clear();
            oppSector.SendKeys("Edited Sector");

            var oppPrimaryContact = Driver.Instance.FindElement(By.Id(INPUTS.EditPrimaryContact));
            oppPrimaryContact.Clear();
            oppPrimaryContact.SendKeys("Edited Primary Contact");

            var oppTelno = Driver.Instance.FindElement(By.Id(INPUTS.EditTelno));
            oppTelno.Clear();
            oppTelno.SendKeys("Edited 12345");
        }

        public static void Save()
        {
            var element = Driver.Instance.FindElement(By.Name(ACTIONS.SaveOpportunity));
            element.Click();
        }
        static int deleteID;
        public static void DeleteOpportunity()
        {
            //get the id of the top most element
            var idElement = Driver.Instance.FindElement(By.XPath(AREAS.FirstRowID));
            deleteID = Convert.ToInt32(idElement.Text);
            var element = Driver.Instance.FindElement(By.XPath(ACTIONS.DeleteTopMostOpportunity));
            element.Click();
        }

        public static void ConfirmDeletion()
        {
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Id(AREAS.DelDialog)).GetCssValue("display") == "block");
            //Wait until the delete dialog is visible
            var element = Driver.Instance.FindElement(By.Name(ACTIONS.ConfirmDelete));
            element.Click();
        }

        public static void CancelDeletion()
        {
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Id(AREAS.DelDialog)).GetCssValue("display") == "block");
            //wait until the delete dialog is visible
            var element = Driver.Instance.FindElement(By.Name(ACTIONS.CancelDelete));
            element.Click();            
        }
    }
}

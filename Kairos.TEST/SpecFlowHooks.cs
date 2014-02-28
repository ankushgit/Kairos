using Kairos.AUTOMATION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Kairos.TEST
{
    [Binding]
    class SpecFlowHooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Driver.Initialise();
            System.Diagnostics.Debug.WriteLine("Before Test Run");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Driver.Close();
            
            System.Diagnostics.Debug.WriteLine("After Test Run");
        }
    }
}

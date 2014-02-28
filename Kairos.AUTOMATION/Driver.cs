using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kairos.AUTOMATION
{
    /// <summary>
    /// Singleton Driver
    /// </summary>
    public static class Driver
    {
        private const int TIMEOUT = 300; //seconds
        public static IWebDriver Instance { get; set; }

        public static void Initialise()
        {
            Instance = new ChromeDriver();
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(TIMEOUT));
            //TIP: Above line is very important to allow time for application to fetch data etc..                    
            //I would recommend a high value as we dont want to fail due to timeout
        }

        public static void Close()
        {
            Instance.Close();
            Instance.Dispose();            
        }

        public static void Wait(int milliSeconds)
        {
            Thread.Sleep(milliSeconds);
        }
    }
}

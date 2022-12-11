using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework
{
    internal class ReporterSingleton
    {

        private static ReporterSingleton instance;
        private ExtentReports extent;
        private string reportsDirectory = ConfigurationManager.AppSettings["ReportsDirectory"];
        private ReporterSingleton() 
        {
            extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(reportsDirectory + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);
        }

        public static ReporterSingleton GetInstance()
        {
            if(instance == null)
            {
                instance = new ReporterSingleton();
            }
            return instance;

        }

        public ExtentTest CreateTest(string testNumber, string description)
        {
            return extent.CreateTest(testNumber).Info(description);
        }

        public void Flush()
        {
            extent.Flush(); 
        }
    }
}

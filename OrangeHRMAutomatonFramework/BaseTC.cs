using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Configuration;

namespace OrangeHRMAutomatonFramework
{
    [TestClass]
    public class BaseTC
    {
        private TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        public static ExtentReports extent;
        protected static string reportsDirectory = ConfigurationManager.AppSettings["ReportsDirectory"] + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + @"\";

        [AssemblyInitialize]
        public static void Initialize(TestContext testContext)
        {
            extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(reportsDirectory);
            extent.AttachReporter(htmlreporter);
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            extent.Flush();
        }
    }
}

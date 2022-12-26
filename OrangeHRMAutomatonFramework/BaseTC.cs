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
using OrangeHRMAutomatonFramework.Logger;

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
        
        [AssemblyInitialize]
        public static void Initialize(TestContext testContext)
        {
            Log.Initialize();
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            Log.Flush();
        }
    }
}

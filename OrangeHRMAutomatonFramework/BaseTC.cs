using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework
{
    public class BaseTC
    {
        private TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }
    }
}

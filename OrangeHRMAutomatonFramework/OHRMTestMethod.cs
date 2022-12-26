using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrangeHRMAutomatonFramework.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework
{
    public class OHRMTestMethod : TestMethodAttribute
    {
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            TestResult[] results = base.Execute(testMethod);

            foreach (TestResult result in results)
            {
                if (result.Outcome == UnitTestOutcome.Failed)
                {
                    Log.Fail(result.TestFailureException.Message);
                }
            }

            return results;
        }
    }
}

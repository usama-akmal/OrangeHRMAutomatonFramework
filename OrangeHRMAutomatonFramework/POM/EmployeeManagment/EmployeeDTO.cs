using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.POM.EmployeeManagment
{
    public class EmployeeDTO
    {
        public string firstName
        {
            get
            {
                return TestContext.DataRow["firstName"].ToString();
            }
        }
        public string middleName
        {
            get
            {
                return TestContext.DataRow["middleName"].ToString();
            }
        }

        public string lastName
        {
            get
            {
                return TestContext.DataRow["lastName"].ToString();
            }
        }

        public string employeeId { get; set; }

        public string joinedDate
        {
            get
            {
                return TestContext.DataRow["joinedDate"].ToString();
            }
        }

        private TestContext TestContext;
        public EmployeeDTO(TestContext TestContext)
        {
            {
                this.TestContext = TestContext;
            }
        }
    }
}

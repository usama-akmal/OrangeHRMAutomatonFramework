using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public string image
        {
            get
            {
                return TestContext.DataRow["image"].ToString();
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

        public string location
        {
            get
            {
                return TestContext.DataRow["location"].ToString();
            }
        }

        public string dateOfBirth
        {
            get
            {
                return TestContext.DataRow["dateOfBirth"].ToString();
            }
        }

        public string maritalStatus
        {
            get
            {
                return TestContext.DataRow["maritalStatus"].ToString();
            }
        }

        public Regex gender
        {
            get
            {
                return new Regex(TestContext.DataRow["gender"].ToString());
            }
        }

        public string nationality
        {
            get
            {
                return TestContext.DataRow["nationality"].ToString();
            }
        }

        public string drivingLicenseNumber
        {
            get
            {
                return TestContext.DataRow["drivingLicenseNumber"].ToString();
            }
        }

        public string licenseExpiryDate
        {
            get
            {
                return TestContext.DataRow["licenseExpiryDate"].ToString();
            }
        }

        public string permanencyDate
        {
            get
            {
                return TestContext.DataRow["permanencyDate"].ToString();
            }
        }

        public Regex jobTitle
        {
            get
            {
                return new Regex(TestContext.DataRow["jobTitle"].ToString());
            }
        }

        public string employementStatus
        {
            get
            {
                return TestContext.DataRow["employementStatus"].ToString();
            }
        }

        public string jobCategory
        {
            get
            {
                return TestContext.DataRow["jobCategory"].ToString();
            }
        }

        public Regex subUnit
        {
            get
            {
                return new Regex(TestContext.DataRow["subUnit"].ToString());
            }
        }

        public string workShift
        {
            get
            {
                return TestContext.DataRow["workShift"].ToString();
            }
        }

        public string comments
        {
            get
            {
                return TestContext.DataRow["comments"].ToString();
            }
        }

        public bool includeContractDetails
        {
            get
            {
                return TestContext.DataRow["includeContractDetails"].ToString().Equals("true");
            }
        }

        public string contractStartDate
        {
            get
            {
                return TestContext.DataRow["contractStartDate"].ToString();
            }
        }

        public string contractEndDate
        {
            get
            {
                return TestContext.DataRow["contractEndDate"].ToString();
            }
        }

        public string region
        {
            get
            {
                return TestContext.DataRow["region"].ToString();
            }
        }

        public string fte
        {
            get
            {
                return TestContext.DataRow["fte"].ToString();
            }
        }

        public string temporartDepartment
        {
            get
            {
                return TestContext.DataRow["temporartDepartment"].ToString();
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

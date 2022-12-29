using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.POM.HRManagement
{
    public class UserDTO
    {
        public string name
        {
            get
            {
                return TestContext.DataRow["name"].ToString();
            }
        }

        public string username
        {
            get
            {
                return TestContext.DataRow["username"].ToString();
            }
        }

        public string essRole
        {
            get
            {
                return TestContext.DataRow["essRole"].ToString();
            }
        }

        public string supervisorRole
        {
            get
            {
                return TestContext.DataRow["supervisorRole"].ToString();
            }
        }

        public string adminRole
        {
            get
            {
                return TestContext.DataRow["adminRole"].ToString();
            }
        }

        public bool status
        {
            get
            {
                return TestContext.DataRow["status"].ToString().Equals("true");
            }
        }

        public string password
        {
            get
            {
                return TestContext.DataRow["password"].ToString();
            }
        }

        public string[] regions
        {
            get
            {
                return TestContext.DataRow["regions"].ToString().Split(',');
            }
        }

        private TestContext TestContext;
        public UserDTO(TestContext TestContext)
        {
            {
                this.TestContext = TestContext;
            }
        }
    }
}

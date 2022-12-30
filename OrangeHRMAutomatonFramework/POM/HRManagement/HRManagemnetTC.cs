using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrangeHRMAutomatonFramework.Logger;
using OrangeHRMAutomatonFramework.POM.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.POM.HRManagement
{
    [TestClass]
    public class HRManagemnetTC : BaseTC
    {
        [Priority(3)]
        [TestCategory("HRManagemnet"), TestCategory("AddUser")]
        [OHRMTestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddUser", DataAccessMethod.Sequential)]
        public async Task AddUser()
        {
            Log.CreateTest("T0006", "Create New User");
            string username = TestContext.DataRow["portalUsername"].ToString();
            string password = TestContext.DataRow["portalPassword"].ToString();
            LoginPage loginPage = new LoginPage();
            await loginPage.PerformLogin(username, password);

            HRManagementPage hrmPage = new HRManagementPage();
            await hrmPage.AddUser(new UserDTO(TestContext));

            await loginPage.PerformLogout();

            Log.Pass("Test Passed");
        }
    }
}

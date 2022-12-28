using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrangeHRMAutomatonFramework.Logger;
using OrangeHRMAutomatonFramework.POM.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.POM.EmployeeManagment
{
    [TestClass]
    public class EmployeeManagementTC: BaseTC
    {

        [TestCategory("EmployeeManagement"), TestCategory("AddEmployee")]
        [OHRMTestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddEmployee", DataAccessMethod.Sequential)]
        public async Task AddEmployee()
        {
            Log.CreateTest("T0005", "Create New Employee");
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            LoginPage loginPage = new LoginPage();
            await loginPage.PerformLogin(username, password);

            EmployeeManagementPage emPage = new EmployeeManagementPage();
            await emPage.AddEmpoyee(new EmployeeDTO(TestContext));

            await loginPage.PerformLogout();

            Log.Pass("Test Passed");
        }
    }
}

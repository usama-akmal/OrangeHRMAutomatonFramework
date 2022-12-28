using OrangeHRMAutomatonFramework.Logger;
using OrangeHRMAutomatonFramework.POM.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.POM.EmployeeManagment
{
    internal class EmployeeManagementPage: BasePage
    {
        private string employeeManagementPath = "client/#/pim/employees";

        public async Task Open()
        {
            Log.Info("EmployeeManagrmentPage.Open started", await TakeScreenshot(Log.reportsDirectory));
            await GoToUrl(employeeManagementPath);
            await WaitForUrl(employeeManagementPath);
            Log.Info("EmployeeManagrmentPage.Open completed", await TakeScreenshot(Log.reportsDirectory));
        }

        public async Task AddEmpoyee()
        {

        }

    }
}

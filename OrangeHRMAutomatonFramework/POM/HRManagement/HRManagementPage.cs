using OrangeHRMAutomatonFramework.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.POM.HRManagement
{
    internal class HRManagementPage: BasePage
    {
        private string hrManagementPath = "/client/#/pim/employees";

        public async Task Open()
        {
            Log.Info("HRManagementPage.Open started");
            await GoToUrl(hrManagementPath);
            await WaitForUrl(hrManagementPath);
            Log.Info("HRManagementPage.Open completed", await TakeScreenshot(Log.reportsDirectory));
        }

        public async Task AddUser()
        {

        }
    }
}

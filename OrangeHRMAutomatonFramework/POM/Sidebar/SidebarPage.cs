using OrangeHRMAutomatonFramework.Logger;
using OrangeHRMAutomatonFramework.POM.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.POM.Sidebar
{
    internal class SidebarPage: BasePage
    {
        private string dashboardPath = "/client/#/dashboard";

        public async Task Open()
        {
            Log.Info("SidebarPage.Open started", await TakeScreenshot(Log.reportsDirectory));
            await GoToUrl(dashboardPath);
            await WaitForUrl(dashboardPath);
            Log.Info("SidebarPage.Open completed", await TakeScreenshot(Log.reportsDirectory));
        }

        public async Task GoToHRManagment()
        {
            Log.Info("SidebarPage.GoToHRManagment started", await TakeScreenshot(Log.reportsDirectory));
            await Open();
            await Click(SidebarLocators.hrManagement);
            Log.Info("SidebarPage.GoToHRManagment completed", await TakeScreenshot(Log.reportsDirectory));
        }
    }
}

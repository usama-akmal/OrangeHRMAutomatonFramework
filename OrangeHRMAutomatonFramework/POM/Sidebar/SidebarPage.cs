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

        public async Task GoToModule(string module)
        {
            Log.Info($"SidebarPage.GoToModule started with module {module}", await TakeScreenshot(Log.reportsDirectory));
            await Open();
            if (module == "HR Administration")
            {
                await Click(SidebarLocators.hrManagement);
            }
            else if (module == "Employee Management")
            {
                await Click(SidebarLocators.employeeManagment);
            }
            
            Log.Info($"SidebarPage.GoToModule completed with module {module}", await TakeScreenshot(Log.reportsDirectory));
        }


    }
}

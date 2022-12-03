using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.DriverCostruction
{
    internal interface IBrowserBuilder
    {
        Task LaunchBrowserAsync();
        void CreateBrowserLaunchOptions();
        IPage GetPage();
        IBrowser GetBrowser();
    }
}

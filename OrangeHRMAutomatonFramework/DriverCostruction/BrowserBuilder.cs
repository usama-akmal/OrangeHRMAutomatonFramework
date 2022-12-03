using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.DriverCostruction
{
    internal class BrowserBuilder
    {
        private IBrowserBuilder builder;

        public BrowserBuilder(IBrowserBuilder builder)
        {
            this.builder = builder;
        }

        public async Task Build()
        {
            this.builder.CreateBrowserLaunchOptions();
            await this.builder.LaunchBrowserAsync();
        }

        public IPage GetPage()
        {
            return this.builder.GetPage();
        }
    }
}

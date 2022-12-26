using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.DriverCostruction
{
    internal class ChromeBuilder : IBrowserBuilder
    {
        public IPage page;
        public IBrowser browser;
        public IBrowserContext context;
        private BrowserTypeLaunchOptions options;
        private IPlaywright playwright;
        public ChromeBuilder(IPlaywright playwright)
        {
            this.playwright = playwright;
        }

        public async Task LaunchBrowserAsync()
        {
            this.browser = await playwright.Chromium.LaunchAsync(this.options);
            this.context = await this.browser.NewContextAsync();
            this.page = await this.context.NewPageAsync();
        }

        public void CreateBrowserLaunchOptions()
        {
            options = new BrowserTypeLaunchOptions() { Headless = false, Timeout = 60000};
            var headless = ConfigurationManager.AppSettings["Headless"];
            if(headless == "true")
            {
                options.Headless = true;
            }
        }

        public IPage GetPage()
        {
            return this.page;
        }

        public IBrowser GetBrowser()
        {
            return this.browser;
        }
    }
}

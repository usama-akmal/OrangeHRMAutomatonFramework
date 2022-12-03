using Microsoft.Playwright;
using OrangeHRMAutomatonFramework.DriverCostruction;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework
{
    internal class BasePage
    {
        protected BrowserBuilder browser;
        protected IPage page;
        public BasePage() 
        {
            this.browser =  BrowserManager.GetBrowser().Result;
            this.page = browser.GetPage();
        }

        public async Task GoToUrl(string url)
        {
            await this.page.GotoAsync(url);
        }

        public async Task<string> GetTitle()
        {
            return await this.page.TitleAsync();
        }

        public async Task Write(string locator, string text)
        {
            await this.page.Locator(locator).FillAsync(text);
        }

        public async Task Click(string locator)
        {
            await this.page.ClickAsync(locator);
        }

        public async Task TakeScreenshot(string path)
        {
            await this.page.ScreenshotAsync(new PageScreenshotOptions() { Path = path });
        }
    }
}

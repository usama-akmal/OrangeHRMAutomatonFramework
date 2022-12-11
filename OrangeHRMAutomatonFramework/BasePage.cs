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
        protected string logoutLocator = "#navbar-logout";

        protected string webBaseUrl = ConfigurationManager.AppSettings["WebBaseUrl"];

        protected BrowserBuilder browser;
        protected IPage page;
        public BasePage() 
        {
            this.browser =  BrowserManager.GetBrowser().Result;
            this.page = browser.GetPage();
        }

        public async Task GoToUrl(string path)
        {
            await this.page.GotoAsync(webBaseUrl + path);
        }

        public async Task<string> GetTitle()
        {
            return await this.page.TitleAsync();
        }

        public string GetUrl()
        {
            return this.page.Url;
        }

        public async Task WaitForUrl(string path)
        {
            await this.page.WaitForURLAsync(webBaseUrl + path);
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

        public async Task PerformLogout()
        {
            await Click(logoutLocator);
        }
    }
}

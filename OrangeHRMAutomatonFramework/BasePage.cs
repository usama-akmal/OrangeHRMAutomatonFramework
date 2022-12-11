using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrangeHRMAutomatonFramework.DriverCostruction;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrangeHRMAutomatonFramework
{
    internal class BasePage
    {
        protected string logoutLocator = "#navbar-logout > a > span";

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
            return this.page.Url.Substring(42);
        }

        public async Task WaitForUrl(string path)
        {
            await this.page.WaitForURLAsync(webBaseUrl + path);
        }

        private ILocator FindLocator(string locator)
        {
            return this.page.Locator(locator);
        }

        public async Task Write(string locator, string text)
        {
            await FindLocator(locator).FillAsync(text);
        }

        public async Task<string> GetText(string locator)
        {
            return await FindLocator(locator).TextContentAsync();
        }

        public async Task Click(string locator)
        {
            await this.page.ClickAsync(locator);
            await this.page.WaitForLoadStateAsync();
        }

        public async Task<string> TakeScreenshot(string directory)
        {
            string path = @"Screenshots\" + DateTime.Now.ToFileTimeUtc() + ".png";
            string completePath = directory + path;
            await this.page.ScreenshotAsync(new PageScreenshotOptions() { Path = completePath });
            return path;
        }

        public async Task PerformLogout()
        {
            await Click(logoutLocator);
        }
    }
}

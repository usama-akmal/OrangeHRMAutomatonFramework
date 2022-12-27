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
using OrangeHRMAutomatonFramework.Logger;
using System.Security.Cryptography;
using Microsoft.CodeAnalysis;

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
            Log.Info($"GoToUrl called with Endpoint[{webBaseUrl + path}]");
            await this.page.GotoAsync(webBaseUrl + path);
            await WaitForUrl(path);
        }

        public async Task<string> GetTitle()
        {
            var title = await this.page.TitleAsync();
            Log.Info($"BasePage.GetTitle called and Title[{title}]");
            return title;
        }

        public string GetUrl()
        {
            var url = this.page.Url.Substring(42);
            Log.Info($"BasePage.GetUrl called and current URL[{url}]");
            return url;
        }

        public async Task WaitForUrl(string path)
        {
            await this.page.WaitForURLAsync(webBaseUrl + path);
            Log.Info($"BasePage.WaitForUrl called Endpoint[{webBaseUrl + path}]");
        }

        private ILocator FindLocator(string locator)
        {
            Log.Info($"BasePage.FindLocator called with Locator[{locator}]");
            return this.page.Locator(locator);
        }

        public async Task Write(string locator, string text)
        {
            await FindLocator(locator).FillAsync(text);
            Log.Info($"BasePage.Write called on Locator[{locator}] and entered Value[{text}]");
        }

        public async Task<string> GetText(string locator)
        {
            var content = await FindLocator(locator).TextContentAsync();
            Log.Info($"BasePage.GetText called on Locator[{locator}] and found Content[{content}]");
            return content;
        }

        public async Task Click(string locator)
        {
            await this.page.ClickAsync(locator);
            await WaitForLoadState();
            Log.Info($"BasePage.Click called on Locator[{locator}]");
        }

        public async Task WaitForLoadState()
        {
            await this.page.WaitForLoadStateAsync();
            Log.Info("BasePage.WaitForLoadState called");
        }

        public async Task<string> TakeScreenshot(string directory)
        {
            string path = @"Screenshots\" + DateTime.Now.ToFileTimeUtc() + ".png";
            string completePath = directory + path;
            await this.page.ScreenshotAsync(new PageScreenshotOptions() { Path = completePath });
            Log.Info($"BasePage.TakeScreenshot called and screenshot saved at Path[{completePath}]");
            return path;
        }

        public async Task PerformLogout()
        {
            Log.Info("BasePage.PerformLogout called");
            await Click(logoutLocator);
        }
        public async Task ClearCookies()
        {
            await this.page.Context.ClearCookiesAsync();
            Log.Info("BasePage.ClearCookies called");
        }
    }
}

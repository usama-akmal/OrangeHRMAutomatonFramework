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
using System.Text.RegularExpressions;
using OrangeHRMAutomatonFramework.POM.EmployeeManagment;

namespace OrangeHRMAutomatonFramework
{
    internal class BasePage
    {
        protected string logoutLocator = "#navbar-logout > a > span";
        protected string trialToastMessageCloseButton = "#toast-container > div > button";
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
            var url = this.page.Url.Substring(48);
            Log.Info($"BasePage.GetUrl called and current URL[{url}]");
            return url;
        }

        public async Task WaitForUrl(string path)
        {
            await this.page.WaitForURLAsync(webBaseUrl + path);
            Log.Info($"BasePage.WaitForUrl called Endpoint[{webBaseUrl + path}]");
        }

        public async Task WaitForUrlUsingRegex(string path)
        {
            await this.page.WaitForURLAsync(new Regex(webBaseUrl + path));
            Log.Info($"BasePage.WaitForUrlUsingRegex called Endpoint[{webBaseUrl + path}]");
        }

        private ILocator FindLocator(string locator)
        {
            Log.Info($"BasePage.FindLocator called with Locator[{locator}]");
            return this.page.Locator(locator);
        }

        public async Task Write(string locator, string text, bool forced = false)
        {
            await FindLocator(locator).FillAsync(text, new LocatorFillOptions() { Force = forced });
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

        public async Task ClickUsingQuerySelector(string locator)
        {
            var node = await this.page.QuerySelectorAsync(locator);
            await node.EvaluateAsync("node => node.click()");
        }

        public async Task Click(string locator, string text)
        {
            await FindLocator(locator).Filter(new LocatorFilterOptions() { HasText = text }).ClickAsync();
            Log.Info($"BasePage.Click called on Locator[{locator}] with Text[{text}]");
        }

        public async Task Click(string locator, Regex text)
        {
            await FindLocator(locator).Filter(new LocatorFilterOptions() { HasTextRegex = text }).ClickAsync();
            Log.Info($"BasePage.Click called on Locator[{locator}] with Text[{text}]");
        }

        public async Task Focus(string locator)
        {
            await FindLocator(locator).FocusAsync();
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

        public async Task ChooseFile(string locator, string file)
        {
            var fileChooser = await page.RunAndWaitForFileChooserAsync(async () =>
            {
                await FindLocator(locator).ClickAsync();
            });
            await fileChooser.SetFilesAsync(file);
            Log.Info($"BasePage.ChooseFile called on Locator[{locator}] with File[{file}]");
        }

        public async Task Check(string locator, bool forced = false)
        {
            await FindLocator(locator).CheckAsync(new LocatorCheckOptions() { Force = forced});
            Log.Info("BasePage.Check called on Locator[{locator}]");
        }

        public async Task Uncheck(string locator, bool forced = false)
        {
            await FindLocator(locator).UncheckAsync(new LocatorUncheckOptions() { Force = forced });
            Log.Info("BasePage.Uncheck called on Locator[{locator}]");
        }

        public async Task Type(string locator, string text)
        {
            await FindLocator(locator).TypeAsync(text);
        }

        public async Task Type(string locator, string text, float delay)
        {
            await FindLocator(locator).TypeAsync(text, new LocatorTypeOptions() { Delay = delay });
        }

        public async Task CloseTrialToast()
        {
            await Click(trialToastMessageCloseButton);    
        }

        public async Task WaitForSelector(string locator)
        {
            await this.page.WaitForSelectorAsync(locator);
        }
    }
}

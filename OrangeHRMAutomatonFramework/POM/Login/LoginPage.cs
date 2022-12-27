using OrangeHRMAutomatonFramework.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.POM.Login
{
    internal class LoginPage : BasePage
    {
        private string loginPath = "/auth/login";

        public async Task Open()
        {
            Log.Info("LoginPage.Open started", await TakeScreenshot(Log.reportsDirectory));
            await GoToUrl(loginPath);
            await WaitForUrl(loginPath);
            Log.Info("LoginPage.Open completed", await TakeScreenshot(Log.reportsDirectory));
        }

        public async Task PerformLogin(string username, string password)
        {
            Log.Info("LoginPage.PerformLogin started", await TakeScreenshot(Log.reportsDirectory));
            await ClearCookies();
            await Open();
            await Write(LoginLocators.usernameLocator, username);
            await Write(LoginLocators.passwordLocator, password);
            await Click(LoginLocators.loginLocator);
            Log.Info("LoginPage.PerformLogin completed", await TakeScreenshot(Log.reportsDirectory));
        }

        public async Task PerformLoginAndWaitForUrl(string username, string password, string url)
        {
            Log.Info("LoginPage.PerformLoginAndWaitForUrl started");
            await PerformLogin(username, password);
            await WaitForUrl(url);
            Log.Info("LoginPage.PerformLoginAndWaitForUrl completed");
        }


        public async Task<string> GetValidationErrorMessage(string type)
        {
            Log.Info("LoginPage.GetValidationErrorMessage started");
            var message = await GetText(type == "username" ? LoginLocators.usernameErrorLocator : LoginLocators.passwordErrorLocator);
            Log.Info("LoginPage.GetValidationErrorMessage completed");
            return message;
        }
    }
}

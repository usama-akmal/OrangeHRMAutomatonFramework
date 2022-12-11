using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.POM.Login
{
    internal class LoginPage : BasePage
    {
        private string usernameLocator = "#txtUsername";
        private string passwordLocator = "#txtPassword";
        private string loginLocator = "#frmLogin > div.button-holder > button";
        private string usernameErrorLocator = "#txtUsername-error";
        private string passwordErrorLocator = "#txtPassword-error";

        public async Task PerformLogin(string username, string password)
        {
            await Write(this.usernameLocator, username);
            await Write(this.passwordLocator, password);
            await Click(loginLocator);
        }

        public async Task PerformLoginAndWaitForUrl(string username, string password, string url)
        {
            await this.PerformLogin(username, password);
            await WaitForUrl(url);
        }


        public async Task<string> GetValidationErrorMessage(string type)
        {
            return await GetText(type == "username" ? usernameErrorLocator: passwordErrorLocator);
        }
    }
}

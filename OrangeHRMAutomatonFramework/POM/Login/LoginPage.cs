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

        public async Task PerformLogin(string username, string password)
        {
            await GoToUrl("https://samaaa-trials77.orangehrmlive.com/");
            await Write(this.usernameLocator, username);
            await Write(this.passwordLocator, password);
            await Click(loginLocator);
        }
    }
}

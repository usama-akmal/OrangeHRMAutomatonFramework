using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.POM.Login
{
    [TestClass]
    public class LoginTestCases
    {
        [TestMethod]
        public async Task Login()
        {
            LoginPage loginPage = new LoginPage();
            await loginPage.PerformLogin("Admin", "IZOh97Rx@b");
        }
    }
}

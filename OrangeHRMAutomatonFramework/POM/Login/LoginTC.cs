using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.POM.Login
{
    [TestClass]
    public class LoginTC : BaseTC
    {
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "LoginWithValidCredentials", DataAccessMethod.Sequential)]
        public async Task LoginWithValidCredentials()
        {
            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string successUrl = TestContext.DataRow["successUrl"].ToString();
            string successTitle = TestContext.DataRow["successTitle"].ToString();
            LoginPage loginPage = new LoginPage();
            await loginPage.GoToUrl(url);
            await loginPage.PerformLoginAndWaitForUrl(username, password, successUrl);

            Assert.AreEqual(successUrl, loginPage.GetUrl());

            Assert.AreEqual(successTitle, await loginPage.GetTitle());

            await loginPage.PerformLogout();
        }


        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "LoginWithInvalidCredentials", DataAccessMethod.Sequential)]
        public async Task LoginWithInvalidCredentials()
        {
            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string invalidUrl = TestContext.DataRow["invalidUrl"].ToString();
            LoginPage loginPage = new LoginPage();
            await loginPage.GoToUrl(url);
            await loginPage.PerformLoginAndWaitForUrl(username, password, invalidUrl);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "LoginWithInvalidCredentials", DataAccessMethod.Sequential)]
        public async Task LoginWithEmptyCredentials()
        {
            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            LoginPage loginPage = new LoginPage();
            await loginPage.GoToUrl(url);
            await loginPage.PerformLogin(username, password);
        }
    }
}

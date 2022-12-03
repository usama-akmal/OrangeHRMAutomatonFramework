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
    public class LoginTestCases
    {

        private TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "LoginWithValidCredentials", DataAccessMethod.Sequential)]
        public async Task Login()
        {
            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string successUrl = TestContext.DataRow["successUrl"].ToString();
            string successTitle = TestContext.DataRow["successTitle"].ToString();
            LoginPage loginPage = new LoginPage();
            await loginPage.GoToUrl(url);
            await loginPage.PerformLogin(username, password, successUrl);

            Assert.AreEqual(successUrl, loginPage.GetUrl());

            Assert.AreEqual(successTitle, await loginPage.GetTitle());
        }
    }
}

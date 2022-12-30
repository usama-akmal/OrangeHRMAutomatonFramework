using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrangeHRMAutomatonFramework.Logger;
using OrangeHRMAutomatonFramework.POM.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.POM.Sidebar
{
    [TestClass]
    public class SidebarTC: BaseTC
    {
        [Priority(1)]
        [TestCategory("Sidebar"), TestCategory("HRManagment")]
        [OHRMTestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "OpenHRManagment", DataAccessMethod.Sequential)]
        public async Task OpenHRManagment()
        {
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string successUrl = TestContext.DataRow["successUrl"].ToString();
            string successTitle = TestContext.DataRow["successTitle"].ToString();
            Log.CreateTest("T0004", $"Open {successTitle} Module");
            Log.Info("Data Loaded");
            LoginPage loginPage = new LoginPage();
            await loginPage.PerformLogin(username, password);

            SidebarPage sidebarPage = new SidebarPage();

            await sidebarPage.GoToModule(successTitle);

            Assert.AreEqual(successUrl, loginPage.GetUrl());

            Log.Pass("Correct URL verification pass");

            Assert.AreEqual(successTitle, await loginPage.GetTitle());

            Log.Pass("Correct Title verification pass");

            await loginPage.PerformLogout();

            Log.Pass("Test passed");
        }
    }
}

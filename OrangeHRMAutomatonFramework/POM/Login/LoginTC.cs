using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrangeHRMAutomatonFramework.Logger;
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
        [TestCategory("Login"), TestCategory("ValidCredentials")]
        [OHRMTestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "LoginWithValidCredentials", DataAccessMethod.Sequential)]
        public async Task LoginWithValidCredentials()
        {
            Log.CreateTest("T0001", "Login With Valid Credentials");
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string successUrl = TestContext.DataRow["successUrl"].ToString();
            string successTitle = TestContext.DataRow["successTitle"].ToString();

            Log.Info("Data Loaded");
            LoginPage loginPage = new LoginPage();
            await loginPage.PerformLoginAndWaitForUrl(username, password, successUrl);

            Assert.AreEqual(successUrl, loginPage.GetUrl());

            Log.Pass("Correct URL verification pass");

            Assert.AreEqual(successTitle, await loginPage.GetTitle());
            
            Log.Pass("Correct Title verification pass");

            await loginPage.PerformLogout();

            Log.Pass("Test passed");
        }

        [TestCategory("Login"), TestCategory("InvalidCredentials")]
        [OHRMTestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "LoginWithInvalidCredentials", DataAccessMethod.Sequential)]
        public async Task LoginWithInvalidCredentials()
        {
            Log.CreateTest("T0002", "Login With Invalid Credentials");
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string invalidUrl = TestContext.DataRow["invalidUrl"].ToString();
            string invalidTitle = TestContext.DataRow["invalidTitle"].ToString();
            Log.Info("Data Loaded");
            LoginPage loginPage = new LoginPage();
            await loginPage.PerformLoginAndWaitForUrl(username, password, invalidUrl);

            Assert.AreEqual(invalidUrl, loginPage.GetUrl());

            Log.Pass("Correct URL verification pass");

            Assert.AreEqual(invalidTitle, await loginPage.GetTitle());

            Log.Pass("Correct Title verification pass");

            Log.Pass("Test passed");
        }

       
        [TestCategory("Login"), TestCategory("EmptyCredentials")]
        [OHRMTestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "LoginWithEmptyCredentials", DataAccessMethod.Sequential)]
        public async Task LoginWithEmptyCredentials()
        {
            
            Log.CreateTest("T0003", "Login Without Credentials");
            string username = TestContext.DataRow["username"].ToString();
            string usernameError = TestContext.DataRow["usernameError"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string passwordError = TestContext.DataRow["passwordError"].ToString();
            string title = TestContext.DataRow["title"].ToString();

            Log.Info("Data Loaded");
            LoginPage loginPage = new LoginPage();
            await loginPage.PerformLogin(username, password);
                
            if (username == "")
            {
                Assert.AreEqual(usernameError, await loginPage.GetValidationErrorMessage("username"));
                Log.Pass("Username Error Visible");
            }

            if (password == "")
            {
                Assert.AreEqual(passwordError, await loginPage.GetValidationErrorMessage("password"));
                Log.Pass("Password Error Visible");
            }

            Assert.AreEqual(title, await loginPage.GetTitle());

            Log.Pass("Correct Title verification pass");
            
            Log.Pass("Test passed");
        }
    }
}

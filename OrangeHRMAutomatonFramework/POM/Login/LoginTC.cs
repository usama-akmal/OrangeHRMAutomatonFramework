﻿using AventStack.ExtentReports;
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
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "LoginWithEmptyCredentials", DataAccessMethod.Sequential)]
        public async Task LoginWithEmptyCredentials()
        {
            var test = extent.CreateTest("T0001", "Login Without Credentials");
            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string usernameError = TestContext.DataRow["usernameError"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string passwordError = TestContext.DataRow["passwordError"].ToString();
            string title = TestContext.DataRow["title"].ToString();

            test.Log(Status.Info, "Data Loaded");
            LoginPage loginPage = new LoginPage();
            await loginPage.GoToUrl(url);
            test.Log(Status.Info, "Go To Url");
            await loginPage.PerformLogin(username, password);
            test.Log(Status.Info, "Perform Login");
            if(username == "")
            {
                Assert.AreEqual(usernameError, await loginPage.GetValidationErrorMessage("username"));
                test.Log(Status.Pass, "Username Error Visible");
            }

            if(password == "")
            {
                Assert.AreEqual(passwordError, await loginPage.GetValidationErrorMessage("password"));
                test.Log(Status.Pass, "Password Error Visible");
            }

            string path = await loginPage.TakeScreenshot(reportsDirectory);

            test.AddScreenCaptureFromPath(path);
           
            Assert.AreEqual(title, await loginPage.GetTitle());
            test.Log(Status.Pass, "Correct Title Visible");

        }
    }
}

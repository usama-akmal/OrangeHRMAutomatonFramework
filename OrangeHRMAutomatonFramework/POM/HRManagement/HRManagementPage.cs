﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrangeHRMAutomatonFramework.Logger;
using OrangeHRMAutomatonFramework.POM.EmployeeManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.POM.HRManagement
{
    internal class HRManagementPage: BasePage
    {
        private string hrManagementPath = "/client/#/admin/systemUsers";

        public async Task Open()
        {
            Log.Info("HRManagementPage.Open started");
            await GoToUrl(hrManagementPath);
            await WaitForUrl(hrManagementPath);
            Log.Info("HRManagementPage.Open completed", await TakeScreenshot(Log.reportsDirectory));
        }

        public async Task AddUser(UserDTO user)
        {
            Log.Info("HRManagementPage.AddEmpoyee started", await TakeScreenshot(Log.reportsDirectory));
            await Open();
            await CloseTrialToast();
            Thread.Sleep(30000);
            await WaitForSelector(HRManagementLocators.tableUsernameColumn);
            await Click(HRManagementLocators.addUserButton);
            await Type(HRManagementLocators.employeeNameInput, user.name, 100);
            await Write(HRManagementLocators.usernameInput, user.username);
            await Click(HRManagementLocators.essRoleDropdown);
            await Click(HRManagementLocators.essRoleItemsInDropdown, user.essRole);
            await Click(HRManagementLocators.supvisorRoleDropdown);
            await Click(HRManagementLocators.supvisorRoleItemsInDropdown, user.supervisorRole);
            await Click(HRManagementLocators.adminRoleDropdown);
            await Click(HRManagementLocators.adminRoleItemsInDropdown, user.adminRole);
            await Check(HRManagementLocators.enabledRadioButton);
            await Type(HRManagementLocators.passwordInput, user.password, 100);
            await Type(HRManagementLocators.confirmPasswordInput, user.password, 100);
            Log.Info("HRManagementPage.AddEmpoyee user details added", await TakeScreenshot(Log.reportsDirectory));
            await Click(HRManagementLocators.saveButton);
            string toastMessage = await GetText(HRManagementLocators.successToastMessage);
            Assert.AreEqual("Successfully Saved", toastMessage);
            Log.Pass("Add User Pass");
            Log.Info("HRManagementPage.AddEmpoyee user regions set", await TakeScreenshot(Log.reportsDirectory));
            await Click(HRManagementLocators.saveButton);
            toastMessage = await GetText(HRManagementLocators.successToastMessage);
            Assert.AreEqual("Successfully Saved", toastMessage);
            Log.Pass("Add User Regions Pass");
            Log.Pass("Successfully Created User");
            Log.Info("HRManagementPage.AddEmpoyee completed", await TakeScreenshot(Log.reportsDirectory));

        }
    }
}

﻿using OrangeHRMAutomatonFramework.Logger;
using OrangeHRMAutomatonFramework.POM.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.POM.EmployeeManagment
{
    internal class EmployeeManagementPage: BasePage
    {
        private string employeeManagementPath = "/client/#/pim/employees";

        public async Task Open()
        {
            Log.Info("EmployeeManagrmentPage.Open started", await TakeScreenshot(Log.reportsDirectory));
            await GoToUrl(employeeManagementPath);
            await WaitForUrl(employeeManagementPath);
            Log.Info("EmployeeManagrmentPage.Open completed", await TakeScreenshot(Log.reportsDirectory));
        }

        public async Task AddEmpoyee(EmployeeDTO employee)
        {
            Log.Info("EmployeeManagrmentPage.AddEmpoyee started", await TakeScreenshot(Log.reportsDirectory));
            await Open();
            await Click(EmployeeManagementLocators.addEmployeeButton);
            await ChooseFile(EmployeeManagementLocators.popupImage, employee.image);
            await Write(EmployeeManagementLocators.popupFirstNameInput, employee.firstName);
            await Write(EmployeeManagementLocators.popupMiddleNameInput, employee.middleName);
            await Write(EmployeeManagementLocators.popupLastNameInput, employee.lastName);
            employee.employeeId = await GetText(EmployeeManagementLocators.popupEmployeeId);
            await Write(EmployeeManagementLocators.popupJoinedDateInput, employee.joinedDate);
            await Click(EmployeeManagementLocators.popupLocationDropdown);
            await Click(EmployeeManagementLocators.popupLocationItemsInDropdown, employee.location);
            await Click(EmployeeManagementLocators.popupNextButton);
            await Write(EmployeeManagementLocators.wizardBirthdayInput, employee.dateOfBirth);
            await Click(EmployeeManagementLocators.wizardMartialStatusDropdown);
            await Click(EmployeeManagementLocators.wizardMartialStatusItemsInDropdown, employee.maritalStatus);
            await Click(EmployeeManagementLocators.wizardGenderDropdown);
            await Click(EmployeeManagementLocators.wizardGenderItemsInDropdown, employee.gender);
            await Click(EmployeeManagementLocators.wizardNationalityDropdown);
            await Click(EmployeeManagementLocators.wizardNationalityItemsInDropdown, employee.nationality);
            await Write(EmployeeManagementLocators.wizardDriverLicenseNumberInput, employee.drivingLicenseNumber);
            await Write(EmployeeManagementLocators.wizardDriverLicenseExpiryDateInput, employee.licenseExpiryDate);
            await Click(EmployeeManagementLocators.wizardNextPageButton);
            await Write(EmployeeManagementLocators.wizardDateOfPermanencyInput, employee.permanencyDate);
            await Click(EmployeeManagementLocators.wizardJobTitleDropdown);
            await Click(EmployeeManagementLocators.wizardJobTitleItemsInDropdown, employee.jobTitle);
            await Click(EmployeeManagementLocators.wizardEmployementStatusDropdown);
            await Click(EmployeeManagementLocators.wizardEmployementStatusItemsInDropdown, employee.employementStatus);
            await Click(EmployeeManagementLocators.wizardJobCategoryDropdown);
            await Click(EmployeeManagementLocators.wizardJobCategoryItemsInDropdown, employee.jobCategory);
            await Click(EmployeeManagementLocators.wizardSubUnitDropdown);
            await Click(EmployeeManagementLocators.wizardSubUnitItemsInDropdown, employee.subUnit);
            await Click(EmployeeManagementLocators.wizardWorkShiftDropdown);
            await Click(EmployeeManagementLocators.wizardWorkShiftItemsInDropdown, employee.workShift);
            await Write(EmployeeManagementLocators.wizardCommentsInput, employee.comments);
            if(employee.includeContractDetails)
            {
                await Check(EmployeeManagementLocators.wizardIncludeEmployeeContractDetailsSwitch);
                await Write(EmployeeManagementLocators.wizardContractStartDate, employee.contractStartDate);
                await Write(EmployeeManagementLocators.wizardContractEndDate, employee.contractEndDate);
            } 
            else
            {
                await Uncheck(EmployeeManagementLocators.wizardIncludeEmployeeContractDetailsSwitch);
            }
            await Click(EmployeeManagementLocators.wizardRegionDropdown);
            await Click(EmployeeManagementLocators.wizardRegionItemsInDropdown, employee.region);
            await Click(EmployeeManagementLocators.wizardFTEDropdown);
            await Click(EmployeeManagementLocators.wizardFTEItemsInDropdown, employee.fte);
            await Click(EmployeeManagementLocators.wizardTempDepartmentDropdown);
            await Click(EmployeeManagementLocators.wizardTempDepartmentItemsInDropdown, employee.temporartDepartment);
            await Click(EmployeeManagementLocators.wizardSaveButton);
            Log.Info("EmployeeManagrmentPage.AddEmpoyee completed", await TakeScreenshot(Log.reportsDirectory));
        }

    }
}

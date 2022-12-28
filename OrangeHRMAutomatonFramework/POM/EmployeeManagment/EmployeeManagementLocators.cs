using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.POM.EmployeeManagment
{
    public class EmployeeManagementLocators
    {
        public static string addEmployeeButton = "#addEmployeeButton > i";
        public static string popupTitle = "#modal-holder > div > div > div > div.modal-header > span > h5";
        public static string popupImage = "#photo-preview-lable";
        public static string popupFirstNameInput = "#first-name-box";
        public static string popupMiddleNameInput = "#middle-name-box";
        public static string popupLastNameInput = "#last-name-box";
        public static string popupEmployeeId = "#employeeId";
        public static string popupJoinedDateInput = "#joinedDate";
        public static string popupLocationDropdown = "#modal-holder > div > div > div > div.modal-body > form > oxd-decorator > div > div.form-group.col-8 > div > div:nth-child(2) > div > div.form-group.col-5 > div > div.dropdown.bootstrap-select.select-dropdown > button > div > div > div";
        public static string popupLocationItemsInDropdown = "#bs-select-1 > ul > li > a > span";
        public static string popupNextButton = "#modal-save-button";
        public static string wizardBirthdayInput = "#emp_birthday";
        public static string wizardMartialStatusDropdown = "#emp_marital_status_inputfileddiv > div > input";
        public static string wizardMartialStatusItemsInDropdown = "#emp_marital_status_inputfileddiv > div > ul > li > span";
        public static string wizardGenderDropdown = "#emp_gender_inputfileddiv > div > input";
        public static string wizardGenderItemsInDropdown = "#emp_gender_inputfileddiv > div > ul > li > span";
        public static string wizardNationalityDropdown = "#nation_code_inputfileddiv > div > input";
        public static string wizardNationalityItemsInDropdown = "#nation_code_inputfileddiv > div > ul > li > span";
        public static string wizardDriverLicenseNumberInput = "#licenseNo";
        public static string wizardDriverLicenseExpiryDateInput = "#emp_dri_lice_exp_date";
        public static string wizardNextPageButton = "#wizard-nav-button-section > button:nth-child(2)";
        public static string wizardDateOfPermanencyInput = "#date_of_permanency";
        public static string wizardJobTitleDropdown = "[data-id='job_title_id']";
        public static string wizardJobTitleItemsInDropdown = "#bs-select-2 > ul > li > a > span";
        public static string wizardEmployementStatusDropdown = "[data-id='employment_status_id']";
        public static string wizardEmployementStatusItemsInDropdown = "#bs-select-3 > ul > li > a > span";
        public static string wizardJobCategoryDropdown = "[data-id='job_category_id']";
        public static string wizardJobCategoryItemsInDropdown = "#bs-select-4 > ul > li > a > span";
        public static string wizardSubUnitDropdown = "[data-id='subunit_id']";
        public static string wizardSubUnitItemsInDropdown = "#bs-select-5 > ul > li > a > span";
        public static string wizardWorkShiftDropdown = "[data-id='work_shift_id']";
        public static string wizardWorkShiftItemsInDropdown = "#bs-select-6 > ul > li > a > span";
        public static string wizardCommentsInput = "#comment";
        public static string wizardIncludeEmployeeContractDetailsSwitch = "#has_contract_details";
        public static string wizardContractStartDate = "#contract_start_date";
        public static string wizardContractEndDate = "#contract_end_date";
        public static string wizardRegionDropdown = "[data-id='9']";
        public static string wizardRegionItemsInDropdown = "#bs-select-8 > ul > li > a > span";
        public static string wizardFTEDropdown = "[data-id='10']";
        public static string wizardFTEItemsInDropdown = "#bs-select-9 > ul > li > a > span";
        public static string wizardTempDepartmentDropdown = "[data-id='11']";
        public static string wizardTempDepartmentItemsInDropdown = "#bs-select-10 > ul > li > a > span";
        public static string wizardSaveButton = "#wizard-nav-button-section > button:nth-child(3)";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.POM.HRManagement
{
    public class HRManagementLocators
    {
        public static string tableUsernameColumn = "#systemUserDiv > crud-panel > div > div > list > table > thead > tr > th:nth-child(2)";
        public static string addUserButton = "#systemUserDiv > div > a > i";
        public static string employeeNameInput = "#selectedEmployee_value";
        public static string usernameInput = "#user_name";
        public static string essRoleDropdown = "[data-id='essrole']";
        public static string essRoleItemsInDropdown = "#bs-select-1 > ul > li > a > span";
        public static string supvisorRoleDropdown = "[data-id='supervisorrole']";
        public static string supvisorRoleItemsInDropdown = "#bs-select-2 > ul > li > a > span";
        public static string adminRoleDropdown = "[data-id='adminrole']";
        public static string adminRoleItemsInDropdown = "#bs-select-3 > ul > li > a > span";
        public static string enabledRadioButton = "#status_1";
        public static string disabledRadioButton = "#status_0";
        public static string passwordInput = "#password";
        public static string confirmPasswordInput = "#confirmpassword";
        public static string allRegions = "#allRegions";
        public static string regionDropdown = "#modal-holder > div > div > div > div.modal-body > form > oxd-decorator:nth-child(2) > div > div > oxd-multiselect > div > div > div > div.input-group > input";
        public static string regionItemsInDropdown = "#dropdown-multyselect > li > a > span";
        public static string saveButton = "#modal-save-button";

        public static string filterModalButton = "#ribbon-actions > ui-view > ul > li > a > i";
        public static string filterModalUsernameInput = "#systemuser_uname_filter";
        public static string filterModalSearchButton = "#systemUser_list_search_modal > div.modal-footer > a.modal-action.modal-close.waves-effect.btn.primary-btn";
        
        public static string listFirstRowCheckbox = "#systemUserDiv > crud-panel > div > div > list > table > tbody > tr:nth-child(1) > td:nth-child(1) > input";
        public static string listOptionsMenuIconButton = "#systemUserDiv > crud-panel > div > div > list > table > thead > tr > th.list-options > a > i";
        public static string listOptionsMenuItemsDropdown = "#listdirective-options-dropdown-list0 > li > a";
        public static string deleteModalConfirmButton = "#delete_confirmation_modal > div.modal-footer > a.modal-action.modal-close.waves-effect.btn.primary-btn";
        public static string successToastMessage = "#toast-container > .toast > .toast-message";


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LastMile.Web.Automation.LMDMSPortal.LMBaseObjects;
using LastMile.Web.Automation.BRControls;
using LastMile.Web.Automation.BRBaseObjects;
using Transport.Automation.Platform.Loggers;

namespace LM_DMS2._0_UI_Automation.LMDMSPortal.LMPageObjects
{
    using LastMile.Web.Automation.BRDataTypes;
    using BRLogger = XPOExtentXunitLogger;
    public class UserManagementPage : LMBasePage
    {
        private string m_groupName = string.Empty;
        private string m_roleName = string.Empty;

        public UserManagementPage()
        {


        }


        public BRLink GroupLink
        {
            get
            {
                string sel = "div[class='xpo-tab-links']>a:nth-child(2)";
                return new BRLink(sel, LocatorTypes.CSS, "GroupLink");
            }
        }
        public BRBaseWidget SuccessMessage
        {
            get
            {
                string sel = "div[class='successMsg']";
                return new BRLink(sel, LocatorTypes.CSS, "SuccessMessage");

            }
        }
        public void ClickGroup()
        {
            GroupLink.Click();
        }

        public BRGrid UserNameLink
        {
            get
            {
                string sel = "div[class='ag-body-container']>div:nth-child(1)";
                return new BRGrid(sel, LocatorTypes.CSS, "UserNameLink");
            }
        }
        public void ClickUserName()
        {
            UserNameLink.Click();
        }

        public BRTab UserGroupslink
        {
            get
            {
                string sel = "div[class='xpo-tab-labels']>div:nth-child(2)";
                return new BRTab(sel, LocatorTypes.CSS, "UserGroupslink");
            }
        }
        public void ClickUserGroups()
        {
            UserGroupslink.Click();
        }

        public BRButton AddUserGroup
        {
            get
            {
                string sel = "span[class='xpo-btn-wrapper']>span[class='xico-add']";
                return new BRButton(sel, LocatorTypes.CSS, "AddUserGroup");
            }
        }
        public void ClickAddUserGroup()
        {
            AddUserGroup.Click();
        }

        
        
        public BRButton SaveUserGroup
        {
            get
            {
                string sel = "button[xpo-btn='primary']";
                return new BRButton(sel, LocatorTypes.CSS, "SaveUserGroup");
            }
        }
        public void ClickSaveUserGroup()
        {
            SaveUserGroup.Click();

        }
        public void VerifyAddGroupSuccessMessage()
        {
            if (SuccessMessage.WaitTilIsClickable())
            {

                if (SuccessMessage.Text().Trim().Equals("User Group Successfully Added!"))
                {
                    XPOXunitLogger.AssertIsTrue(true, "User Group Successfully Added!");
                }
            }
            else
            {
                XPOXunitLogger.AssertFail("Success Message is not displayed");
            }
        }
        public BRGrid DeleteUserGroup
        {
            get
            {
                string sel = "div[class='ag-body-container']>div:nth-child(1)>div:nth-child(2)>span[id='delete']";
                return new BRGrid(sel, LocatorTypes.CSS, "DeleteUserGroup");
            }
        }
        public void ClickDeleteUserGroup()

        {
            DeleteUserGroup.WaitTilIsClickable();
            DeleteUserGroup.Click();
        }
        public BRButton ConfirmDeleteGroup
        {
            get
            {
                string sel = "button[xpo-btn='primary']";
                return new BRButton(sel, LocatorTypes.CSS, "ConfirmDeleteGroup");
            }
        }
        public void ClickConfirmDeleteGroup()
        {
            ConfirmDeleteGroup.Click();

        }
        public void VerifyDeleteGroupSuccessMessage()
        {
            if (SuccessMessage.WaitTilIsClickable())
            {

                if (SuccessMessage.Text().Trim().Equals("User Group Successfully Removed!"))
                {
                    XPOXunitLogger.AssertIsTrue(true, "User Group Successfully Removed!");
                }
                else
                {
                    XPOXunitLogger.AssertFail("Success Message is not displayed");
                }
            }
            else
            {
                XPOXunitLogger.AssertFail("Success Message is not displayed");
            }
        }

        public BRTab UserRoleslink
        {
            get
            {
                string sel = "div[class='xpo-tab-labels']>div:nth-child(3)";
                return new BRTab(sel, LocatorTypes.CSS, "UserRoleslink");
            }
        }
        public void ClickUserRoles()
        {
            UserRoleslink.Click();
        }

        public BRButton AddUserRoles
        {
            get
            {
                string sel = "span[class='xpo-btn-wrapper']>span[class='xico-add']";
                return new BRButton(sel, LocatorTypes.CSS, "AddUserRoles");
            }
        }
        public void ClickAddUserRoles()
        {
            AddUserRoles.Click();
        }

        

        
        public BRButton SaveUserRole
        {
            get
            {
                string sel = "button[xpo-btn='primary']";
                return new BRButton(sel, LocatorTypes.CSS, "SaveUserRole");
            }
        }
        public void ClickSaveUserRole()
        {
            SaveUserRole.Click();

        }
        public void VerifyAddRoleSuccessMessage()
        {
            if (SuccessMessage.WaitTilIsClickable())
            {

                if (SuccessMessage.Text().Trim().Equals("User Role Successfully Added!"))
                {
                    XPOXunitLogger.AssertIsTrue(true, "User Role Successfully Added!");
                }
            }
            else
            {
                XPOXunitLogger.AssertFail("Success Message is not displayed");
            }
        }
        public BRGrid DeleteUserRole
        {
            get
            {
                string sel = "div[class='ag-body-container']>div:nth-child(1)>div:nth-child(2)>span[id='delete']";
                return new BRGrid(sel, LocatorTypes.CSS, "DeleteUserRole");
            }
        }
        public void ClickDeleteUserRole()

        {
            DeleteUserRole.WaitTilIsClickable();
            DeleteUserRole.Click();
        }
        public BRButton ConfirmDeleteRole
        {
            get
            {
                string sel = "button[xpo-btn='primary']";
                return new BRButton(sel, LocatorTypes.CSS, "ConfirmDeleteRole");
            }
        }
        public void ClickConfirmDeleteRole()
        {
            ConfirmDeleteRole.Click();

        }
        public void VerifyDeleteRoleSuccessMessage()
        {
            if (SuccessMessage.WaitTilIsClickable())
            {

                if (SuccessMessage.Text().Trim().Equals("User Role Successfully Removed!"))
                {
                    XPOXunitLogger.AssertIsTrue(true, "User Role Successfully Removed!");
                }
                else
                {
                    XPOXunitLogger.AssertFail("Success Message is not displayed");
                }
            }
            else
            {
                XPOXunitLogger.AssertFail("Success Message is not displayed");
            }
        }

        public BRButton CloseSuccessMessage
        {
            get
            {
                string sel = "button[xpo-btn='secondary']>span[class='xpo-btn-wrapper']>span[class='xico-close']";
                return new BRButton(sel, LocatorTypes.CSS, "CloseSuccessMessage");
            }
        }
        public void ClickCloseSuccessMessage()
        {
            CloseSuccessMessage.Click();

        }


        public BRDropDownList SelectUserGroupName
        {
            get
            {
                string sel = "div[xpo-select-trigger]";
                return new BRDropDownList(sel, LocatorTypes.CSS, "SelectUserGroupName");
            }
        }
        public void ClickUserGroupName(string groupName)
        {
            m_groupName = groupName;
            SelectUserGroupName.SelectItem(m_groupName);
            


        }
        public BRDropDownList SelectUserRoleName
        {
            get
            {
                string sel = "div[xpo-select-trigger]";
                return new BRDropDownList(sel, LocatorTypes.CSS, "SelectUserRoleName");
            }
        }
        public void ClickUserRoleName(string roleName)
        {
            m_roleName = roleName;
            SelectUserRoleName.SelectItem(m_roleName);



        }

    }
}

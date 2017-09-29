using Xunit;
using LastMile.Web.Automation.LMDMSPortal.LMBaseObjects;
using LM_DMS2._0_UI_Automation.LMDMSPortal.LMPageObjects;
using LastMile.Web.Automation.BRBaseObjects;
using LastMile.Web.Automation.LMDMSPortal.LMDataObjects;
using LM_DMS2._0_UI_Automation.LMUIPortal.LMDataObjects;

namespace LM_DMS2._0_UI_Automation.LMDMSPortal.LMTests
{
    public class UserManagement : LMBaseUITest
    {
        UserManagementPageData m_BasePageData = new UserManagementPageData("Jturner_key");
        public UserManagement()
        {

        }

        [Fact]
        public void XLMHL_674()
        {
            TestCaseBegin();

            UserManagementPage BasePage = new UserManagementPage();
            BasePage.ClickUserName();
            BasePage.ClickUserGroups();
            BasePage.ClickAddUserGroup();
            BasePage.ClickUserGroupName(m_BasePageData.retrieveTestData("GroupName"));
            BasePage.ClickSaveUserGroup();
            BasePage.VerifyAddGroupSuccessMessage();
            XPOBrowser.Close();
            



        }

        [Fact]
        public void XLMHL_522()
        {
            TestCaseBegin();

            UserManagementPage BasePage = new UserManagementPage();
            BasePage.ClickUserName();
            BasePage.ClickUserRoles();
            BasePage.ClickAddUserRoles();
            BasePage.ClickUserRoleName(m_BasePageData.retrieveTestData("RoleName"));
            BasePage.ClickSaveUserRole();
            BasePage.VerifyAddRoleSuccessMessage();
            XPOBrowser.Close();


        }


        [Fact]
        public void XLMHL_675()
        {
            TestCaseBegin();

            UserManagementPage BasePage = new UserManagementPage();
            BasePage.ClickUserName();
            BasePage.ClickUserGroups();
            BasePage.ClickDeleteUserGroup();
            BasePage.ClickConfirmDeleteGroup();
            BasePage.VerifyDeleteGroupSuccessMessage();
            XPOBrowser.Close();
        
         
        }

       

        [Fact]
        public void XLMHL_438()
        {
            TestCaseBegin();

            UserManagementPage BasePage = new UserManagementPage();
            BasePage.ClickUserName();
            BasePage.ClickUserRoles();
            BasePage.ClickDeleteUserRole();
            BasePage.ClickConfirmDeleteRole();
            BasePage.VerifyDeleteRoleSuccessMessage();
            XPOBrowser.Close();
            
        }

    }
}

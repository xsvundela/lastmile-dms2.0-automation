using LastMile.Web.Automation.LMDMSPortal.LMBaseObjects;
using LastMile.Web.Automation.BRControls;
using LastMile.Web.Automation.BRBaseObjects;

using Transport.Automation.Platform.Loggers;

namespace LastMile.Web.Automation.LMDMSPortal.CARPageObjects
{
   
    using BRLogger = XPOExtentXunitLogger;



    public class LMLoginPage : LMBasePage
    {

        private string m_strRoleName = string.Empty;
        private string del_rolename = string.Empty;
        private string m_count = string.Empty;
        private string del_conf_message = "Are you sure you want to permanently delete {0} ?";
        private int permissioncount;
        private string m_role_permission = string.Empty;
        private string m_permission_section = string.Empty;


        public string Delete_Rolename
        {
            get
            {
                return del_rolename;
            }
            set
            {
                del_rolename = value;
            }
        }

        public string Delete_Message
        {
            get
            {
                return del_conf_message;
            }
            set
            {
                del_conf_message = value;
            }
        }

        public string Count
        {
            get
            {
                return m_count;
            }
            set
            {
                m_count = value;
            }
        }



        public BRButton AddNewRole
        {
            get
            {
                
                string sel = @"button#add-role-btn.xpo-bold.add-role-btn";
                return new BRButton(sel, LocatorTypes.CSS, "AddNewRole");
            }
        }

        public BRTextBox AddRoleInput
        {
            get
            {
                string sel = "//div[@class='xpo-input-infix']/form/input[@id='role-name']";
                return new BRTextBox(sel, LocatorTypes.XPATH, "AddRoleInput");
            }
        }


        public BRCard RoleCard
        {
            get
            {
                string sel = @"h1.xpo-dialog-title";
                return new BRCard(sel, LocatorTypes.CSS, "RoleCard");
            }
        }

        public BRButton SaveRole
        {
            get
            {
                string sel = @"button#save-role-btn";
                return new BRButton(sel, LocatorTypes.CSS, "SaveRole");
            }
        }

        public BRButton CancelAddRole
        {
            get
            {
                string sel = @"button#cancel-role-btn";
                return new BRButton(sel, LocatorTypes.CSS, "CancelRole");
            }
        }

        public BRButton CloseAddRole
        {
            get
            {
                string sel = @"xpo-icon#close-role-icon";
                return new BRButton(sel, LocatorTypes.CSS, "CloseAddRole");
            }
        }

        public BRMenu Roles
        {
            get
            {

                string sel = "//div[@class='xpo-col-1']/div[@class='role-list-head border-top']";
                return new BRMenu(sel, LocatorTypes.XPATH, "Roles");
            }
        }

        public BRMenu CreatedRole
        {
            get
            {
                int count = GetRoleCount() - 1;
                string sel = "//div[@id='role-name-" + count + "']";
                return new BRMenu(sel, LocatorTypes.XPATH, "CreatedRole");
            }
        }

        public BRButton Delete_Role
        {
            get
            {

                string sel = "//div[@class='role-list-head border-top'][contains(text(),'{0}')]/xpo-icon[@class='action-color xico-close']";
                sel = sel.Replace("{0}", Delete_Rolename);
                return new BRButton(sel, LocatorTypes.XPATH, "DeleteRole");
            }
        }

        public BRCard DeleteRoleCard
        {
            get
            {
                string sel = @"h1.xpo-dialog-title";
                return new BRCard(sel, LocatorTypes.CSS, "DeleteRoleCard");
            }

        }
        public BRButton Confirm_Delete_Role
        {
            get
            {

                string sel = @"button#delete-role-btn";
                return new BRButton(sel, LocatorTypes.CSS, "Confirm Delete Role");
            }
        }

        public BRButton Cancel_Delete_Role
        {
            get
            {

                string sel = @"button#cancel-role-btn";
                return new BRButton(sel, LocatorTypes.CSS, "Cancel Delete Role");
            }
        }

        public BRButton Close_Delete_Role
        {
            get
            {

                string sel = @"xpo-icon#close-role-icon";
                return new BRButton(sel, LocatorTypes.CSS, "Close Delete Role");
            }
        }


        public BRCard DeleteConfirmMessage
        {
            get
            {
                string sel = "//div[@class='xpo-dialog-content']/div[1]";
                return new BRCard(sel, LocatorTypes.XPATH, "DeleteConfirmMessage");
            }
        }

        public BRMenu DeletedRole
        {
            get
            {
                string sel = "//div[@class='role-list-head border-top'][contains(text(),'{0}')]";
                sel = sel.Replace("{0}", Delete_Rolename);
                return new BRMenu(sel, LocatorTypes.XPATH, "DeletedRole");

            }

        }

        public BRMenu Permissions
        {
            get
            {
                string sel = "//div[@class='permission-head border-top']/div[@class='xpo-col-3']";
                return new BRMenu(sel, LocatorTypes.XPATH, "Permissions");

            }

        }



        public BRToggleButton RolePermissionsON
        {
            get
            {       
               
                return new BRToggleButton(m_strRoleName, Count,  "RolePermissionsON");
            }
        }


        public BRToggleButton RolePermissionsOFF
        {
            get
            {

                return new BRToggleButton(m_strRoleName, Count, "RolePermissionsOFF","OFF");
            }
        }

        public BRMenu RolePermissionsWebPortal
        {
            get
            {
                string sel = "//div[@id='Web Portal-permission-{0}']";
                sel = sel.Replace("{0}", Count);

                return new BRMenu(sel, LocatorTypes.XPATH, "RolePermissions");

            }

        }

        public BRMenu RolePermissionsDriverApp
        {
            get
            {
                string sel = "//div[@id='Driver App-permission-{0}']";
                sel = sel.Replace("{0}", Count);

                return new BRMenu(sel, LocatorTypes.XPATH, "RolePermissions");

            }

        }

        public LMLoginPage()
        {
        }
        public void waitUntilReady()
        {

            BRLogger.AssertIsTrue(AddNewRole.WaitTilIsVisible(), "Verify Roles Page");

        }


        public void isTestRoleDisplayed()
        {

            BRLogger.AssertIsTrue(AddNewRole.WaitTilIsVisible(), "Verify Add Role Button");

        }

        public void isRoleCardDisplayed()
        {

            BRLogger.AssertIsTrue(RoleCard.WaitTilIsVisible(), "Verify Add new role popup");

        }

        public void isCreatedRoleDisplayed(string new_role_name)
        {
            string rolename = CreatedRole.Text().TrimEnd();

            BRLogger.AssertIsTrue(new_role_name.Equals(rolename), "Verify new role");

        }


        public void isDeleteButtonDisplayed()
        {

            BRLogger.AssertIsTrue(Delete_Role.WaitTilIsVisible(), "Verify Delete button");

        }


        public void VerifyIfDeleteCardDisplayed()
        {

            BRLogger.AssertIsTrue(DeleteRoleCard.WaitTilIsVisible(), "Verify Delete Role pop up");


        }

        public void VerifyDelConfirmMessage(string del_rolename)
        {
            string conf_message = DeleteConfirmMessage.Text();
            Delete_Message = Delete_Message.Replace("{0}", del_rolename);

            BRLogger.AssertIsTrue(Delete_Message.Equals(conf_message), "Verify delete confirmation message");

        }

        public void VerifyRoleisDeleted()
        {
            BRLogger.AssertIsTrue(!DeletedRole.IsDisplayed(), "Verify Delete Role");
        }

        public int GetRoleCount()
        {
            int count = 0;
            count = Roles.GetCount();
            return count;
        }

        public void VerifyToggleStatus_ON()
        {
            int count = 0;
            int permissionCount = Permissions.GetCount();
            for (int i =0;i < permissionCount; i++)
            {
                Count = i.ToString();
                if (RolePermissionsON.VerifyToggleON())
                    count++;
            }
        }


        public void VerifyToggleStatus_OFF()
        {
            int count = 0;
            int permissionCount = Permissions.GetCount();
            for (int i = 0; i < permissionCount; i++)
            {
                Count = i.ToString();
                if (RolePermissionsOFF.VerifyAllToggleOFF())
                    count++;
            }
        }


        public void ChangetoONStatus(string role_perm, string section)
        {
            
            int permissionCount = Permissions.GetCount();
            if (section == "WebPortal")
            {
                for (int i = 0; i < permissionCount; i++)
                {
                     Count = i.ToString();
                     if (RolePermissionsWebPortal.Text()== role_perm)
                     {
                            if (RolePermissionsOFF.VerifyToggleOFF())
                            {
                                RolePermissionsOFF.Click();
                                BRLogger.AssertIsTrue(RolePermissionsON.VerifyToggleON(), "Verify On Status");
                                break;

                            }
                      }
                 }
            }

            else if (section == "DriverApp")
            {
                for (int i = 0; i < permissionCount; i++)
                {
                    Count = i.ToString();
                    if (RolePermissionsDriverApp.Text() == role_perm)
                    {
                        if (RolePermissionsOFF.VerifyToggleOFF())
                        {
                            RolePermissionsOFF.Click();
                            BRLogger.AssertIsTrue(RolePermissionsON.VerifyToggleON(), "Verify On Status");
                            break;

                        }
                    }
                }
            }

        }



        public void ChangetoOFFStatus(string role_perm, string section)
        {

            int permissionCount = Permissions.GetCount();
            if (section == "WebPortal")
            {
                for (int i = 0; i < permissionCount; i++)
                {
                    Count = i.ToString();

                    if (RolePermissionsWebPortal.Text() == role_perm)
                    {
                        if (RolePermissionsON.VerifyToggleON())
                        {
                            RolePermissionsON.Click();
                            BRLogger.AssertIsTrue(RolePermissionsOFF.VerifyToggleOFF(), "Verify Off Status");
                            break;
                        }
                    }

                }
            }

            else if (section == "DriverApp")
            {
                for (int i = 0; i < permissionCount; i++)
                {
                    Count = i.ToString();

                    if (RolePermissionsDriverApp.Text() == role_perm)
                    {
                        if (RolePermissionsON.VerifyToggleON())
                        {
                            RolePermissionsON.Click();
                            BRLogger.AssertIsTrue(RolePermissionsOFF.VerifyToggleOFF(), "Verify Off Status");
                            break;
                        }
                    }

                }
            }
        }



        private int perm_Count
        {
            get
            {
                return permissioncount;
            }

            set
            {
                permissioncount = value;
            }
        }
        

        public void GetDeletedRole(string deletedrole)
        {
            Delete_Rolename = deletedrole;
        }


       

       


   /*     public void CancelDeleteRole(CARRolesData Role)
        {
            m_strRoleName = Role.RoleName;
            isDeleteButtonDisplayed();
            Delete_Role.Click();
            Cancel_Delete_Role.Click();
            isTestRoleDisplayed();
        }
        */

       
        
    
       

    }
}


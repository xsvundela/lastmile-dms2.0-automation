﻿using System.Collections.Generic;
using LastMile.Web.Automation.BRDataTypes;
using LastMile.Web.Automation.LMDMSPortal.LMBaseObjects;

namespace LM_DMS2._0_UI_Automation.LMUIPortal.LMDataObjects
{
    class UserManagementPageData: LMBaseData
    {
        private string newrol = string.Empty;
        private string rolepermission = string.Empty;
        private string permission_section = string.Empty;
        private static Dictionary<string, string> testData;
        public UserManagementPageData()
        {
        }


        public UserManagementPageData(string testKey)

        {
            //LMLogin is the sheet name and testKey is the key value of a row from the particular sheet

            BRGlobalVars.TESTDATA = GetTestData("UMPage", testKey);

        }

        public string retrieveTestData(string key)
        {
            string cellValue;
            BRGlobalVars.TESTDATA.TryGetValue(key, out cellValue);
            return cellValue;
        }

        public string RoleName
        {
            get
            {
                return newrol;
            }

            set
            {
                newrol = value;
            }
        }

        public string RolePermission
        {
            get
            {
                return rolepermission;
            }

            set
            {
                rolepermission = value;
            }
        }

        public string PermissionSection
        {
            get
            {
                return permission_section;
            }

            set
            {
                permission_section = value;
            }
        }

        private void SetData(Dictionary<string, string> testData)
        {
            string cellValue;
            //New Role Name
            testData.TryGetValue("RoleName", out cellValue);
            RoleName = cellValue;
            testData.TryGetValue("RolePermission", out cellValue);
            RolePermission = cellValue;
            testData.TryGetValue("PermissionSection", out cellValue);
            PermissionSection = cellValue;

        }
    }
}

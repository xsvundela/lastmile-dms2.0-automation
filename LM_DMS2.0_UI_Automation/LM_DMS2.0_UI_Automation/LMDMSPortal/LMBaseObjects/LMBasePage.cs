using LastMile.Web.Automation.BRBaseObjects;
using LastMile.Web.Automation.BRControls;
using LastMile.Web.Automation.LMDMSPortal.CARPageObjects;
using Transport.Automation.Platform.Loggers;

namespace LastMile.Web.Automation.LMDMSPortal.LMBaseObjects
{
    using BRLogger = XPOExtentXunitLogger;
    public class LMBasePage :BRBasePage
    {
        
        public LMBasePage()
        {

        }
        public BRMenu CarrierMenu
        {
            get
            {
              return new BRMenu("Carrier Main Card");
            }
        }
        public void TestMainMenuItems()
        {      
            string[] menuItemList = { "Dashboard", "Tenders", "Loads", "Users", "Roles", "Available Loads", "My Profile" };
            string itemsNotFound = CarrierMenu.TestMenuItemsPresent(menuItemList);
            if (itemsNotFound.Equals(""))
            {
                //
                string itemlist = string.Empty;
                foreach (string actions in menuItemList)
                {
                    itemlist += actions + ",";
                }
                itemlist = itemlist.Remove(itemlist.Length - 1);
                BRLogger.AssertIsTrue(true, itemlist + " menu items are present in the Carrier Portal Main menu");
            }
            else
            {
                //
                BRLogger.AssertFail(itemsNotFound + " menu items are not present ");
            }
        }

        public void MainMenuItemClick(string item)
        {
            CarrierMenu.MenuItemsClick(item);
            BRLogger.LogInfo(item+" is clicked from the Carrier Portal Main menu");
        }
        //public CARUserPage NavigatetoUsers()
        //{
        //    CARUserPage userPage = new CARUserPage();
        //    CarrierMenu.MenuItemsClick("Users");
        //    BRLogger.LogInfo(" User is clicked from the Carrier Portal Main menu");
        //    //verify if the user page loads.
        //    userPage.waitUntilReady();
        //    return userPage;

        //}


        public LMLoginPage NavigatetoRoles()
        {
            LMLoginPage rolesPage = new LMLoginPage();
            CarrierMenu.MenuItemsClick("Roles");
            BRLogger.LogInfo(" User is clicked from the Carrier Portal Main menu");
            //verify if roles page loads...
            rolesPage.waitUntilReady();
            return rolesPage;

        }

        

        //public CARMyProfilePage NavigatetoMyProfile()
        //{
        //    CARMyProfilePage myProfilePage = new CARMyProfilePage();
        //    CarrierMenu.MenuItemsClick("My Profile");
        //    BRLogger.LogInfo(" User is clicked from the Carrier Portal Main menu");
        //    //verify if the my profile page loads.
        //    myProfilePage.waitUntilReady();
        //    return myProfilePage;
        //}


        public void NavigatetoLoads()
        {
            //similar to users
            CarrierMenu.MenuItemsClick("Loads");
            BRLogger.LogInfo(" Loads is clicked from the Carrier Portal Main menu");

            //verify if the Loads page loads ...
            //userPage.waitUntilReady();
        }


        //public CARAvailableLoadsPage NavigatetoAvailableLoads()
        //{
        //    CARAvailableLoadsPage availloadsPage = new CARAvailableLoadsPage();
        //    CarrierMenu.MenuItemsClick("Available Loads");
        //    BRLogger.LogInfo(" User is clicked from the Carrier Portal Main menu");
        //    //verify if Available page loads...
        //    availloadsPage.waitUntilReady();
        //    return availloadsPage;

        //}

        //public CARAvailableLoadsPage NavigateLoads()
        //{
        //    CARAvailableLoadsPage availloadsPage = new CARAvailableLoadsPage();
        //    CarrierMenu.MenuItemsClick("Loads");
        //    BRLogger.LogInfo(" User is clicked from the Carrier Portal Main menu");
        //    //verify if Available page loads...
        //    availloadsPage.waitUntilReady();
        //    return availloadsPage;

        //}
    }
}

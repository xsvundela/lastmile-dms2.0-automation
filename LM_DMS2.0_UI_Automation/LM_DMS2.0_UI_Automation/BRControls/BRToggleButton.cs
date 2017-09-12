using LastMile.Web.Automation.BRBaseObjects;

namespace LastMile.Web.Automation.BRControls
{
    public class BRToggleButton: BRBaseWidget
    {

        private int permissionCount;
     

        public int Permission_Count
        {
            get
            {
                return permissionCount;
            }
            set
            {
                permissionCount = value;
            }
        }
       // public BRToggleButton(string locator, LocatorTypes locatorType, string displayName) : base(locator, locatorType,"Button", displayName) { }

        public BRToggleButton(string locator, LocatorTypes locatorType, string displayName) : base(locator, locatorType, "Button", displayName)
        {

        }

   
        public BRToggleButton(string roleName, string count, string displayName) : base(@"//xpo-slidetoggle[@ng-reflect-id='" + roleName + "-" + count + "-toggle' and @class='xpo-slide-toggle xpo-slide-toggle--checked']//div[@class='xpo-slide-toggle__thumb']", LocatorTypes.XPATH, "Button", displayName) { }

        public BRToggleButton(string roleName, string count, string displayName, string buttonStatus) : base(@"//xpo-slidetoggle[@ng-reflect-id='" + roleName + "-" + count + "-toggle' and @class='xpo-slide-toggle']//div[@class='xpo-slide-toggle__thumb']", LocatorTypes.XPATH, "Button", displayName) { }


        public bool VerifyAllToggleOFF()
        {
            if (this.IsDisplayed())
                return true;
            else
                return false;
        }

        public bool VerifyToggleON()
        {
            if (this.IsDisplayed())
                return true;
            else
                return false;
        }


        public bool VerifyToggleOFF()
        {
            if (this.IsDisplayed())
                return true;
            else
                return false;
        }


    }
}

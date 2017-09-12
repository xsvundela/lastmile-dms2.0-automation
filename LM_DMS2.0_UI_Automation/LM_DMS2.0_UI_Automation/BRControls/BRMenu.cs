
using LastMile.Web.Automation.BRBaseObjects;
using Transport.Automation.Platform.Loggers;

namespace LastMile.Web.Automation.BRControls
{
    using BRLogger = XPOExtentXunitLogger;
    public class BRMenu : BRBaseWidget
    {
        #region MemberVars
        private string m_item;

        #endregion

        #region Properties
        private string Item
        {
            get
            {
                return m_item;
            }

            set
            {
                m_item = value;
            }
        }

        private BRBaseWidget MenuItem
        {
            get
            {
                string sel = @"//xpo-menubar//a[text()='{0}']";
                sel = sel.Replace("{0}", Item);
                return new BRBaseWidget(sel, LocatorTypes.XPATH, "menuitem", "Menu Item");
                //return BRMenu.FindElement(GetFindBy(LocatorTypes.XPATH, sel));

            }
        }
        #endregion

        #region Constructors

        public BRMenu(string locator, LocatorTypes locatorType, string displayName) : base(locator, locatorType, "Menu", displayName) { }
        public BRMenu(string displayName) : base(@"//xpo-menubar", LocatorTypes.XPATH, "XPO MENU", displayName) { }
        #endregion

        #region Methods
        public string TestMenuItemsPresent(params string[] menuItems)
        {
            bool itemFound = false;
            string itemNotFound = string.Empty;
            
            for (int i = 0; i < menuItems.Length; i++)
            {
                Item = menuItems[i];
                itemFound=MenuItem.DoesExist();
                if (!itemFound)
                {
                    if (itemNotFound == null)
                    {
                        itemNotFound = Item;
                    }
                    else
                    {
                        itemNotFound = itemNotFound + "," + Item;
                    }
                }

            }

            return itemNotFound;

        }

        public void MenuItemsClick(string menuItem)
        {
            Item = menuItem;
            if (MenuItem.WaitTilIsClickable()) { 
                if (!MenuItem.Click())
                {
                    BRLogger.AssertFail(menuItem + " is not clicked");
                }
            }
            else
            {
                BRLogger.AssertFail(menuItem + " is not available.");
            }

        }
        #endregion

        #region Statics

        #endregion
    }
}

using LastMile.Web.Automation.BRBaseObjects;

namespace LastMile.Web.Automation.BRControls
{
    public class BRDropDownList : BRBaseWidget
    {
        private BRBaseWidget DropDownList
        {
            get
            {
                string sel = @"div#select2-drop > ul.select2-results";
                return new BRBaseWidget(sel, LocatorTypes.CSS, "dropdownlist", "Drop Down List");
            }
        }

        private BRTextBox SearchBox
        {
            get
            {
                string sel = @"div#select2-drop input.select2-input";
                return new BRTextBox(sel, LocatorTypes.CSS, "Search Box");
            }
        }

        private BRBaseWidget Open
        {
            get
            {
                string sel = Locator + " > a > span.select2-arrow";
                return new BRBaseWidget(sel, LocatorTypes.CSS , "downarrow", "Down Arrow"); 
            }
        }

        private BRBaseWidget Chosen
        {
            get
            {
                string sel = Locator + " span.select2-chosen";
                return new BRBaseWidget(sel, LocatorTypes.CSS, "chosen", "Chosen Selection");
            }
        }


        public BRDropDownList(string locator,LocatorTypes locatorType, string displayName) : base(locator,  locatorType, "DropDownList", displayName) { }

        public string GetCurrentSelection()
        {
            return Chosen.Text();
        }

        public bool SelectItem(string item)
        {
            bool WasSelected = false;

            Open.Click();  //open the dropdown

            BRBaseWidget m_dropDownList = DropDownList;
            m_dropDownList.WaitTilIsVisible();

            string sel = "//li/div[contains(@class, 'select2-result-label')][contains(text(),'" + item + "')]";
            BRBaseWidget m_theItem = new BRBaseObjects.BRBaseWidget(sel, LocatorTypes.XPATH, "dropdownItem", item);
            m_theItem.WaitTilIsVisible();
            m_theItem.Click();
            WasSelected = true;

            return WasSelected;
        }

        public bool SearchFor(string item)
        {
            Open.Click();

            SearchBox.WaitTilIsVisible();
            SearchBox.SearchFor(item);

            return true;
        }
    }
}

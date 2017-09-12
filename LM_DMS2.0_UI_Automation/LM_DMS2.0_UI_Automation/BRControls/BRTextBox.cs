
using System;
using System.Linq;


using LastMile.Web.Automation.BRBaseObjects;

namespace LastMile.Web.Automation.BRControls
{
    public class BRTextBox : BRBaseWidget
    {
        #region MemberVars
        private const string attributeName = "style";
        private const string attributeParam = "display: block;";
        private const int maxWaitTime = 15; //seconds

        #endregion

        #region Properties

        private BRBaseWidget UIAutoComplete
        {
            get
            {
                string sel = @"ui-autocomplete";
                return new BRBaseWidget(sel, LocatorTypes.CSS,"autocomplete", "UI-AutoComplete");
            }
        }

        #endregion

        #region Constructors

        public BRTextBox(string locator,LocatorTypes locatorType, string displayName) : base(locator, locatorType,"TextBox", displayName) { }

        public BRTextBox(string locator, LocatorTypes locatorType, string controlType, string displayName) : base(locator, locatorType,controlType, displayName) { }

        #endregion

        #region Methods

        public void SendKeysInIntervals(string text, int delayMiliSeconds)
        {
            if (!string.IsNullOrEmpty(text))
            {
                char[] locationCharArray = text.ToArray();
                foreach (char currChar in locationCharArray)
                {
                    SendKeys(currChar.ToString());
                    Delay(delayMiliSeconds);
                }
            }
        }

        public bool SelectItem(string item)
        {
            SendKeys(item);
            string sel = "//li/a/b[contains(text(),'" + item + "')]";

            BRBaseWidget m_item = new BRBaseWidget(sel, LocatorTypes.XPATH,"dropdownmenuitem", "Drop Down Menu Item");
            try
            {
                m_item.WaitTilIsVisible();
                m_item.Click();
            }
            catch (Exception)
            {
                sel = "//li/a[contains(text(),'" + item + "')]";
                m_item = new BRBaseWidget(sel, LocatorTypes.XPATH, "dropdownmenuitem", "Drop Down Menu Item");
                m_item.WaitTilIsVisible();
                m_item.Click();
            }

            return true;
        }

        public bool WaitForElasticSearch(string waitFor)
        {
            bool WasFound = false;

            if (UIAutoComplete.WaitForElementAttributeToBeSet(waitFor, attributeName, attributeParam))
            {
                WasFound = true;
            }

                return WasFound;
        }

        public bool SearchFor(string item)
        {

            SendKeys(item);

            string sel = "//div[@class='numbers' and contains(text(),'" + item + "')]";
            BRBaseWidget searchResults = new BRBaseWidget(sel,LocatorTypes.XPATH ,"searchresults", "Search Results");
            try
            {
                searchResults.WaitTilIsVisible(5);
                SendEnter();
                return true;
            }
            catch (Exception)
            {
                   
                sel = "//div[@class='displayname' and contains(text(),'" + item + "')]";
                searchResults = new BRBaseWidget(sel, LocatorTypes.XPATH,"searchresults", "Search Results");
                try
                {
                    searchResults.WaitTilIsVisible(1);
                    SendEnter();
                }
                catch (Exception)
                {
                    sel = "//div[@class='select2-result-label' and contains(text(),'" + item + "')]";
                    searchResults = new BRBaseWidget(sel, LocatorTypes.XPATH,"searchresults", "Search Results");
                    searchResults.WaitTilIsVisible(1);
                    SendEnter();

                }
                return true;

            }
            //return false;
        }

        public bool WaitForTextToBePresent()
        {
            bool IsPresent = false;

            string m_currentText = Value();
            for(int i=0; i<20; i++)
            {
                if (!string.IsNullOrEmpty(m_currentText))
                {
                    break;
                }

                Delay(250);
                m_currentText = Value();

            }

            return IsPresent;
        }


        #endregion

        #region Statics

        #endregion
    }
}
using System.Collections.Generic;
using OpenQA.Selenium;

using LastMile.Web.Automation.BRBaseObjects;

namespace LastMile.Web.Automation.BRControls
{
    public class BRFilter : BRBaseWidget
    {
        #region MemberVars

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public BRFilter(string locator, LocatorTypes locatorType, string displayName) : base(locator,  locatorType, "Filter", displayName) { }

        public BRFilter(string locator, LocatorTypes locatorType, string controlType, string displayName) : base(locator,  locatorType, controlType, displayName) { }

        #endregion

        #region Methods


        public void FilterCheckBoxClear()
        {
            IWebElement e = GetMyPopup();
            IWebElement clear = e.FindElement(By.LinkText("Clear"));
            //XPOLogger.LogInfo("Click the 'Clear' link on the filter popup.");
            clear.Click();
        }

        private IWebElement GetMyPopup()
        {
            string sel = @"div.popover.filterpop";
            IReadOnlyCollection<IWebElement> allPopups = Browser.FindElements(By.CssSelector(sel));
            IWebElement myPopup = null;

            foreach (IWebElement e in allPopups)
            {
                if (e.Displayed)
                {
                    myPopup = e;
                }
}
            if (myPopup == null)
            {
                //throw new XPOException("The filter popup was not displayed as expected.");
            }
            return myPopup;
        }

        #endregion

        #region Statics

        #endregion
    }

    public class BRAutoCompleteFilter: BRFilter
    {
        #region MemberVars

        private string m_dataCriteria = string.Empty;
        #endregion

        #region Properties

        #endregion

        #region Constructors

        public BRAutoCompleteFilter(string locator, LocatorTypes locatorType, string displayName) : base(locator,  locatorType, "AutoCompleteFilter", displayName) { }

        #endregion

        #region Methods

        public void Filter(string search, string valueToFilter)
        {
            // RIGHT now, this works one at a time!
            // This needs to be updated if we want to do more than one filter at a time.

            FindElement(Locator).Click();

            string sel = @"div.popover.filterpop[data-criteria=""" + m_dataCriteria  + @"""]";
            BRBaseWidget w = new BRBaseWidget(sel, LocatorTypes.CSS,"PopOver", "PopOver");

            sel = @"input#s2id_autogen4";
            IWebElement f = FindElement(w.Locator).FindElement(By.CssSelector(sel));

            //XPOLogger.LogInfo("In the filter textbox, enter: '" + search + "' and click enter.");

            f.SendKeys(search);

//            f.SendKeys(Keys.Enter);

            string liSel = @"li.select2-results-dept-0.select2-result.select2-result-selectable";
            IReadOnlyCollection<IWebElement> availULs = Browser.FindElements(By.CssSelector("ul.select2-results"));
            if (availULs.Count > 0)
            {
                foreach (IWebElement ul in availULs)
                {
                    if (ul.Displayed)
                    {
//                        CurrentPage.WaitTilElementIsVisible(liSel);

                        IReadOnlyCollection<IWebElement> lineItems = ul.FindElements(By.CssSelector(liSel));
                        if (lineItems.Count > 0)
                        {
                            foreach (IWebElement li in lineItems)
                            {
                                if (li.Text.ToLower().Equals(valueToFilter.ToLower()))
                                {
                                    //XPOLogger.LogInfo("In the list of available choices, click '" + valueToFilter + "'.");
                                    // make sure to document
                                    li.Click();
//                                    CurrentPage.WaitTilTruckDoneLoading();
                                    this.Click();
                                    return;
                                }
                            }
                            //throw new XPOException("The menu item was not found.");
                        }
                        else
                        {
                           // throw new XPOException("The list of menu items was not found.");

                        }
                    }
                }
            }
        }

        #endregion

        #region Statics

        #endregion
    }
}
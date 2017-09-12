using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

using LastMile.Web.Automation.BRBaseObjects;

namespace LastMile.Web.Automation.BRControls
{
    public class BRTabularData : BRBaseWidget
    {
        #region MemberVars

        private BRBaseWidget m_baseControl = null;

        #endregion

        #region Properties

        public BRBaseWidget TabularBaseControl
        {
            get
            {
                return m_baseControl;
            }

        }

        #endregion

        #region Constructors

        public BRTabularData() : base(@"div.tabular-data",LocatorTypes.CSS, "TabularData", "Tabular Data") { }

        public BRTabularData(string locator,LocatorTypes locatorType, string displayName) : base(locator, locatorType,"TabularData", displayName) { }

        #endregion

        #region Methods


        public BRBaseWidget GetRow(int index)
        {
            // In that table look for the row with the text we need
            string sel = @"div.tabular-data__row";
           IReadOnlyCollection<IWebElement> allRows = Browser.FindElements(By.CssSelector(sel));
            IWebElement myRow = allRows.ElementAt(index);
//            XPOGenericElement row = new XPOGenericElement(CurrentPage, myRow, "Table Data Row");
            return null;
        }

        #endregion

        #region Statics

        #endregion
    }
}
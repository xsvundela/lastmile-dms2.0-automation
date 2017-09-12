
using OpenQA.Selenium.Support.UI;
using LastMile.Web.Automation.BRBaseObjects;

namespace LastMile.Web.Automation.BRControls
{
    public class BRSelect : BRBaseWidget
    {
        #region MemberVars
        SelectElement m_select;
        #endregion

        #region Properties

        #endregion

        #region Constructors

        public BRSelect(string locator, LocatorTypes locatorType, string displayName) : base(locator, locatorType, "Select", displayName) { }

        #endregion

        #region Methods
        public bool SelectItem(string item)
        {
//            IWebElement e = FindElement();
            m_select = new SelectElement(FindElement());
            m_select.SelectByText(item);

            return true;
        }

        #endregion

        #region Statics

        #endregion
    }
}
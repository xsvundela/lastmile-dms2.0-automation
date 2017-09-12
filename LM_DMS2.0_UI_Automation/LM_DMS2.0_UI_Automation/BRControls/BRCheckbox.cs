
using LastMile.Web.Automation.BRBaseObjects;

namespace LastMile.Web.Automation.BRControls
{
    public class BRCheckbox : BRBaseWidget
    {
        #region MemberVars

        #endregion

        #region Properties

        #endregion

        #region Constructors
        public BRCheckbox(string locator, LocatorTypes locatorType, string displayName) : base(locator, locatorType, "Checkbox", displayName) { }

        #endregion

        #region Methods


        public bool IsChecked()
        {
            bool isChecked = base.Selected();
            string checkOrNot = isChecked ? "checked" : "not checked";

            return isChecked;
        }

        public void EnsureChecked()
        {
            if (IsChecked())
            {
                return;
            }
            else
            {
                base.Click();
            }

        }
        #endregion

        #region Statics

        #endregion
    }
}
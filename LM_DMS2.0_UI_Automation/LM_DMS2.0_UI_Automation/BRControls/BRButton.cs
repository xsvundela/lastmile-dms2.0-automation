using System;
using System.Collections.Generic;
using LastMile.Web.Automation.BRBaseObjects;
using OpenQA.Selenium;

namespace LastMile.Web.Automation.BRControls
{ 
    public class BRButton : BRBaseWidget
    {
        #region MemberVars
        //This for test  
        #endregion

        #region Properties

        #endregion

        #region Constructors

        public BRButton(string locator,LocatorTypes locatorType ,string displayName) : base(locator, locatorType,"Button", displayName) { }

        public static explicit operator BRButton(List<IWebElement> v)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Methods

        #endregion

        #region Statics

        #endregion
    }
}
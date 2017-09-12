using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using FOLogger = Transport.Automation.Platform.Loggers.XPOExtentXunitLogger;
using LastMile.Web.Automation.BRDataTypes;

namespace LastMile.Web.Automation.BRBaseObjects
{

    public class BRBaseWidget : XPOBaseWidget
    {

        private string m_Locator;        
        private string m_ControlType;
        private string m_DisplayName;
        private LocatorTypes m_LocatorType;

        #region MemberVar

        public string Locator
        {
            get
            {
                return m_Locator;
            }

            set
            {
                m_Locator = value;
            }
        }
       

        public string ControlType
        {
            get
            {
                return m_ControlType;
            }

            set
            {
                m_ControlType = value;
            }
        }

        public string DisplayName
        {
            get
            {
                return m_DisplayName;
            }

            set
            {
                m_DisplayName = value;
            }
        }

        public LocatorTypes LocatorType
        {
            get { return m_LocatorType;}
            set { m_LocatorType = value; }
        }

        public static BRBaseWidget TruckLoading
        {
            get
            {
                string sel = @"div.gridLoadingContainer";
                return new BRBaseWidget(sel, LocatorTypes.CSS, "truckloadingicon", "Truck Loading"); ;
            }
        }

        public static BRBaseWidget LoadingSpinner
        {
            get
            {
                string sel = @"div.loadingspinner";
                return new BRBaseWidget(sel,LocatorTypes.CSS ,"truckloadingicon", "Truck Loading"); ;
            }
        }

        #endregion

        #region Constructors

        public BRBaseWidget(string locator, LocatorTypes locatorType, string controlType,string displayName)
        {
            Locator = locator;
            ControlType = controlType;
            DisplayName = displayName;
            LocatorType = locatorType;
            By m_By = GetFindBy();
            FindBy = m_By;
        }

    

        #endregion

        #region Methods

        //        public FOBaseWidget GetChild(string locator, string controlType, string displayName)
        //        {
        //            By m_Parent = FindBy;
        //            By m_MyBy = GetFindBy(locator);
        //            string m_MyLocator = m_Parent.ToString() + " > " + m_MyBy.ToString();
        //            return new FOBaseWidget(m_MyLocator, controlType, displayName);
        //        }

        public new bool Click()
        {
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    base.Click();
                    FOLogger.LogInfo("Clicked the '" + DisplayName + "' " + ControlType);
                    return true;
                }
                catch (StaleElementReferenceException) { }
            }

            return false;
        }

        public bool DoesExist()
        {
            By by = GetFindBy();
            return DoesElementExist(by);
        }

        public IWebElement FindElement(string locator)
        {
            By by = GetFindBy();
            return Browser.FindElement(by);
            
        }
        public bool isEnabled()
        {
            By by = GetFindBy();
            return Browser.FindElement(by).Enabled;

        }

        public new bool SendKeys(string keys)
        {
            base.SendKeys(keys);
            FOLogger.LogInfo("In the '" + DisplayName + "' " + ControlType + " enter the text: '" + keys + "'.");
            return true;

        }

        public bool SendDownArrow()
        {
            base.SendKeys(Keys.ArrowDown);
            return true;
        }

        public bool WaitTilDoneSpinning()
        {
            bool IsReady = true;

            string sel = @"div.cm-loader";
            BRBaseWidget spinning = new BRBaseWidget(sel, LocatorTypes.CSS, "spinning", "Spinning");

            try
            {
                spinning.WaitTilIsVisible(2);
                IsReady = TruckLoading.WaitTilNotVisible();
            }
            catch (Exception)
            { }

            return IsReady;
        }


        public bool WaitTilTruckDoneLoading()
        {
            bool IsReady = true;
            try
            {
                //if (TruckLoading.WaitTilIsVisible(2))
                //{
                    IsReady &= TruckLoading.WaitTilNotVisible();
                //}
            }
            catch (Exception)
            { }

            return IsReady;
        }

        public bool WaitTilDoneLoading()
        {
            bool IsReady = true;
            try
            {
                //if (TruckLoading.WaitTilIsVisible(2))
                //{
                IsReady &= LoadingSpinner.WaitTilNotVisible();
                //}
            }
            catch (Exception)
            { }

            return IsReady;
        }


        public bool WaitTilIsClickable()
        {
            var wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(BRGlobalVars.DEFAULT_TIMEOUT));
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(FindBy));
                    break;
                }
                catch (StaleElementReferenceException)
                { }
            }
            return true;
        }

        public bool WaitForTextToBePresent()
        {
            bool IsPresent = false;

            string m_currentText = Text();
            for (int i = 0; i < 20; i++)
            {
                if (!string.IsNullOrEmpty(m_currentText))
                {
                    IsPresent = true;
                    break;
                }

                Delay(250);
                m_currentText = Text();

            }

            return IsPresent;
        }



        public bool WaitTilIsVisible()
        {
            bool IsReady = WaitTilIsVisible(BRGlobalVars.DEFAULT_TIMEOUT);
            return IsReady;
        }

        public bool WaitTilNotVisible()
        {
            bool IsReady = WaitTilNotVisible(BRGlobalVars.DEFAULT_TIMEOUT);
            return IsReady;
        }

        public bool WaitForElementAttributeToBeSet(string containsText, string attributeName, string attributeProperty)
        {

            bool isItemPresent = false;
            int currentWaitTime = 0;
            int currentWaitIntervals = 0;
            int waitIntervalInMiliSec = 250; //miliseconds

            do
            {
                List<IWebElement> elementList = FindElements(By.ClassName(Locator)).ToList();
                //Locate the displayed element
                foreach (IWebElement displayedElement in elementList)
                {
                    try
                    {
                        if (displayedElement.GetAttribute(attributeName).Contains(attributeProperty))
                        {
                            //Verify that the displayed Element contains the text
                            if (displayedElement.Text.Contains(containsText))
                            {
                                isItemPresent = true;
                                break;
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }

                Delay(waitIntervalInMiliSec);
                currentWaitIntervals++;
                currentWaitTime = currentWaitIntervals * (waitIntervalInMiliSec) / 1000;

            } while (!isItemPresent && (currentWaitTime < BRGlobalVars.DEFAULT_TIMEOUT));

            return isItemPresent;

        }
       
        //public void ScrollElementToScreenCenter()
        //{
        //    IWebElement element = FindElement();
        //    //int x_position = element.Location.X;
        //    int x_position = 0;
        //    int y_position = element.Location.Y - 1080 / 2;
        //    ScrollToPosition(x_position, y_position);
        //}

        //public void ScrollToPosition(int x, int y)
        //{
        //    string script = "window.scrollTo(" + x.ToString() + "," + y.ToString() + ")";
        //    ExecuteScript(script);
        //}

        //public static object ExecuteScript(string script)
        //{
        //    return ((IJavaScriptExecutor)Browser).ExecuteScript(script);
        //}


      protected By GetFindBy(params string[] locator)
        {
            if(locator.Length != 0)
            {
                Locator = locator[0];
            }
            By by = null;
            try
            {
                switch (LocatorType)
                {
                    case LocatorTypes.ID:
                        by = By.Id(Locator);
                        break;
                    case LocatorTypes.TAGNAME:
                        by = By.TagName(Locator);
                        break;
                    case LocatorTypes.LINKTEXT:
                        by = By.LinkText(Locator);
                        break;
                    case LocatorTypes.CLASS:
                        by = By.ClassName(Locator);
                        break;
                    case LocatorTypes.CSS:
                        by = By.CssSelector(Locator);
                        break;
                    case LocatorTypes.NAME:
                        by = By.Name(Locator);
                        break;
                    case LocatorTypes.XPATH:
                        by = By.XPath(Locator);
                        break;
                }
            }
            catch (Exception e)
            {
               
            }


            return by;
        }

        protected By GetFindBy(LocatorTypes LocatorType,  params string[] locator)
        {
            if (locator.Length != 1)
            {
                Locator = locator[0];
            }
            By by = null;
            try
            {
                switch (LocatorType)
                {
                    case LocatorTypes.ID:
                        by = By.Id(Locator);
                        break;
                    case LocatorTypes.TAGNAME:
                        by = By.TagName(Locator);
                        break;
                    case LocatorTypes.LINKTEXT:
                        by = By.LinkText(Locator);
                        break;
                    case LocatorTypes.CLASS:
                        by = By.ClassName(Locator);
                        break;
                    case LocatorTypes.CSS:
                        by = By.CssSelector(Locator);
                        break;
                    case LocatorTypes.NAME:
                        by = By.Name(Locator);
                        break;
                    case LocatorTypes.XPATH:
                        by = By.XPath(Locator);
                        break;
                }
            }
            catch (Exception e)
            {

            }


            return by;
        }

        protected By GetFindBys(string locator)
        {
            By by = null;
            if (locator.StartsWith("//"))
            {
                by = By.XPath(Locator);
            }
            else if (locator.StartsWith("XPath-"))
            {
                string sel = Locator.Replace("XPath-", "");
                by = By.XPath(@sel);
            }
            else if (locator.StartsWith("PartialLinkText-"))
            {
                string sel = Locator.Replace("PartialLinkText-", "");
                by = By.PartialLinkText(sel);
            }
            else if (locator.StartsWith("LinkText-"))
            {
                string sel = Locator.Replace("LinkText-", "");
                by = By.LinkText(sel);
            }
            else if (locator.StartsWith("Id-"))
            {
                string sel = Locator.Replace("Id-", "");
                by = By.Id(sel);
            }
            else if (locator.StartsWith("Class-"))
            {
                string sel = Locator.Replace("Class-", "");
                by = By.ClassName(sel);
            }
            else
            {
                by = By.CssSelector(Locator);
            }

            return by;
        }



        #endregion

        #region Statics-cling!

        #endregion

    }
    public enum LocatorTypes
    {
        CLASS,
        TAGNAME,
        ID,
        LINKTEXT,
        PARTIALLINKTEXT,
        CSS,
        XPATH,
        NAME

    }
}

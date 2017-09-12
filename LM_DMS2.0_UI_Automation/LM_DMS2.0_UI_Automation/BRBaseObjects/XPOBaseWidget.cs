using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LastMile.Web.Automation.BRBaseObjects
{
    public class XPOBaseWidget
    {
        #region MemberVar

        //        private string m_Locator;
        //        private string m_ControlType;
        //        private string m_DisplayName;
        private By m_FindBy = null;
        private IWebElement m_element = null;
        private const int implicitWaitMiliSeconds = 100;



        #endregion

        #region Properties

        public By FindBy
        {
            get
            {
                return m_FindBy;
            }

            set
            {
                m_FindBy = value;
            }
        }
        //public string Locator
        //{
        //    get
        //    {
        //        return m_Locator;
        //    }

        //    set
        //    {
        //        m_Locator = value;
        //    }
        //}

        //public string ControlType
        //{
        //    get
        //    {
        //        return m_ControlType;
        //    }

        //    set
        //    {
        //        m_ControlType = value;
        //    }
        //}

        //public string DisplayName
        //{
        //    get
        //    {
        //        return m_DisplayName;
        //    }

        //    set
        //    {
        //        m_DisplayName = value;
        //    }
        //}

        //public string Locator
        //{
        //    get
        //    {
        //        return m_Locator;
        //    }

        //    set
        //    {
        //        m_Locator = value;
        //    }
        //}

        //public string ControlType
        //{
        //    get
        //    {
        //        return m_ControlType;
        //    }

        //    set
        //    {
        //        m_ControlType = value;
        //    }
        //}

        //public string DisplayName
        //{
        //    get
        //    {
        //        return m_DisplayName;
        //    }

        //    set
        //    {
        //        m_DisplayName = value;
        //    }
        //}

        public static IWebDriver Browser
        {
            get
            {
                return XPOBrowser.Browser;
            }
        }

        #endregion

        #region Constructors

        public XPOBaseWidget()
        {
            //            Locator = locator;
            //            ControlType = controlType;
            //            DisplayName = displayName;
            //            FindBy = findBy;
        }

        #endregion

        #region Methods

        public bool Click()
        {
            bool m_wasClicked = false;

            if (IsDisplayed())
            {
                FindElement().Click();
                m_wasClicked = true;
            }
            return m_wasClicked;
        }

        public static void Delay(int milliSeconds)
        {
            //Utilities.MilliSecondDelay(milliSeconds);
        }

        public bool DoesElementExist(By by)
        {
            bool elementExists = false;
            try
            {
                IWebElement e = FindElement(by);
                if (e != null)
                {
                    elementExists = true;
                }

            }
            catch (Exception)
            {
                elementExists = false;
            }

            return elementExists;
        }

        public IWebElement FindElement()
        {
            //            if (m_element == null)
            //            {
            Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(implicitWaitMiliSeconds);
            try
            {
                m_element = Browser.FindElement(FindBy);
            }
            catch (Exception ex)
            {
            }

            //            }

            return m_element;
        }


        public IWebElement FindElement(By by)
        {
            IWebElement element = null;
            Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(implicitWaitMiliSeconds);
            element = Browser.FindElement(by);

            return element;
        }

        public List<IWebElement> FindElements(By by)
        {
            List<IWebElement> elementList = null;
            try
            {
                Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(implicitWaitMiliSeconds);
                elementList = Browser.FindElements(by).ToList();
            }
            catch (Exception)
            {

            }

            return elementList;
        }

        public string GetAttribute(string attribute)
        {
            return FindElement().GetAttribute(attribute);
        }

        public int GetCount()
        {
            return Browser.FindElements(FindBy).Count;
        }

        public void Hover()
        {
            Actions act = new Actions(Browser);
            Actions hoverOnMyItem = act.MoveToElement(FindElement());
            hoverOnMyItem.Perform();
        }

        public bool Selected()
        {
            return FindElement().Selected;
        }

        public virtual void SendKeys(string keys)
        {
            FindElement().SendKeys(keys);
        }

        public virtual void SendEnter()
        {
            FindElement().SendKeys(Keys.Enter);
        }

        public virtual void Clear()
        {
            FindElement().Clear();
        }

        public string Text()
        {
            return FindElement().Text;
        }

        public string Value()
        {
            return FindElement().GetAttribute("value");
        }

        public bool DoesElementExist()
        {
            bool elementExists = false;
            try
            {
                Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(100);
                IWebElement e = FindElement();
                elementExists = true;
                Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            }
            catch (Exception ex)
            {
                elementExists = false;
                Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            }

            return elementExists;
        }


        public bool IsDisplayed()
        {
            return IsDisplayed(FindBy);
        }

        public bool IsDisplayed(By by)
        {
            bool isDisplayed = false;

            try
            {
                if (DoesElementExist(by))
                {
                    IWebElement e = FindElement(by);
                    isDisplayed = e.Displayed;
                }
                //If element does NOT exist it is NOT displayed
                else
                {
                    isDisplayed = false;
                }
            }

            //If an exception occured 
            catch (Exception ex)
            {
                isDisplayed = false;
            }

            return isDisplayed;
        }

        public bool WaitTilNotVisible(int maxWaitTime)
        {

            TimeSpan ts = new TimeSpan(0, 0, maxWaitTime);
            WebDriverWait wdw = new WebDriverWait(Browser, ts);
            wdw.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            return wdw.Until(ExpectedConditions.InvisibilityOfElementLocated(FindBy));
        }

        public bool WaitTilIsVisible(int maxWaitTime)
        {
            TimeSpan ts = new TimeSpan(0, 0, maxWaitTime);
            WebDriverWait wdw = new WebDriverWait(Browser, ts);
            wdw.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            IWebElement e = wdw.Until(ExpectedConditions.ElementIsVisible(FindBy));
            if (e == null)
            {
                return false;
            }

            return true;
        }

        public void ScrollElementToScreenCenter()
        {
            IWebElement element = FindElement();
            //int x_position = element.Location.X;
            int x_position = 0;
            int y_position = element.Location.Y - 1080 / 2;
            ScrollToPosition(x_position, y_position);
        }

        public void ScrollToPosition(int x, int y)
        {
            string script = "window.scrollTo(" + x.ToString() + "," + y.ToString() + ")";
            ExecuteScript(script);
        }

        public static object ExecuteScript(string script)
        {
            return ((IJavaScriptExecutor)Browser).ExecuteScript(script);
        }


        //private By GetFindBy(string locator)
        //{
        //    By by = null;
        //    if (locator.StartsWith("//"))
        //    {
        //        by = By.XPath(Locator);
        //    }
        //    else if (locator.StartsWith("XPath-"))
        //    {
        //        string sel = Locator.Replace("XPath-", "");
        //        by = By.XPath(@sel);
        //    }
        //    else if (locator.StartsWith("PartialLinkText-"))
        //    {
        //        string sel = Locator.Replace("PartialLinkText-", "");
        //        by = By.PartialLinkText(sel);
        //    }
        //    else if (locator.StartsWith("LinkText-"))
        //    {
        //        string sel = Locator.Replace("LinkText-", "");
        //        by = By.LinkText(sel);
        //    }
        //    else if (locator.StartsWith("Id-"))
        //    {
        //        string sel = Locator.Replace("Id-", "");
        //        by = By.Id(sel);
        //    }
        //    else
        //    {
        //        by = By.CssSelector(Locator);
        //    }

        //    return by;
        //}



        #endregion


    }
}

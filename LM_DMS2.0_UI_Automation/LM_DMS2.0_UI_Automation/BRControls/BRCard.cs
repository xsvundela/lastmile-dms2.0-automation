using LastMile.Web.Automation.BRBaseObjects;
using OpenQA.Selenium;
using System.Collections.Generic;
using Transport.Automation.Platform.Loggers;


namespace LastMile.Web.Automation.BRControls
{
    using BRLogger = XPOExtentXunitLogger;

    public class BRCard : BRBaseWidget
    {
        #region MemberVars
        
      
        #endregion

        #region Properties
       
        private BRBaseWidget CardHeader
        {
            get
            {
                string sel = Locator + ">card-header";
                return new BRBaseWidget(sel,LocatorTypes.CSS, "card-header", "Card Header");
            }
        }

        private BRBaseWidget CardTitle
        {
            get
            {
                string sel = CardHeader.Locator + " card-header-title";
                return new BRBaseWidget(sel, LocatorTypes.CSS, "card-title", "Card Title");
            }
        }

        private BRBaseWidget CardSubTitle
        {
            get
            {
                string sel = CardHeader.Locator + " card-header-subtitle";
                return new BRBaseWidget(sel, LocatorTypes.CSS,"card-subtitle", "Card SubTitle");
            }
        }
        private BRBaseWidget CardContent
        {
            get
            {
                string sel = Locator + ">card-content";
                return new BRBaseWidget(sel, LocatorTypes.CSS,"card-content", "Card Content");
            }
        }
        private BRBaseWidget CardActions
        {
            get
            {
                string sel = Locator + ">card-actions";
                return new BRBaseWidget(sel, LocatorTypes.CSS, "card-actions", "Card Actions");
            }
        }
       
        private BRBaseWidget CardActionButton
        {
            get
            {
                string sel = CardActions.Locator + " card-title";
                return new BRBaseWidget(sel, LocatorTypes.CSS, "card-title", "Card Title");
            }
        }
        #endregion

        #region Constructors

        public BRCard(string locator,LocatorTypes locatorType, string displayName) : base(locator, locatorType,"CARD", displayName)
        {
;
        }

        public BRCard(string displayName) : base(@"xpo-card",LocatorTypes.CSS, "CARD", displayName)
        {
            
        }

        #endregion

        #region Methods
        public bool TestCardContents()
        {
            this.WaitTilIsVisible();
            if(CardHeader.IsDisplayed() && CardTitle.IsDisplayed() && CardSubTitle.IsDisplayed() && CardContent.IsDisplayed() && CardActions.IsDisplayed())
            {
                return true;
            }
            else
            {
                if(!CardHeader.WaitTilIsVisible())
                {
                    BRLogger.LogInfo("Card Header is not available");
                }
                if (!CardTitle.WaitTilIsVisible())
                {
                    BRLogger.LogInfo("Card Title is not available");
                }
                if (!CardSubTitle.WaitTilIsVisible())
                {
                    BRLogger.LogInfo("Card Subtitle is not available");
                }
                if (!CardContent.WaitTilIsVisible())
                {
                    BRLogger.LogInfo("Card Content is not available");
                }
                if (!CardActions.WaitTilIsVisible())
                {
                    BRLogger.LogInfo("Card Action/s is not available");
                }
              
                return false;
            }
           
        }

        public bool TestCardContentText(string cardContent)
        {
            if (CardContent.Text().Contains(cardContent))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public string TestCardActionsPresent(params string[] cardContent)
        {
            bool buttonFound = false;
            string buttonsNotFound = string.Empty;
            string action;
            for (int i = 0; i < cardContent.Length; i++)
            {
                action= cardContent[i];
                List<IWebElement> buttons= CardActions.FindElements(GetFindBy(LocatorTypes.CSS,"button")); 

                foreach (IWebElement Button in buttons)
                {
                    if (Button.Text.Contains(action))
                    {
                        buttonFound = true;
                        break;
                    }

                }
                if(!buttonFound)
                {
                    if (buttonsNotFound == null)
                    {
                        buttonsNotFound = action;
                    }
                    else
                    {
                        buttonsNotFound = buttonsNotFound +":"+ action;
                    }
                }

            }

            return buttonsNotFound;

        }

        public bool CardActionClick(string buttonName)
        {
            bool buttonFound = false;
            CardActions.WaitTilDoneLoading();
            foreach (BRButton Button in CardActions.FindElements(GetFindBy(LocatorTypes.CSS,"button")))
            {
                if(Button.Text().Contains(buttonName))
                {
                    Button.WaitTilIsClickable();
                    Button.Click();
                    buttonFound = true;
                    break;
                }

            }            
           if(buttonFound)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Statics

        #endregion
    }
}
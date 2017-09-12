using LastMile.Web.Automation.BRBaseObjects;

namespace LastMile.Web.Automation.BRControls
{
    public class BRDatePicker : BRTextBox
    {
        #region MemberVars

        #endregion

        #region Properties


        public BRTextBox TodayPlusDays
        {
            get
            {
                string plus = @"input.xpoInt";
                return new BRTextBox(plus, LocatorTypes.CSS,"Today Plus Days");
            }
        }

        public BRButton Today
        {
            get
            {
                string sel = @"a[data-id=""today""]";
                return new BRButton(sel,LocatorTypes.XPATH, "Today");
            }
        }

        public BRButton Tomorrow
        {
            get
            {
                string sel = @"a[data-id=tommorrow]";
                return new BRButton(sel, LocatorTypes.XPATH, "Tomorrow");
            }
        }

        public BRButton ThisWeek
        {
            get
            {
                string sel = @"a[data-id=thisweek]";
                return new BRButton(sel, LocatorTypes.XPATH, "This Week");
            }
        }

        public BRButton ThisWeekend
        {
            get
            {
                string sel = @"a[data-id=thisweekend]";
                return new BRButton(sel, LocatorTypes.XPATH, "This Weekend");
            }
        }

        public BRButton NextWeek
        {
            get
            {
                string sel = @"a[data-id=nextweek]";
                return new BRButton(sel, LocatorTypes.XPATH, "Next Week");
            }
        }

        public BRButton CustomRange
        {
            get
            {
                string sel = @"a[data-id=customrange]";
                return new BRButton(sel, LocatorTypes.XPATH, "Custom Range");
            }
        }


        public BRTextBox StartDate
        {
            get
            {
                string sel = @"input#Filter_PickupDate_Min";
                return new BRTextBox(sel, LocatorTypes.XPATH, "Start Date");
            }
        }

        public BRTextBox EndDate
        {
            get
            {
                string sel = @"input#Filter_PickupDate_Max";
                return new BRTextBox(sel, LocatorTypes.XPATH, "End Date");
            }
        }

        public BRTextBox Done
        {
            get
            {
                string sel = @"button[class ^= 'ui-datepicker-close']";
                return new BRTextBox(sel, LocatorTypes.XPATH, "End Date");
            }
        }

        #endregion

        #region Constructors
        public BRDatePicker(string locator, LocatorTypes locatorType, string displayName) : base(locator, locatorType, "DatePicker", displayName)
        {
        }

        #endregion

        #region Methods

        public void Close()
        {
        }

        public bool SetDate(string date)
        {
            SendKeys(date);
            Done.WaitTilIsVisible();
            Done.ScrollElementToScreenCenter();
            Done.Click();
            return true;

        }

        #endregion

        #region Statics

        #endregion
    }
}
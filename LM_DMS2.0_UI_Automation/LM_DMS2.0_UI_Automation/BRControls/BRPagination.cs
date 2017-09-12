using LastMile.Web.Automation.BRBaseObjects;
using System;
using Transport.Automation.Platform.Loggers;

namespace LastMile.Web.Automation.BRControls
{
    using BRLogger = XPOExtentXunitLogger;
    public class BRPagination : BRBaseWidget
    {
        private int m_pagenumber;
        private int m_rowposition;
        private int m_columnposition;
        private int PageNumber
        {
            get
            {
                return m_pagenumber;
            }

            set
            {
                m_pagenumber = value;
            }
        }
        private int RowPosition
        {
            get
            {
                return m_rowposition;
            }

            set
            {
                m_rowposition = value;
            }
        }
        private int ColumnPosition
        {
            get
            {
                return m_columnposition;
            }

            set
            {
                m_columnposition = value;
            }
        }

        private BRBaseWidget PreviousPage
        {
            get
            {
                string sel = Locator + "/li[contains(@class,'pagination-previous')]";
                return new BRBaseWidget(sel, LocatorTypes.XPATH, "PreviousPage", "Previous Page");
            }
        }

        private BRBaseWidget NextPage
        {
            get
            {
               string sel = Locator + "/li[contains(@class,'pagination-next')]";
                return new BRBaseWidget(sel, LocatorTypes.XPATH, "PreviousPage", "Previous Page");
            }
        }

        private BRBaseWidget Page
        {
            get
            {
                string sel = Locator + @"//li[{0}]";
                sel = sel.Replace("{0}", Convert.ToString(PageNumber + 1));
                return new BRBaseWidget(sel, LocatorTypes.XPATH, "grid", "Grid");
            }
        }

        private BRBaseWidget Pages
        {
            get
            {
                string sel = Locator + "/li";
                return new BRBaseWidget(sel, LocatorTypes.XPATH, "PreviousPage", "Previous Page");
            }
        }

        public BRPagination(string displayName) : base(@"//ul[@class='paginationUl']", LocatorTypes.XPATH, "Grid", displayName) { }

        public void NavigateToPage(string pageNumber)
        {
       
            PageNumber = Convert.ToInt32(pageNumber);
            if(Page.isEnabled())
            {
                Page.Click();
            }
            else if(Page.GetAttribute("class").Equals("current"))
            {
                BRLogger.LogInfo("The user is already on the "+pageNumber+" page.");
            }
            else
            {
               
                BRLogger.AssertFail(pageNumber+" is not enabled to be clicked.");
            }


        }

        public void GoToPreviousPage()
        {
           if (PreviousPage.isEnabled())
            {
                PreviousPage.Click();
            }
           else
            {
                BRLogger.LogInfo("User is on the first page.");
            }
        }

        public void GoToNextPage()
        {
            if (NextPage.isEnabled())
            {
                NextPage.Click();
            }
            else
            {
                BRLogger.LogInfo("User is on the Last page.");
            }
        }

        public void GoToPreviousPage(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (PreviousPage.isEnabled())
                {
                    PreviousPage.Click();
                }
                else
                {
                    BRLogger.LogInfo("User is on the first page.");
                    break;
                }
            }
        }

        public void GoToNextPage(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (NextPage.isEnabled())
                {
                    NextPage.Click();
                }
                else
                {
                    BRLogger.LogInfo("User is on the Last page.");
                    break;
                }
            }
        }

        public void IsFirstPage()
        {
            BRLogger.AssertIsTrue(!PreviousPage.isEnabled(), "User is on the First Page");
        }

        public void IsLastPage()
        {
            BRLogger.AssertIsTrue(! NextPage.isEnabled(),"User is on the Last Page");
        }

        public int NumberofPages()
        {
            int count = 1;
            count = Pages.GetCount();
            Pages.WaitTilIsVisible();
            // would need to update

            if(count==1)
            {
                return count;
            }
            count = Pages.GetCount() - 2;
            return count;
        }
    }
}

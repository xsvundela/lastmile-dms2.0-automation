
using LastMile.Web.Automation.BRBaseObjects;

namespace LastMile.Web.Automation.BRControls
{
    public class BRTable : BRBaseWidget
    {


        private BRBaseWidget TableBody
        {
            get
            {
                string sel = @"tbody";
                return new BRBaseWidget(sel, LocatorTypes.XPATH, "tablebody", "Table Body");
            }
        }

        private BRBaseWidget TableRow
        {
            get
            {
                string sel = Locator + ">" + TableBody.Locator + "> tr";
                return new BRBaseWidget(sel, LocatorTypes.CSS, "rows", "Table Body Rows");
            }
        }

        public BRTable(string locator,LocatorTypes locatorType, string displayName) : base(locator, locatorType, "Table", displayName) { }

        public int GetRowCount()
        {
            TableRow.WaitTilIsVisible();
            int count = TableRow.GetCount();
            return count;
        }

        public bool DoesRowExist(string item)
        {
            string sel = "//tbody/tr//*[contains(text(), '" + item + "')]";
            BRBaseWidget row = new BRBaseWidget(sel, LocatorTypes.XPATH, "tableitem", "Table Item");

            return row.DoesExist();
        }

        public BRBaseWidget GetRow(string item)
        {
            string sel = "//tbody/tr//*[contains(text(), '" + item + "')]//parent::tr";
            BRBaseWidget row = new BRBaseWidget(sel, LocatorTypes.XPATH,"tablerow", "Table Row");

            return row;
        }

        public bool WaitUntilReady()
        {
            bool IsReady = true;
            IsReady = WaitTilIsVisible();
            IsReady &= TableRow.WaitTilIsVisible();
            Delay(500);

            return IsReady;
        }


    }
}


using System;

using LastMile.Web.Automation.BRBaseObjects;

namespace LastMile.Web.Automation.BRControls


{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Linq;
    public class BRFieldSet : BRBaseWidget
    {
        #region Properties

        BRBaseWidget FieldSet
        {
            get
            {
                string sel = "//fieldset/legend[contains(text(),'" + Locator + "')]";
                return new BRBaseWidget(sel,LocatorTypes.XPATH ,"fieldset", "Field Set");
            }
        }

        BRButton EditButton
        {
            get
            {
                string sel = Locator + "/" + @"a[contains(@title, 'Edit')]";
                return new BRButton(sel,LocatorTypes.XPATH, "Edit");
            }
        }

        BRButton Save
        {
            get
            {
                string sel = Locator + "/" + @"a[contains(@title, 'Save')]";
                return new BRButton(sel, LocatorTypes.XPATH, "Save");
            }
        }

        BRButton Cancel
        {
            get
            {
                string sel = Locator + "/" + @"a[contains(@title, 'Cancel')]";
                return new BRButton(sel, LocatorTypes.XPATH, "Cancel");
            }
        }


        #endregion

        public BRFieldSet(string Locator, LocatorTypes locatorType, string DisplayName) : base(Locator,  locatorType, "fieldset", DisplayName) { }

        public bool ClickEdit ()
        {
            bool m_WasEdited = false;

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    EditButton.WaitTilIsVisible();
                    EditButton.Click();
                    break;
                }
                catch (Exception)
                {
                    Delay(250);
                }
            }

            return m_WasEdited;
        }

        public bool ClickSave ()
        {
            Save.Click();

            EditButton.WaitTilIsVisible();

            return true;
        }

        public virtual string GetPropertyValue(string prop)
        {

            string tableSel = @"table.table.table-condensed";
            string propValue = "The value was not found";

            BRBaseWidget table = new BRBaseWidget(tableSel, LocatorTypes.CSS, "table", "Field Set ");


            IReadOnlyCollection<IWebElement> tableRows = table.FindElements(By.CssSelector(@"tr.table-row"));

            if (tableRows.Count > 0)
            {
                foreach (IWebElement row in tableRows)
                {
                    // Check the cell - and get the value from the second cell
                    IReadOnlyCollection<IWebElement> cells = row.FindElements(By.TagName("td"));
                    if (cells.Count > 0)
                    {
                        if (cells.ElementAt(0).Text == prop + ":")
                        {
                            return cells.ElementAt(1).Text;
                        }
                    }
                }
            }
            else
            {
               // throw new XPOException("There are no table rows available.");
            }
            return propValue;
        }

        public bool WaitTilReady()
        {
            string sel = FieldSet.Locator + "/following-sibling::/div/div[@id='loadingspinner']";
            BRBaseWidget spinner = new BRBaseWidget(sel,LocatorTypes.CSS ,"fieldset", "Field Set");
            spinner.WaitTilNotVisible();    

            return true;
        }


        protected BRBaseWidget GetFieldSet()
        {
            string sel = "//fieldset/legend[contains(text(),'" + Locator + "')]";
            return new BRBaseWidget(sel, LocatorTypes.XPATH, "fieldset", "Field Set");
        }
    }


}

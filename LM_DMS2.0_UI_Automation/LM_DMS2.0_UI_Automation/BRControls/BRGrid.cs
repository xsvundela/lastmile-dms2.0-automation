using LastMile.Web.Automation.BRBaseObjects;

namespace LastMile.Web.Automation.BRControls
{
    public class BRGrid : BRBaseWidget
    {

        private string m_RowIndex = string.Empty;
        private string m_ChildIndex = string.Empty;
        private string m_SubchildIndex = string.Empty;
        private string m_SubchildIndex2 = string.Empty;

        public string RowIndex
        {
            get
            {
                return m_RowIndex;
                
            }
            set
            {
                m_RowIndex = value;
            }
        }
        public string ChildIndex
        {
            get
            {
                return m_ChildIndex;

            }
            set
            {
                m_ChildIndex = value;
            }
        }

        public string SubchildIndex
        {
            get
            {
                return m_SubchildIndex;

            }
            set
            {
                m_SubchildIndex = value;
            }
        }


        public string SubchildIndex2
        {
            get
            {
                return m_SubchildIndex2;

            }
            set
            {
                m_SubchildIndex2 = value;
            }
        }

        //the grid
        public BRGrid(string locator, LocatorTypes locatorTypes,  string displayName) : base(locator,locatorTypes, "Grid", displayName) { }

        //Rows

        private BRBaseWidget GridRows
        {
            get
            {
                string sel = Locator + "/li";
                return new BRBaseWidget(sel, LocatorTypes.CSS, "card-header", "Card Header");
            }
        }

        private BRBaseWidget GridRow
        {
            get
            {
                string sel = Locator + "/l1[{0}]";
                sel = sel.Replace("{0}", RowIndex);
                return new BRBaseWidget(sel, LocatorTypes.CSS, "card-header", "Card Header");
            }
        }

        //child
        private BRBaseWidget GridChildren
        {
            get
            {
                string sel = GridRow + "/div";
                return new BRBaseWidget(sel, LocatorTypes.CSS, "card-header", "Card Header");
            }
        }
        private BRBaseWidget GridChild
        {
            get
            {
                string sel = GridRow + "/div[{0}]";
                sel = sel.Replace("{0}", ChildIndex);
                return new BRBaseWidget(sel, LocatorTypes.CSS, "card-header", "Card Header");
            }
        }

        //subchild - level 1
        private BRBaseWidget GridSubChildren
        {
            get
            {
                string sel = GridChild + "/div";
                return new BRBaseWidget(sel, LocatorTypes.CSS, "card-header", "Card Header");
            }
        }
        private BRBaseWidget GridSubChild
        {
            get
            {
                string sel = GridChild + "/div[{0}]";
                sel = sel.Replace("{0}", SubchildIndex);
                return new BRBaseWidget(sel, LocatorTypes.CSS, "card-header", "Card Header");
            }
        }


        private BRBaseWidget GridSubChild2
        {
            get
            {
                string sel = GridSubChild + "/div[{0}]";
                sel = sel.Replace("{0}", SubchildIndex2);
                return new BRBaseWidget(sel, LocatorTypes.CSS, "card-header", "Card Header");
            }
        }
        //subchild - level 2

        //subchild - level 3

        public int GetRowCount()
        {
            GridRows.WaitTilIsVisible();
            int count = GridRows.GetCount();
            return count;
        }

       public bool SelectRow(int position)
        {
            RowIndex = position.ToString();
            GridRow.WaitTilIsVisible();
            GridRow.Click();
            return true;
        }

        public int GetColCount()
        {
            RowIndex = "1";
            GridChildren.WaitTilIsVisible();
            int count = GridChildren.GetCount();
            return count;
        }

        public string ChildText(int row , int child)
        {

            RowIndex =row.ToString();
            ChildIndex = child.ToString();
            GridChild.WaitTilIsVisible();
            return GridChild.Text();
        }

        public string SubChildText(int row, int child, int subChild)
        {
            RowIndex = row.ToString();
            ChildIndex = child.ToString();
            SubchildIndex = subChild.ToString();
            GridSubChild.WaitTilIsVisible();
            return GridSubChild.Text();
        }

        public BRBaseWidget GetRow(int row)
        {
            RowIndex = row.ToString();
            return GridRow;
        }

        public BRBaseWidget GetChild(int row, int child)
        {
            RowIndex = row.ToString();
            ChildIndex = child.ToString();
            return GridChild;
        }
        public BRBaseWidget GetSubChild(int row, int child, int subChild)
        {
            RowIndex = row.ToString();
            ChildIndex = child.ToString();
            SubchildIndex = subChild.ToString();
            return GridSubChild;
        }


        public BRBaseWidget GetSubChild2(int row, int child, int subChild, int subChild2)
        {
            RowIndex = row.ToString();
            ChildIndex = child.ToString();
            SubchildIndex = subChild.ToString();
            SubchildIndex2 = subChild2.ToString();
            return GridSubChild2;
        }

        public string SubChild2Text(int row, int child, int subChild, int subChild2)
        {
            RowIndex = row.ToString();
            ChildIndex = child.ToString();
            SubchildIndex = subChild.ToString();
            SubchildIndex2 = subChild2.ToString();
            GridSubChild2.WaitTilIsVisible();
            return GridSubChild2.Text();
        }
  /*      public string TestrowPresent(params string[] rowContent)
        {
            bool rowFound = false;
            string rowsNotFound = string.Empty;
            string action;
            for (int i = 0; i < rowContent.Length; i++)
            {
                action = rowContent[i];
              List<IWebElement> rows = LoadList.GetSubChild2(1, 1, 1, 1).FindElements(GetFindBy(LocatorTypes.XPATH, "//div[@class='xpo-bold']"));


                foreach (IWebElement row in rows)
                {
                    if (row.Text.Contains(action))
                    {
                        rowFound = true;
                        break;
                    }

                }
                if (!rowFound)
                {
                    if (rowsNotFound == null)
                    {
                        rowsNotFound = action;
                    }
                    else
                    {
                        rowsNotFound = rowsNotFound + ":" + action;
                    }
                }

            }

            return rowsNotFound;

        }
        */

    }

   
    }

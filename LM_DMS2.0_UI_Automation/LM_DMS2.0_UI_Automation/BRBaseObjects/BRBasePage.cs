using LastMile.Web.Automation.BRControls;

namespace LastMile.Web.Automation.BRBaseObjects
{
    public  class BRBasePage
    {
        private string m_loginas = string.Empty;
        private string m_password = string.Empty;
        public BRTextBox UserName
        {
            get
            {
                string sel = @"input#UserName";
                return new BRTextBox(sel, LocatorTypes.CSS, "User Name");
            }
        }

        public BRTextBox Password
        {
            get
            {
                string sel = @"input#Password";
                return new BRTextBox(sel, LocatorTypes.CSS, "Password");
            }
        }

        public BRButton SignIn
        {
            get
            {
                string sel = "//input[@value='Sign In']";
                return new BRButton(sel, LocatorTypes.XPATH, "Sign In");
            }
        }

        public virtual BRBasePage LoginAs(string loginAs, string password)
        {
            m_loginas = loginAs;
            m_password = password;
            UserName.WaitTilIsVisible();
            UserName.SendKeys(m_loginas);
            Password.SendKeys(m_password);
            SignIn.Click();
            return this;
        }
    }
}

using System;
using LastMile.Web.Automation.LMDMSPortal.CARPageObjects;
using Xunit;
using LastMile.Web.Automation.LMDMSPortal.LMBaseObjects;
using LastMile.Web.Automation.LMDMSPortal.LMDataObjects;



namespace LastMile.Web.Automation.LMDMSPortal.LMTests
{

    public class Login : LMBaseUITest
    {


        public Login()
        {
            TestCategory = "Login";
            Console.WriteLine("Inside the constructor of Login class");
        }

        //To verify if a new role is added.

        [Fact]
        public void TestLogin()
        {
            TestCaseBegin();
            LMLoginPageData m_BasePageData = new LMLoginPageData("Jturner_key");
            LMLoginPage LMbase = new LMLoginPage();
            LMbase.LoginAs(m_BasePageData.retrieveTestData("UserName"), m_BasePageData.retrieveTestData("Password"));

            BRBaseObjects.XPOBrowser.Close();
            
        }

        // Verify Cancelling add a new role.
        
    }
}


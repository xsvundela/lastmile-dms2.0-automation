using LastMile.Web.Automation.BRDataTypes;
using LastMile.Web.Automation.BRUtilities;
using System;
using System.Diagnostics;
using Transport.Automation.Platform.Loggers;
using Xunit;

namespace LastMile.Web.Automation.BRBaseObjects
{
    [TestCaseOrderer(
      CustomTestCaseOrderer.TypeName,
      CustomTestCaseOrderer.AssembyName)]
    public class BRUIFixture : XPOExtentXunitLogger, IDisposable
    {

        public BRUIFixture()
        {
            Debug.WriteLine("One Time Set up");
            ServerURL = BRGlobalVars.EXTENT_ADDRESS;
            string env = BRGlobalVars.ENV;
            TestProject = BRGlobalVars.PROJECT_NAME + env;
            UseExtentX = BRGlobalVars.USE_EXTENTX;
            StartTesting(BRGlobalVars.HTML_DIR, BRGlobalVars.SCREENSHOT_DIR);
        }

        private object MyNamespace()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //GlobalVars.SESSION.DeleteDoc();
            TestingComplete();
            XPOBrowser.Close();
        }
    }
}

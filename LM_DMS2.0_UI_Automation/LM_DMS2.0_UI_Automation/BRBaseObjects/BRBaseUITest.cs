using LastMile.Web.Automation.BRDataTypes;
using LastMile.Web.Automation.BRUtilities;
using System;
using Transport.Automation.Platform.Loggers;

namespace LastMile.Web.Automation.BRBaseObjects
{
    public class BRBaseUITest : XPOExtentXunitLogger, IDisposable
    {
        #region MemberVars
        private bool IsInConclusive = false;
        private static bool BrowserStarted = false;
        private static bool m_Blogin = false;
        
        //public static MPBaseWorkspace workspace = null;
        #endregion

        #region Properties
        public bool SkipTest
        {
            get
            {
                return IsInConclusive;
            }
        }

        public static bool Blogin
        {
            get
            {
                return m_Blogin;
            }
            set
            {
                m_Blogin = value;
            }
        }

        #endregion

        #region Constructors

        #endregion

        #region Methods
        public BRBaseUITest()
        {
            if (!BrowserStarted)
            {
               XPOBrowser.AddUserProfilePreference("download.default_directory", BRGlobalVars.DOWNLOAD_DIR);

                if (BRGlobalVars.DEVICE_NAME == "NONE")
                {
                    XPOBrowser.StartChrome(BRGlobalVars.DRIVE_PATH);
                }
                else
                {
                    XPOBrowser.StartChrome(BRGlobalVars.DRIVE_PATH, BRGlobalVars.DEVICE_NAME);
                }
                //XPOBrowser.StartChrome(BRGlobalVars.DRIVE_PATH);
                XPOBrowser.GoToUrl(BRGlobalVars.SERVER_ADDRESS);
                if (Blogin)
                {
                    BRBasePage login = new BRBasePage();
                    login.LoginAs(BRGlobalVars.DEFAULT_USER, BRGlobalVars.DEFAULT_PASS);
                }
                BrowserStarted = true;
            }
        }

        protected void AssertTestName(string testName)
        {
            var type = GetType();
            var queue = CustomTestCaseOrderer.QueuedTests[type.FullName];
            string dequeuedName;
            var result = queue.TryDequeue(out dequeuedName);
            // Assert.True(result);
            //Assert.Equal(testName, dequeuedName);
        }
        public virtual void Dispose()
        {

            var stacktrace = "";

            /*string.IsNullOrEmpty(NunitStackTrace)
                ? ""
                : string.Format("<pre>{0}</pre>", NunitStackTrace);*/

            // check for Modal dialogs left open
            //if found, Warn and screenshot it
            //then close it

            if (!string.IsNullOrEmpty(stacktrace))
            {
                //    //SOMETHING FATAL occurred...make all subsequent steps be INCONCLUSIVE
                //    //bMakeInConclusive = true;
                //    if (stacktrace.Contains("AssertIsTrue")  || stacktrace.Contains("LogInconclusive"))
                //    {
                //        //Assert failed need to start skipping the remaining tests
                //        //LogInconclusive("");
                //        TestStatus = SKIP;
                //        stacktrace = string.Empty;
                //    }
                //    else
                //    {
                LogException(stacktrace);
                //    }
            }

            TestCaseEnd(stacktrace);

        }





        #endregion

        #region Statics

        #endregion
    }
}

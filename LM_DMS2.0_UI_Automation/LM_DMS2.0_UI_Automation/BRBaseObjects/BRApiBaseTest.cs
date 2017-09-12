using System;
using System.Net;
using Transport.Automation.Platform.Loggers;

namespace LastMile.Web.Automation.BRBaseObjects
{
    public class BRAPIBaseTest : XPOExtentXunitLogger, IDisposable
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
        public BRAPIBaseTest()
        {

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
        /// <summary>
        /// Used to check the API server up or not
        /// </summary>
        /// <param name="hostAddress"></param>
        /// <returns></returns>
        public static HttpStatusCode PingHost(string hostAddress)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(hostAddress);
                request.Timeout = 30000;
                request.AllowAutoRedirect = false; // find out if this host is up and don't follow a redirector  
                using (var response = request.GetResponse())
                {
                    return HttpStatusCode.OK;
                }
            }
            catch(Exception)
            {                
                return HttpStatusCode.NotFound;
            }
        }  
        #endregion
    }

}
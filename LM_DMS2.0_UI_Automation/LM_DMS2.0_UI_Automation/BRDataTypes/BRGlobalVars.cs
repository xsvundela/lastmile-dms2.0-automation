using System.Collections.Generic;

namespace LastMile.Web.Automation.BRDataTypes
{
    class BRGlobalVars
    {

        private static BRPermaSession m_session = null;
        private static BRConfiguration m_config = null;
        private static bool m_IsNAUser;
        private static bool m_IsEUUser;
        private static Dictionary<string, string> testData;


        public static Dictionary<string, string> TESTDATA
        {
            get
            {
                return testData;
            }
            set
            {
                testData = value;
            }
        }
        public static BRPermaSession SESSION
        {
            get { return m_session ?? (m_session = new BRPermaSession()); }
        }

        private static BRConfiguration CONFIG
        {
            get { return m_config ?? (m_config = new BRConfiguration()); }
        }

        #region CTAPI
        public static string BaseApiServerUrl
        {
            get
            {
                return CONFIG.BaseServerUrl;
            }
        }

        public static string ServerUrlWIthPackage
        {
            get
            {
                return CONFIG.ServerWithPackageUrl;
            }
        }


        public static string ENV
        {
            get { return CONFIG.Env; }
        }
        #endregion CTAPI
        /// <summary
        /// </summary>
        public static string BROWSER
        {
            get
            {
                return CONFIG.Browser;
            }
        }

        public static bool IS_NA_USER
        {
            get
            {
                return m_IsNAUser;
            }
            set
            {
                m_IsNAUser = value;
            }
        }

        public static bool IS_EU_USER
        {
            get
            {
                return m_IsEUUser;
            }
            set
            {
                m_IsEUUser = value;
            }
        }

        public static bool ISQA
        {
            get
            {
                string suffix = SERVER_ADDRESS;
                if (suffix.ToUpper().EndsWith("QA"))
                {
                    return true;
                }

                return false;
            }
        }

        public static bool ISUAT
        {
            get
            {
                string suffix = SERVER_ADDRESS;
                if (suffix.ToUpper().EndsWith("UAT"))
                {
                    return true;
                }

                return false;
            }
        }

        public static bool ISMAIN
        {
            get
            {
                string suffix = SERVER_ADDRESS;
                if (suffix.ToUpper().EndsWith("MAIN"))
                {
                    return true;
                }

                return false;
            }
        }
        public static string DEVICE_NAME
        {
            get { return CONFIG.DeviceName; }
        }
        public static string DRIVE_PATH
        {
            get { return CONFIG.DrivePath; }
        }

        /// <summary>
        /// Gets the SERVER_ADDRESS. http:// url.
        /// </summary>
        /// <value>The SERVER_ADDRESS.</value>
        public static string SERVER_ADDRESS
        {
            get { return CONFIG.ServerAddress; }
        }

        public static string EXTENT_ADDRESS
        {
            get { return CONFIG.ExtentAddress; }
        }

        public static string PROJECT_NAME
        {
            get { return CONFIG.ProjectName; }
        }

        /// <summary>
        /// Gets the DEFAULT_TIMEOUT.
        /// </summary>
        /// <value>The DEFAULT_TIMEOUT.</value>
        public static int DEFAULT_TIMEOUT
        {
            get { return CONFIG.DefaultTimeout; }
        }

        /// <summary>
        /// Gets the DEFAULT signing password.
        /// </summary>
        /// <value>The DEFAULT_PASS.</value>
        public static string DEFAULT_PASS
        {
            get { return CONFIG.DefaultPassword; }
        }

        public static string DEFAULT_USER
        {
            get { return CONFIG.DefaultUser; }
        }

        public static string DEFAULT_NICE_USERNAME
        {
            get { return CONFIG.DefaultNiceName; }
        }

        public static string DEFAULT_EURO_PASS
        {
            get { return CONFIG.DefaultEuroPassword; }
        }

        public static string DEFAULT_EURO_USER
        {
            get { return CONFIG.DefaultEuroUser; }
        }

        public static string DEFAULT_EURO_NICE_USERNAME
        {
            get { return CONFIG.DefaultEuroNiceName; }
        }

        public static string SCREENSHOT_DIR
        {
            get { return CONFIG.ScreenShotDir; }
        }

        public static string SUPPORT_DIR
        {
            get { return CONFIG.SupportDir; }
        }

        public static string HTML_DIR
        {
            get { return CONFIG.HtmlDir; }
        }

        public static string DOWNLOAD_DIR
        {
            get
            {
                return SUPPORT_DIR + CONFIG.DownloadDir;
            }
        }

        public static string LANEPRICING_DIR
        {
            get
            {
                return SUPPORT_DIR + CONFIG.LanePricingDir;
            }
        }

        public static string CARRIERINSURANCE_DIR
        {
            get
            {
                return SUPPORT_DIR + CONFIG.CarrierInsuranceDir;

            }
        }

        public static bool USE_EXTENTX
        {
            get
            {
                return CONFIG.UseExtentX;
            }
        }

        public static string LOCALE
        {
            get { return CONFIG.Locale; }
        }


        #region ApiAutomation

        public static string TruckerPath_Login
        {
            get { return CONFIG.TruckerPathLogin; }
        }
        public static string TruckerPath_Password
        {
            get { return CONFIG.TruckerPathPassword; }
        }
        public static string BullHornServerUrl
        {
            get { return CONFIG.BullHornServerUrl; }
        }
        public static string TrackServerUrl
        {
            get { return CONFIG.TrackServerUrl; }
        }

        public static string WoodServerUrl
        {
            get { return CONFIG.WoodServerUrl; }
        }

        public static string PostingProcessorPath
        {
            get { return CONFIG.PostingProcessorPath; }
        }
        public static string JobInterval
        {
            get { return CONFIG.JobInterval; }
        }

        public static string ProcessRunningTime
        {
            get { return CONFIG.ProcessRunningTime; }
        }
        public static string PartnerMasterConnectionString
        {
            get { return CONFIG.PartnerMasterConnectionString; }
        }
        public static string PMRoleClientUrl
        {
            get { return CONFIG.PMRoleClientUrl; }
        }
        public static string PMPartnerClientUrl
        {
            get { return CONFIG.PMPartnerClientUrl; }
        }
        public static string PMUserAccessClientUrl
        {
            get { return CONFIG.PMUserAccessClientUrl; }
        }
        public static string XpoAdminServerUrl
        {
            get { return CONFIG.XpoAdminServerUrl; }
        }

        #endregion ApiAutomation

    }
}
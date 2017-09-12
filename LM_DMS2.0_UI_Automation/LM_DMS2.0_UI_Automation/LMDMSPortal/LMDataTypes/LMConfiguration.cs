using System.Xml;

namespace LastMile.Web.Automation.BRDataTypes
{
    class CARConfiguration : BRConfiguration 
    {
        #region MemberVars
        private static int m_timeOut = -1;
        private static string m_browser;
        private static string m_drivePath;
        private static string m_defaultUser;
        private static string m_defaultPassword;
        private static string m_defaultNiceName;
        private static string m_defaultEuroUser;
        private static string m_defaultEuroPassword;
        private static string m_defaultEuroNiceName;
        private static string m_htmlDir;
        private static string m_screenShotDir;
        private static string m_supportDir;
        private static string m_downloadDir;
        private static string m_lanePricingDir;
        private static string m_carrierInsuranceDir;
        private static string m_serverAddress;
        private static bool m_useExtentX;
        private static string m_locale;
        private static string m_env;
        private static string m_extentAddress;
        private static string m_projectName;
        private static string m_applicationName;


        #endregion

        #region Properties

        /// <summary>
        /// Gets the root node.
        /// </summary>
        /// <value>The root node.</value>
        public XmlNode RootNode
        {
            get { return base.GetXmlNode("Configuration"); }
        }


        public string Browser
        {
            get { return m_browser; }
            set { m_browser = value; }
        }

        public string DrivePath
        {
            get { return m_drivePath; }
            set { m_drivePath = value; }
        }

        public int DefaultTimeout
        {
            get { return m_timeOut; }
            set { m_timeOut = value; }
        }

        public string DefaultUser
        {
            get { return m_defaultUser; }
            set { m_defaultUser = value; }
        }

        public string DefaultPassword
        {
            get { return m_defaultPassword; }
            set { m_defaultPassword = value; }
        }

        public string DefaultNiceName
        {
            get { return m_defaultNiceName; }
            set { m_defaultNiceName = value; }
        }

        public string DefaultEuroUser
        {
            get { return m_defaultEuroUser; }
            set { m_defaultEuroUser = value; }
        }

        public string DefaultEuroPassword
        {
            get { return m_defaultEuroPassword; }
            set { m_defaultEuroPassword = value; }
        }

        public string DefaultEuroNiceName
        {
            get { return m_defaultEuroNiceName; }
            set { m_defaultEuroNiceName = value; }
        }

        public string ExtentAddress
        {
            get { return m_extentAddress; }
            set { m_extentAddress = value; }
        }

        public string ProjectName
        {
            get { return m_projectName; }
            set { m_projectName = value; }
        }


        public string HtmlDir
        {
            get { return m_htmlDir; }
            set { m_htmlDir = value; }
        }

        public string ScreenShotDir
        {
            get { return m_screenShotDir; }
            set { m_screenShotDir = value; }
        }

        public string SupportDir
        {
            get { return m_supportDir; }
            set { m_supportDir = value; }
        }

        public string DownloadDir
        {
            get { return m_downloadDir; }
            set { m_downloadDir = value; }
        }

        public string LanePricingDir
        {
            get { return m_lanePricingDir; }
            set { m_lanePricingDir = value; }
        }

        public string CarrierInsuranceDir
        {
            get { return m_carrierInsuranceDir; }
            set { m_carrierInsuranceDir = value; }
        }

        public string ServerAddress
        {
            get { return m_serverAddress; }
            set { m_serverAddress = value; }
        }

        public bool UseExtentX
        {
            get { return m_useExtentX; }
            set { m_useExtentX = value; }
        }

        public string Locale
        {
            get { return m_locale.ToUpper(); }
            set { m_locale = value; }
        }

        public string Env
        {
            get { return m_env.ToUpper(); }
            set { m_env = value; }
        }

        public string ApplicationName
        {
            get { return m_applicationName; }
            set { m_applicationName = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        public CARConfiguration() : base()
        {
            BRConfiguration config = new BRConfiguration();
            config.ApplicationName = "";

        }
        #endregion

        

       
    }
}
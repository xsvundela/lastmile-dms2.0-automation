
//using FreightOptimizer.FOResources;
using LM_DMS2._0_UI_Automation.LMResources;
using System.Resources;
using System.Xml;

namespace LastMile.Web.Automation.BRDataTypes
{
    class BRConfiguration : BRBaseXmlManager
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
        private static string m_devicenName;

        #region ApiAutomation
        private static string m_truckerPathLogin;
        private static string m_ruckerPathPassword;
        private static string m_bullHornServerUrl;
        private static string m_trackServerUrl;
        private static string m_woodServerUrl;
        private static string m_postingProcessorPath;
        private static string m_jobInterval;
        private static string m_processRunningTime;
        private static string m_PMConnectionString;
        private static string m_PMRoleClientUrl;
        private static string m_PMPartnerClientUrl;
        private static string m_PMUserAccessClientUrl;
        private static string m_XpoAdminServerUrl;
        #endregion ApiAutomation

        #region CTApiAutomation
        private static string c_baseApiUrl;
        private static string c_baseWithPackageApiUrl;
        #endregion CTApiAutomation

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


        public string BaseServerUrl
        {
            get { return c_baseApiUrl; }
            set { c_baseApiUrl = value; }
        }
        public string ServerWithPackageUrl
        {
            get { return c_baseWithPackageApiUrl; }
            set { c_baseWithPackageApiUrl = value; }
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

        public string DeviceName
        {
            get { return m_devicenName; }
            set { m_devicenName = value; }
        }

        #region ApiAutomation

        public string TruckerPathLogin
        {
            get { return m_truckerPathLogin; }
            set { m_truckerPathLogin = value; }
        }
        public string TruckerPathPassword
        {
            get { return m_ruckerPathPassword; }
            set { m_ruckerPathPassword = value; }
        }
        public string BullHornServerUrl
        {
            get { return m_bullHornServerUrl; }
            set { m_bullHornServerUrl = value; }
        }
        public string TrackServerUrl
        {
            get { return m_trackServerUrl; }
            set { m_trackServerUrl = value; }
        }
        public string WoodServerUrl
        {
            get { return m_woodServerUrl; }
            set { m_woodServerUrl = value; }
        }

        public string PostingProcessorPath
        {
            get { return m_postingProcessorPath; }
            set { m_postingProcessorPath = value; }
        }
        public string JobInterval
        {
            get { return m_jobInterval; }
            set { m_jobInterval = value; }
        }
        public string ProcessRunningTime
        {
            get { return m_processRunningTime; }
            set { m_processRunningTime = value; }
        }
        public string PartnerMasterConnectionString
        {
            get { return m_PMConnectionString; }
            set { m_PMConnectionString = value; }
        }
        public string PMRoleClientUrl
        {
            get { return m_PMRoleClientUrl; }
            set { m_PMRoleClientUrl = value; }
        }
        public string PMPartnerClientUrl
        {
            get { return m_PMPartnerClientUrl; }
            set { m_PMPartnerClientUrl = value; }
        }

        public string PMUserAccessClientUrl
        {
            get { return m_PMUserAccessClientUrl; }
            set { m_PMUserAccessClientUrl = value; }
        }

        public string XpoAdminServerUrl
        {
            get { return m_XpoAdminServerUrl; }
            set { m_XpoAdminServerUrl = value; }
        }
        #endregion ApiAutomation

        #endregion

        #region Constructors
        /// <summary>
        public BRConfiguration() : base("C:\\BUILD_AUTOMATION\\Config.xml")
        {
            
            Browser = GetConfigValue("BROWSER");
            DrivePath = GetConfigValue("DRIVE_PATH");
            DefaultTimeout = GetConfigIntValue("DEFAULT_TIMEOUT");
            HtmlDir = GetConfigValue("HTML_DIR");
            ScreenShotDir = GetConfigValue("SCREENSHOT_DIR");
            SupportDir = GetConfigValue("SUPPORT_DIR");
            DownloadDir = GetConfigValue("DOWNLOAD_DIR");
            LanePricingDir = GetConfigValue("LANEPRICING_DIR");
            CarrierInsuranceDir = GetConfigValue("CARRIERINSURANCE_DIR");
            UseExtentX = GetConfigBoolValue("USE_EXTENTX");
            Locale = GetConfigValue("LOCALE");
            Env = GetConfigValue("ENV");
            ApplicationName = GetConfigValue("APPLICATION");
            DeviceName = GetConfigValue("DEVICE");

            
            DefaultUser = GetResourceValue("DEFAULT_USER_" + Locale);
            DefaultPassword = GetResourceValue("DEFAULT_PASS_" + Locale);
            DefaultNiceName = GetResourceValue("DEFAULT_NICE_USERNAME_" + Locale);
            ServerAddress = GetResourceValue("SERVER_ADDRESS_" + Env);
            ExtentAddress = GetResourceValue("EXTENT_SERVER");
            ProjectName = GetResourceValue("PROJECT_NAME_" + Locale);

            /*   #region ApiAutomation
               TruckerPathLogin = GetResourceValue("TRUCKERPATH_LOGIN");
               TruckerPathPassword = GetResourceValue("TRUCKERPATH_PASSWORD");
               BullHornServerUrl = GetResourceValue("BULLHORNSERVER_URL");
               TrackServerUrl = GetResourceValue("TRACKSERVER_URL");
               WoodServerUrl = GetResourceValue("WOODSERVER_URL");
               PostingProcessorPath = GetResourceValue("POSTINGPROCESSOR_PATH");
               JobInterval= GetResourceValue("JOB_INTERVAL");
               ProcessRunningTime = GetResourceValue("PROCESSRUNNING_TIME");
               PartnerMasterConnectionString = GetResourceValue("PMCONNECTION_STRING");
               PMRoleClientUrl= GetResourceValue("PMSERVER_URL");
               PMPartnerClientUrl= GetResourceValue("PMSERVER_URL");
               PMUserAccessClientUrl= GetResourceValue("PMSERVER_URL");
               XpoAdminServerUrl = GetResourceValue("XPOADMINSERVER_URL");
               #endregion ApiAutomation */


            //Env = GetConfigValue("ENV");

            if(ApplicationName.Equals("LMAPI"))
            {
                if (Env.Equals("INT"))
                {

                    BaseServerUrl = GetResourceValue("INT_SERVER_URL_BASE");
                    ServerWithPackageUrl = GetResourceValue("SERVER_URL_WITH_PACKAGE");
                }
                else if (Env.Equals("STA"))
                {
                    BaseServerUrl = GetResourceValue("STA_SERVER_URL_BASE");
                    ServerWithPackageUrl = GetResourceValue("SERVER_URL_WITH_PACKAGE");
                }
                else if(Env.Equals("LocalHost"))
                {
                    BaseServerUrl = GetResourceValue("CFM_API_LocalHost");
                    ServerWithPackageUrl = GetResourceValue("CFM_API_Package");

                }
            }
           

        }
        #endregion

        #region Methods
        public virtual string GetResourceValue(string resourceName)
        {
            ResourceManager rm;
            switch (ApplicationName)
            {
                case "DMSPortal":
                    rm = new ResourceManager("LM_DMS2._0_UI_Automation.LMResources.LMConfig", typeof(LMConfig).Assembly);
                    break;
                default:
                    rm = new ResourceManager("LM_DMS2._0_UI_Automation.LMResources.LMConfig", typeof(LMConfig).Assembly);
                    break;
            }
            return rm.GetString(resourceName);

        }
        /// <summary>
        /// Gets the session value.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <returns></returns>
        public string GetConfigValue(string keyName)
        {
            return GetNodeValue(keyName);
        }

        /// <summary>
        /// Gets the int value.
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        /// <param name="defaultVal">The default val.</param>
        /// <returns></returns>
        public int GetConfigIntValue(string tagName, int defaultVal)
        {
            int id = defaultVal;

            try
            {
                id = int.Parse(GetConfigValue(tagName));
            }
            catch
            {
                id = defaultVal;
            }

            return id;
        }

        public bool GetConfigBoolValue(string tagName)
        {
            bool m_bool = false;
            string m_value = GetConfigValue(tagName).ToLower();
            m_bool = m_value == "true";
            return m_bool;
        }

        /// <summary>
        /// Gets the int value.
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        /// <returns></returns>
        public int GetConfigIntValue(string tagName)
        {
            return GetConfigIntValue(tagName, -1);
        }



        public string GetFOResourceValue(string resourceFileName, string resourceName)
        {
            ResourceManager rm = new ResourceManager("LastMile.Web.Automation.LMDMSPortal.LMResources." + resourceFileName, typeof(LMConfig).Assembly);
            return rm.GetString(resourceName);
        }


        #endregion

        #region Statics

        #endregion
    }


}
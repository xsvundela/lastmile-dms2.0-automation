using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.ObjectModel;

namespace LastMile.Web.Automation.BRBaseObjects
{
    public static class XPOBrowser
    {
        private static IWebDriver m_Driver;
        private static ChromeOptions options = new ChromeOptions();

        public static IWebDriver Browser
        {
            get
            {
                return m_Driver;
            }

            set
            {
                m_Driver = value;
            }
        }



        static XPOBrowser()
        {
            /*options = new ChromeOptions();
            options.AddArguments("chrome.switches", "--disable-extensions-file-access-check");
            options.AddArguments("disable-infobars");
            options.AddArgument("--start-maximized");

            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);*/
        }

        private static IWebElement FindElement(By by)
        {
            return Browser.FindElement(by);
        }

        public static ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Browser.FindElements(by);
        }


        public static void GoToUrl(string sURL)
        {
            try
            {
                Browser.Navigate().GoToUrl(sURL);
            }
            catch
            {
            }

        }

        public static void StartChrome(string chromePath, params string[] mobileName)
        {
            //ChromeOptions options = new ChromeOptions();
            options.AddArguments("chrome.switches", "--disable-extensions-file-access-check");
            options.AddArguments("disable-infobars");
            options.AddArgument("--start-maximized");
            if (mobileName.Length == 1)
            {
                options.EnableMobileEmulation(mobileName[0]);
            }
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            var chromeDriverService = ChromeDriverService.CreateDefaultService(chromePath);
            chromeDriverService.HideCommandPromptWindow = true;
            Browser = new ChromeDriver(chromeDriverService, options);
            Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(100);

        }
        public static void StartFirefox( params string[] mobileName)
        {
            
            Browser = new FirefoxDriver();
            Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(100);

            //resize
            if (mobileName.Length == 1)
            {
                options.EnableMobileEmulation(mobileName[0]);
            }


        }

        public static void AddUserProfilePreference(string prefToSet, string value)
        {
            options.AddUserProfilePreference(prefToSet, value);
        }

        public static void CaptureScreen(string screenShotFile)
        {
            Screenshot image = ((ITakesScreenshot)Browser).GetScreenshot();
            image.SaveAsFile(screenShotFile, ScreenshotImageFormat.Bmp);
        }

        public static void Close()
        {
            Browser.Close();
            Browser.Quit();
        }

        public static void Refresh()
        {
            Browser.Navigate().Refresh();
        }

        public static void SwitchToTab(int tab)
        {
            ReadOnlyCollection<string> tabs = Browser.WindowHandles;

            //Switch to tab -- 0 based index
            Browser.SwitchTo().Window(tabs[tab]);
        }
    }
    
}

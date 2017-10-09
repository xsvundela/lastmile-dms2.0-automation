using System;
using System.Net;
using LastMile.Web.Automation.BRBaseObjects;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.Common;
using System.Net.Http;

namespace LM_DMS2._0_UI_Automation.LMAPI.Common
{
    public class ServerStatus: BRAPIBaseTest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostAddress"></param>
        public static void PingServerUrl(string hostAddress)
        {
            try
            {
                HttpStatusCode pingStatus = PingHost(hostAddress);
                if (pingStatus != HttpStatusCode.OK)
                {
                    if (messageStatus == false)
                    {
                        LogWarning("The Server is down:-" + hostAddress);
                        messageStatus = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw;
            }
        }


       
    }
}

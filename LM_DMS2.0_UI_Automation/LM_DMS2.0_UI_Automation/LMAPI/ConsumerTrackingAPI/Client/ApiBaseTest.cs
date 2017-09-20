using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Transport.Automation.Platform.Loggers;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.Common;

namespace LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.Client
{
   public class ApiBaseTest: XPOExtentXunitLogger
    {
        public static bool status = false;
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
            catch (Exception)
            {
                return HttpStatusCode.NotFound;
            }
        }
        public static void PingServerUrl(string hostAddress)
        {
            try
            {
                HttpStatusCode pingStatus = PingHost(hostAddress);
                if (pingStatus != HttpStatusCode.OK)
                {
                    if (status == false)
                    {
                        LogWarning("The Server is down:-" + hostAddress);
                        status = true;
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

#region References
using System;
using System.Threading.Tasks;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.ViewModel;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.Common;
using LM_DMS2._0_UI_Automation.LMAPI.Common;
using LastMile.Web.Automation.BRDataTypes;
using System.Net;
using System.Net.Http;
#endregion References

namespace LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.Client
{
    public class ExtendedLMApiClient : LMApiClient
    {
        public static string xpoCTCoreServerUrl = BRGlobalVars.BaseApiServerUrl + BRGlobalVars.ServerUrlWIthPackage;

        public ExtendedLMApiClient() : base(new Uri(xpoCTCoreServerUrl))
        {
            ServerStatus.PingServerUrl(BRGlobalVars.BaseApiServerUrl);
        }

        public TrackingInformationAPIResponse GetResponse(int orderId, bool detailsStatus)
        {
            var task = GetDataAsync(orderId, detailsStatus);
            return task.Result;
        }
        /// <summary>
        /// Read the response from CT Api
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="detailsStatus"></param>
        /// <returns></returns>
        public async Task<TrackingInformationAPIResponse> GetDataAsync(int orderId, bool detailsStatus)
        {
            var result = await GetAsync<TrackingInformationAPIResponse>(new Uri(BaseUri, $"Order?orderId={orderId}&detail={detailsStatus}")).ConfigureAwait(false);
            return result;
        }


        //public httpstatuscode getserverstatus(int orderid, bool status)
        //{
        //    //httpclient client = new httpclient();
        //    //httpresponsemessage response = await client.getasync(new uri(baseuri, $"order?orderid={orderid}&detail={status}"));
        //    //return response.res
        //    httpstatuscode pingstatus = pingho(new uri(baseuri, $"order?orderid={orderid}&detail={detailsstatus}"));


        //}
    }
}

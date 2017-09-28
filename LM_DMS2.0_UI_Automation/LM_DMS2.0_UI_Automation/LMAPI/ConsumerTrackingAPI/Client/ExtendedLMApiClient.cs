#region References
using System;
using System.Threading.Tasks;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.ViewModel;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.Common;
using LM_DMS2._0_UI_Automation.LMAPI.Common;
using LastMile.Web.Automation.BRDataTypes;
#endregion References

namespace LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.Client
{
    public class ExtendedLMApiClient:LMApiClient
    {
        public static string xpoCTCoreServerUrl = BRGlobalVars.BaseApiServerUrl+BRGlobalVars.ServerUrlWIthPackage;

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



    }
}

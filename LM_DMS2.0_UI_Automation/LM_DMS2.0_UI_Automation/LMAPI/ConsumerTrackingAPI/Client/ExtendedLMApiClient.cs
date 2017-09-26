using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.ViewModel;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.Common;
using LM_DMS2._0_UI_Automation.LMAPI.Common;
using LastMile.Web.Automation.BRDataTypes;

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
        /// GetFilterValues
        /// </summary>
        /// <returns></returns>
        public async Task<TrackingInformationAPIResponse> GetDataAsync(int orderId, bool detailsStatus)
        {
            var result = await GetAsync<TrackingInformationAPIResponse>(new Uri(BaseUri, $"Order?orderId={orderId}&detail={detailsStatus}")).ConfigureAwait(false);
            return result;
        }



    }
}

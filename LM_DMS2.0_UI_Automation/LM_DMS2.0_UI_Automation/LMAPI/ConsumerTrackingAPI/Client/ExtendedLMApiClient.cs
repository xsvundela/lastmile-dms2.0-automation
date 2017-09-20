using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.ViewModel;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.Common;


namespace LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.Client
{
    public class ExtendedLMApiClient:LMApiClient
    {
        public static string xpoRatesServerUrl = "http://int-xlmapi.xpo.com/CTCoreAPI/api/v1/";//BRGlobalVars.XpoRatesServerUrl;
        public ExtendedLMApiClient() : base(new Uri(xpoRatesServerUrl))
        {        
        }

        public TrackingInformation GetData(int orderId, bool detailsStatus)
        {
            var task = GetDataAsync(orderId,detailsStatus);
            return task.Result;
        }
        /// <summary>
        /// GetFilterValues
        /// </summary>
        /// <returns></returns>
        public async Task<TrackingInformation> GetDataAsync(int orderId,bool detailsStatus)
        {    
            var result = await GetAsync<TrackingInformation>(new Uri(BaseUri, $"Order?orderId={orderId}&detail={detailsStatus}")).ConfigureAwait(false);
            return result;
        }
    }
}

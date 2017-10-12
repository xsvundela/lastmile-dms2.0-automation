using System;
using System.Threading.Tasks;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.Common;
using LM_DMS2._0_UI_Automation.LMAPI.Common;
using LastMile.Web.Automation.BRDataTypes;
using System.Net;
using System.Net.Http;
using Xpo.LastMile.CustomFieldManagement.Backend.Api.Site.Models;
using System.Collections.Generic;

namespace LM_DMS2._0_UI_Automation.LMAPI.CustomeFieldManagement.Client
{
    public  class XPOCustomeFieldManagementApiClient : LMApiClient
    {
       
       

        public static string xpoCTCoreServerUrl = BRGlobalVars.BaseApiServerUrl + BRGlobalVars.ServerUrlWIthPackage;

        public XPOCustomeFieldManagementApiClient() : base(new Uri(xpoCTCoreServerUrl))
        {
            ServerStatus.PingServerUrl(BRGlobalVars.BaseApiServerUrl);
        }

      

       
        /// <summary>
        /// GetValues
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<CustomField> GetApiResponse()
        {
            var task = GetValuesAsync();
            return task.Result;
        }
        /// <summary>
        /// GetValuesAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IList<CustomField>> GetValuesAsync()
        {
            // Removed .ConfigureAwait(false) from below line
            var result = await GetAsync<IList<CustomField>>(new Uri(BaseUri, $"v1/customfields")).ConfigureAwait(false);
            return result;
        }



       
    }
}

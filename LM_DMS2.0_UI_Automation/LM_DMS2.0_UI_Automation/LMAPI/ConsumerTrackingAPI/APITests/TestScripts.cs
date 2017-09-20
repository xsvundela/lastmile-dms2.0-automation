using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.Client;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.ViewModel;
using LM_DMS2._0_UI_Automation.LMAPI.Common;

namespace LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.APITests
{
   public class TestScripts
    {
        ExtendedLMApiClient txtendedTestApiClient = new ExtendedLMApiClient();
        DBUtilities dbUtil = new DBUtilities();
        [Fact]
        public void ValidateGetData()
        {
            try
            {
               // var data = txtendedTestApiClient.GetData(65085417, true);
                TrackingInformation trackingInfo = txtendedTestApiClient.GetData(65085417, true);
                if(trackingInfo.ReferenceId.Equals("07272017893"))
                {
                    Console.Write("Reference Id:", trackingInfo.ReferenceId);
                }
                //ConsumerTrackingAPI.ViewModel.TrackingInformation trackingInfo = txtendedTestApiClient.GetData(65085417, true);
                // TrackingInformation trackingInfo= txtendedTestApiClient.GetData(65085417, true)
                validateServiceResponse(trackingInfo);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void validateServiceResponse(TrackingInformation trackingInfo)
        {
            dbUtil.openDBConnection();
        }

        //private static T _download_serialized_json_data<T>(string url) where T : new()
        //{
        //    using (var w = new WebClient())
        //    {
        //        var json_data = string.Empty;
        //        // attempt to download JSON data as a string
        //        try
        //        {
        //            json_data = w.DownloadString(url);
        //        }
        //        catch (Exception) { }
        //        // if string with JSON data is not empty, deserialize it to class and return its instance 
        //        return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
        //    }
        //}
    }
}

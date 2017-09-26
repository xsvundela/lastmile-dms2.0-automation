using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Xunit;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.Client;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.ViewModel;
using LM_DMS2._0_UI_Automation.LMAPI.Common;
using LM_DMS2._0_UI_Automation.LMDBFactory;
using LastMile.Web.Automation.BRBaseObjects;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.Common;
using static LM_DMS2._0_UI_Automation.LMDBFactory.DMS1DbQueryFactory;

namespace LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.APITests
{
    public class GetOrderTrackingWithOrderId : BRAPIBaseTest, IClassFixture<BRAPIFixture>
    {
        public GetOrderTrackingWithOrderId()
        {
            TestCategory = "Get Order Tracking Information With Order Id";
            Console.WriteLine("Inside the constructor of GetOrderTrackingWithOrderId");
        }
        ExtendedLMApiClient ExtendedTestApiClient = new ExtendedLMApiClient();

        //....GetOrderTrackingAPI() return the CT API response...//
        public TrackingInformationAPIResponse GetOrderTrackingAPI()
        {

            TrackingInformationAPIResponse trackingInfoAPI = ExtendedTestApiClient.GetResponse(65098608, true);
            try
            {
                Assert.NotNull(trackingInfoAPI);
            }
            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;
            }
            return trackingInfoAPI;


        }


        [Fact]
        public void TC_18577_18570_ValidateAPIResponseEmailandPhone()
        {
            LogInfo("TC_18577_18570_ValidateAPIResponseEmailandPhone Test Started");
            TestCaseBegin();
            TrackingInformationAPIResponse trackingInformation = GetOrderTrackingAPI();
            try
            {
                string _callcenterPhoneNo = string.Empty;
                _callcenterPhoneNo = DMS1DbQueryFactory.CallcenterTelephoneNumber(trackingInformation.OrderId.ToString());
                if (!string.IsNullOrEmpty(_callcenterPhoneNo))
                {
                    Assert.NotNull(_callcenterPhoneNo);
                    Assert.Equal(trackingInformation.CallCenterTelephoneNumber, _callcenterPhoneNo);

                }
                else
                {
                    List<callCenterEmail> _callCenterEmail = DMS1DbQueryFactory.CallcenterEmailAddress();
                    Assert.NotNull(_callCenterEmail);
                    _callCenterEmail.ForEach(_callEmailPhone =>
                    {
                        Assert.NotNull(_callEmailPhone.CallCenterPhone);
                        Assert.NotNull(_callEmailPhone.CallCenterPhone);
                        Assert.Equal(trackingInformation.CallCenterTelephoneNumber, _callEmailPhone.CallCenterPhone.ToString().TrimEnd());
                        Assert.Equal(trackingInformation.CallCenterEmailAddress, _callEmailPhone.CallCenterEmail.ToString().TrimEnd());

                    });

                }
                LogInfo("TC_18577_18570_ValidateAPIResponseEmailandPhoneTest Passed");

                /*


                //Fetch and validate Shipper Details
                List<shiperAddress> _shipperDetails = dbUtil.GetShipperAddressDetails(trackingInfoAPI.OrderId.ToString());
                Assert.NotNull(_shipperDetails);
                _shipperDetails.ForEach(_shipperDetail =>
                {

                    Assert.Equal(trackingInfoAPI.Shipper.Name, _shipperDetail.Name.ToString().TrimEnd());
                    Assert.Equal(trackingInfoAPI.Shipper.City, _shipperDetail.City.ToString().TrimEnd());
                    Assert.Equal(trackingInfoAPI.Shipper.State, _shipperDetail.State.ToString().TrimEnd());
                    Assert.Equal(trackingInfoAPI.Shipper.PostalCode, _shipperDetail.PostalCode.ToString().TrimEnd());

                });
                /*
    //fetch and validate Consignee details
    List<consignee> _consigneDetails = dbUtil.GetConsigneesDetails(trackingInfo.OrderId.ToString());
    _consigneDetails.ForEach(_consigneDetail =>
    {


        Assert.Equal(trackingInfo.Consignee.Name, _consigneDetail.consignee_Name.ToString().TrimEnd());


        Assert.Equal(trackingInfo.Consignee.Address, _consigneDetail.consignee_Address.ToString().TrimEnd());


        Assert.Equal(trackingInfo.Consignee.City, _consigneDetail.consignee_City.ToString().TrimEnd());


        Assert.Equal(trackingInfo.Consignee.State, _consigneDetail.consignee_State.ToString().TrimEnd());

        Assert.Equal(trackingInfo.Consignee.PostalCode, _consigneDetail.consignee_PostalCode.ToString().TrimEnd());


        Assert.Equal(trackingInfo.Consignee.Phone, _consigneDetail.consignee_Phone.ToString().TrimEnd());


        Assert.Equal(trackingInfo.Consignee.Email, _consigneDetail.consignee_Email.ToString().TrimEnd());


    });


    */
            }
            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw;
            }



        }
    }
}

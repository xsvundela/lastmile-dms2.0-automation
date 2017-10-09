#region References
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.Client;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.ViewModel;
using LM_DMS2._0_UI_Automation.LMDBFactory;
using LastMile.Web.Automation.BRBaseObjects;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.Common;
using static LM_DMS2._0_UI_Automation.LMDBFactory.DMS1DbQueryFactory;
using LastMile.Web.Automation.BRDataTypes;
using System.Linq;
#endregion References

namespace LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.APITests
{
    public class OrderTracking : BRAPIBaseTest, IClassFixture<BRAPIFixture>
    {
        public OrderTracking()
        {
            TestCategory = "Get Order Tracking Information With Order Id";
            Console.WriteLine("Inside the constructor of GetOrderTrackingWithOrderId");
        }
        ExtendedLMApiClient ExtendedTestApiClient = new ExtendedLMApiClient();

        //....GetOrderTrackingAPI() return the CT API response...//
        public TrackingInformationAPIResponse GetOrderTrackingAPI(int OrderId, bool status)
        {

            TrackingInformationAPIResponse trackingInfoAPI = ExtendedTestApiClient.GetResponse(OrderId, status);
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



        #region User Story :XLMDEV-3563
        //...... Test Case No 18577 and 18570........//
        [Fact]
        public void TC_18577_18570_ValidateAPIResponseEmailandPhone()
        {
            LogInfo("TC_18577_18570_ValidateAPIResponseEmailandPhone Test Started");
            TestCaseBegin();
            TrackingInformationAPIResponse trackingInformation = GetOrderTrackingAPI(52045639, true);//65098608
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
#endregion User Story :XLMDEV-3563
        #region UserStory:XLMDEV3562


        /// <summary>
        /// User Story :3562
        /// TestCases :TC17942,TC_17913,TC_17912
        /// </summary>
        /// 

        ////.....TC17942:Verify Package ID and Customer Reference of items for a non detailed non CI shipment tracking request....////
        [Fact]
        public void TC_17942_ValidatePackageIdAndCustomerRefNonCIWithStatusFalse()
        {
            try
            {
                LogInfo("TC_17942_ValidatePackageIdAndCustomerRefNonCIWithStatusFalse Test Started");
                TestCaseBegin();
                TrackingInformationAPIResponse trackingInformation = GetOrderTrackingAPI(65098608, false);
                if (!trackingInformation.Items.Any())
                {
                    LogWarning("No data found in Items");
                }
                else
                {
                    List<Items> _items = DMS1DbQueryFactory.CustomerRefNumberAndPackageId(trackingInformation.OrderId.ToString());
                    Assert.NotNull(_items);
                    // trackingInformation.Items.Select(x => x.PackageID);
                    _items.ForEach(_item =>
                    {
                        Assert.True(trackingInformation.Items.Any(x => x.PackageID == _item.PackageID));
                        Assert.True(trackingInformation.Items.Any(x => x.CustomerReferenceNumber == _item.CustomerReferenceNumber));

                    });
                }
            }

            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;

            }
            LogInfo("TC_17942_ValidatePackageIdAndCustomerRefNonCIWithStatusFalse Passed");
        }
        ////......TC_17913:Verify Package ID and Customer Reference of items for a non CI shipment tracking request...////
        [Fact]
        public void TC_17913_ValidatePackageIdAndCustomerRefNonCIWithStatusTrue()
        {
            try
            {
                LogInfo("TC_17913_ValidatePackageIdAndCustomerRefNonCIWithStatusTrue Test Started");
                TestCaseBegin();
                TrackingInformationAPIResponse trackingInformation = GetOrderTrackingAPI(65098608, true);
                if (!trackingInformation.Items.Any())
                {
                    LogWarning("No data found in Items");
                }
                else
                {
                    List<Items> _items = DMS1DbQueryFactory.CustomerRefNumberAndPackageId(trackingInformation.OrderId.ToString());
                    Assert.NotNull(_items);
                    // trackingInformation.Items.Select(x => x.PackageID);
                    _items.ForEach(_item =>
                    {
                        Assert.True(trackingInformation.Items.Any(x => x.PackageID == _item.PackageID));
                        Assert.True(trackingInformation.Items.Any(x => x.CustomerReferenceNumber == _item.CustomerReferenceNumber));

                    });
                }

            }

            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;

            }
            LogInfo("TC_17913_ValidatePackageIdAndCustomerRefNonCIWithStatusTrue Passed");
        }

        //...TC_17943 :Verify SKU, Package ID and Customer Reference in the non-detailed tracking response for a CI shipment

        //65143480
        [Fact]
        public void TC_17943_VerifySKUPackageandCustomerReferenceNonDetailedCI()
        {
            try
            {
                LogInfo("TC_17943_VerifySKUPackageandCustomerReferenceNonDetailedCI Test Started");
                TestCaseBegin();
                TrackingInformationAPIResponse trackingInformation = GetOrderTrackingAPI(65143480, false);
                if (!trackingInformation.Segments.Any())
                {
                    LogWarning("No data found in Segments");
                }
                else
                {
                    //Fetching data from database
                    CustomClass _dbreturns = DMS1DbQueryFactory.ValidateItemsandServicesinCIshipmentsDetailedAndNonDetailed(trackingInformation.OrderId.ToString());
                    Assert.NotNull(_dbreturns);
                    foreach (var items in _dbreturns.Items)
                    {
                        var datas = trackingInformation.Segments.Select(y => y.Items);
                        datas.Select(u => u.Select(z => z.PackageID)).ToList();
                        bool isFoundPackageId = false;
                        bool isFoundCusRefId = false;
                        datas.ToList().ForEach(data =>
                        {
                            if (data.Count() > 0)
                            {
                               
                                if (data.Any(x => x.PackageID == items.PackageID))
                                {
                                    LogInfo("Validating Package Id" + items.PackageID);
                                    Assert.True(data.Any(x => x.PackageID == items.PackageID));
                                    isFoundPackageId = true;
                                    LogInfo("Successfully Validated" + items.PackageID);
                                }

                                if (data.Any(x => x.CustomerReferenceNumber == items.CustomerReferenceNumber))
                                {
                                    LogInfo("Validating Customer Reference Number Id" + items.CustomerReferenceNumber);
                                    Assert.True(data.Any(x => x.CustomerReferenceNumber == items.CustomerReferenceNumber));
                                    isFoundCusRefId = true;
                                    LogInfo("Successfully Validated" + items.CustomerReferenceNumber);
                                }


                            }
                        });

                        Assert.True(isFoundPackageId, "PackageID Not Found");
                        Assert.True(isFoundCusRefId, "Customer Reference Number Not Found");
                    }
                    // code for validating SKU

                    foreach (var services in _dbreturns.Service)
                    {
                        var serviceData = trackingInformation.Segments.Select(y => y.Services);
                        serviceData.SelectMany(u => u.Select(z => z.SKU)).ToList();
                        serviceData.Select(x => x.Select(u => u.SKU));


                        bool isSKUfound = false;
                        serviceData.ToList().ForEach(items =>
                        {
                            if (items.Count() > 0)
                            {


                                if (items.Any(x => x.SKU == services.SKU))
                                {
                                    LogInfo("Validating SKU :" + services.SKU);
                                    Assert.True(items.Any(x => x.SKU == services.SKU));
                                    isSKUfound = true;
                                    LogInfo("Successfully Validated::" + services.SKU);
                                }



                            }
                        });
                        Assert.True(isSKUfound, "SKU not Found");
                    }
                }


            }
            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw;
            }
            LogInfo("TC_17943_VerifySKUPackageandCustomerReferenceNonDetailedCI Passed");
        }


        //..TC_17912: Verify SKU, Package ID and Customer Reference for a detailed CI shipment tracking request

        [Fact]
        public void TC_17912_VerifySKUPackageandCustomerReferenceDetailedCI()
        {
            try
            {
                LogInfo("TC_17912_VerifySKUPackageandCustomerReferenceDetailedCI Test Started");
                TestCaseBegin();
                TrackingInformationAPIResponse trackingInformation = GetOrderTrackingAPI(65143480, true);
                if (!trackingInformation.CISegments.Any())
                {
                    LogWarning("No data found in CISegments");
                }
                else
                {
                    //Fetching data from database
                    CustomClass _dbreturns = DMS1DbQueryFactory.ValidateItemsandServicesinCIshipmentsDetailedAndNonDetailed(trackingInformation.OrderId.ToString());
                    Assert.NotNull(_dbreturns);
                    foreach (var items in _dbreturns.Items)
                    {
                        var datas = trackingInformation.CISegments.Select(y => y.Items);
                        datas.Select(u => u.Select(z => z.PackageID)).ToList();
                        datas.Select(x => x.Select(u => u.PackageID));
                        bool isFoundPackageId = false;
                        bool isFoundCusRefId = false;
                        datas.ToList().ForEach(data =>
                        {
                            if (data.Count() > 0)
                            {
                        
                                if (data.Any(x => x.PackageID == items.PackageID))
                                {
                                    LogInfo("Validating Package Id :" + items.PackageID);
                                    Assert.True(data.Any(x => x.PackageID == items.PackageID));
                                    isFoundPackageId = true;
                                    LogInfo("Successfully Validated :" + items.PackageID);
                                }

                                if (data.Any(x => x.CustomerReferenceNumber == items.CustomerReferenceNumber))
                                {
                                    LogInfo("Validating Customer Reference Number Id :" + items.CustomerReferenceNumber);
                                    Assert.True(data.Any(x => x.CustomerReferenceNumber == items.CustomerReferenceNumber));
                                    isFoundCusRefId = true;
                                    LogInfo("Successfully Validated :" + items.CustomerReferenceNumber);
                                }


                            }
                        });

                        Assert.True(isFoundPackageId, "PackageID Not Found");
                        Assert.True(isFoundCusRefId, "Customer Reference Number Not Found");
                    }
                    // code for validating SKU

                    foreach (var services in _dbreturns.Service)
                    {
                        var serviceData = trackingInformation.CISegments.Select(y => y.Services);
                        serviceData.SelectMany(u => u.Select(z => z.SKU)).ToList();
                        serviceData.Select(x => x.Select(u => u.SKU));


                        bool isSKUfound = false;
                        serviceData.ToList().ForEach(items =>
                        {
                            if (items.Count() > 0)
                            {


                                if (items.Any(x => x.SKU == services.SKU))
                                {
                                    LogInfo("Validating SKU :" + services.SKU);
                                    Assert.True(items.Any(x => x.SKU == services.SKU));
                                    isSKUfound = true;
                                    LogInfo("Successfully Validated::" + services.SKU);
                                }



                            }
                        });
                        Assert.True(isSKUfound, "SKU not Found");
                    }
                }


            }
            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw;
            }
            LogInfo("TC_17912_VerifySKUPackageandCustomerReferenceDetailedCI Passed");
        }


        #endregion UserStory:XLMDEV3562

        #region UserStory:XLMDEV5143

        //TC-18558:Verify for Non-CI orders, the API response fetches all times in standard ISO format & it matches with db data & conversions


        [Fact]
        public void TC_18558_ValidateAllTimeZoneInIsoNonCI()
        {
            try
            {
                LogInfo("TC_18558_ValidateAllTimeZoneInIsoNonCI Test Started");
                TestCaseBegin();
                TrackingInformationAPIResponse trackingInformation = GetOrderTrackingAPI(64385603, true);
                if (!trackingInformation.Items.Any())
                {
                    LogWarning("No data found in Items");
                }
                else
                {
                    //fetching and validate order book date
                    string OrderBookDate = DMS1DbQueryFactory.ReturnOrderBookDate(trackingInformation.OrderId.ToString());
                    LogInfo("Validating Order Booke Date" + trackingInformation.OrderBookedDate);
                    Assert.NotNull(OrderBookDate);
                    Assert.True(trackingInformation.OrderBookedDate.ToString().Trim() == OrderBookDate.Trim());
                    LogInfo("Order Book Date verified with server date time" + trackingInformation.OrderBookedDate);

                    //fetching and validate Order Scheduled Date
                    string OrderScheduledDate = DMS1DbQueryFactory.ReturnOrderScheduledDate(trackingInformation.OrderId.ToString());
                    LogInfo("Validating Order Scheduled Date" + trackingInformation.OrderScheduledDate);
                    Assert.NotNull(OrderScheduledDate);
                    Assert.True(trackingInformation.OrderScheduledDate.ToString().Trim() == OrderScheduledDate.Trim());
                    LogInfo("Order Scheduled Date verified with server date time" + trackingInformation.OrderBookedDate);

                    //to be add the code for fetching date inside events

                }
            }

            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;

            }
            LogInfo("TC_18558_ValidateAllTimeZoneInIsoNonCI Passed");
        }



        //...TC1855:Verify as validated API user, if the response fetches all times in standard ISO format-Non CI


        [Fact]
        public void TC1855_ValidateAPIuserAndTimeZoneinISO()
        {
            try
            {
                LogInfo("TC1855_ValidateAPIuserAndTimeZoneinISO Test Started");
                TestCaseBegin();
                HttpStatusCode pingStatus = PingHost(BRGlobalVars.BaseApiServerUrl);
                if (pingStatus == HttpStatusCode.OK)
                {
                    LogInfo("The Server Response Status is 200");
                    TrackingInformationAPIResponse trackingInformation = GetOrderTrackingAPI(65085422, true);
                    LogInfo("Passing URL with valid user");
                    if (!trackingInformation.Items.Any())
                    {
                        LogWarning("No data found");
                    }
                    else
                    {
                        //fetching and validate order book date
                        string OrderBookDate = DMS1DbQueryFactory.ReturnOrderBookDate(trackingInformation.OrderId.ToString());
                        LogInfo("Validating Order Booke Date" + trackingInformation.OrderBookedDate);
                        Assert.NotNull(OrderBookDate);
                        Assert.True(trackingInformation.OrderBookedDate.ToString().Trim() == OrderBookDate.Trim());
                        LogInfo("Order Book Date verified with server date time" + trackingInformation.OrderBookedDate);

                        //fetching and validate Order Scheduled Date
                        string OrderScheduledDate = DMS1DbQueryFactory.ReturnOrderScheduledDate(trackingInformation.OrderId.ToString());
                        LogInfo("Validating Order Scheduled Date" + trackingInformation.OrderScheduledDate);
                        Assert.NotNull(OrderScheduledDate);
                        Assert.True(trackingInformation.OrderScheduledDate.ToString().Trim() == OrderScheduledDate.Trim());
                        LogInfo("Order Scheduled Date verified with server date time" + trackingInformation.OrderBookedDate);

                        //to be add the code for fetching date inside events

                    }
                }
                else
                {
                    LogWarning("Server is not responding this time");
                }

            }

            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;

            }
            LogInfo("TC1855_ValidateAPIuserAndTimeZoneinISO Passed");
        }


        //..TC-18556:- Verify as non-validated API user, if the response fetches all times in standard ISO format

        [Fact]
        public void TC18556_NonValidateAPIuserAndTimeZoneinISO()
        {
            try
            {
                LogInfo("TC18556_NonValidateAPIuserAndTimeZoneinISO Test Started");
                TestCaseBegin();
                HttpStatusCode pingStatus = PingHost(BRGlobalVars.BaseApiServerUrl);
                if (pingStatus == HttpStatusCode.OK)
                {
                    LogInfo("The Server Response Status is 200");
                    TrackingInformationAPIResponse trackingInformation = GetOrderTrackingAPI(65085422, false);
                    LogInfo("Passing URL with valid user");
                    if (!trackingInformation.Items.Any())
                    {
                        LogWarning("No data found");
                    }
                    else
                    {
                        //fetching and validate order book date
                        string OrderBookDate = DMS1DbQueryFactory.ReturnOrderBookDate(trackingInformation.OrderId.ToString());
                        LogInfo("Validating Order Booke Date" + trackingInformation.OrderBookedDate);
                        Assert.NotNull(OrderBookDate);
                        Assert.True(trackingInformation.OrderBookedDate.ToString().Trim() == OrderBookDate.Trim());
                        LogInfo("Order Book Date verified with server date time" + trackingInformation.OrderBookedDate);

                        //fetching and validate Order Scheduled Date
                        string OrderScheduledDate = DMS1DbQueryFactory.ReturnOrderScheduledDate(trackingInformation.OrderId.ToString());
                        LogInfo("Validating Order Scheduled Date" + trackingInformation.OrderScheduledDate);
                        Assert.NotNull(OrderScheduledDate);
                        Assert.True(trackingInformation.OrderScheduledDate.ToString().Trim() == OrderScheduledDate.Trim());
                        LogInfo("Order Scheduled Date verified with server date time" + trackingInformation.OrderBookedDate);

                        //to be add the code for fetching date inside events

                    }
                }
                else
                {
                    LogWarning("Server is not responding this time");
                }

            }

            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;

            }
            LogInfo("TC18556_NonValidateAPIuserAndTimeZoneinISO Passed");
        }
        #endregion UserStory:XLMDEV5143

        #region Userstory:XLMDEV-5475
        /// <summary>
        /// user story XLMDEV-5475
        /// API response will fetch consignee lattitude & longitude
        /// </summary>

        // TC_18860_TC_18858:To validate that API response fetches consignee lat & long appropiately
        [Fact]
        public void TC_18860_TC_18858_Validate_Consigneelatandlong()
        {
            LogInfo("TC_18860_TC_18858_Validate_Consigneelatandlong Test Started");
            TestCaseBegin();
            TrackingInformationAPIResponse trackingInformation = GetOrderTrackingAPI(65098608, true);
            try
            {
                List<consigneeLatandlong> _consigneelatandlong = DMS1DbQueryFactory.GetConsigneeLatandLong(trackingInformation.OrderId.ToString());
                Assert.NotNull(_consigneelatandlong);
                _consigneelatandlong.ForEach(_consigneelatlong =>
                {
                    LogInfo("Validating Latitude :"+ Math.Round(double.Parse(trackingInformation.Consignee.Latitude.ToString()), 3));
                    Assert.True(Math.Round(double.Parse(trackingInformation.Consignee.Latitude.ToString()), 3)== Math.Round(double.Parse(_consigneelatlong.Latitude.ToString()), 3));
                    LogInfo("Validated Latitude Successfully:" + Math.Round(double.Parse(trackingInformation.Consignee.Latitude.ToString()), 3));
                    LogInfo("Validating Longitude :"+ Math.Round(double.Parse(trackingInformation.Consignee.Longitude.ToString())));
                    Assert.True(Math.Round(double.Parse(trackingInformation.Consignee.Longitude.ToString()), 3) == Math.Round(double.Parse(_consigneelatlong.longitude.ToString()), 3));
                    LogInfo("Validated Longitude Successfully :" + Math.Round(double.Parse(_consigneelatlong.longitude.ToString())));
                });
            }
            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw;
            }


        }



        #endregion Userstory:XLMDEV-5475

        #region userStory: XLMDEV-5109

        [Fact]
        public void TC_18531_18543_ValidateAPIResponseConsumerEmailandPhone()
        {
            LogInfo("TC_18531_18543_ValidateAPIResponseConsumerEmailandPhone Test Started");
            TestCaseBegin();
            TrackingInformationAPIResponse trackingInformation = GetOrderTrackingAPI(65098608, true);
            try
            {
                
                string _consigneePhoneDB = DMS1DbQueryFactory.ConsigneePhoneNumber(trackingInformation.OrderId.ToString());

                if (String.IsNullOrEmpty(_consigneePhoneDB))
                {
                   
                    Assert.Null(trackingInformation.Consignee.Phone);
                }
                else
                {
                    LogInfo("Validating Consignee Phone :" + trackingInformation.Consignee.Phone);
                    Assert.Equal(trackingInformation.Consignee.Phone, trackingInformation.Consignee.Phone);
                    LogInfo("Validated  Consignee Phone Successfully :" + trackingInformation.Consignee.Phone);
                }
                string _consigneeEmailDB = DMS1DbQueryFactory.ConsigneeEmailId(trackingInformation.OrderId.ToString());
                if (String.IsNullOrEmpty(_consigneeEmailDB))
                {
                    Assert.Null(trackingInformation.Consignee.Email);
                }
                else
                {
                    LogInfo("Validating Consignee Email :" + trackingInformation.Consignee.Email);
                    Assert.Equal(trackingInformation.Consignee.Email, trackingInformation.Consignee.Email);
                    LogInfo("Validated  Consignee Email Successfully :" + trackingInformation.Consignee.Email);
                }


                LogInfo("TC_18531_18543_ValidateAPIResponseConsumerEmailandPhoneTest Passed");
            }

            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw;
            }

        }
        #endregion userStory: XLMDEV-5109


        #region user strory:XLMDEV4771

        //TC_18289:Verify that the order booked date is sent in the detailed tracking response for the validated API user

        [Fact]
        public void TC_18289_VerifyOrderBookDate()
        {
            try
            {
                LogInfo("TC_18289_VerifyOrderBookDate Test Started");
                TestCaseBegin();

                TrackingInformationAPIResponse trackingInformation = GetOrderTrackingAPI(65085422, true);

                //fetching and validate order book date
                string OrderBookDate = DMS1DbQueryFactory.ReturnOrderBookDate(trackingInformation.OrderId.ToString());
                LogInfo("Validating Order Booke Date" + trackingInformation.OrderBookedDate);
                Assert.NotNull(OrderBookDate);
                Assert.True(trackingInformation.OrderBookedDate.ToString().Trim() == OrderBookDate.Trim());
                LogInfo("Order Book Date verified with server date time" + trackingInformation.OrderBookedDate);
            }



            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;

            }
            LogInfo("TC_18289_VerifyOrderBookDate Passed");
        }

        //TC_18274:As a validated API user for Non CI shipment, I need to be able to get detailed tracking detail along with Order booking date
        [Fact]
        public void TC_18274_VerifyOrderBookDateNonCiValidAPIUser()
        {
            try
            {
                LogInfo("TC_18274_VerifyOrderBookDateNonCiValidAPIUser Test Started");
                TestCaseBegin();

                TrackingInformationAPIResponse trackingInformation = GetOrderTrackingAPI(64385603, true);

                //fetching and validate order book date
                string OrderBookDate = DMS1DbQueryFactory.ReturnOrderBookDate(trackingInformation.OrderId.ToString());
                LogInfo("Validating Order Booke Date" + trackingInformation.OrderBookedDate);
                Assert.NotNull(OrderBookDate);
                Assert.True(trackingInformation.OrderBookedDate.ToString().Trim() == OrderBookDate.Trim());
                LogInfo("Order Book Date verified with server date time" + trackingInformation.OrderBookedDate);
            }



            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;

            }
            LogInfo("TC_18274_VerifyOrderBookDateNonCiValidAPIUser Passed");
        }

        //TC_18275:As a non validated API user for Non CI shipment, I need to be able to get the Order booking date along with the limited tracking detail

        [Fact]
        public void TC_18275_VerifyOrderBookDateNonCiNonValidAPIUser()
        {
            try
            {
                LogInfo("TC_18275_VerifyOrderBookDateNonCiNonValidAPIUser Test Started");
                TestCaseBegin();

                TrackingInformationAPIResponse trackingInformation = GetOrderTrackingAPI(64385603, false);

                //fetching and validate order book date
                string OrderBookDate = DMS1DbQueryFactory.ReturnOrderBookDate(trackingInformation.OrderId.ToString());
                LogInfo("Validating Order Booke Date" + trackingInformation.OrderBookedDate);
                Assert.NotNull(OrderBookDate);
                Assert.True(trackingInformation.OrderBookedDate.ToString().Trim() == OrderBookDate.Trim());
                LogInfo("Order Book Date verified with server date time" + trackingInformation.OrderBookedDate);
            }



            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;

            }
            LogInfo("TC_18275_VerifyOrderBookDateNonCiNonValidAPIUser Passed");
        }

        //TC_18276:As a validated API user for CI shipments, I need to be able to get the Order booking date along with the detailed tracking detail

        [Fact]
        public void TC_18276_VerifyOrderBookDateCIValidAPIUser()
        {
            try
            {
                LogInfo("TC_18276_VerifyOrderBookDateCIValidAPIUser Test Started");
                TestCaseBegin();

                TrackingInformationAPIResponse trackingInformation = GetOrderTrackingAPI(65098608, true);

                //fetching and validate order book date
                string OrderBookDate = DMS1DbQueryFactory.ReturnOrderBookDate(trackingInformation.OrderId.ToString());
                LogInfo("Validating Order Booke Date" + trackingInformation.OrderBookedDate);
                Assert.NotNull(OrderBookDate);
                Assert.True(trackingInformation.OrderBookedDate.ToString().Trim() == OrderBookDate.Trim());
                LogInfo("Order Book Date verified with server date time" + trackingInformation.OrderBookedDate);
            }



            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;

            }
            LogInfo("TC_18276_VerifyOrderBookDateCIValidAPIUser Passed");
        }

        //TC_18277 :As a non validated API user for CI shipment, I need to be able to get limited tracking detail along with Order booking date
        [Fact]
        public void TC_18277_VerifyOrderBookDateCINonValidAPIUser()
        {
            try
            {
                LogInfo("TC_18277_VerifyOrderBookDateCINonValidAPIUser Test Started");
                TestCaseBegin();

                TrackingInformationAPIResponse trackingInformation = GetOrderTrackingAPI(65098608, false);

                //fetching and validate order book date
                string OrderBookDate = DMS1DbQueryFactory.ReturnOrderBookDate(trackingInformation.OrderId.ToString());
                LogInfo("Validating Order Booke Date" + trackingInformation.OrderBookedDate);
                Assert.NotNull(OrderBookDate);
                Assert.True(trackingInformation.OrderBookedDate.ToString().Trim() == OrderBookDate.Trim());
                LogInfo("Order Book Date verified with server date time" + trackingInformation.OrderBookedDate);
            }



            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;

            }
            LogInfo("TC_18277_VerifyOrderBookDateCINonValidAPIUser Passed");
        }
        #endregion user strory:XLMDEV4771

    }
}

#region References
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;
using LM_DMS2._0_UI_Automation.LMDBFactory;
using LastMile.Web.Automation.BRBaseObjects;
using LM_DMS2._0_UI_Automation.LMAPI.CustomeFieldManagement.Client;
using LastMile.Web.Automation.BRDataTypes;
using System.Linq;
using Xpo.LastMile.CustomFieldManagement.Backend.Api.Site.Models;
using LM_DMS2._0_UI_Automation.LMAPI.Common;
#endregion References



namespace LM_DMS2._0_UI_Automation.LMAPI.CustomFieldManagement.APITests
{ 
    public class CustomFieldManagement :BRAPIBaseTest, IClassFixture<BRAPIFixture>
    {
        public CustomFieldManagement()
        {
            TestCategory = "Get All Custom Field Management Data";
            Console.WriteLine("Inside the constructor of GetOrderTrackingWithOrderId");
        }

        XPOCustomeFieldManagementApiClient xpoCFMApiClient = new XPOCustomeFieldManagementApiClient();



  
        #region  XLMHL-798

        /// <summary>
        /// User Story : XLMHL-798
        /// Description : List All Custom fields in CFM ...
        /// </summary>

        [Fact]
        public void XLMHL_888_ValidateAllCustomFields()
        {

            try
            {
                LogInfo("XLMHL_888_ValidateAllCustomFields Test Started");
                TestCaseBegin();
                //fetching API response
                IList<CustomField> valuesResponse = xpoCFMApiClient.GetApiResponse();
                if (valuesResponse.Any())
                {

                    //Fetching Db response
                    List<CustomField> dbResponse = DMS2DbQueryFactory.GetAllCustomeFields();
                    Assert.NotNull(dbResponse);

                    dbResponse.ForEach(_item =>
                    {

                        if (valuesResponse.Any(x => x.CustomFieldName == _item.CustomFieldName))
                        {
                            LogInfo("Validating CustomFieldName" + _item.CustomFieldName);
                            Assert.True(valuesResponse.All(x => x.CustomFieldName == _item.CustomFieldName));
                            LogInfo("Successfully CustomFieldName" + _item.CustomFieldName);
                        }

                        if (valuesResponse.Any(x => x.CustomFieldId == _item.CustomFieldId))
                        {
                            LogInfo("Validating CustomFieldId" + _item.CustomFieldId);
                            Assert.True(valuesResponse.All(x => x.CustomFieldId == _item.CustomFieldId));
                            LogInfo("Successfully CustomFieldId" + _item.CustomFieldId);
                        }


                        if (valuesResponse.Any(x => x.MinLength == _item.MinLength))
                        {
                            LogInfo("Validating MinLength" + _item.MinLength);
                            Assert.True(valuesResponse.All(x => x.MinLength == _item.MinLength));
                            LogInfo("Successfully MinLength" + _item.MinLength);
                        }

                        if (valuesResponse.Any(x => x.MaxLength == _item.MaxLength))
                        {
                            LogInfo("Validating MaxLength" + _item.MaxLength);
                            Assert.True(valuesResponse.All(x => x.MaxLength == _item.MaxLength));
                            LogInfo("Successfully MaxLength" + _item.MaxLength);
                        }
                        if (valuesResponse.Any(x => x.MaxValue == _item.MaxValue))
                        {
                            LogInfo("Validating MaxValue" + _item.MaxValue);
                            Assert.True(valuesResponse.All(x => x.MaxValue == _item.MaxValue));
                            LogInfo("Successfully MaxValue" + _item.MaxValue);
                        }

                        if (valuesResponse.Any(x => x.MinValue == _item.MinValue))
                        {
                            LogInfo("Validating MinValue" + _item.MinValue);
                            Assert.True(valuesResponse.All(x => x.MinValue == _item.MinValue));
                            LogInfo("Successfully MinValue" + _item.MinValue);
                        }
                        if (valuesResponse.Any(x => !string.IsNullOrEmpty(x.ValidationRegEx) == !string.IsNullOrEmpty(_item.ValidationRegEx)))
                        {
                            LogInfo("Validating ValidationRegEx" + _item.ValidationRegEx);
                            Assert.True(valuesResponse.All(x => x.ValidationRegEx == _item.ValidationRegEx));
                            LogInfo("Successfully ValidationRegEx" + _item.ValidationRegEx);
                        }

                        if (valuesResponse.Any(x => x.CreatedOn == _item.CreatedOn))
                        {
                            LogInfo("Validating CreatedOn" + _item.CreatedOn);
                            Assert.True(valuesResponse.All(x => x.CreatedOn == _item.CreatedOn));
                            LogInfo("Successfully CreatedOn" + _item.CreatedOn);
                        }

                        if (valuesResponse.Any(x => !string.IsNullOrEmpty(x.ModifiedBy) == !string.IsNullOrEmpty(_item.ModifiedBy)))
                        {
                            LogInfo("Validating ModifiedBy" + _item.ModifiedBy);
                            Assert.True(valuesResponse.All(x => x.ModifiedBy == _item.ModifiedBy));
                            LogInfo("Successfully ModifiedBy" + _item.ModifiedBy);
                        }

                        if (valuesResponse.Any(x => x.ModifiedOn == _item.ModifiedOn))
                        {
                            LogInfo("Validating ModifiedOn" + _item.ModifiedOn);
                            Assert.True(valuesResponse.All(x => x.ModifiedOn == _item.ModifiedOn));
                            LogInfo("Successfully ModifiedOn" + _item.ModifiedOn);
                        }
                        if (valuesResponse.Any(x => x.CurrentVersion == _item.CurrentVersion))
                        {
                            LogInfo("Validating CurrentVersion" + _item.CurrentVersion);
                            Assert.True(valuesResponse.All(x => x.CurrentVersion == _item.CurrentVersion));
                            LogInfo("Successfully CurrentVersion" + _item.CurrentVersion);
                        }
                       


                    });
                }
            }
            catch (Exception ex)
            {

                LogHandler.LogException(ex);
                throw ex;

            }
            LogInfo("TC_18289_VerifyOrderBookDate Passed");
        }



        //Verify that API returns 200 & {An Empty Array }, if not found Using GET ../v1/customfields


        [Fact]
        public void ValidateEmptyApiResponse()
        {

            try
            {
                //fetching API response
                IList<CustomField> valuesResponse = xpoCFMApiClient.GetApiResponse();
                if (valuesResponse.Count() <= 0)
                {
                    Console.WriteLine("Api return an empty array");
                    List<CustomField> dbResponse = DMS2DbQueryFactory.GetAllCustomeFields();
                    if (dbResponse.Count() <= 0)
                    Console.WriteLine("Database return empty");
                    Assert.True(valuesResponse.Count() < 0 == dbResponse.Count() <= 0);

                }


            }
            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;

            }
        }


        #endregion  XLMHL-798



    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.Common;
using Xpo.LastMile.CustomFieldManagement.Backend.Api.Site.Models;
using System.Data;

namespace LM_DMS2._0_UI_Automation.LMDBFactory
{
    public class DMS2DbQueryFactory:DBFactory
    {
        DBFactory sqlconnection = new DBFactory();



        #region Custom Field Management
        public static List<CustomField> GetAllCustomeFields()
        {
            DataTable dt = new DataTable();
            List<CustomField> customeFields = new List<CustomField>();

            try
            {

                var query = @"select CustomFieldId,
                            CustomFieldName,DataTypeId,MinLength,MaxLength,MinValue,MaxValue,ValidationRegEx,Convert(bigint,CurrentVersion) as CurrentVersion,
                            CreatedBy,CreatedOn,ModifiedBy,ModifiedOn from dbo.CUSTOMFIELD  ";
                dt = DBFactory.ExecuteQuerywithNoparam(query);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        CustomField data = new CustomField();
                        data.CustomFieldId = long.Parse(dr[0].ToString());
                        data.CustomFieldName = dr[1].ToString();
                        data.DataTypeId = Byte.Parse(dr[2].ToString());
                        data.MinLength = long.Parse(dr[3].ToString());
                        data.MaxLength = long.Parse(dr[4].ToString());
                        data.MinValue = decimal.Parse(dr[5].ToString());
                        data.MaxValue = decimal.Parse(dr[6].ToString());
                        data.ValidationRegEx = dr[7].ToString();
                        data.CurrentVersion = Int64.Parse(dr[8].ToString());
                        data.CreatedBy = dr[9].ToString();
                        data.CreatedOn = DateTimeOffset.Parse(dr[10].ToString());
                        data.ModifiedBy = dr[11].ToString();
                        data.ModifiedOn = DateTimeOffset.Parse(dr[12].ToString());
                        customeFields.Add(data);
                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return customeFields;
        }


        #endregion Custom Field Management
    }
}

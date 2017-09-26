using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.Common;

namespace LM_DMS2._0_UI_Automation.LMDBFactory
{
    public class DMS1DbQueryFactory : DBFactory
    {
        DBFactory sqlConnection = new DBFactory();

        /*............. Shipper Details................*/

        #region shipperDetails

        public class shiperAddress
        {
            public string Name { set; get; }
            public string City { set; get; }
            public string State { set; get; }
            public string PostalCode { set; get; }

        }
        //GetShipperAddressDetails() return shipper details such as Name,City,State,PostalCode//
        public static List<shiperAddress> GetShipperAddressDetails(string OrderId)
        {
            List<shiperAddress> _shipperAddress = new List<shiperAddress>();
            try
            {
                string fl_st_city = string.Empty;
                shiperAddress obj = new shiperAddress();
                con.Open();
                var query = @"select a.fh_pkey,a.fh_id,b.fl_sf_name,b.fl_sf_city,b.fl_sf_state,b.fl_sf_country,b.fl_sf_zip 
                from fcfgthd a join fclegs b on a.fh_pkey=b.fl_pkey where a.fh_id =@OrderNumber";
                var queryCmd = new SqlCommand(query, con);
                queryCmd.Parameters.Add(new SqlParameter("OrderNumber", OrderId));
                var queryReader = queryCmd.ExecuteReader();
                while (queryReader.Read())
                {
                    obj.Name = queryReader[2].ToString();
                    obj.City = queryReader[3].ToString();
                    obj.State = queryReader[4].ToString();
                    obj.PostalCode = queryReader[6].ToString();
                    _shipperAddress.Add(obj);
                }
                queryReader.Close();

                con.Close();
            }
            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;
            }
            return _shipperAddress;
        }
        #endregion shipperDetails

        /*......... Call Center Email and Phone ........*/

        #region callcenterEmailPhone
        public class callCenterEmail
        {
            public string CallCenterEmail { set; get; }
            public string CallCenterPhone { set; get; }

        }
        //CallcenterEmailAddress() will return the call center email and telephone
        public static List<callCenterEmail> CallcenterEmailAddress()
        {
            
            List<callCenterEmail> _callCenterEmail = new List<callCenterEmail>();
            try
            {
                con.Open();
                callCenterEmail obj = new callCenterEmail();
                var query = @"select * from CustomerCareContactInfo";
                var queryCmd = new SqlCommand(query, con);
                var queryReader = queryCmd.ExecuteReader();
                while (queryReader.Read())
                {
                    obj.CallCenterEmail = queryReader[0].ToString();
                    obj.CallCenterPhone = queryReader[1].ToString();
                    _callCenterEmail.Add(obj);
                }
                queryReader.Close();

                con.Close();
            }
            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;
            }
            return _callCenterEmail;
        }

        //CallcenterTelephoneNumber() will return only the call center phone number//
        public static string CallcenterTelephoneNumber(string OrderId)
        {
            string _Telephone = string.Empty;
            try
            {
                con.Open();
                var query1 = @"SELECT cb_nbr FROM dbo.fcfgthd fc inner JOIN
                            fcbillto fcb on fc.fh_bt_id= fcb.bt_id
                            inner join fccity b on fcb.bt_ctpkey= b.ct_pkey
                            INNER JOIN fcctCallback a ON b.ct_pkey = a.cb_ctpkey 
                            where fh_id=@OrderNumber";
                var query1Cmd = new SqlCommand(query1, con);
                query1Cmd.Parameters.Add(new SqlParameter("OrderNumber", OrderId));
                var query1Reader = query1Cmd.ExecuteReader();
                while (query1Reader.Read())
                {
                    _Telephone = query1Reader[0].ToString();
                }
                query1Reader.Close();

                con.Close();
            }
            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;
            }
            return _Telephone;
        }

        #endregion callcenterEmailPhone



    }
}

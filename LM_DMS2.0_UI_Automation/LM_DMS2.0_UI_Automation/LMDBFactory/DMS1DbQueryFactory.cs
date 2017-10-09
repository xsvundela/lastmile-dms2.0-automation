using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.Common;
using System.Data;

namespace LM_DMS2._0_UI_Automation.LMDBFactory
{
    public class DMS1DbQueryFactory : DBFactory
    {

        static DBFactory sqlConnection = new DBFactory();
        //public DMS1DbQueryFactory()
        //{
        //   DBFactory sqlConnection = new DBFactory();
        //}



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

        public static List<callCenterEmail> CallcenterEmailAddressCommon()
        {

            List<callCenterEmail> _callCenterEmail = new List<callCenterEmail>();
            try
            {
                callCenterEmail obj = new callCenterEmail();
                var query = @"select * from CustomerCareContactInfo";
                DataTable fillDt = sqlConnection.ExecuteQuerywithNoparam(query);
                foreach (DataRow dr in fillDt.Rows)
                {
                    obj.CallCenterEmail = dr[0].ToString();
                    obj.CallCenterPhone = dr[1].ToString();
                    _callCenterEmail.Add(obj);
                }
            }
            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;
            }
            return _callCenterEmail;
        }





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

        #region Non_Ci Package Id and Customer Ref Id

        public class Items
        {
            public string Description { get; set; }
            public int Quantity { get; set; }
            public string PackageID { get; set; }
            public string CustomerReferenceNumber { get; set; }
        }

        public static List<Items> CustomerRefNumberAndPackageId(string OrderId)
        {

            List<Items> _customerRefandPackage = new List<Items>();
            try
            {
                con.Open();
                Items obj = new Items();
                var query = @"SELECT ld_pkey As skuID,ld_commodity As Id_PackageId from fcload Where ld_fh_id =@OrderId";
                var queryCmd = new SqlCommand(query, con);
                queryCmd.Parameters.Add(new SqlParameter("OrderId", OrderId));
                var queryReader = queryCmd.ExecuteReader();
                while (queryReader.Read())
                {
                    obj.PackageID = queryReader[1].ToString();
                    obj.CustomerReferenceNumber = queryReader[0].ToString();
                    _customerRefandPackage.Add(obj);
                }
                queryReader.Close();

                con.Close();
            }
            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;
            }
            return _customerRefandPackage;
        }
        #endregion Non_Ci Package Id and Customer Ref Id




        #region Verify Sku,Customer Reference, package in CI detailed and non detailed

        public class Services
        {
            public string Description { get; set; }
            public string Status { get; set; }
            public string SKU { get; set; }
        }

        public class CustomClass
        {
            public List<Services> Service { get; set; }
            public List<Items> Items { get; set; }
        }

        /*This method will return the Customer Reference Id,Package id inside the segment Items along
         * with SKU's in Services  CI detailed/non detailed*/

        public static CustomClass ValidateItemsandServicesinCIshipmentsDetailedAndNonDetailed(string OrderId)
        {
            List<Items> _item = new List<Items>();
            List<Services> _services = new List<Services>();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            string ServicePackageId = string.Empty;
            try
            {
                con.Open();
                //fetching package id and customer reference number from items//
                var query = @"select ld_commodity as PackageId,lda_custNum as CustomerRefId,fh_id from fcfgthd a 
                            join FCLOAD b on a.fh_id = b.ld_fh_id
                            join LOADANC c on b.ld_pkey = c.lda_ldpkey
                            where a.fh_id=@OrderId";
                var queryCmd = new SqlCommand(query, con);
                queryCmd.Parameters.Add(new SqlParameter("OrderId", OrderId));
                SqlDataAdapter dob = new SqlDataAdapter(queryCmd);
                dob.Fill(dt1);
                dob.Dispose();
                if(dt1.Rows.Count>0)
                {
                    for(int i=0;i<dt1.Rows.Count;i++)
                    {
                        Items _itemclass = new Items();
                        _itemclass.PackageID = dt1.Rows[i]["PackageId"].ToString();
                        _itemclass.CustomerReferenceNumber = dt1.Rows[i]["CustomerRefId"].ToString();
                        _item.Add(_itemclass);

                    }
                }


               /*.... Below parts will find SKU's from segments.....*/

                /*..The below query will return the each segments..*/
                var query1 = @" select distinct  b.seg_pkey,a.fh_pkey,a.fh_id,a.fh_status,fh_bt_id,
                             b.seg_fhpkey,c.SegmentId,c.StatusId,d.Description,d.Code from fcfgthd a 
                             join Segments b on a.fh_pkey = b.seg_fhpkey
                             join ServiceSchema.SegmentAssociation c on b.seg_pkey = c.SegmentId
                             join [ServiceSchema].[Status]d on c.StatusId = d.StatusId
                             where a.fh_id = @OrderId and d.Description not in('Rescheduled') ";
                var queryCmd1 = new SqlCommand(query1, con);
                queryCmd1.Parameters.Add(new SqlParameter("OrderId", OrderId));
                SqlDataAdapter da = new SqlDataAdapter(queryCmd1);
                da.Fill(dt);
                da.Dispose();

                if (dt.Rows.Count > 0)
                {

                    /*.. This part will return the Master Id against the billtoid.*/
                    var query2 = @"select  ab_vchar from addlbillto where ab_type like '%MASTERACCT%' and ab_btid = @ab_btid";
                    var queryCmd2 = new SqlCommand(query2, con);
                    queryCmd2.Parameters.Add(new SqlParameter("ab_btid", dt.Rows[0][4].ToString()));
                    SqlDataAdapter da1 = new SqlDataAdapter(queryCmd2);

                    // this will query your database and return the result to your datatable
                    da1.Fill(dt2);
                    da1.Dispose();

                    if (dt2.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dt2.Rows[0][0].ToString()))
                        {
                            /*..The method ReturnServicePackageId will return the comma seperated ServicePackage Id's..*/
                            ServicePackageId = ReturnServicePackageId(dt);
                            /*..The below code will mappaed all SKU's to list<Service>...*/
                            string query3 = string.Format("select ClientServiceSku,ServicePackageId,AccountId from SERVICESCHEMA.SERVICEPACKAGEACCOUNT where ServicePackageId in ({0}) and AccountId = {1}", ServicePackageId.TrimEnd(','), dt2.Rows[0][0].ToString());
                            var queryCmd3 = new SqlCommand(query3, con);
                            SqlDataAdapter sd = new SqlDataAdapter(queryCmd3);
                            sd.Fill(dt3);
                            sd.Dispose();
                            if (dt3.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt3.Rows.Count; i++)
                                {
                                    Services _serviceClass = new Services();
                                    _serviceClass.SKU = dt3.Rows[i]["ClientServiceSku"].ToString();
                                    _services.Add(_serviceClass);

                                }
                            }
                           
                         
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;
            }
            //retun two lists to a class model//
            return new CustomClass { Service = _services, Items = _item };
        }



        public static string ReturnServicePackageId(DataTable dt)
        {
            string ServicePackageId = string.Empty;
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var queryCmd2 = new SqlCommand("spCTGetSegmentItemForCIOrder", con);
                    queryCmd2.CommandType = CommandType.StoredProcedure;
                    queryCmd2.Parameters.Add("@p_SegmentIds", SqlDbType.VarChar).Value = dr[0].ToString();
                    queryCmd2.Parameters.Add("@p_EntityServiceType", SqlDbType.VarChar).Value = "Service";
                    queryCmd2.Parameters.Add("@p_EntityLineItemType", SqlDbType.VarChar).Value = "LineItem";

                    using (SqlDataReader reader = queryCmd2.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                if (!string.IsNullOrEmpty(reader[1].ToString()))
                                    ServicePackageId += "'" + reader[1].ToString() + "',";
                            }
                        }
                        reader.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ServicePackageId;
        }

        #endregion Verify Sku,Customer Reference, package in CI detailed and non detailed


        #region verify and validate all Time Zone in ISO format

        public class Events
        {
            public string Name { get; set; }
            public string Date { get; set; }
        }

        //method for return OrderBookDate

        public static string ReturnOrderBookDate(string OrderId)
        {
            string _OrderBookDate = string.Empty;
            try
            {
                con.Open();
                var query = @" DECLARE @convertTZString int         
                SELECT @convertTZString = LTRIM(RTRIM(STR(zl_tzi)))  from dbo.fclegs  fl          
                LEFT JOIN fcziploc fz ON fl.fl_st_zip=fz.zl_zip          
                WHERE fl_fh_id= CAST(@OrderId As Varchar(10))  
                select dbo.GetISODateLocalFromServer (fh_ship_dt,@convertTZString,'','Y') as OrderBookedDate            
                FROM Fcfgthd Where fh_id= CAST(@OrderId As Varchar(10)) ";
                var queryCmd = new SqlCommand(query, con);
                queryCmd.Parameters.Add(new SqlParameter("OrderId", OrderId));
                var queryReader = queryCmd.ExecuteReader();
                while (queryReader.Read())
                {
                    _OrderBookDate = queryReader[0].ToString();
                }
                queryReader.Close();

                con.Close();
            }
            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;
            }
            return _OrderBookDate;
        }

        //Rerurn Order Schedule Date
        public static string ReturnOrderScheduledDate(string OrderId)
        {
            string _OrderScheduledDate = string.Empty;
            try
            {
                con.Open();
                var query = @"
				DECLARE @ConvertedTime datetime
				DECLARE @Display varchar(20)
				DECLARE @datetime varchar(30)
                DECLARE @convertTZString int
                SELECT @convertTZString = LTRIM(RTRIM(STR(zl_tzi)))  from dbo.fclegs  fl          
                LEFT JOIN fcziploc fz ON fl.fl_st_zip=fz.zl_zip          
                WHERE fl_fh_id= CAST(@OrderId As Varchar(10)) 
			    select @ConvertedTime=dbo.[GetLocalFromServerDateTime] (fl_st_rta,13)             
                FROM fclegs   Where fl_fh_id= CAST(@OrderId As Varchar(10))
                 SELECT CONVERT(NVARCHAR(19),@ConvertedTime, 126)+ SUBSTRING(Display,5,6) as OrderScheduledDate  FROM dbo.tbTimeZoneInfo WHERE TimeZoneID = @convertTZString";
                var queryCmd = new SqlCommand(query, con);
                queryCmd.Parameters.Add(new SqlParameter("OrderId", OrderId));
                var queryReader = queryCmd.ExecuteReader();
                while (queryReader.Read())
                {
                    _OrderScheduledDate = queryReader[0].ToString();
                }
                queryReader.Close();

                con.Close();
            }
            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;
            }
            return _OrderScheduledDate;
        }

        #endregion # verify and validate all Time Zone in ISO format



        #region  consignee lat & long

        public class consigneeLatandlong
        {
            public string Latitude { set; get; }
            public string longitude { set; get; }

        }
        public static List<consigneeLatandlong> GetConsigneeLatandLong(string OrderId)
        {
            List<consigneeLatandlong> _conLatandLong = new List<consigneeLatandlong>();
            try
            {
                string fl_st_city = string.Empty;
                consigneeLatandlong obj = new consigneeLatandlong();
                // DBFactory connection = new DBFactory();
                con.Open();
                var query = @"select fh_id, case c.st_lat when '0' then d.zl_lat else c.st_lat end AS ConsigneeLatitude,
                       case c.st_lon when '0' then d.zl_lon else c.st_lon  end AS ConsigneeLongitude from fcfgthd a
                    join fclegs b on a.fh_pkey=b.fl_pkey join FCSHIPTO c on b.fl_st_id=c.st_id join fcziploc d on c.st_zip = d.zl_zip
                     where a.fh_id =@OrderID";
                var queryCmd = new SqlCommand(query, con);
                queryCmd.Parameters.Add(new SqlParameter("OrderID", OrderId));
                var queryReader = queryCmd.ExecuteReader();
                while (queryReader.Read())
                {
                    obj.Latitude = queryReader[1].ToString();
                    obj.longitude = queryReader[2].ToString();
                    _conLatandLong.Add(obj);
                }
                queryReader.Close();

                con.Close();
            }
            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;
            }
            return _conLatandLong;
        }
        #endregion consignee lat & long





        #region ConsigneeEmailPhone
        //will return consignee phone number

        public static string ConsigneePhoneNumber(string OrderId)
        {
            string _consigneePhone = string.Empty;
            try
            {
                DBFactory ob = new DBFactory();
                con.Open();
                var query1 = @"SELECT ccp.cp_number FROM  
                Contact.ContactPhone AS ccp INNER JOIN Contact.Contact AS cc  ON ccp.cp_copkey = cc.co_pkey INNER JOIN
                dbo.ShipmentContacts AS sc  ON cc.co_pkey = sc.sc_contact_pkey INNER JOIN
                dbo.fcfgthd AS job ON sc.sc_fh_pkey = job.fh_pkey
                WHERE  (job.fh_id = @OrderId AND ccp.cp_typepkey = 1 AND cc.co_typepkey =7)";
                var query1Cmd = new SqlCommand(query1, con);
                query1Cmd.Parameters.Add(new SqlParameter("OrderId", OrderId));
                var query1Reader = query1Cmd.ExecuteReader();
                while (query1Reader.Read())
                {
                    _consigneePhone = query1Reader[0].ToString();
                }
                query1Reader.Close();

                con.Close();

            }

            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;
            }

            return _consigneePhone;
        }

        //will return consignee EmailId
        public static string ConsigneeEmailId(string OrderId)
        {
            string _consigneeEmailId = string.Empty;
            try
            {
                DBFactory ob = new DBFactory();
                con.Open();
                var query1 = @"SELECT  aj_vchar FROM ADDLJOB WHERE aj_fhid = CAST(@OrderId As Varchar(10)) AND aj_type = 'DREMAILID'";
                var query1Cmd = new SqlCommand(query1, con);
                query1Cmd.Parameters.Add(new SqlParameter("OrderId", OrderId));
                var query1Reader = query1Cmd.ExecuteReader();
                while (query1Reader.Read())
                {
                    _consigneeEmailId = query1Reader[0].ToString();
                }
                query1Reader.Close();

                con.Close();

            }

            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw ex;
            }

            return _consigneeEmailId;
        }

        #endregion ConsigneeEmailPhone

    }


}


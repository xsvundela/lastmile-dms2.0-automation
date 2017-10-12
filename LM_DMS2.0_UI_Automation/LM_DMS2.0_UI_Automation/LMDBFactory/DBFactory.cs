using System.Data.SqlClient;
using LastMile.Web.Automation.BRDataTypes;
using System.Configuration;
using System.Data;
using System;

namespace LM_DMS2._0_UI_Automation.LMDBFactory
{
    public class DBFactory
    {
        public static SqlConnection con;

        public DBFactory()
        {
            if (BRGlobalVars.ENV.Equals("INT"))//have the permission to change the dbconnection 
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["IntDBConnection"].ConnectionString.ToString());

            }
            else if(BRGlobalVars.ENV.Equals("STA"))
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["StaDBConnection"].ConnectionString.ToString());

            }
            else if (BRGlobalVars.ENV.Equals("LocalHost"))
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomFieldManagement"].ConnectionString.ToString());
            }
        }


        public static  DataTable ExecuteQuerywithNoparam(string Query)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(Query, con))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dt);
                    }
                }
                con.Close();
            }

            catch(Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable ExecuteStoredProcedurewithNoParam(string spName)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
               
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = con;
                    command.CommandText = spName;
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dt);
                    }
                }
                con.Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
    }
}

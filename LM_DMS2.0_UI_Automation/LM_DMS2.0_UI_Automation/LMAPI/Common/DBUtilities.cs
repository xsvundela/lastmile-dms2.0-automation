using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace LM_DMS2._0_UI_Automation.LMAPI.Common
{
    public class DBUtilities
    {
       // string Connection = ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
       // SqlConnection con = new SqlConnection("Data Source=10.54.48.53,3341;Initial Catalog=FC_MDT;User id=QASuperUser;Password=R@merT3@m_!;");
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString);
        //SqlCommand cmd;
        SqlDataAdapter adapt;
        public void openDBConnection()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select top 10 * from fclegs", con);
                adapt.Fill(dt);
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }

            //con.Open();
            //SqlCommand cmd = new SqlCommand("select top 10 * from fclegs", con);
            //cmd.CommandType = CommandType.Text;
            //DataTable fillDt = new DataTable();
            //SqlDataAdapter ad = new SqlDataAdapter();
            //ad.SelectCommand = cmd;
            //ad.Fill(fillDt);
            //con.Close();
        }

        public DataTable fetchDatafromDb()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                adapt = new SqlDataAdapter("select top 10 * from fclegs", con);
                adapt.Fill(dt);
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
            //con.Open();
            //SqlCommand cmd = new SqlCommand("select top 10 * from fclegs", con);
            //cmd.CommandType = CommandType.Text;
            //DataTable fillDt = new DataTable();
            //SqlDataAdapter ad = new SqlDataAdapter();
            //ad.SelectCommand = cmd;
            //ad.Fill(fillDt);
            //con.Close();
        }
    }
}

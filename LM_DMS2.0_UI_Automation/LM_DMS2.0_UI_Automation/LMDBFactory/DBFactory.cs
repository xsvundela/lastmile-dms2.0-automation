using System.Data.SqlClient;
using LastMile.Web.Automation.BRDataTypes;
using System.Configuration;

namespace LM_DMS2._0_UI_Automation.LMDBFactory
{
    public class DBFactory
    {
        public static SqlConnection con = null;

        public DBFactory()
        {
            if (BRGlobalVars.ENV.Equals("INT"))//have the permission to change the dbconnection 
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["IntDBConnection"].ConnectionString.ToString());

            }
            else
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["StaDBConnection"].ConnectionString.ToString());

            }
        }


    }
}

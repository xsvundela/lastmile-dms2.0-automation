using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace LM_DMS2._0_UI_Automation.LMAPI.Common
{
    public class DBUtilities
    {
        SqlConnection con = new SqlConnection("Data Source=10.54.48.53,3341;Initial Catalog=FC_MDT;User id=QASuperUser;Password=R@merT3@m_!;");
        //SqlCommand cmd;
        SqlDataAdapter adapt;
        public void openDBConnection()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select top 10 * from fclegs", con);
            adapt.Fill(dt);
            //dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}

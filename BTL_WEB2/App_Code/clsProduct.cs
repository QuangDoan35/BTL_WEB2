using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace BTL_WEB2.App_Code
{
    public class ClsProduct
    {
        public DataTable GetList()
        {
            string connString = WebConfigurationManager.ConnectionStrings["DataBase_QLBanCay"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            string sqlString = "SELECT * FROM Product";
            SqlCommand cmd = new SqlCommand(sqlString, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            return dataTable;
        }
    }
}

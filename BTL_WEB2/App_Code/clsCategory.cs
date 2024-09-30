using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace BTL_WEB2.App_Code
{
    public class ClsCategory
    {
        public DataTable GetList()
        {
            string connString = WebConfigurationManager.ConnectionStrings["DataBase_QLBanCay"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();
            string sqlString = "SELECT * FROM Category ORDER BY STT"; //Lấy dữ liệu và sắp xếp theo STT

            SqlCommand cmd = new SqlCommand(sqlString, sqlConnection);
            cmd.CommandType = CommandType.Text;

            // Tạo SqlDataAdapter để đổ dữ liệu vào DataTable
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable); // Đổ dữ liệu vào DataTable

            return dataTable;
        }

        public void Insert(string maDanhMuc, string tenDanhMuc, string moTaDanhMuc, string anhDanhMuc)
        {
            // Chuỗi kết nối đến cơ sở dữ liệu
            string connString = WebConfigurationManager.ConnectionStrings["DataBase_QLBanCay"].ConnectionString;

            // Tạo kết nối đến cơ sở dữ liệu
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            // Câu lệnh SQL INSERT với các tham số
            string sqlString = "INSERT INTO Category (MaDanhMuc, TenDanhMuc, MoTaDanhMuc, AnhDanhMuc) " +
                               "VALUES (@maDanhMuc, @tenDanhMuc, @moTaDanhMuc, @anhDanhMuc)";

            // Tạo đối tượng SqlCommand
            SqlCommand cmd = new SqlCommand(sqlString, sqlConnection);
            cmd.CommandType = CommandType.Text;

            // Thêm các tham số cho câu lệnh SQL
            cmd.Parameters.AddWithValue("@maDanhMuc", maDanhMuc);
            cmd.Parameters.AddWithValue("@tenDanhMuc", tenDanhMuc);
            cmd.Parameters.AddWithValue("@moTaDanhMuc", moTaDanhMuc);
            cmd.Parameters.AddWithValue("@anhDanhMuc", anhDanhMuc);

            // Thực thi câu lệnh
            cmd.ExecuteNonQuery();

            // Đóng kết nối
            sqlConnection.Close();
        }

    }
}

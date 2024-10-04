using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace BTL_WEB2.App_Code.Category
{
    public class CategoryDAO
    {
        public List<Category> listCategory;

        public CategoryDAO()
        {
            // Khởi tạo danh sách danh mục
            listCategory = new List<Category>();
        }

        //Lấy danh sách danh mục
        public List<Category> GetList()
        {
            string connString = WebConfigurationManager.ConnectionStrings["DataBase_QLBanCay"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();
            string sqlString = "SELECT * FROM Category ORDER BY TrangThai"; // Lấy dữ liệu từ Category

            SqlCommand cmd = new SqlCommand(sqlString, sqlConnection);
            cmd.CommandType = CommandType.Text;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string ma = reader["MaDanhMuc"].ToString();
                string ten = reader["TenDanhMuc"].ToString();
                string mota = reader["MoTaDanhMuc"].ToString();
                string anh = reader["AnhDanhMuc"].ToString();
                string trangthai = reader["TrangThai"].ToString();

                Category category = new Category(ma, ten, mota, anh, trangthai);

                listCategory.Add(category);
            }

            return listCategory;
        }

        //Lấy ra một danh mục
        public Category GetCategoryById(string maDanhMuc)
        {
            string connString = WebConfigurationManager.ConnectionStrings["DataBase_QLBanCay"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();
            string sqlString = "SELECT * FROM Category WHERE MaDanhMuc = @maDanhMuc"; // Lấy dữ liệu từ Category

            SqlCommand cmd = new SqlCommand(sqlString, sqlConnection);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@maDanhMuc", maDanhMuc);
            SqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.Read()) // Sử dụng Read() để kiểm tra dữ liệu
            {
                // Nếu có dữ liệu, lấy thông tin
                string MaDanhMuc = dataReader["MaDanhMuc"].ToString();
                string TenDanhMuc = dataReader["TenDanhMuc"].ToString();
                string MoTaDanhMuc = dataReader["MoTaDanhMuc"].ToString();
                string AnhDanhMuc = dataReader["AnhDanhMuc"].ToString();
                string TrangThai = dataReader["TrangThai"].ToString();

                // Tạo đối tượng ClsCategory
                Category Category = new Category(MaDanhMuc, TenDanhMuc, MoTaDanhMuc, AnhDanhMuc, TrangThai);

                return Category; // Trả về đối tượng danh mục
            }
            else
            {
                return null;
            }
        }

        //Thêm mới danh mục
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

        //Chỉnh sửa danh mục
        public void Update(string maDanhMuc, string tenDanhMuc, string moTaDanhMuc, string anhDanhMuc)
        {
            // Chuỗi kết nối đến cơ sở dữ liệu
            string connString = WebConfigurationManager.ConnectionStrings["DataBase_QLBanCay"].ConnectionString;

            // Tạo kết nối đến cơ sở dữ liệu
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            // Câu lệnh SQL UPDATE
            string sqlString = "UPDATE Category SET TenDanhMuc = @tenDanhMuc , MoTaDanhMuc = @moTaDanhMuc, AnhDanhMuc = @anhDanhMuc WHERE MaDanhMuc = @maDanhMuc";

            // Tạo đối tượng SqlCommand
            SqlCommand cmd = new SqlCommand(sqlString, sqlConnection);

            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@maDanhMuc", maDanhMuc);
            cmd.Parameters.AddWithValue("@tenDanhMuc", tenDanhMuc);
            cmd.Parameters.AddWithValue("@moTaDanhMuc", moTaDanhMuc);
            cmd.Parameters.AddWithValue("@anhDanhMuc", anhDanhMuc);

            // Thực thi câu lệnh
            cmd.ExecuteNonQuery();

            // Đóng kết nối
            sqlConnection.Close();
        }

        //Chuyển trạng thái cho danh mục
        public void SetCategoryStatus(string maDanhMuc, int check)
        {
            // Chuỗi kết nối đến cơ sở dữ liệu
            string connString = WebConfigurationManager.ConnectionStrings["DataBase_QLBanCay"].ConnectionString;

            // Tạo kết nối đến cơ sở dữ liệu
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            // Câu lệnh SQL DELETE
            string sqlString = null;
            //Tùy vào check truyền vào giá trị là bao nhiêu thì tương ứng là câu lệnh sql đó
            if (check == 0) // 0 là set vô hiệu hóa cho danh mục
            {
                sqlString = "UPDATE Category SET TrangThai = 'UNACTIVATED' WHERE MaDanhMuc = @maDanhMuc";
            }
            else if (check == 1)
            {
                sqlString = "UPDATE Category SET TrangThai = 'ACTIVATED' WHERE MaDanhMuc = @maDanhMuc";
            }

            SqlCommand cmd = new SqlCommand(sqlString, sqlConnection);

            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@maDanhMuc", maDanhMuc);

            // Thực thi câu lệnh
            cmd.ExecuteNonQuery();

            // Đóng kết nối
            sqlConnection.Close();
        }
    }
}
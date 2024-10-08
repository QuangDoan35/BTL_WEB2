using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace BTL_WEB2.App_Code.Product
{
    public class ProductDAO
    {
        public List<Product> listProduct;
        string connnetionString = WebConfigurationManager.ConnectionStrings["DataBase_QLBanCay"].ConnectionString;

        public ProductDAO() { }

        public List<Product> getListProduct(string dieuKien) //Lấy danh sách theo điều kiện truyền vào
        {
            listProduct = new List<Product>();

            SqlConnection sqlConnection = new SqlConnection(connnetionString);
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;

            string sql; //Tạo câu truy vấn theo điều kiện truyền vào
            switch (dieuKien)
            {
                case "sale":
                    sql = "SELECT * FROM Product ORDER BY GiamGia DESC"; //Lấy theo chỉ số giảm giá, sắp xếp theo thứ tự giảm giá giảm dần
                    break;
                case "banChay":
                    sql = "SELECT * FROM Product ORDER BY SoLuongDaBan DESC"; //Lấy theo chỉ số Số lượng đã bán, sắp xếp theo thứ tự số lượng đã bán giảm dần
                    break;
                case "cayAnQua":
                    sql = "SELECT * FROM Product WHERE MaDanhMuc = @MaDanhMuc"; //Lấy sản phẩm thuộc danh mục cây ăn quả
                    cmd.Parameters.AddWithValue("@MaDanhMuc", "DM002");
                    break;
                default:
                    sql = "SELECT * FROM Product"; //Lấy mặc định
                    break;
            }

            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string ma = reader["MaSanPham"].ToString();
                string ten = reader["TenSanPham"].ToString();
                double gia = double.Parse(reader["GiaSanPham"].ToString());
                string mota = reader["MoTaSanPham"].ToString();
                string anh = reader["AnhSanPham"].ToString();
                int sltk = Convert.ToInt32(reader["SoLuongTonKho"]);
                string madanhmuc = reader["MaDanhMuc"].ToString();
                int giamgia = Convert.ToInt32(reader["GiamGia"]);
                int soluongdaban = Convert.ToInt32(reader["SoLuongDaBan"]);

                Product product = new Product(ma, ten, gia, mota, anh, sltk, madanhmuc, giamgia, soluongdaban);

                listProduct.Add(product);
            }
            return listProduct;
        }
    }
}
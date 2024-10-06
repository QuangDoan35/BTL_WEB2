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

        public ProductDAO()
        {
            listProduct = new List<Product>();
        }

        public void getListProduct()
        {
            SqlConnection sqlConnection = new SqlConnection(connnetionString);
            sqlConnection.Open();
            string sql = "SELECT * FROM Product ORDER BY SoLuongDaBan";

            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            cmd.CommandType = CommandType.Text;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string ma = reader["MaSanPham"].ToString();
                string ten = reader["TenSanPham"].ToString();
                double gia = double.Parse(reader["GiaSanPham"].ToString());
                string mota = reader["MoTaSanPham"].ToString();
                string anh = reader["AnhSanPham"].ToString();

                // Kiểm tra giá trị SoLuongTonKho
                int sltk = 0; // Giá trị mặc định
                if (reader["SoLuongTonKho"] != DBNull.Value)
                {
                    sltk = Convert.ToInt32(reader["SoLuongTonKho"]);
                }

                string madanhmuc = reader["MaDanhMuc"].ToString();

                // Kiểm tra giá trị GiamGia
                int giamgia = 0; // Giá trị mặc định
                if (reader["GiamGia"] != DBNull.Value)
                {
                    giamgia = Convert.ToInt32(reader["GiamGia"]);
                }

                Product product = new Product(ma, ten, gia, mota, anh, sltk, madanhmuc, giamgia);

                listProduct.Add(product);
            }
        }
    }
}
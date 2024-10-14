using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace SimpleRegister.Pages
{
    public partial class WebRegister : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DataBase_QLBanCay"].ConnectionString;

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            // Kiểm tra mật khẩu có khớp không
            if (password != confirmPassword)
            {
                lblErrorMessage.Text = "Passwords do not match!";
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spud_addCustomer", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Tạo mã khách hàng (có thể sử dụng GUID hoặc lấy từ input)
                        string customerId = Guid.NewGuid().ToString().Substring(0, 10); // Tạo ID ngẫu nhiên

                        // Truyền đúng số lượng tham số vào stored procedure
                        cmd.Parameters.AddWithValue("@makhachhang", customerId); // Giá trị này không được để rỗng
                        cmd.Parameters.AddWithValue("@tenKhachHang", name);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@matKhau", password);

                        conn.Open();
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            Response.Redirect("WebLogin.aspx");
                        }
                        else
                        {
                            lblErrorMessage.Text = "Lỗi đăng ký.";
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 2627) // Lỗi trùng khóa chính
                {
                    lblErrorMessage.Text = "Email đã tồn tại. Vui lòng sử dụng email khác.";
                }
                else
                {
                    lblErrorMessage.Text = "SQL Error: " + sqlEx.Message;
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}

using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace BTL_WEB2.Pages.AdminPage
{
    public partial class Register : System.Web.UI.Page
    {
        // Chuỗi kết nối đến cơ sở dữ liệu
        private string connectionString = WebConfigurationManager.ConnectionStrings["DataBase_QLBanCay"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Logic khi trang tải có thể thêm vào đây
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các trường nhập
            string maKhachHang = txtMaKH.Text.Trim();
            string tenKhachHang = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            // Kiểm tra tính hợp lệ của đầu vào
            if (IsValidInput(maKhachHang, tenKhachHang, email, password, confirmPassword))
            {
                // Thực hiện đăng ký người dùng
                if (RegisterUser(maKhachHang, tenKhachHang, email, password))
                {
                    Response.Redirect("AdminLogin.aspx");
                }
                else
                {
                    lblErrorMessage.Text = "Đã xảy ra lỗi. Vui lòng thử lại.";
                }
            }
            else
            {
                lblErrorMessage.Text = "Tất cả các trường đều bắt buộc và mật khẩu phải khớp.";
            }
        }

        // Kiểm tra tính hợp lệ của đầu vào
        private bool IsValidInput(string maKhachHang, string tenKhachHang, string email, string password, string confirmPassword)
        {
            return !string.IsNullOrEmpty(maKhachHang) &&
                   !string.IsNullOrEmpty(tenKhachHang) &&
                   !string.IsNullOrEmpty(email) &&
                   !string.IsNullOrEmpty(password) &&
                   password == confirmPassword;
        }

        // Hàm thêm người dùng vào cơ sở dữ liệu
        private bool RegisterUser(string maKhachHang, string tenKhachHang, string email, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spud_addCustomer", conn))
                    {
                        conn.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;


                        // Thêm tham số vào command
                        cmd.Parameters.AddWithValue("@maKhachHang", maKhachHang);
                        cmd.Parameters.AddWithValue("@tenKhachHang", tenKhachHang);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@matKhau", password);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0; // Trả về true nếu có ít nhất một dòng được thêm vào
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 50000) // Mã lỗi tùy chỉnh cho RAISERROR
                {
                    lblErrorMessage.Text = "Khách hàng đã tồn tại. Vui lòng sử dụng mã khác.";
                }
                else
                {
                    lblErrorMessage.Text = "Lỗi: " + sqlEx.Message;
                }
                return false;
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "Lỗi: " + ex.Message;
                return false;
            }
        }
    }
}

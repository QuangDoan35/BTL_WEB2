using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace SimpleRegister.Pages
{
    public partial class WebRegister : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DataBase_QLBanCay"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtName.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtConfirmPassword.Text = string.Empty;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (
                string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword)
                )
            {
                lblErrorMessage.Text = "Vui lòng điền đầy đủ thông tin trước khi nhấn đăng ký";
                return;
            }

            // Kiểm tra mật khẩu có khớp không
            if (password != confirmPassword)
            {
                lblErrorMessage.Text = "Mật khẩu nhập vào không khớp!";
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("spud_addCustomer", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    string customerId = Guid.NewGuid().ToString().Substring(0, 10); // Tạo ID ngẫu nhiên

                    // Truyền đúng số lượng tham số vào stored procedure
                    cmd.Parameters.AddWithValue("@makhachhang", customerId);
                    cmd.Parameters.AddWithValue("@tenKhachHang", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@matKhau", password);

                    cmd.ExecuteNonQuery();
                }
            }

            Response.Redirect("WebLogin.aspx");
        }
    }
}

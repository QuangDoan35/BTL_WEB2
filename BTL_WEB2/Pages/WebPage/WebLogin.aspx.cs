using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace BTL_WEB2.Pages.WebPage
{
    public partial class WebLogin : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["DataBase_QLBanCay"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (ValidateUser(username, password))
            {
                //Lưu thông tin dăng nhập vào cookies
                HttpCookie loginCookie = new HttpCookie("loginCookie");
                loginCookie["userName"] = username;
                loginCookie.Expires = DateTime.Now.AddDays(30); // Đặt thời gian hết hạn cho cookie là 30 ngày

                // Thêm cookie vào Response
                Response.Cookies.Add(loginCookie);

                getUserID(username, password);

                //Chuyển đến trang chủ khi đăng nhập thành công
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblErrorMessage.Text = "Tài khoản hoặc mật khẩu không đúng!";
            }
        }


        private bool ValidateUser(string username, string password)
        {
            string query = "SELECT * FROM Customer WHERE Email = @Email AND Password = @Password";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Email", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    return reader.Read();
                }
            }
        }

        //Lấy mã người dùng đăng nhập
        protected void getUserID(string username, string password)
        {
            string query = "SELECT * FROM Customer WHERE Email = @Email AND Password = @Password";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Email", username);
            cmd.Parameters.AddWithValue("@Password", password);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            //Lưu thông tin dăng nhập vào cookies
            HttpCookie userIDLogin = new HttpCookie("userIDLogin");
            userIDLogin["userID"] = reader["MaKhachHang"].ToString();
            userIDLogin.Expires = DateTime.Now.AddDays(30); // Đặt thời gian hết hạn cho cookie là 30 ngày
            // Thêm cookie vào Response
            Response.Cookies.Add(userIDLogin);
        }
    }
}
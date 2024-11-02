using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace BTL_WEB2.Pages.AdminPage
{
    public partial class AdminLogin : System.Web.UI.Page
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
                Session["AdminLogin"] = true; //lưu trạng thái đăng nhập của admin
                Response.Redirect("CategoryManager.aspx");
            }
            else
            {
                lblErrorMessage.Text = "Tài khoản hoặc mật khẩu không chính xác!";
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
    }
}
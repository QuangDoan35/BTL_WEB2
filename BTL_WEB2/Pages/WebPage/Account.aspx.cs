using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace BTL_WEB2.Pages.WebPage
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getUserInfor();
        }

        protected void getUserInfor()
        {
            if (Request.Cookies["userIDLogin"] != null)
            {
                // Truy cập vào giá trị của cookie
                string userID = Request.Cookies["userIDLogin"]["userID"];

                string connectionString = WebConfigurationManager.ConnectionStrings["DataBase_QLBanCay"].ConnectionString;
                string query = "SELECT * FROM Customer WHERE MaKhachHang = @userID";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userID", userID);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                lblUserName.Text = reader["TenKhachHang"].ToString();
                lblEmail.Text = reader["Email"].ToString();

            }
            else
            {
                Response.Redirect("WebLogin.aspx");
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            //Xóa cookies đăng nhập
            HttpCookie userIDLogin = new HttpCookie("userIDLogin");
            userIDLogin.Expires = DateTime.Now.AddDays(-1); // Đặt thời gian hết hạn về quá khứ
            Response.Cookies.Add(userIDLogin); // Thêm cookie vào Response để xóa

            Response.Redirect("Default.aspx");
        }
    }
}
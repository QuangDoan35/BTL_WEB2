using System;
using System.Data.SqlClient;
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
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblErrorMessage.Text = "Tai khoan hoac mat khau khong ton tai!";
            }
        }


        private bool ValidateUser(string username, string password)
        {
            // SQL query to check for username and password in the database
            string query = "SELECT COUNT(*) FROM Customer WHERE Email = @Email AND Password = @Password";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Open the database connection
                        conn.Open();

                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Email", username);
                        cmd.Parameters.AddWithValue("@Password", password); // Make sure to hash passwords in production!

                        // Execute the query and get the result
                        int userCount = (int)cmd.ExecuteScalar();

                        // If the result is greater than 0, the user exists
                        return userCount > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                lblErrorMessage.Text = "An error occurred: " + ex.Message;
                return false;
            }
        }
    }
}
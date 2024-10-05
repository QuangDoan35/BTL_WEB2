using System;

namespace BTL_WEB2.Pages.WebPage
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        //Hiển thị danh sách sản phẩm
        private void LoadProducts()
        {
            DisplayProducts();
        }

        private void DisplayProducts()
        {

        }
    }
}
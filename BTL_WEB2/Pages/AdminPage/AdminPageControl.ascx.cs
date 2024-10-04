using System;

namespace BTL_WEB2.Pages.AdminPage
{
    public partial class AdminPageControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string request = Request["f"];

            // Nếu request không có giá trị, đặt giá trị mặc định
            if (string.IsNullOrEmpty(request))
            {
                request = "Category"; // Trang mặc định là Category
            }

            switch (request)
            {
                case "Category":
                    plAdminPageControl.Controls.Add(LoadControl("CategoryManager/CategoryControl.ascx"));
                    break;
                case "Customer":
                    plAdminPageControl.Controls.Add(LoadControl("CustomerManager/CustomerControl.ascx"));
                    break;
                case "Order":
                    plAdminPageControl.Controls.Add(LoadControl("OrderManager/OrderControl.ascx"));
                    break;
                case "Product":
                    plAdminPageControl.Controls.Add(LoadControl("ProductManager/ProductControl.ascx"));
                    break;
            }
        }
    }
}
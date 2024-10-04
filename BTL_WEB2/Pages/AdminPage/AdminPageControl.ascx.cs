using System;

namespace BTL_WEB2.Pages.AdminPage
{
    public partial class AdminPageControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string request = Request["f"];

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
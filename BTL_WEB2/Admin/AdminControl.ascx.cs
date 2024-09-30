using System;

namespace BTL_WEB2.Admin
{
    public partial class AdminControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = Request["f"];
            switch (s)
            {
                case "category":
                    plLoad.Controls.Add(LoadControl("Category/CategoryControl.ascx"));
                    break;
                case "user":
                    plLoad.Controls.Add(LoadControl("User/UserControl.ascx"));
                    break;
                case "order":
                    plLoad.Controls.Add(LoadControl("Order/OrderControl.ascx"));
                    break;
                case "product":
                    plLoad.Controls.Add(LoadControl("Product/ProductControl.ascx"));
                    break;
            }
        }
    }
}
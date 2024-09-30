using System;
using System.Web.UI;

namespace BTL_WEB2
{
    public partial class Manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Tải AdminControl vào PlaceHolder
            Control adminControl = LoadControl("Admin/AdminControl.ascx");
            plLoad.Controls.Add(adminControl);
        }
    }
}
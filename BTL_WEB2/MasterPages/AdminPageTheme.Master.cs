using System;

namespace BTL_WEB2.MasterPages
{
    public partial class AdminPageTheme : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DanhMucLink.NavigateUrl = "../Pages/AdminPage/WebForm1.aspx";
                NguoiDungLink.NavigateUrl = "";
                DonDatHangLink.NavigateUrl = "";
                SanPhamLink.NavigateUrl = "";
            }
        }
    }
}
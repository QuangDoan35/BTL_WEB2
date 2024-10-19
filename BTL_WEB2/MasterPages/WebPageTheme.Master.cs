using System;

namespace BTL_WEB2.MasterPages
{
    public partial class WebPageTheme : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                homeLink.NavigateUrl = "../Pages/WebPage/Default.aspx";
                saleLink.NavigateUrl = "../Pages/WebPage/SieuSALE.aspx";
                cayAnQuaLink.NavigateUrl = "../Pages/WebPage/CayAnQua.aspx";
                cayCanhLink.NavigateUrl = "../Pages/WebPage/CayCanh.aspx";
                senDaLink.NavigateUrl = "../Pages/WebPage/SenDa.aspx";
                hatGiongLink.NavigateUrl = "../Pages/WebPage/HatGiong.aspx";
                banChayLink.NavigateUrl = "../Pages/WebPage/BanChay.aspx";
                cartLink.NavigateUrl = "../Pages/WebPage/GioHang.aspx";
                accontLink.NavigateUrl = "../Pages/WebPage/Account.aspx";

                homeLinkFooter.NavigateUrl = "../Pages/WebPage/Default.aspx";
                saleLinkFooter.NavigateUrl = "../Pages/WebPage/SieuSALE.aspx";
                cayAnQuaLinkFooter.NavigateUrl = "../Pages/WebPage/CayAnQua.aspx";
                cayCanhLinkFooter.NavigateUrl = "../Pages/WebPage/CayCanh.aspx";
                senDaLinkFooter.NavigateUrl = "../Pages/WebPage/SenDa.aspx";
                hatGiongLinkFooter.NavigateUrl = "../Pages/WebPage/HatGiong.aspx";
                banChayLinkFooter.NavigateUrl = "../Pages/WebPage/BanChay.aspx";
            }
        }
    }
}
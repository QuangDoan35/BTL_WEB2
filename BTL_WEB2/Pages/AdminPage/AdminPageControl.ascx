<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminPageControl.ascx.cs" Inherits="BTL_WEB2.Pages.AdminPage.AdminPageControl" %>
<header>
    <div class="banner">
        Trang quản trị
        <asp:LinkButton runat="server">Quay về trang WEB</asp:LinkButton>
    </div>
    <div class="nav-bar">
        <div>logo</div>
        <div class="menu">
            <ul>
                <li><a href="#">Trang chủ</a></li>
                <li><a href="AdminPage.aspx?f=Category">Danh Mục</a></li>
                <li><a href="AdminPage.aspx?f=Customer">Người dùng</a></li>
                <li><a href="AdminPage.aspx?f=Order">Đơn đặt hàng</a></li>
                <li><a href="AdminPage.aspx?f=Product">Sản phẩm</a></li>
            </ul>
        </div>
    </div>
</header>

<asp:PlaceHolder ID="plAdminPageControl" runat="server"></asp:PlaceHolder>

<footer>
    this is footer
</footer>

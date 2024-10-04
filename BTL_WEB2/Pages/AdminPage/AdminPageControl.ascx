<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminPageControl.ascx.cs" Inherits="BTL_WEB2.Pages.AdminPage.AdminPageControl" %>
<style type="text/css">
</style>
<header>
    <div style="height: 100px; padding: 10px 50px; display: flex; justify-content: space-between; align-items: center; color: white; background-color: #5bc0be;">
        <h2>Trang quản trị</h2>
        <a href="../WebPage/Default.aspx">Quay về trang WEB</a>
    </div>
    <div class="nav-bar">
        <div>logo</div>
        <div class="menu">
            <ul>
                <li><a href="AdminPage.aspx?f=Category">Danh Mục</a></li>
                <li><a href="AdminPage.aspx?f=Customer">Người dùng</a></li>
                <li><a href="AdminPage.aspx?f=Order">Đơn đặt hàng</a></li>
                <li><a href="AdminPage.aspx?f=Product">Sản phẩm</a></li>
            </ul>
        </div>
    </div>
</header>

<asp:PlaceHolder ID="plAdminPageControl" runat="server"></asp:PlaceHolder>
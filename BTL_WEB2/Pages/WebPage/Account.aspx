<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/WebPageTheme.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="BTL_WEB2.Pages.WebPage.Account" %>

<asp:Content ContentPlaceHolderID="plHead" runat="server">
    <title>Tài Khoản</title>
    <link type="text/css" rel="stylesheet" href="../../Content/Styles/WebPage/Account.css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentWebPage" runat="server">
    <div class="container flex">
            <div class="flex">
                <img src="../../Images/user-avatar.jpg" width="200"/>
                <div>
                    <div style="font-weight: bold; font-size: 1.25rem"><asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></div>
                    <div style="color: #11111150; font-size: 1rem"><asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></div>
                </div>
            </div>
            <asp:LinkButton CssClass="btn-logout" ID="LogoutButton" runat="server" OnClick="Logout_Click">Đăng xuất  <i class="bi bi-box-arrow-right"></i></asp:LinkButton>
        </div>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="BTL_WEB2.Pages.AdminPage.AdminPage" %>

<%@ Register Src="~/Pages/AdminPage/AdminPageControl.ascx" TagPrefix="uc1" TagName="AdminPageControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trang quản trị</title>
    <link rel="stylesheet" href="../../Content/Styles/Admin/Admin.css" />
</head>
<body>
    <form runat="server">
        <uc1:AdminPageControl runat="server" ID="AdminPageControl" />
    </form>
</body>
</html>

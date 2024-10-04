<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="BTL_WEB2.Manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản trị</title>
    <link rel="stylesheet" type="text/css" href="Content/Styles/Admin.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 20px 100px; background-image: linear-gradient(to bottom right, #14CC60, #27FB6B);">
            <h1>TRANG QUẢN TRỊ</h1>
        </div>
        <div>
            <asp:PlaceHolder ID="plLoad" runat="server">
            </asp:PlaceHolder>
        </div>
    </form>
</body>
</html>

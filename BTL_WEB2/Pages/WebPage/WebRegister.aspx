<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebRegister.aspx.cs" Inherits="SimpleRegister.Pages.WebRegister" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simple User Registration</title>
    <style>
       body {
    font-family: Arial, sans-serif;
    background-color: #f4f4f4;
    margin: 0;
    padding: 0;
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
}

.register-container {
    background-color: #fff;
    padding: 20px;
    border-radius: 10px;
    box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
    width: 100%;
    max-width: 400px; /* Giới hạn chiều rộng */
    text-align: center; /* Căn giữa nội dung */
}

h2 {
    font-size: 24px;
    margin-bottom: 20px;
    color: #333;
}

input[type="text"],
input[type="password"],
input[type="email"] {
    width: 100%;
    padding: 12px;
    margin: 10px 0;
    border-radius: 5px;
    border: 1px solid #ccc;
    font-size: 16px;
    box-sizing: border-box;
}

input[type="submit"] {
    width: 100%;
    padding: 12px;
    background-color: #4caf50;
    border: none;
    color: white;
    font-size: 16px;
    border-radius: 5px;
    cursor: pointer;
    margin-top: 10px;
}

input[type="submit"]:hover {
    background-color: #45a049;
}

.error-message {
    color: red;
    font-size: 14px;
    margin-top: 10px;
}

@media (max-width: 500px) {
    .register-container {
        padding: 15px;
    }

    input[type="text"],
    input[type="password"],
    input[type="email"] {
        font-size: 14px;
    }

    h2 {
        font-size: 20px;
    }
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="register-container">
            <h2>Đăng ký tài khoản</h2>
            <asp:TextBox ID="txtName" runat="server" placeholder="Họ Và Tên"></asp:TextBox><br />
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox><br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Mật khẩu"></asp:TextBox><br />
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" placeholder="Nhập lại mật khẩu"></asp:TextBox><br />
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" /><br />
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message"></asp:Label>
        </div>
    </form>
</body>
</html>

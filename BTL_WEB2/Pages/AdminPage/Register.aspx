<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BTL_WEB2.Pages.AdminPage.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Registration</title>
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;600&display=swap" rel="stylesheet">
    <style>
        body {
            margin: 0;
            padding: 0;
            background: url('~/Images/nature-background.jpg') no-repeat center center fixed;
            background-size: cover;
            font-family: 'Poppins', sans-serif;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .register-container {
            background-color: rgba(255, 255, 255, 0.95);
            padding: 30px;
            width: 400px;
            border-radius: 10px;
            box-shadow: 0 10px 20px rgba(0, 0, 0, 0.2);
            text-align: center;
        }

        h2 {
            font-size: 26px;
            margin-bottom: 20px;
            color: #4caf50;
        }

        .register-container input[type="text"],
        .register-container input[type="password"],
        .register-container input[type="email"] {
            width: 100%;
            padding: 12px;
            margin: 10px 0;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 16px;
        }

        .register-container input[type="submit"] {
            width: 100%;
            padding: 12px;
            background-color: #4caf50;
            border: none;
            color: white;
            font-size: 16px;
            border-radius: 5px;
            cursor: pointer;
        }

        .register-container input[type="submit"]:hover {
            background-color: #45a049;
        }

        .error-message {
            color: red;
            font-size: 14px;
            margin-top: 10px;
        }

        a {
            color: #4caf50;
            font-size: 14px;
            display: block;
            margin-top: 10px;
            text-decoration: none;
        }

        a:hover {
            text-decoration: underline;
        }

        .btn-back {
            background-color: #f44336; /* Màu đỏ cho nút quay lại */
            margin-top: 15px; /* Khoảng cách trên nút */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="register-container">
            <h2>User Registration</h2>

            <!-- Mã Khách Hàng -->
            <asp:TextBox ID="txtMaKH" runat="server" CssClass="form-control" placeholder="Mã Khách Hàng" required></asp:TextBox>

            <!-- Tên Khách Hàng -->
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Họ và Tên" required></asp:TextBox>

            <!-- Tên Đăng Nhập -->

            <!-- Email -->
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" required></asp:TextBox>

            <!-- Mật Khẩu -->
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Mật Khẩu" required></asp:TextBox>

            <!-- Xác Nhận Mật Khẩu -->
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Xác Nhận Mật Khẩu" required></asp:TextBox>

            <!-- Nút Đăng Ký -->
            <asp:Button ID="btnRegister" runat="server" Text="Đăng Ký" CssClass="btn-register" OnClick="btnRegister_Click" />

            <!-- Thông báo lỗi -->
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message"></asp:Label>

            <!-- Liên kết đến trang Đăng Nhập -->
            <a href="AdminLogin.aspx">Đã có tài khoản? Đăng nhập tại đây</a>
        </div>
    </form>
</body>
</html>

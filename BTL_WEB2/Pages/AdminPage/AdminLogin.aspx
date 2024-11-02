<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="BTL_WEB2.Pages.AdminPage.AdminLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
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

        .login-container {
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

        .login-container input[type="text"], 
        .login-container input[type="password"] {
            width: 100%;
            padding: 12px;
            margin: 10px 0;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 16px;
        }

        .login-container input[type="submit"] {
            width: 100%;
            padding: 12px;
            background-color: #4caf50;
            border: none;
            color: white;
            font-size: 16px;
            border-radius: 5px;
            cursor: pointer;
        }

        .login-container input[type="submit"]:hover {
            background-color: #45a049;
        }

        .login-container a {
            color: #4caf50;
            font-size: 14px;
            display: block;
            margin: 10px 0;
            text-decoration: none;
        }

        .login-container a:hover {
            text-decoration: underline;
        }

        .error-message {
            color: red;
            font-size: 14px;
            margin-top: 10px;
        }

        .show-password {
            margin-top: 10px;
        }

        .show-password input {
            margin-left: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Admin Login</h2>

            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>

            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>

            <div class="show-password">
                <input type="checkbox" id="chkShowPassword" onclick="togglePassword()" />
                <label for="chkShowPassword">Hiển thị mật khẩu </label>
            </div>

            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn-login" OnClick="btnLogin_Click" />

            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message"></asp:Label>
        </div>
    </form>

    <script type="text/javascript">
        function togglePassword() {
            var passwordInput = document.getElementById('<%= txtPassword.ClientID %>');
            if (passwordInput.type === 'password') {
                passwordInput.type = 'text';
            } else {
                passwordInput.type = 'password';
            }
        }
    </script>
</body>
</html>

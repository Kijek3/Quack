<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Quack.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon">
    <title>Rejestracja</title>
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/buttonReset.css">
    <link rel="stylesheet" href="css/menu.css" />
    <link rel="stylesheet" href="css/forms.css" />
    <script src="Scripts/actions.js"></script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="registerButton">
        <asp:Panel ID="Menu" runat="server" CssClass="fixedTopMenu"></asp:Panel>
        <div class="loginForm">
            <h2>Rejestracja</h2>
            <asp:Label runat="server" ID="errorLabel" ForeColor="#FF3300" Width="100%"></asp:Label>
            <div class="formRow">
                <label>Adres email</label>
                <asp:TextBox ID="email" runat="server" TextMode="Email"></asp:TextBox>
            </div>
            <div class="formRow">
                <label>Login</label>
                <asp:TextBox ID="login" runat="server"></asp:TextBox>
            </div>
            <div class="formRow">
                <label>Hasło</label>
                <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Button ID="registerButton" runat="server" Text="Zarejestruj się" OnClick="registerButton_Click" />
            <asp:Button ID="loginRedirect" runat="server" Text="Masz już konto? Zaloguj się!" OnClick="loginRedirect_Click" />
        </div>
    </form>
</body>
</html>

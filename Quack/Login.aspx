<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Quack.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon">
    <title>Logowanie</title>
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/buttonReset.css">
    <link rel="stylesheet" href="css/menu.css" />
    <link rel="stylesheet" href="css/forms.css" />
    <script src="Scripts/actions.js"></script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="loginButton">
        <asp:Panel ID="Menu" runat="server" CssClass="fixedTopMenu"></asp:Panel>
        <div class="loginForm">
            <h2>Logowanie</h2>
            <asp:Label runat="server" ID="errorLabel" ForeColor="#FF3300" Width="100%"></asp:Label>
            <div class="formRow">
                <label>Login</label>
                <asp:TextBox ID="login" runat="server"></asp:TextBox>
            </div>
            <div class="formRow">
                <label>Hasło</label>
                <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Button ID="loginButton" runat="server" Text="Zaloguj się" OnClick="loginButton_Click"/>
            <asp:Button ID="registerRedirect" runat="server" Text="Nie masz jeszcze konta? Zarejestruj się!" OnClick="registerRedirect_Click" />
        </div>
    </form>
</body>
</html>

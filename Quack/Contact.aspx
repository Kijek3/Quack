<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Quack.Contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon">
    <title>Formularz kontaktowy</title>
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/buttonReset.css">
    <link rel="stylesheet" href="css/menu.css" />
    <link rel="stylesheet" href="css/forms.css" />
    <script src="Scripts/actions.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Menu" runat="server" CssClass="fixedTopMenu"></asp:Panel>
        <div class="loginForm">
            <h2>Kontakt</h2>
            <asp:Label runat="server" ID="errorLabel" ForeColor="#FF3300" Width="100%"></asp:Label>
            <div class="formRow">
                <label>Email</label>
                <asp:TextBox ID="email" runat="server" TextMode="Email"></asp:TextBox>
            </div>
            <div class="formRow">
                <label>Temat</label>
                <asp:TextBox ID="subject" runat="server" TextMode="SingleLine"></asp:TextBox>
            </div>
            <div class="formRow">
                <label>Wiadomość</label>
                <asp:TextBox ID="messageText" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <asp:Button ID="sendButton" runat="server" Text="Wyślij wiadomość" OnClick="sendButton_Click" />
        </div>
    </form>
</body>
</html>

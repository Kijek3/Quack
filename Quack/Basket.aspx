<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Basket.aspx.cs" Inherits="Quack.Basket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon" />
    <title>Koszyk</title>
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/buttonReset.css" />
    <link rel="stylesheet" href="css/menu.css" />
    <link rel="stylesheet" href="css/basket.css" />
    <style>
        .deleteButton {
            background-color: #ff1c23;
        }

        .deleteButton:hover {
            background-color: #ff7c23;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Menu" runat="server" CssClass="fixedTopMenu"></asp:Panel>
        <div id="basketContainer">
            <asp:Table ID="basketTable" runat="server">
                <asp:TableRow>
                    <asp:TableHeaderCell runat="server" Text="Nazwa produktu"></asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server" Text="Rozmiar"></asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server" Text="Kolor"></asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server" Text="Ilość"></asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server" Text=""></asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server" Text="Cena"></asp:TableHeaderCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <asp:Button ID="buttonOrder" runat="server" Text="Złóż zamówienie" OnClick="buttonOrder_Click" />
    </form>
</body>
</html>

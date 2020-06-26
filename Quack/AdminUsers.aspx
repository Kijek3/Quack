<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminUsers.aspx.cs" Inherits="Quack.AdminUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon" />
    <title>Zarządzanie użytkownikami</title>
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/buttonReset.css" />
    <link rel="stylesheet" href="css/menu.css" />
    <link rel="stylesheet" href="css/basket.css" />
    <style>
        #usersTable .deleteButton {
            background-color: #ff1c23;
        }

            #usersTable .deleteButton:hover {
                background-color: #ff7c23;
            }

        #usersTable .adminButton {
            background-color: #ffb11c;
        }

            #usersTable .adminButton:hover {
                background-color: #ffd11c;
            }

        #ordersTable .doneButton {
            background-color: #46c610;
        }

            #ordersTable .doneButton:hover {
                background-color: #46e610;
            }

        #productsTable .deleteButton {
            background-color: #ff1c23;
        }

            #productsTable .deleteButton:hover {
                background-color: #ff7c23;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Menu" runat="server" CssClass="fixedTopMenu"></asp:Panel>
        <div id="usersContainer">
            <asp:Table ID="usersTable" runat="server">
                <asp:TableRow>
                    <asp:TableHeaderCell runat="server" Text="Użytkownik"></asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server" Text="Administrator"></asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server" Text=""></asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server" Text=""></asp:TableHeaderCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <h2 style="text-align: center; margin-top: 10px; margin-bottom: 10px;">Zamówienia</h2>
        <div id="usersContainer">
            <asp:Table ID="ordersTable" runat="server">
                <asp:TableRow>
                    <asp:TableHeaderCell runat="server" Text="Użytkownik"></asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server" Text="Produkt"></asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server" Text="Ilość"></asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server" Text="Kolor"></asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server" Text="Rozmiar"></asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server" Text=""></asp:TableHeaderCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <h2 style="text-align: center; margin-top: 10px; margin-bottom: 10px;">Produkty</h2>
        <div id="usersContainer">
            <asp:Table ID="productsTable" runat="server">
                <asp:TableRow>
                    <asp:TableHeaderCell runat="server" Text="Nazwa produktu"></asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server" Text="Cena"></asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server" Text=""></asp:TableHeaderCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>

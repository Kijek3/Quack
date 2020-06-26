<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Quack.AddProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon">
    <title>Product add</title>
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/buttonReset.css">
    <link rel="stylesheet" href="css/menu.css" />
    <link rel="stylesheet" href="css/forms.css" />
    <script src="Scripts/actions.js"></script>
    <style>
        #productAdd {
            margin: 20px;
            display: flex;
            flex-direction: column;
        }

        .formRow {
            display: flex;
            margin: 10px;
        }

        #addButton {
            background-color: rgb(39, 190, 51);
        }

            #addButton:hover {
                background-color: rgb(91, 211, 101);
            }

        #colorsCheckbox tr {
            display: inline-block;
            margin: 5px;
        }
        #colorsCheckbox label {
            margin: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Menu" runat="server" CssClass="fixedTopMenu"></asp:Panel>
        <div id="productAdd">
            <div class="formRow">
                <span>Nazwa produktu</span>
                <asp:TextBox ID="productName" runat="server"></asp:TextBox>
            </div>
            <div class="formRow">
                <span>Kategoria produktu</span>
                <asp:TextBox ID="productCategory" runat="server"></asp:TextBox>
            </div>
            <div class="formRow">
                <span>Opis produktu</span>
                <asp:TextBox ID="productDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="formRow">
                <span>Dodaj zdjęcia</span>
                <asp:FileUpload ID="productPictures" runat="server" AllowMultiple="True" ClientIDMode="Inherit" />
            </div>
            <div class="formRow">
                <span>Cena</span>
                <asp:TextBox ID="productPrice" runat="server" TextMode="Number" step="0.01"></asp:TextBox>
            </div>
            <div class="formRow">
                <span>Kolory</span>
                <div>
                    <asp:CheckBoxList ID="colorsCheckbox" runat="server">
                        <asp:ListItem style="color: black;">Black</asp:ListItem>
                        <asp:ListItem style="color: pink;">Pink</asp:ListItem>
                        <asp:ListItem style="color: green;">Green</asp:ListItem>
                        <asp:ListItem style="color: blue;">Blue</asp:ListItem>
                        <asp:ListItem style="color: cadetblue;">Cadetblue</asp:ListItem>
                        <asp:ListItem style="color: brown;">Brown</asp:ListItem>
                        <asp:ListItem style="color: moccasin;">Moccasin</asp:ListItem>
                        <asp:ListItem style="color: cornflowerblue;">Cornflowerblue</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </div>
            <asp:Button ID="addButton" runat="server" Text="Dodaj produkt do sklepu" OnClick="addButton_Click" />
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Quack.Product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon" />
    <title>Super Hiper Product</title>
    <link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.css" />
    <link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick-theme.css" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/buttonReset.css" />
    <link rel="stylesheet" href="css/menu.css" />
    <link rel="stylesheet" href="css/product.css" />
    <link rel="stylesheet" href="css/productShow.css" />
    <script src="Scripts/actions.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Menu" runat="server" CssClass="fixedTopMenu"></asp:Panel>
        <div id="productTop">
            <div id="productImages">
                <asp:Panel ID="productSlider" runat="server" CssClass="productSlider"></asp:Panel>
            </div>
            <div id="productOrder">
                <asp:Label ID="productName" runat="server" Text="" Font-Size="Larger" Font-Bold="True"></asp:Label>
                <p>Rozmiar</p>
                <asp:Panel ID="sizeButtons" runat="server"></asp:Panel>
                <p>Kolor</p>
                <asp:Panel ID="colorButtons" runat="server"></asp:Panel>
                <asp:Panel ID="basketPanel" runat="server">
                    <asp:Button ID="basketAddButton" runat="server" Text="Dodaj do koszyka" OnClick="basketAddButton_Click" />
                    <asp:Label ID="labelCount" runat="server" Text="Ilość"></asp:Label>
                    <asp:TextBox ID="basketCount" runat="server" TextMode="Number" min="1" max="50" Font-Size="Large">1</asp:TextBox>
                </asp:Panel>
            </div>
        </div>
    </form>
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.4.1.min.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.productSlider').slick({
                infinite: false,
                dots: true,
                slidesToShow: 1,
                slidesToScroll: 1
            });
            //changeColor("black");
        });
    </script>
</body>
</html>

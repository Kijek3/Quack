<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Quack.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon" />
    <title>Strona główna</title>
    <link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.css" />
    <link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick-theme.css" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/buttonReset.css" />
    <link rel="stylesheet" href="css/menu.css" />
    <link rel="stylesheet" href="css/product.css" />
    <style>
        h2 {
            margin: 15px;
            text-align: center;
        }
    </style>
    <script src="Scripts/actions.js"></script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="">
        <asp:Panel ID="Menu" runat="server" CssClass="fixedTopMenu"></asp:Panel>
        <asp:Panel ID="PanelProducts" runat="server"></asp:Panel>
    </form>
        <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.4.1.min.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //console.log($('.productsRow'))
            $('.productsRow').slick({
                infinite: false,
                dots: true,
                slidesToShow: 3,
                slidesToScroll: 1
            });
        });
    </script>
</body>
</html>

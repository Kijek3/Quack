<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error404.aspx.cs" Inherits="Quack.Error404" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Error 404</title>
    <link rel="stylesheet" href="css/style.css" />
    <style>
        #container {
            display: flex;
            height: 100vh;
            flex-direction: column;
            justify-content: center;
            align-items: center;
        }

        img {
            animation: duckAnim 3s ease-in-out 0s infinite;
            /*cursor: pointer;*/
            transition: width 1s;
        }

        img:hover {
            width: 450px;
        }

        @keyframes duckAnim {
            0% {
                transform: rotate(0deg);
            }

            25% {
                transform: rotate(30deg);
            }
            50% {
                transform: rotate(0deg);
            }

            75% {
                transform: rotate(-30deg);
            }
            100% {
                transform: rotate(0deg);
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <a href="Index.aspx"><img src="logo.png" alt="quack" width="300" /></a>
            <h2>KWAtastrofa! (404)</h2>
            <p>O żesz w kaczkę! Jak tutaj trafiłeś? Nie martw się, nasza kaczka Cię stąd wyciągnie!</p>
        </div>
    </form>
</body>
</html>

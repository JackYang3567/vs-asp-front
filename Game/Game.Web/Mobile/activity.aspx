<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="activity.aspx.cs" Inherits="Game.Web.Mobile.activity" %>

<!doctype html>
<html class="market-html">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1, maximum-scale=1, minimum-scale=1, user-scalable=no">
    <meta name="format-detection" content="telphone=no, email=no" />
    <title>活动</title>
    <link rel="stylesheet" href="Css/market.css" />
    <script src="../js/jquery.min.js" charset="utf-8" type="text/javascript"></script>
    <style>
        iframe {
            display:none
        }
    </style>
</head>
<body>
    <div class="wrap">
        <div class="main">
            <ul class="activity">
                <asp:Repeater ID="rptData" runat="server">
                    <ItemTemplate>
                        <li activity="88">
                            <img src="<%#Game.Utils.ApplicationSettings.Get("fileUrl")+"/Activity/"+Eval("ImageUrl").ToString()%>" />
                            <div class="activety-list-alert">
                                <%#Eval("Describe").ToString().Replace("/Content/Upload", Game.Utils.ApplicationSettings.Get("fileUrl"))%>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <script>
        // "活动一览"－－点击图片时下面的内容展开与收起
        $(".activity li[activity]").on("click", function () {
            $(this).find("div:first").slideToggle("slow").closest("li").siblings().children(".activety-list-alert").slideUp("slow");
        });
    </script>
</body>
</html>

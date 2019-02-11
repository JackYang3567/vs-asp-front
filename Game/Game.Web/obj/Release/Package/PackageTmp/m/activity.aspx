<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="/m/activity.aspx.cs" Inherits="Game.Web.m.activity" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1, maximum-scale=1, minimum-scale=1, user-scalable=no">
    <meta name="format-detection" content="telphone=no, email=no" />
    <title>云鼎-活动中心</title>
    <link rel="stylesheet" href="common.css">
    <script src="js/jquery-1.10.2.min.js"></script>
</head>
<body>
    <div class="wrap">
        <div class="header">
            <img src="images/subpage_header.png" alt="logo" />
        </div>
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
            <img src="images/online_service.png" alt="Alternate Text" class="online-service" />
            <a href="javascript:history.back(-1);" class="return-btn">返&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;回</a>
    </div>
    <script>
        var on = 1;
        // "活动一览"－－点击图片时下面的内容展开与收起
        $(".activity li[activity]").on("click", function () {
            $(this).find("div:first").slideToggle("slow").closest("li").siblings().children(".activety-list-alert").slideUp("slow");
        });
    </script>
</body>
</html>

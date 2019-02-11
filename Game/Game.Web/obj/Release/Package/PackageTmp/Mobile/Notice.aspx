<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notice.aspx.cs" Inherits="Game.Web.Mobile.Notice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1, maximum-scale=1, minimum-scale=1, user-scalable=no">
    <meta name="format-detection" content="telphone=no, email=no" />
    <title>公告</title>
    <script src="../js/jquery.min.js" charset="utf-8" type="text/javascript"></script>
    <style>
        html{color:#fff;background-color:#1f1f1f;font-family:Arial,'Microsoft YaHei','宋体';}
        body,div,dl,dt,dd,ul,ol,li,h1,h2,h3,h4,h5,h6,pre,code,form,fieldset,legend,input,button,textarea,p,blockquote,th,td,strong{padding:0;margin:0;font-family:'Microsoft YaHei',Arial,'宋体';}
        html,
        body {
            width: 100%;
            height: 100%;
        }
        marquee {
            height: 100%;
        }
        .notice-list {
            width: 90%;
            margin: 0 auto;
            line-height: 20px;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <marquee scrollamount="3" direction="up">
        <div class="notice-list">
           <asp:Literal ID="ltlNotice" runat="server"></asp:Literal>
        </div>       
    </marquee>
</body>
</html>

﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExchangeBindings.aspx.cs" Inherits="Game.Web.Mobile.ExchangeBindings" %>


<!DOCTYPE html>
<html class="market-html">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width,initial-scale=1, maximum-scale=1, minimum-scale=1, user-scalable=no" />
    <meta name="format-detection" content="telphone=no, email=no" />
    <title>兑换绑定</title>
    <link rel="stylesheet" href="Css/market.css" />
    <script src="../js/jquery.min.js" charset="utf-8" type="text/javascript"></script>
</head>
<body>
     <div class="binding-main">
        <div class="binding-card clearfix" >
            <span class="fl">银行卡：</span>
            <strong class="fl"><%= msgInfo %></strong>
            <%if(!isBind){%>
            <a href="BindingsList.aspx" class="fl">
                <img src="Image/btn_binding.png" alt="Alternate Text" />
            </a>
            <%} %>
        </div>
        <p class="prompt">温馨提示：请填写真实信息，详细信息保存后将无法进行修改。如需修改，请联系客服人员！</p>     
    </div>
</body>
</html>

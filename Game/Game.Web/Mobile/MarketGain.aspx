<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MarketGain.aspx.cs" Inherits="Game.Web.Mobile.MarketGain" %>

<!DOCTYPE html>

<html class="market-html">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1, maximum-scale=1, minimum-scale=1, user-scalable=no">
    <meta name="format-detection" content="telphone=no, email=no"/>
    <title>推广赚金</title>
    <link rel="stylesheet" href="Css/market.css" />
    <script src="../js/jquery-1.8.3.min.js" charset="utf-8" type="text/javascript"></script>
</head>
<body>
    <div class="warp">
        <div class="main clearfix">
            <div class="fl gain-code">
                <div>
                    <img src="/WS/QRCode.ashx?qt=<%=url %>&qs=244" width="244" />
                </div>
                <p>推广二维码</p>        
            </div>
            <div class="fl gain-list">
                <img src="Image/gain_tit.png" alt="" />                
                <p>方式一：截图本页面二维码，发送给好友扫码，并注册下载游戏</p>
               
                <p>方式二：在游戏主页右下角点击<img src="Image/share_btn.png" alt="" />发送给好友，注册下载游戏</p>
                <p class="clearfix">
                    <span id="copyText" class="fl">方式三：</span> 
                    <input class="fl shurubox" id="awardQqQun1" type="text" name="copy_link" onclick="copyTo();" value="<%=url %>" readonly="readonly" />
                    <%--<input type="button" class="fl linkback" value="复制链接" />--%>
                    <button class="fl linkback" data-clipboard-text="<%=url %>">复制链接</button>           
                </p>
                      
                <p class="explain">复制您的专属网站，发送给好友，注册下载游戏</p>
               <%-- <a href="/mobile/activity.aspx?id=1">查看详情</a>--%>
            </div>
        </div>
    </div>
    <script src="Js/MarketGain.js" charset="utf-8" type="text/javascript"></script>
    <script src="/js/clipboard.min.js"></script>
    <script>
        var btn = document.querySelectorAll('button');
        var clipboard = new Clipboard(btn);

        clipboard.on('success', function (e) {
            alert("已成功复制到剪切板！");
        });

        clipboard.on('error', function (e) {
            alert('浏览器不支持复制功能，请手动复制！');
        });
    </script>
</body>
</html>

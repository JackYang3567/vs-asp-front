<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="send.aspx.cs" Inherits="Game.Web.Pay.zhifu.send" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1, maximum-scale=1, minimum-scale=1, user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="renderer" content="webkit">
    <meta name="HandheldFriendly" content="true">
    <meta name="full-screen" content="yes">
    <meta name="screen-orientation" content="portrait">
    <meta name="x5-fullscreen" content="true">
    <meta name="x5-orientation" content="portrait">
    <meta name="format-detection" content="telphone=no, email=no" />
    <title>扫码支付</title>
    <style>
        html {
            color: #C3BFC0;
            background: #fff;
            font-family: Arial,'Microsoft YaHei','宋体';
        }

        body, div, h1, p, strong {
            padding: 0;
            margin: 0;
            font-family: 'Microsoft YaHei',Arial,'宋体';
        }

        img {
            border: 0;
        }

        a {
            text-decoration: none;
            color: #fff;
            outline: none;
        }

        em, strong {
            font-style: normal;
            font-weight: normal;
        }

        em, strong, {
            font-style: inherit;
            font-weight: inherit;
        }

        h1, h2, h3, h4, h5, h6 {
            font-size: 100%;
            font-weight: normal;
        }

        q:before, q:after {
            content: '';
        }

        body {
            -webkit-text-size-adjust: none;
        }

        * {
            -webkit-tap-highlight-color: rgba(0,0,0,0);
        }

        @media only screen and (max-width: 415px) {
            html {
                font-size: 60px;
            }

            body .amount-payable-info p {
                width: 5.3rem;
            }
        }

        @media only screen and (min-width:720px ) and (max-width: 1023px) {
            html {
                font-size: 80px;
            }
        }

        @media only screen and (min-width:1024px ) and (max-width: 1199px) {
            html {
                font-size: 90px;
            }
        }

        @media only screen and (min-width:1200px ) and (max-width: 1400px) {
            html {
                font-size: 100px;
            }
        }

        @media only screen and (min-width: 1401px) {
            html {
                font-size: 110px;
            }
        }

        .wrap {
            width: 100%;
            padding-bottom: .5rem;
            font-size: .2rem;
        }

        .order-info p {
            margin: .4rem 0 .1rem;
            color: #4D90BD;
            font-size: .25rem;
        }

        .amount-payable-info span,
        .order-info {
            display: block;
            text-align: center;
        }

        .header {
            width: 100%;
            height: 1rem;
            background-color: #000;
            line-height: 1rem;
            color: #fff;
            font-size: .4rem;
            text-align: center;
        }

        .amount-payable-info img {
            display: block;
            width: 4.0rem;
            height: 4.0rem;
            margin: 2% auto 2%;
        }

        .order-info,
        .amount-payable-info {
            width: 94%;
            margin: 0 auto;
            line-height: .3rem;
        }

            .amount-payable-info div {
                margin: .2rem 0;
                color: #FF0017;
                font-size: .35rem;
                text-align: center;
            }

            .amount-payable-info p {
                width: 6rem;
                margin: .1rem auto 0;
                color: #414141;
                font-size: .20rem;
                font-weight: bold;
                 text-align:center;
            }
    </style>
</head>
<body>
    <div class="wrap">
        <h1 class="header"><%=paytype %>扫码</h1>
        <div class="order-info">
            <p>商户订单号：<%=order_no %></p>
            <span>请您在5分钟内完成支付，否则订单会自动取消</span>
        </div>
        <div class="amount-payable-info">
            <img src="/view/MakeQRCode.aspx?data=<%=qrcode %>" alt="" title="">
            <div>
                <em>应付金额：</em>
                <strong><%=order_amount %></strong>
            </div>
            <span>登录手机<%=paytype %>，进入“扫一扫”，瞄准二维码扫码并支付</span>
            <p>如果您是手机充值、请使用手机截屏保存二维码，</p>
            <p>打开<%=paytype %>扫一扫，从手机相册调取保存的二维码，完成支付。</p>
        </div>
    </div>
</body>
</html>


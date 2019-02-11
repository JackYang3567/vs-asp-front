<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="/Register.aspx.cs" Inherits="Game.Web.Register" %>

<%@ Register Src="Template/Head.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="Template/Notice.ascx" TagPrefix="uc1" TagName="Notice" %>
<%@ Register Src="Template/Foot.ascx" TagPrefix="uc1" TagName="Foot" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>博都棋牌-玩家注册</title>
</head>
<body>
    <uc1:Header runat="server" ID="Header" />
     <script src="/js/lhgdialog/lhgdialog.min.js"></script>
    <!-- banner start -->
    <div class="register-banner-bg">
        <img src="images/banner/register_banner.jpg" alt="" title="" class="" />
    </div>
    <!-- banner end -->
    <uc1:Notice runat="server" ID="Notice" />
    <!-- 主体内容start -->
    <form id="form1">
        <div class="register-main">
            <div class="register-list">
                <div class="register-info">
                    <div class="register-tit">
                        <span></span>
                        <strong>创建账号</strong>
                    </div>
                    <div class="register-form">
                        <label for="accountNumber" class="fl">手机号码：</label>
                        <input type="text" name="account" value="" id="account" maxlength="11" />
                    </div>
                    <div class="register-form">
                        <label for="accountNumber" class="fl">验证码：</label>
                        <input type="text" name="vcode" value="" id="vcode" maxlength="6" />
                        <a href="javascript:void(0)" class="btn-send-code" id="btnSendCode">获取验证码</a>
                    </div>
                    <div class="register-form">
                        <label for="accountNumber" class="fl">登录密码：</label>
                        <input type="password" name="pwd" value="" id="pwd" maxlength="26" />
                    </div>
                    <div class="register-form">
                        <label for="accountNumber" class="fl">确认密码：</label>
                        <input type="password" name="pwd2" value="" id="pwd2" maxlength="26" />
                    </div>
                    <div class="consent-clause">
                        <input type="hidden" id="adid" value="<%=adid %>"/>
                        <input type="hidden" id="adname" value="<%=adname %>" />
                       
                        <input type="checkbox" name="agreementInput" value="我已阅读并接受《博都游戏开户服务协议》" id="agreementCheckbox" checked="checked"/>
                        <label for="agreementCheckbox">我已阅读并接受《博都游戏开户服务协议》</label>
                    </div>
                </div>
            </div>
            <div class="register-now-btn">
                <input id="btnReg" type="button" value="" />
            </div>
        </div>
    </form>
    <!-- 主体内容end -->
    <uc1:Foot runat="server" ID="Foot" />
    <script src="/m/js/register.js" charset="utf-8" type="text/javascript"></script>
    <script>var tag = 1;</script>

</body>
</html>

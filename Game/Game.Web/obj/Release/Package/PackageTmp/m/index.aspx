<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="index.aspx.cs" Inherits="Game.Web.m.index"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width,initial-scale=1, maximum-scale=1, minimum-scale=1, user-scalable=no" />
    <meta name="format-detection" content="telphone=no, email=no" />
    <title>波士顿娱乐</title>
    <link href="newIndex.css" rel="stylesheet" />
    <script src="js/jquery-1.10.2.min.js"></script>
    <script src="/js/lhgdialog/lhgdialog.min.js"></script>
    <script src="/js/entity.js"></script>
    <script src="js/register.js?v=1112"></script>
    <script src="../js/Common.js"></script>
    <style type="text/css">
        .weixin-tip {
            display: none;
            margin: 0;
            padding: 0;
            position: fixed;
            left: 0;
            top: 0;
            bottom: 0;
            background: rgba(255,255,255,0.9);
            filter: alpha(opacity=80);
            height: 100%;
            width: 100%;
            z-index: 100;
        }

            .weixin-tip p {
                text-align: center;
                margin-top: 10%;
                padding: 0 5%;
            }

            .weixin-tip img {
                max-width: 100%;
                height: auto;
            }

        .logo, .register-btn img, .logo-list a:nth-child(1) {
            width: 100%;
        }
    </style>
</head>
<body>
    <div class="weixin-tip" id="androiddownload">
        <p>
            <img src="images/androiddownload.png" alt="在浏览器打开" />
        </p>
    </div>
    <div class="weixin-tip" id="iosdownload">
        <p>
            <img src="images/iosdownload.png" alt="在浏览器打开" />
        </p>
    </div>
    <div class="header">
        <div class="auto-96 logo-list clearfix">
            <a href="#" class="fl">
                <img src="images/logo.png" alt="" class="fl logo" />
                <div class="fl logo-name">
                </div>
            </a>
            <a href="#" class="fr register-btn"></a>
        </div>
    </div>
    <form id="form1" runat="server">
        <div class="col-100 wrap">
            <div class="header-bg">
            </div>
            <form class="" id="form" onsubmit="return false;" name="passwordSet" data-validator-option="{focusCleanup:true, theme:'simple_right'}">
                <div class="main-tit" id="registerList">
                    <img src="images/yun_register_tit.png" alt="" />
                </div>
                <div class="col-100 register-list">
                    <div class="clearfix">
                        <span class="fl">手机号码</span>
                        <input type="text" value="" class="fl" name="pwd2" id="telnum" maxlength="20" />
                    </div>
                    <%--  <div class="clearfix">
                        <span class="fl">登录账号</span>
                        <input type="text" value="" class="fl" name="account" id="account" maxlength="12" />
                    </div>--%>
                    <div class="clearfix">
                        <span class="fl">登录密码</span>
                        <input type="password" value="" class="fl" name="pwd" id="pwd" maxlength="12" />
                    </div>
                    <div class="clearfix">
                        <span class="fl">确认密码</span>
                        <input type="password" value="" class="fl" name="pwd2" id="pwd2" maxlength="20" />
                    </div>
                    <%-- <div class="clearfix">
                        <span class="fl">验&nbsp;&nbsp;证&nbsp;&nbsp;码</span>
                        <input type="text" name="vcode" id="vcode" placeholder="请输入验证码">
                        <img class="code-pic" src="/ValidateImage.aspx" style="cursor: pointer" title="点击更换验证码图片!" onclick="this.src = this.src + '?'">
                    </div>--%>

                    <div class="clearfix">
                        <span class="fl">&nbsp;</span>
                        <input id="btnSendCode1" type="button" value="获取验证码" style="width: 100px" />
                    </div>
                    <div class="clearfix">
                        <span class="fl">手机验证码</span>
                        <input type="text" value="" class="fl" name="pwd2" id="telcode" maxlength="20">
                    </div>
                    <div class="agreement clearfix">
                        <input type="checkbox" name="agreementInput" value="我已阅读并接受《波士顿娱乐开户服务协议》" id="agreementCheckbox">
                        <span class="active"></span>
                        <label for="agreementCheckbox">我已阅读并接受《波士顿娱乐开户服务协议》</label>
                    </div>
                    <div class="button-active" id="submitBtn">
                        <input id="btnReg" type="button" value="" />
                    </div>
                    <div style="margin-top: 20px; text-align: center">
                        <a href="http://web.daoen1kj.cn/">已注册玩家点击下载</a>
                    </div>
                    <div style="margin-top: 20px; text-align: center">
                        <a href="http://web.daoen1kj.cn/" style="margin-right: 40px;">备用安卓</a>
                        <a href="http://web.daoen1kj.cn/">备用苹果</a>
                    </div>
                </div>
            </form>
            <div class="game-list">
                <div class="main-tit">
                    <img src="images/yun_game_tit.png" alt="" />
                </div>
                <div class="game-list-item clearfix">
                    <a href="javascript:void(0)" class="game-list-style">
                        <img src="images/yun_game_01.png" alt="" />
                    </a>
                    <a href="javascript:void(0)" class="game-list-style">
                        <img src="images/yun_game_02.png" alt="" />
                    </a>
                    <a href="javascript:void(0)" class="game-list-style">
                        <img src="images/yun_game_03.png" alt="" />
                    </a>
                </div>
                <a href="javascript:void(0)" class="game-list-img"></a>
            </div>
            <div class="agent-list">
                <div class="main-tit">
                    <img src="images/yun_agent_tit.png" alt="" />
                </div>
                <div>
                    <a href="javascript:void(0)" class="agent-list-img">
                        <img src="images/yun_agent_img.png" alt="" />
                    </a>
                </div>
            </div>
        </div>

        <script>download();</script>

        <%--先注册后下载的弹窗--%>
        <div class="alert-info" id="alertInfo">
            <p>温馨提示：为您更便捷体验游戏乐趣</p>
            <h1>请先注册，后下载游戏</h1>
            <a href="javascript:;" id="closeBtn">
                <img src="images/alert_btn_info.png" /></a>
        </div>
        <div class="window-mask"></div>
        <script>
          
            $(".agreement").on("click", function () {
                checkboxclick(this);
            })
            //checkbox的点击事件绑定
            var checkboxclick = function (obj) {
                if ($(obj).children("input").is(":checked")) {
                    $(obj).children("span").addClass("active");
                } else {
                    $(obj).children("span").removeClass("active");
                }
            }

            $("#closeBtn").on("click", function () {
                $("#alertInfo").hide("show");
                $(".window-mask").hide("show");
            })
            var isShouci = false;
            $(function () {
                var android_url = Download.androUrl;
                var ios_url = Download.iosUrl;
                $('.download').click(function () {
                    var host = location.host
                    if (host.indexOf('www.') > -1 || host.indexOf('jc.') > -1 || host.split('.').length == 2) {

                    }
                    else if (!isShouci && !isReg) {
                        $("#alertInfo").show("show");
                        $(".window-mask").show("show");
                        isShouci = true;
                        return;
                    }
                    var ua = navigator.userAgent;
                    if (!!ua.match(/\(i[^;]+;( U;)? CPU.+Mac OS X/)) {
                        location.href = ios_url;
                    } else {
                        location.href = android_url
                    }
                })
            })
        </script>
        <script>
            $(function () {
                var isSend1 = false, sss = 30;
                $('#btnSendCode1').click(function () {
                    if (isSend1) return;
                    var telnum = $('#telnum').val();
                    if (telnum == "") {
                        $.dialog.alert('请输入手机号！', function () {
                            $("#telnum").focus();
                        });
                        return;
                    }
                    if (!(/^1[3|4|5|7|8][0-9]{9}$/.test(telnum))) {
                        $.dialog.alert('手机号格式不正确！', function () {
                            $("#telnum").focus();
                        });
                        return;
                    }
                    isSend1 = true;
                    $.post("/WS/Account.ashx?action=SendCode", { phone: telnum }, function (data) {
                        if (data && data.code == 0) {
                            $.dialog({
                                icon: 'success.gif', content: "发送成功", close: function () {
                                    my_interval = setInterval(function () {
                                        if (sss > 0) {
                                            $('#btnSendCode1').val("发送中" + sss + "s");
                                            sss--;
                                        } else {
                                            clearInterval(my_interval);
                                            isSend1 = false;
                                            $('#btnSendCode1').val("获取验证码");
                                        }
                                    }, 1000);
                                }
                            });
                        }
                        else {
                            isSend1 = false;
                            $.dialog.alert(data.msg)
                        }
                    })

                })
            });
        </script>
        <script>
            var ua1 = window.navigator.userAgent.toLowerCase();
            if (ua1.match(/MicroMessenger/i) == "micromessenger" || ua1.match(/WeiBo/i) == "weibo") {

                //iphone-微信 iphone-微博 iphone-qq
                var winHeight = $(window).height();
                if (ua1.indexOf('android') > -1 || ua1.indexOf('adr') > -1) {
                    $("#androiddownload").css("height", winHeight);
                    $("#androiddownload").show();
                }
                else if (/(iPhone|iPad|iPod|iOS)/i.test(navigator.userAgent)) {

                    $("#iosdownload").css("height", winHeight);
                    $("#iosdownload").show();
                }
            }
        </script>
    </form>
</body>
</html>
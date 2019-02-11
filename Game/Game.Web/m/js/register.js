var isReg = false;
$(function () {
    var isChuli = false;

    $('#btnReg').click(function () {
        if (isChuli) return;
        var account = $('#telnum').val();
        var pwd = $('#pwd').val();
        var vcode = $('#vcode').val();
        var telnum = $('#telnum').val();
        var telcode = $('#telcode').val();
        var beeline = "0";
        beeline = GetQueryString("beeline");
        if (account == "") {
            $.dialog.alert('请输入账号！', function () {
                $("#account").focus();
            });
            return;
        }
        //if (account.length < 6 || account.length > 12) {
        //    $.dialog.alert('账号长度为6-12位！', function () {
        //        $("#account").focus();
        //    });
        //}

        //if (!(/^1[3|4|5|7|8][0-9]{9}$/.test(account))) {
        //    $.dialog.alert('手机号格式不正确！', function () {
        //        $("#account").focus();
        //    });
        //    return;
        //}

        if (pwd == "") {
            $.dialog.alert('请输入登录密码！', function () {
                $("#pwd").focus();
            });
            return;
        }
        if (pwd.length < 6 || pwd.length > 26) {
            $.dialog.alert('登录密码长度为6-26位！', function () {
                $("#pwd").focus();
            });
            return;
        }
        var pwd2 = $('#pwd2').val();
        if (pwd2 == "") {
            $.dialog.alert('请输入确认密码！', function () {
                $("#pwd2").focus();
            });
            return;
        }
        if (pwd2 != pwd) {
            $.dialog.alert('两次密码输入不一致！', function () {
                $("#pwd2").focus();
            });
            return;
        }

        if (account == pwd) {
            $.dialog.alert('密码不能与帐号相同，请重新输入！', function () {
                $("#pwd").focus();
            });
            return;
        }

        //if (vcode == "") {
        //    $.dialog.alert('请输入验证码！', function () {
        //        $("#vcode").focus();
        //    });
        //    return;
        //}
        //if (vcode.length < 4) {
        //    $.dialog.alert('验证码错误！', function () {
        //        $("#vcode").focus();
        //    });
        //    return;
        //}

        if (telnum == "") {
            $.dialog.alert('请输入手机号码！', function () {
                $("#telnum").focus();
            });
            return;
        }
        if (telcode == "") {
            $.dialog.alert('请输入手机验证码！', function () {
                $("#telcode").focus();
            });
            return;
        }
        var adid = $('#adid').val();

        var adname = $('#adname').val();
        var postData = { account: account, pwd: pwd, adid: adid, adname: adname, telnum: telnum, telcode: telcode, beeline: beeline };
        $.ajaxSetup({
            async: false
        });
        isChuli = true;
        $.post("/WS/Account.ashx?action=RegUser", postData, function (data) {
            if (data.code == 0) {
                isReg = true;
                setCookie("name", account);
                $.dialog({
                    icon: 'success.gif', content: "注册成功", close: function () {
                        $('#account').val("");
                        $('#pwd').val("")
                        $('#pwd2').val("");
                        $('#vcode').val("");
                        location.reload();
                    }
                });

                
            }
            else {
                if (data.code == 2)
                    $('#code').attr("src", "/ValidateImage.aspx?" + Math.random())
                $.dialog.alert(data.msg)
            }
            isChuli = false;
        })
    })

    var isSend = false, ss = 30;
    $('#btnSendCode').click(function () {
        if (isSend) return;
        var account = $('#account').val();
        if (account == "") {
            $.dialog.alert('请输入账号！', function () {
                $("#account").focus();
            });
            return;
        }
        if (!(/^1[3|4|5|7|8|9][0-9]{9}$/.test(account))) {
            $.dialog.alert('手机号格式不正确！', function () {
                $("#account").focus();
            });
            return;
        }
        isSend = true;
        $.post("/WS/Account.ashx?action=SendCode", { phone: account }, function (data) {
            if (data.code == 0) {
                $.dialog({
                    icon: 'success.gif', content: "发送成功", close: function () {
                        my_interval = setInterval(function () {
                            if (ss > 0) {
                                $('#btnSendCode').text("发送中" + ss + "s");
                                ss--;
                            } else {
                                clearInterval(my_interval);
                                isSend = false;
                                $('#btnSendCode').text("获取验证码");
                            }
                        }, 1000);
                    }
                });
            }
            else {
                isSend = false;
                $.dialog.alert(data.msg)
            }
        })
    })
    $('#vcode').blur(function () {
        if ($(this).val().length == 6) {
            clearInterval(my_interval);
            isSend = false;
            $('#btnSendCode').text("获取验证码");
            ss = 0;
        }
    })
})
function download() {
    if (getCookie("name") != null) {
        document.writeln("       <div class=\'position-fixed btn-items clearfix\'>");
        document.writeln("            <a href=\'http://xmvip.vip/Esm2Z4\' id=\'ios_url\' class=\'fl ios-btn download\'>");
        document.writeln("                <img src=\'images/yun_apple_btn.png\' alt=\'苹果下载\' />");
        document.writeln("            </a>");
        document.writeln("            <a href=\'http://xmvip.vip/ZAeLo2\' id=\'android_url\' class=\'fl android-btn download\'>");
        document.writeln("                <img src=\'images/yun_android_btn.png\' alt=\'安卓下载\' />");
        document.writeln("            </a>");
        document.writeln("        </div>");
    }
}
function setCookie(name, value) {
    var Days = 30;
    var exp = new Date();
    exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
    document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString();
}
function getCookie(name) {
    var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
    if (arr = document.cookie.match(reg)) {
        return unescape(arr[2]);
    }
    else {
        return null;
    }
}
/**
 * Created by ouye-61 on 2017/5/19.
 */
var tag = 3;
// 子导航栏tab
$(function () {
    // 子导航栏tab
    tabShow($(".game-details-sidebar li"), $(".details-list"), "active");

    var xuanz = 1
    $(".fs-top").find('a').click(function () {
        xuanz = $(this).index();
        $(".fs-top a").removeClass('acur').eq(xuanz - 1).addClass('acur');
        if (xuanz == 1) {
            $('#type').val("alipay");
        }
        if (xuanz == 2) {
            $('#type').val("weixin");
        }
        if (xuanz == 3) {
            $('#type').val("ABC-NET");
            if ($(".banks_box").css("display") == "none") {
                $(".banks_box").show();
            } else {
                $(".banks_box").hide();
            };
        } else
        {
            $(".banks_box").hide();
        }
    });
   

    var payRate = 1;
    $('#spanPayRate').html(payRate);
    $('.xinbi').html(10 * payRate + "金币");
    $(".jiner").keyup(function () {
        var jiner = $(".jiner").val();
        $(".yinghu").html(jiner + "元");
        $(".xinbi").html(jiner * payRate + "金币")
    });
    $(".payn a").click(function () {

        var c = $(this).index();
        if (c == 0) {
            $(".jiner").val("20");
            $(".yinghu").html("20元");
            $(".xinbi").html(20 * payRate + "金币");
        }
        if (c == 1) {
            $(".jiner").val("30");
            $(".yinghu").html("30元");
            $(".xinbi").html(30 * payRate + "金币")
        }
        if (c == 2) {
            $(".jiner").val("50");
            $(".yinghu").html("50元");
            $(".xinbi").html(50 * payRate + "金币")
        }
        if (c == 3) {
            $(".jiner").val("100");
            $(".yinghu").html("100元");
            $(".xinbi").html(100 * payRate + "金币")
        }
        if (c == 4) {
            $(".jiner").val("500");
            $(".yinghu").html("500元");
            $(".xinbi").html(500 * payRate + "金币")
        }
        if (c == 5) {
            $(".jiner").val("1000");
            $(".yinghu").html("1000元");
            $(".xinbi").html(1000 * payRate + "金币")
        }
    });

    $('#btnRecharge').click(function () {
        var uName = $('#txtAccount').val();
        var money = $('#txtMoney').val();
        if (uName == "") {
            alert("请输入充值账号");
            $('#txtAccount').focus();
            return false;
        }
        if (money == "") {
            alert("请输入充值金额");
            $('#txtMoney').focus();
            return false;
        }
        var reg = new RegExp("^[0-9]*[1-9][0-9]*$");
        if (!reg.test(money)) {
            alert("充值金额应为正整数");
            $('#txtMoney').focus();
            return false;
        }
        $.ajaxSetup({ async: false });
        var res = 0;
        $.get("/ashx/CheckAccount.ashx", { account: uName, r: Math.random() }, function (data) {
            res = data;
        })
        if (res > 0) {
            $('#uid').val(res);
            return true;
        } else {
            alert("充值账号不存在");
            return false;
        }
    })




    $(".banks a").click(function () {
        var b = $(this).index();
        $(".banks a").children("span").removeClass('bcur');
        $(".banks a").children("span").eq(b).addClass("bcur");
        var bankCode = $(this).attr("data-bank");
        $('#type').val(bankCode);
    });
    $(".czk").click(function () {
        $(".czk").hide();
        $(".csq").show();
        $(".c11").show();
        $(".c4").show();
        $(".c8").show();
        $(".c15").show();
        $(".c16").show();
    });
    $(".csq").click(function () {
        $(".czk").show();
        $(".csq").hide();
        $(".c11").hide();
        $(".c4").hide();
        $(".c8").hide();
        $(".c15").hide();
        $(".c16").hide();
    });

});
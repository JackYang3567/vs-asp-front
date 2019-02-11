<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BindingsList.aspx.cs" Inherits="Game.Web.Mobile.BindingsList" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width,initial-scale=1, maximum-scale=1, minimum-scale=1, user-scalable=no"/>
    <meta name="format-detection" content="telphone=no, email=no" />
    <title>绑定-银行</title>
    <link rel="stylesheet" href="Css/market.css" />
    <script src="../js/jquery.min.js" charset="utf-8" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
     <div class="bindings-list">
        <div class="bank-info clearfix">
            <div class="fl bank-logo">
                <img src="Image/bank_logo.png" alt="Alternate Text" />
            </div>
            <p class="fl"></p> 
            <div class="fl name-card">
                <div>
                    <span>真实姓名：</span>
                    <input type="text" id="uname" value=" " />
                </div>
                <div>
                    <span>银行卡账号：</span>
                    <input type="text" id="card" value=" " />
                </div>
                <div>
                    <span>开户行地址：</span>
                    <input type="text" id="bankAddress" value=" " />
                </div>
            </div>                  
        </div>
        <div class="bank-list clearfix">
            <a href="javascript:void(0)" class="active" data="光大银行">
                <img src="Image/guangda.png" alt="光大银行" />
                <span></span>
            </a>
            <a href="javascript:void(0)" data="浦发银行">
                <img src="Image/pudong.png" alt="浦发银行" />
                <span></span>
            </a>
            <a href="javascript:void(0)" data="中国邮政">
                <img src="Image/youzheng.png" alt="中国邮政" />
                <span></span>
            </a>
            <a href="javascript:void(0)" data="交通银行">
                <img src="Image/jiaotong.png" alt="交通银行" />
                <span></span>
            </a>
            <a href="javascript:void(0)" data="建设银行">
                <img src="Image/jianhang.png" alt="建设银行" />
                <span></span>
            </a>
            <a href="javascript:void(0)" data="民生银行">
                <img src="Image/minsheng.png" alt="民生银行" />
                <span></span>
            </a>
            <a href="javascript:void(0)" data="招商银行">
                <img src="Image/zhaohang.png" alt="招商银行" />
                <span></span>
            </a>
            <a href="javascript:void(0)" data="农业银行">
                <img src="Image/nonghang.png" alt="农业银行" />
                <span></span>
            </a>
            <a href="javascript:void(0)" data="中国银行">
                <img src="Image/zhonghang.png" alt="中国银行" />
                <span></span>
            </a>
            <a href="javascript:void(0)" data="工商银行">
                <img src="Image/gonghang.png" alt="工商银行" />
                <span></span>
            </a>                                                                                                           
        </div>
        <p class="binding-prompt">提示：请输入正确的银行卡信息、开户姓名和所属银行信息，兑换时将直接转入此银行卡号，为了能顺利到账，请仔细确认，绑定后不可修改。</p>
        <a href="javascript:void(0)" class="binding-btn" id="btn">
            <img src="Image/btn_binding.png" alt="Alternate Text" />
        </a>
    </div>
    <script>
        $(".bank-list a").on("click", function () {
            $(this).addClass("active").siblings().removeClass("active");
        });
        $("#btn").on("click", function () {
            var bankName = $(".active").attr("data");
            if (bankName == "")
            {
                alert("请选择你要绑定卡的银行");
                return false;
            }
            var uname = $("#uname").val().trim();
            if (uname == "")
            {
                alert("请输入真实姓名");
                return false;
            }
            var card = $("#card").val().trim();
            if (card == "") {
                alert("请输入银行卡账号");
                return false;
            }
            if (isNaN(card)) {
                alert("银行卡账号只能是数字");
                return false;
            }
            if (card.length < 16) {
                alert("银行卡账号位数有误");
                return false;
            }
            var bankAddress = $('#bankAddress').val();
            if (bankAddress == "")
            {
                alert("请输入开户行地址");
            }
            $.post("/ashx/Mobile.ashx", { action: "PLayerBindBank",userid: parseInt('<%=uID%>'), uname: uname, card: card, bankName: bankName,bankAddress:bankAddress, r: Math.random() }, function (data) {
                var result = eval("(" + data + ")");
                alert(result.msg);
            })
        });
    </script>
    </form>
</body>
</html>

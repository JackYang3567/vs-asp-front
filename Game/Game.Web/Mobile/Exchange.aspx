<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Exchange.aspx.cs" Inherits="Game.Web.Mobile.Exchange" %>

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width,initial-scale=1, maximum-scale=1, minimum-scale=1, user-scalable=no" />
    <meta name="format-detection" content="telphone=no, email=no" />
    <title>兑换</title>
    <link rel="stylesheet" href="Css/market.css" />
    <script src="../js/jquery.min.js" charset="utf-8" type="text/javascript"></script>
    <style>
        .exchange-main {
            overflow: hidden;
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="exchange-main">
            <%if (isBind == 0)
              { %>
            <div class="nobing">
                <h1 style="font-size:.7rem">请先绑定银行卡</h1>
                <h3 style="font-size:.3rem;margin-top:10px;">请点击 <font color="yellow">大厅头像>兑换绑定>绑定</font>按钮绑定您的银行卡信息</h3>
            </div>
            <%}
              else
              { %>
            <div class="exchange-list">
                <div>
                    <span>银行金币：</span>
                    <strong><%=insure %></strong>
                </div>
                <div>
                    <span>银行卡号：</span>
                    <strong><%=account %></strong>
                </div>
                <div>
                    <span>真实姓名：</span>
                    <strong><%=name %></strong>
                </div>
            </div>
            <div class="exchange-btn clearfix">
                <input type="text" runat="server" id="dwScore" name="name" placeholder="请输入兑换金币" class="fl" />
                <a href="#" class="fl" id="btn">
                    <img src="Image/btn_exchange.png" alt="" />
                </a>
            </div>
            <div class="exchange-prompt">
                <p>*<%=BalancePrice %>金币=1RMB；</p>
                <p>*最小兑换额度<%=MinBalance %>金币；</p>
                <p>*兑换3~5分钟内到账；</p>
                <p>*兑换手续费标准：100万金币以下手续费<%=MinCounterFee %>万金币；100万以上手续费为兑换金币的<%=CounterFee %>%。</p>
            </div>
            <%} %>
        </div>
        <script>
            $("#btn").on("click", function () {

                var score = $("#dwScore").val().trim();
                if (score == "") {
                    alert("请输入兑换金币");
                    return false;
                }
                if (/^\d+(\.\d{1,2})?$/.test(score)) {
                    $.post("/ashx/Mobile.ashx", { action: "PlayerDraw", userid: parseInt('<%=UId%>'), score: score, r: Math.random() }, function (data) {
                        var result = eval("(" + data + ")");
                        if (result.error == 0) {
                            alert(result.msg);
                        } else {
                            alert(result.msg);
                        }
                        return false;
                    })
                } else {
                    alert("兑换金币的格式有误");
                    return false;
                }
            });
        </script>
    </form>
</body>
</html>

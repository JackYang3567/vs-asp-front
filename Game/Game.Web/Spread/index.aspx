<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Game.Web.Spread.index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>推广查询
    </title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1, minimum-scale=1, user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <link rel="stylesheet" href="css/base.css" />
    <link rel="stylesheet" href="css/sm.css" />
    <link rel="stylesheet" href="css/style.css" />
    <script type='text/javascript' src="js/flexible.js" charset='utf-8'></script>
    <script src="../js/jquery-1.8.3.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-group">
            <div class="page page-current p-v-index">
                <div class="content native-scroll">
                    <div class="row no-gutter indexbg">
                        <div class="col-100 no-gutter i-title">
                            <span>推广查询</span>
                        </div>
                        <div class="col-50 search-text">
                            <input type="text" id="txtSeach" placeholder="请输入推广码" pattern="[0-9]*">
                        </div>
                        <div class="col-50 search-btn">
                            <input type="button" id="btnSearch" value="查询">
                        </div>
                    </div>
                    <div class="row no-gutter">
                        <ul class="admin-info clearfix">
                            <li><a href="javascript:">今日注册：</a></li>
                            <li><a href="javascript:" id="TdNum"></a></li>
                            <li><a href="javascript:">本月注册：</a></li>
                            <li><a href="javascript:" id="TmNum"></a></li>
                            <li><a href="javascript:">上月注册：</a></li>
                            <li><a href="javascript:" id="LmNum"></a></li>
                            <li><a href="javascript:">总注册：</a></li>
                            <li><a href="javascript:" id="AllNum"></a></li>
                        </ul>
                    </div>
                    <%--<div class="row no-gutter tui-text">
                        <div class="col-25" style="line-height: .8rem">推广链接：</div>
                        <div class="col-75">
                            <input type="text" class="tuilink" value="" />
                        </div>
                    </div>
                    <div class="row no-gutter tuibtn">
                        <div class="col-100">
                            <button data-clipboard-text=""></button>
                        </div>
                    </div>--%>
                    <div class="row no-gutter bottom-img">
                        <div class="col-100">
                            <img src="css/img/bottom.png" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="js/clipboard.min.js"></script>
    <script>
        $(function () {
            $('#btnSearch').click(function () {
                var id = $('#txtSeach').val();
                if (id == "") {
                    alert("请输入推广码");
                    $('#txtSeach').focus();
                    return;
                }
                if (!/^[0-9]*$/.test(id)) {
                    alert("推广码只能为数字");
                    $('#txtSeach').focus();
                    return;
                }
                $.post("/WS/Promoter.aspx", { action: "MySpreadCheck", id: id }, function (data) {
                    var json = $.parseJSON(data);
                    if (json.code == 0) {
                        $("#TdNum").html(json.data[0].TdNum)
                        $("#TmNum").html(json.data[0].TmNum)
                        $("#LmNum").html(json.data[0].LmNum)
                        $("#AllNum").html(json.data[0].AllNum)
                        //var host = window.location.host.split('.');
                        //if (host.length > 2) {
                        //    host = host[1] + "." + host[2];
                        //} else
                        //{
                        //    host = host[0] + "." + host[1];
                        //}
                        //var tuilink = "http://" + id + "." + host;
                        //$(".tuilink").val(tuilink);
                        //$("button").attr("data-clipboard-text", tuilink);
                    } else {
                        alert(json.msg);
                    }
                })
            })
        })
        //var btn = document.querySelectorAll('button');
        //var clipboard = new Clipboard(btn);

        //clipboard.on('success', function (e) {
        //    alert("已成功复制到剪切板！");
        //});

        //clipboard.on('error', function (e) {
        //    alert('浏览器不支持复制功能，请手动复制！');
        //});

       
    </script>
</body>
</html>

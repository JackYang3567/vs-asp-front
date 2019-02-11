<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MarketCount.aspx.cs" Inherits="Game.Web.Mobile.MarketCount" %>

<!DOCTYPE html>

<html class="market-html">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1, maximum-scale=1, minimum-scale=1, user-scalable=no">
    <meta name="format-detection" content="telphone=no, email=no" />
    <title>推广统计</title>
    <link rel="stylesheet" href="Css/market.css" />
    <script src="../js/jquery.min.js" charset="utf-8" type="text/javascript"></script>
    <script src="../js/lhgdialog/lhgdialog.min.js"></script>
</head>
<body>
    <div class="warp">
        <div class="main clearfix">
            <div class="market-info clearfix">
                <div class="fl market-admin-tit" id="marketCountRidio">
                    <span class="active" onclick="tabChange(this,0)">今日累计</span>
                    <span onclick="tabChange(this,1)">昨日累计</span>
                    <span onclick="tabChange(this,2)">本周累计</span>
                    <span onclick="tabChange(this,3)">上周统计</span>
                </div>
                <div class="fl market-admin-list">
                    <table>
                        <thead>
                            <tr>
                                <th><span>下线等级</span></th>
                                <th><span>抽水贡献</span></th>
                                <th><span>抽水比例</span></th>
                                <th><span>获得抽水</span></th>
                            </tr>
                        </thead>
                        <tbody id="market-list">
                                                  
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="count-settlement clearfix">
                <div>
                    <span>总抽水：</span>
                    <span><%=tjthree %></span>
                </div>
                <div>
                    <span>已提取：</span>
                    <span><%=tjfourth %></span>
                </div>
                <div>
                    <span>待提取：</span>
                    <span><%=tjfive %></span>
                </div>
            </div>
            <div class="count-settlement clearfix">
                <div>
                    <span>总下线：</span>
                    <span><%=total %></span>
                </div>
                <div>
                    <span>直接下线：</span>
                    <span><%=zhijie %></span>
                </div>
                <div>
                    <span>间接下线：</span>
                    <span><%=jianjie %></span>
                </div>
            </div>
            <div class="market-tiqu clearfix">
                <span>提取金额</span>
                <input type="number" id="glod" />
                <input type="button" id="btn_tiqu" />
            </div>       
        </div>
        
    </div>
    <script src="Js/MarketCount.js"></script>
</body>
</html>

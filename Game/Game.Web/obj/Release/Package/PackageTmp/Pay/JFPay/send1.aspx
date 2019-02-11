<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="send.aspx.cs" Inherits="Game.Web.Pay.JFPay.send" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>提交</title>
</head>
<body onload="document.getElementById('form1').submit();">
    <form id="form1" runat="server" style="display: none">
        <input type="text" name="p1_usercode" value='<%= requestBean.p1_usercode %>' />
        <input type="text" name="p2_order" value='<%= requestBean.p2_order %>' />
        <input type="text" name="p3_money" value='<%= requestBean.p3_money %>' />
        <input type="text" name="p4_returnurl" value='<%= requestBean.p4_returnurl %>' />
        <input type="text" name="p5_notifyurl" value='<%= requestBean.p5_notifyurl %>' />
        <input type="text" name="p6_ordertime" value='<%= requestBean.p6_ordertime %>' />
        <input type="text" name="p7_sign" value='<%= requestBean.p7_sign %>' />
        <input type="text" name="p8_signtype" value='<%= requestBean.p8_signtype %>' />
        <input type="text" name="p9_paymethod" value='<%= (int)requestBean.p9_paymethod %>' />
        <input type="text" name="p10_paychannelnum" value='<%= requestBean.p10_paychannelnum %>' />
         <input type="text" name="p18_product" value='<%= requestBean.p18_product %>' />
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="return_url.aspx.cs" Inherits="Game.Web.Pay.thwxpay.return_url" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div style="text-align: center; padding-top: 20px;">
        <h1>支付结果</h1>
    </div>
    <div style="text-align: center; font-size: 20px; color: red;">
        <strong><asp:Label ID="label_result" runat="server" /></strong>
    </div>
    <div>
        <table align="center" cellpadding="2" style="margin-top: 5px;">
            <tr>
                <td>
                    订单号：
                </td>
                <td>
                    <asp:Label ID="label_order_no" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    订单金额：
                </td>
                <td>
                    <asp:Label ID="label_order_amount" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    订单时间：
                </td>
                <td>
                    <asp:Label ID="label_order_time" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="send.aspx.cs" Inherits="Game.Web.Pay.JFPay.send" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
        function Post() {
            document.getElementById("form1").submit();
        }
    </script>

</head>
<body>
    <form id="form1" runat="server" method="post" action="http://order.z.jtpay.com/jh-web-order/order/receiveOrder">
        <asp:HiddenField ID="p1_yingyongnum" runat="server" />
        <asp:HiddenField ID="p2_ordernumber" runat="server" />
        <asp:HiddenField ID="p3_money" runat="server" />
        <asp:HiddenField ID="p6_ordertime" runat="server" />
        <asp:HiddenField ID="p7_productcode" runat="server" />
        <asp:HiddenField ID="p8_sign" runat="server" />
        <asp:HiddenField ID="p9_signtype" runat="server" />
        <asp:HiddenField ID="p10_bank_card_code" runat="server" />
        <asp:HiddenField ID="p11_cardtype" runat="server" />
        <asp:HiddenField ID="p12_channel" runat="server" />
        <asp:HiddenField ID="p13_orderfailertime" runat="server" />
        <asp:HiddenField ID="p14_customname" runat="server" />
        <asp:HiddenField ID="p15_customcontact" runat="server" />
        <asp:HiddenField ID="p16_customip" runat="server" />
        <asp:HiddenField ID="p17_product" runat="server" />
        <asp:HiddenField ID="p18_productcat" runat="server" />
        <asp:HiddenField ID="p19_productnum" runat="server" />
        <asp:HiddenField ID="p20_pdesc" runat="server" />
        <asp:HiddenField ID="p21_version" runat="server" />
        <asp:HiddenField ID="p22_sdkversion" runat="server" />
        <asp:HiddenField ID="p23_charset" runat="server" />
        <asp:HiddenField ID="p24_remark" runat="server" />
        <asp:HiddenField ID="p25_terminal" runat="server" />
        <asp:HiddenField ID="p26_ext1" runat="server" />
        <asp:HiddenField ID="p27_ext2" runat="server" />
        <asp:HiddenField ID="p28_ext3" runat="server" />
        <asp:HiddenField ID="p29_ext4" runat="server" />
        <asp:HiddenField ID="Card_Number" runat="server" />
        <asp:HiddenField ID="Card_Password" runat="server" />
    </form>
</body>
</html>

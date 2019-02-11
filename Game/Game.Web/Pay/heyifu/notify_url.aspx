<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notify_url.aspx.cs" Inherits="Game.Web.Pay.heyifu.notify_url" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>支付结果</title>
	<!--
	<link rel="stylesheet" type="text/css" href="styles.css">
	<link href="Styles/mobaopay.css" type="text/css" rel="stylesheet" />
	-->
</head>
<body runat="server">
    <table width="50%" border="0" align="center" cellpadding="0" cellspacing="0" style="border: solid 1px #107929">
        <tr>
            <td>
                <table width="100%" border="0" align="center" cellpadding="5" cellspacing="1">

                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td align="left" width="30%">
                                        &nbsp;&nbsp;充值金额
                                    </td>
                                    <td align="left">
                                        &nbsp;&nbsp;<input size="50" type="text" name="tradeAmt" id="tradeAmt" value="<%=tradeAmt%>" />
                                    </td>
                                </tr>
								<tr>
									<td align="left" width="30%">
										&nbsp;&nbsp;订单号
									</td>
									<td align="left">
										&nbsp;&nbsp;<input size="50" type="text" name="orderNo" id="orderNo" value="<%=orderNo%>" />
									</td>
								</tr>
								<tr>
									<td align="left" width="30%">
										&nbsp;&nbsp;充值日期
									</td>
									<td align="left">
										&nbsp;&nbsp;<input size="50" type="text" name="tradeDate" id="tradeDate" value="<%=tradeDate%>" />
									</td>
								</tr>
								<tr>
									<td align="left" width="30%">
										&nbsp;&nbsp;支付系统订单号
									</td>
									<td align="left">
										&nbsp;&nbsp;<input size="50" type="text" name="accNo" id="accNo" value="<%=accNo%>" />
									</td>
								</tr>
								<tr>
									<td align="left" width="30%">
										&nbsp;&nbsp;充值结果
									</td>
									<td align="left">
										&nbsp;&nbsp;<input size="50" type="text" name="orderStatus" id="orderStatus" value="<%=orderStatus%>" />
									</td>
								</tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="5" bgcolor="#6BBE18" colspan="2">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>
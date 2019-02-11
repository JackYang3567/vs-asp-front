<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdsNotice.aspx.cs" Inherits="Game.Web.Mobile.AdsNotice" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1, maximum-scale=1, minimum-scale=1, user-scalable=no">
    <meta name="format-detection" content="telphone=no, email=no" />
	<title>公告</title>
    <style type="text/css">
        html{color:#fff;background-color:#0b0b0b;font-family:Arial,'Microsoft YaHei','宋体';}
		body,div,dl,dt,dd,ul,ol,li,h1,h2,h3,h4,h5,h6,pre,code,form,fieldset,legend,input,button,textarea,p,blockquote,th,td,strong{padding:0;margin:0;font-family:'Microsoft YaHei',Arial,'宋体';}
        div,
		html,
		body {
			width: 100%;
		}
		div {height: 100%;}
		img {
			display: block;
			width: 100%;
			height: auto;
		}
    </style>
</head>
<body>
    <div>
        <asp:Literal ID="ltlNotice" runat="server"></asp:Literal>
        <%--<img src="<%= Game.Facade.Fetch.GetUploadFileUrl("/Site/AdsMobileAlert.png")%>" style="width:100%;height:100%;display:block;" />--%>
    </div>
</body>
</html>

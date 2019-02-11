<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tiaozhuan.aspx.cs" Inherits="Game.Web.tiaozhuan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
     <script src="/js/entity.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <script type="text/javascript">
                var ua = navigator.userAgent;
                var android_url = Download.androUrl;
                var ios_url = Download.iosUrl;
                if (!!ua.match(/\(i[^;]+;( U;)? CPU.+Mac OS X/)) {
                    location.href = ios_url;
                } else {
                    location.href = android_url;
                }
            </script>
        </div>
    </form>
</body>
</html>

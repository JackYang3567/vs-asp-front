<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="/Template/Head.ascx.cs" Inherits="Game.Web.Head" %>
 <link rel="stylesheet" href="/css/leading_center.css">
    <link rel="stylesheet" href="/css/common.css">
    <script src="/public/jquery-1.8.3.min.js" charset="utf-8" type="text/javascript"></script>
<!-- 导航栏start -->
<div class="col-100 nav">
    <div class="min-widths nav-list clearfix">
        <img src="images/nav_pic.png" alt="" title="" class="fl">
        <div class="fl nav-info clearfix">
            <a href="index.aspx" title="">
                <strong>网站首页</strong>
                <em>HOME</em>
                <span></span>
            </a>
            <a href="register.aspx" title="">
                <strong>玩家注册</strong>
                <em>REGISTERED</em>
                <span></span>
            </a>
            <a href="gameDownloads.aspx" title="">
                <strong>游戏下载</strong>
                <em>DOWNLOAD</em>
                <span></span>
            </a>
            <a href="pay.aspx" title="">
                <strong>在线充值</strong>
                <em>Recharge</em>
                <span></span>
            </a>
            <a href="Activity.aspx" title="">
                <strong>活动专区</strong>
                <em>ACTIVITY</em>
                <span></span>
            </a>
            <a href="Business.aspx" title="">
                <strong>合作加盟</strong>
                <em>Join US</em>
                <span></span>
            </a>
            <a href="Service.aspx" title="">
                <strong>客服中心</strong>
                <em>SERVICE</em>
                <span></span>
            </a>
        </div>
    </div>
    <!-- 主导航栏end -->
</div>
<!-- 导航栏end -->
 <script type="text/javascript">
     var browser = {
         versions: function () {
             var u = navigator.userAgent, app = navigator.appVersion;
             return {//移动终端浏览器版本信息
                 trident: u.indexOf('Trident') > -1, //IE内核
                 presto: u.indexOf('Presto') > -1, //opera内核
                 webKit: u.indexOf('AppleWebKit') > -1, //苹果、谷歌内核
                 gecko: u.indexOf('Gecko') > -1 && u.indexOf('KHTML') == -1, //火狐内核
                 mobile: !!u.match(/AppleWebKit.*Mobile/i) || !!u.match(/MIDP|SymbianOS|NOKIA|SAMSUNG|LG|NEC|TCL|Alcatel|BIRD|DBTEL|Dopod|PHILIPS|HAIER|LENOVO|MOT-|Nokia|SonyEricsson|SIE-|Amoi|ZTE/), //是否为移动终端
                 ios: !!u.match(/\(i[^;]+;( U;)? CPU.+Mac OS X/), //ios终端
                 android: u.indexOf('Android') > -1 || u.indexOf('Linux') > -1, //android终端或者uc浏览器
                 iPhone: u.indexOf('iPhone') > -1 || u.indexOf('Mac') > -1, //是否为iPhone或者QQHD浏览器
                 iPad: u.indexOf('iPad') > -1, //是否iPad
                 webApp: u.indexOf('Safari') == -1 //是否web应该程序，没有头部与底部
             };
         }(),
         language: (navigator.browserLanguage || navigator.language).toLowerCase()
     }
     if (browser.versions.iPhone || browser.versions.iPad || browser.versions.ios || browser.versions.android) {
         location.href = "m/";
     }

        </script>
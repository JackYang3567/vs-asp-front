<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="/index.aspx.cs" Inherits="Game.Web.index" %>

<%@ Register Src="Template/Head.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="Template/Notice.ascx" TagPrefix="uc1" TagName="Notice" %>
<%@ Register Src="Template/Foot.ascx" TagPrefix="uc1" TagName="Foot" %>
<!doctype html>
<html>
<head>
    <meta charset="UTF-8">
    <title>云顶棋牌-首页</title>
</head>
<body>
    <div class="wrap">
        <uc1:Header runat="server" ID="Header" />
       

        <script src="/public/jslides.js" charset="utf-8" type="text/javascript"></script>
        <script src="/public/jMarquee.js" charset="utf-8" type="text/javascript"></script>
        <!-- banner start -->
        <div id="full-screen-slider clearfix">
            <ul id="slides">
                <li>
                    <img src="images/banner/banner01.jpg">
                </li>
                <li>
                    <img src="images/banner/banner02.jpg">
                </li>
                <li>
                    <img src="images/banner/banner01.jpg">
                </li>
            </ul>
            <!-- banner图片滚动的圆点 -->
            <ul class="full-screen">
                <li class="current">●</li>
                <li>●</li>
                <li>●</li>
            </ul>
        </div>
        <!-- banner end -->
        <uc1:Notice runat="server" ID="Notice" />
        <!-- 热闹游戏start -->
        <div class="clearfix">
            <div class="min-widths hot-game">
                <div class="fl hot-game-list">
                    <img src="images/hot_game_tit.png" alt="" title="" class="hot-game-tit">
                    <div class="hot-game-info clearfix">
                        <ul class="clearfix">
                            <asp:Repeater ID="rptData" runat="server">
                                <ItemTemplate>
                                    <li class="">
                                        <a href="gameDetails.aspx?id=<%#Eval("KindID")%>" title="">
                                            <img src="<%#Game.Utils.ApplicationSettings.Get("fileUrl")+"/Rules/"+Eval("ImgRuleUrl")%>">
                                        </a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <img src="images/hot_pic.png" alt="" title="" class="fr hot-game-r">
            </div>
        </div>
        <!-- 热闹游戏end -->
        <!-- 游戏流程start -->
        <div class="game-flow">
            <img src="images/game_flow.png" alt="" title="" class="min-widths">
        </div>
        <!-- 游戏流程end -->
        <img src="images/trust.jpg" alt="" title="" class="min-widths trust">
        <!-- 子导航栏start -->
        <div class="subnav">
            <ul class="min-widths subnav-tit clearfix" id="indexSubNavTab">
                <li class="active">
                    <span class="index-product"></span>
                </li>
                <li>
                    <span class="index-novice"></span>
                </li>
                <li>
                    <span class="index-loading"></span>
                </li>
                <li>
                    <span class="index-agent"></span>
                </li>
            </ul>
            <div class="min-widths subnav-list-content clearfix">
                <div class="fl subnav-list">
                    <!-- 全线产品start -->
                    <div class="index-subnav-info">
                        <div class="fl agent-list-info">
                            <h3>棋牌游戏</h3>
                            <p>平台提供斗地主、智勇三张等棋牌游戏，在棋牌游戏世界里，博都游戏平台让每位玩家可以畅享打牌的欢乐。 </p>
                            <h3>竞技游戏</h3>
                            <p>平台提供德州扑克等竞技游戏，在竞技游戏的世界里，博都游戏平台让每位玩家可以体验战胜对手的喜悦，同时您还有机会获取高额的比赛奖金。</p>
                            <h3>转运游戏</h3>
                            <p>平台提供牛牛、激情30秒等转运游戏，在转运游戏的世界里，博都棋牌平台让每位玩家可以用心理战术、牌运手气改变人生道路，体验一局定输赢，怎么想怎么玩的乐趣</p>
                        </div>
                        <img src="images/subnav_info_product.png" alt="" title="" class="fl product-list-pic">
                    </div>
                    <!-- 全线产品end -->
                    <!-- 新手上路start -->
                    <div class="index-subnav-info dis-none">
                        <div class="fl  novice-list-info">
                            <div class="novice-two">
                                <h3>注册账号密码</h3>
                                <p></p>
                            </div>
                            <div class="novice-two">
                                <h3>注册账号密码</h3>
                                <p>点击本网站提供<游戏下载>，下载游戏安装程序。</p>
                            </div>
                            <div class="novice-two">
                                <h3>安装游戏大厅</h3>
                                <p>双击下载的安装程序，根据提示进行安装，安装成功后将在桌面产生游戏图标。</p>
                            </div>
                            <div class="novice-two">
                                <h3>登录游戏</h3>
                                <p>点击桌面产生的游戏图标，输入您注册的账号密码即可进入游戏大厅</p>
                            </div>
                            <div class="novice-two">
                                <h3>进入游戏</h3>
                                <p>点击大厅的游戏图标下载游戏，游戏下载完时，您即可畅玩游戏。</p>
                            </div>
                        </div>
                        <img src="images/subnav_info_novice.png" alt="" title="" class="fl product-list-pic">
                    </div>
                    <!-- 新手上路end -->
                    <!-- 游戏下载start -->
                    <div class="index-subnav-info dis-none">
                        <div class="fl agent-list-info">
                            <h3>游戏品种繁多</h3>
                            <p>本平台为广大玩家准备了众多游戏，其中包括斗地主、经典牛牛、德州、百家乐、跑车、捕鱼等精品游戏，在这众多游戏中，肯定有你喜欢的!加入吧！ </p>
                            <h3>三平台互通、极致体验</h3>
                            <p>为广大玩家不受设备的限制，我们做到了三平台互使得玩家不再因为设备的原因，缺少对手！</p>
                            <p>三平台互通，上线以来赢得了众多好评和喝彩！你还在因为缺少对手而烦恼吗？，还在因为朋友之间平台不一样而烦恼吗？别发愁！这些我们都解决了，这里不缺少高手，开来“战斗”吧！</p>
                            <p>还在犹豫什么？赶紧赶紧加入!</p>
                        </div>
                        <img src="images/subnav_info_loading.png" alt="" title="" class="fl product-list-pic">
                    </div>
                    <!-- 游戏下载end -->
                    <!-- 游戏代理start -->
                    <div class="index-subnav-info dis-none clearfix">
                        <div class="fl agent-list-info">
                            <h3>神奇复利</h3>
                            <p>1 今天一次性给你1亿元 </p>
                            <p>2 今天给你1元，接下来连续30天每天给你比前一天翻一倍的钱。</p>
                            <p>你会选哪个？很多人选1.但告诉你选2的结果是21.47亿元！</p>
                            <p>你想不想日收入达到金额的月收入水准？？赶紧加入我们，推广专属于你的复利吧！</p>
                            <h3>推广流程</h3>
                            <p>1 注册账号获得推广码</p>
                            <p>2 复制推广码给新玩家</p>
                            <p>3 获得推广奖励</p>
                        </div>
                        <img src="images/subnav_info_agent.png" alt="" title="" class="fl agent-list-pic">
                    </div>
                    <!-- 游戏代理end -->
                </div>
                <div class="fr service-advantage">
                    <h3>服务优势</h3>
                    <div class="advantage-list clearfix">
                        <div class="fl">
                            <strong>存款到账</strong>
                            <span>平均时间</span>
                        </div>
                        <p class="fr">
                            <strong>25</strong>
                            <span>秒</span>
                        </p>
                    </div>
                    <img src="images/advantage_01.png" alt="" title="" class="">
                    <div class="advantage-list clearfix">
                        <div class="fl">
                            <strong>取款到账</strong>
                            <span>平均时间</span>
                        </div>
                        <p class="fr">
                            <strong>2'57</strong>
                            <span>分</span>
                        </p>
                    </div>
                    <img src="images/advantage_02.png" alt="" title="" class="">
                    <div class="advantage-list clearfix">
                        <div class="fl">
                            <strong>便捷行服务</strong>
                            <span>目前我们支持的机构有</span>
                        </div>
                        <p class="fr">
                            <strong>34</strong>
                            <span>家</span>
                        </p>
                    </div>
                    <img src="images/advantage_03.png" alt="" title="" class="">
                </div>
            </div>
        </div>
        <!-- 子导航栏end -->

        <div class="index-card">
            <img src="images/card.png" alt="" title="" />
            <div class="index-card-list clearfix">
                <div class="fl hotline">
                    <span></span>
                    <em>服务热线：</em>
                    <strong>
                        <asp:Literal ID="ltlPhone" runat="server"></asp:Literal></strong>
                </div>
                <div class="fl qq-hotline">
                    <span></span>
                    <em>QQ热线：</em>
                    <strong>
                        <asp:Literal ID="ltlQQ" runat="server"></asp:Literal></strong>
                </div>
                <div class="fl email-hotline">
                    <span></span>
                    <em>邮箱热线：</em>
                    <strong>
                        <asp:Literal ID="ltlEmail" runat="server"></asp:Literal></strong>
                </div>
                <div class="fl time-hotline">
                    <span></span>
                    <strong>7x24</strong>
                    <em>小时在线客服</em>
                </div>
            </div>
        </div>
        <uc1:Foot runat="server" ID="Foot" />
    </div>

    <script src="/js/index.js" charset="utf-8" type="text/javascript"></script>
</body>
</html>

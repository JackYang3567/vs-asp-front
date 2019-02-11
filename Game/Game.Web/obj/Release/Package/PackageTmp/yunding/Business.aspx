<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="/Business.aspx.cs" Inherits="Game.Web.Business" %>
<%@ Register Src="Template/Head.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="Template/Notice.ascx" TagPrefix="uc1" TagName="Notice" %>
<%@ Register Src="Template/Foot.ascx" TagPrefix="uc1" TagName="Foot" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <title>云顶棋牌-合作加盟</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header runat="server" ID="Header" />
        <!-- banner start -->
		<div class="register-banner-bg">
			<img src="images/banner/register_banner.jpg" alt="" title="" class="" />
		</div>
		<!-- banner end -->
        <uc1:Notice runat="server" ID="Notice" />
        <!-- 主体内容start -->
		<div class="main">
			<div class="register-list">
				<div class="franchise-partner-advantage">
					<img src="images/partner_advantage_img.png" alt="" title="">
					<p>我们充满活力，拥有自主品牌平台，讲信用、诚信。拥有无与伦比的前瞻性及合作黏附力，缺少的？就是您的加入</p>
					<p>只要您是博都棋牌的正式会员，拥有自己的游戏账号，即可加入我们的大家庭</p>
				</div>
				<div class="franchise-join-us clearfix">
					<div class="fl">
						<img src="images/join_us_01.png" alt="" title="">
						<h4>强大品牌优势</h4>
						<p>多年业界运作经验 经验丰富</p>
					</div>
					<div class="fl">
						<img src="images/join_us_02.png" alt="" title="">
						<h4>资金优势</h4>
						<p>信誉卓越资金保障</p>
						<p>多年赔付保证，无任何负面消息，</p>
						<p>玩家评价优良</p>
					</div>
					<div class="fl">
						<img src="images/join_us_03.png" alt="" title="">
						<h4>系统优势</h4>
						<p>行业领先的客户系统</p>
						<p>及合作伙伴系统</p>
						<p>并不断创新，可定制化</p>
					</div>
					<div class="fl">
						<img src="images/join_us_04.png" alt="" title="">
						<h4>技术优势</h4>
						<p>全球服务器群组支持，多种技术优化</p>
						<p>保障运营稳定，响应需求迅速，</p>
						<p>一流技术团队运维</p>
					</div>
					<div class="fl">
						<img src="images/join_us_05.png" alt="" title="">
						<h4>服务优势</h4>
						<p>24小时全年无休服务，</p>
						<p>多种支付渠道，存提款处理迅速，</p>
						<p>业界一流，可亲自体验c</p>
					</div>
					<div class="fl join-us-btn">
						<a href="" title="" class="block">
							<img src="images/join_us_btn.png" alt="" title="">
						</a>
					</div>
					<div class="fl">
						<img src="images/join_us_06.png" alt="" title="">
						<h4>双赢态度</h4>
						<p>专业品牌建设，诚信为先，</p>
						<p>用心做好与合作伙伴的沟通，</p>
						<p>致力双赢</p>
					</div>
				</div>
			</div>
			<div class="franchise-promotion-method clearfix">
				<div class="fl">
					<img src="images/promotion_method_one.png" alt="" title="" class="">
					<div class="franchise-promotion-info">
						<p>您不是一个人在战斗，只要介绍用户注册，填写您为推荐人即可形成营销体系</p>
						<p>通过社交工具创收</p>
						<p>通过个人网站创收</p>
						<p>通过SEO创收 </p>
						<p>通过朋友渠道创收</p>
						<span>---此方式适合所有用户</span>
						<a href="" title="">查看详情</a>
					</div>
				</div>
				<div class="fr">
					<img src="images/promotion_method_two.png" alt="" title="" class="">
					<div class="franchise-promotion-info">
						<h4>1.在公共上网场所（如网吧），安装博都棋牌游戏</h4>
						<h4>2.在安装游戏的目录下建立文件PlazaProfile\Spreader.txt</h4>
						<p>文件内容设置为： [SPREADERCONFIG]</p>
						<p>Accounts=您的游戏帐号 </p>
						<p>完成以上两个步骤之后，通过这台电脑注册的所有游戏用户，都将默认该游戏账号推荐人。</p>
						<p>例：把游戏安装在C:\Program Files\博都棋牌，您的游戏帐号为Ifeng888,那么就先在 博都棋牌 目录下建立PlazaProfile文件夹 然后新建文件Spreader.txt ，该文件内容设置为： [SPREADERCONFIG] Accounts=Ifeng888</p>
					</div>
				</div>
			</div>
		</div>
		<!-- 主体内容end -->
        <uc1:Foot runat="server" ID="Foot" />
        <script src="/js/cooperativeFranchise.js" charset="utf-8" type="text/javascript"></script>
    </form>
</body>
</html>
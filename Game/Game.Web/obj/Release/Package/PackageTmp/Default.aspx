<%@ Page Language="C#" AutoEventWireup="true" %>

<%@ Import Namespace="System.Drawing" %>
<%@ Import Namespace="ThoughtWorks.QRCode.Codec" %>

<script type="text/C#" runat="server">
    string qrcode = "";
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        string host = Request.Url.Host;

        if (host.IndexOf('.') > -1)
        {
            string yuming = "";
            string[] hostList = host.Split('.');
            string gameid = "";
            if (hostList.Length > 2 && hostList[0] != "www")
            {
                gameid = hostList[0];
                yuming = hostList[hostList.Length - 2] + "." + hostList[hostList.Length - 1];
            }
            else
                yuming = host;

            Game.Entity.NativeWeb.ConfigInfo configInfo = new Game.Entity.NativeWeb.ConfigInfo();
            if (HttpRuntime.Cache["configInfo"] == null)
            {
                configInfo = Game.Facade.FacadeManage.aideNativeWebFacade.GetConfigInfo("ShareConfig");
                if (configInfo != null)
                {
                    Game.Facade.CacheHelper.AddCache("configInfo", configInfo);
                }
            }
            else
            {
                configInfo = HttpRuntime.Cache["configInfo"] as Game.Entity.NativeWeb.ConfigInfo;
            }
            string shareUrl = configInfo.Field1;
            string url = configInfo.Field4;//跳转域名
            int shareTime = Convert.ToInt32(configInfo.Field5);
            if (shareUrl != "")
            {
                if (shareUrl.Contains(yuming))//分享域名进来的
                {

                    if (url.IndexOf("|") > -1)  //跳转域名有多个
                    {
                        string[] urllist = url.Split('|');
                        int i = new Random().Next(0, urllist.Length - 1);
                        if (gameid == "")
                            Response.Redirect("http://" + urllist[i] + "?t=" + Request["t"]);
                        else
                            Response.Redirect("http://" + gameid + "." + urllist[i] + "?t=" + Request["t"]);
                    }
                    else if (url != "") //跳转域名只有一个
                    {
                        if (gameid == "")
                            Response.Redirect("http://" + url + "?t=" + Request["t"]);
                        else
                            Response.Redirect("http://" + gameid + "." + url + "?t=" + Request["t"]);
                    }
                    else //没有跳转域名
                    {
                        if (Request["t"] == null || Request["t"] == "")
                        {
                            Response.Redirect("tiaozhuan.aspx");
                        }

                        long t = Convert.ToInt64(Request["t"]);

                        TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 8, 0, 0, 0);
                        long time = Convert.ToInt64(ts.TotalSeconds);

                        if ((time - t) > shareTime * 60) //超时无效
                        {
                            Response.Redirect("tiaozhuan.aspx");
                        }
                    }

                }
            }
            if (url != "" && url.Contains(yuming))//跳转域名进来的
            {
                if (Request["t"] == null || Request["t"] == "")
                {
                    Response.Redirect("tiaozhuan.aspx");
                }

                long t = Convert.ToInt64(Request["t"]);

                TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 8, 0, 0, 0);
                long time = Convert.ToInt64(ts.TotalSeconds);

                if ((time - t) > shareTime * 60) //超时无效
                {
                    Response.Redirect("tiaozhuan.aspx");
                }
            }
        }



        qrcode = "/images/" + host + ".png";
        string fileName = Server.MapPath(qrcode);
        if (!System.IO.File.Exists(fileName))
        {
            string data = "http://" + Request.Url.Host;
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeVersion = 0;
            var encodedData = qrCodeEncoder.Encode(data, System.Text.Encoding.UTF8);
            //绘制图片
            int x = 0, y = 0;
            int w = 0, h = 0;
            int size = 250;
            Color qrCodeBackgroundColor = Color.White;
            Color qrCodeForegroundColor = Color.Black;
            // 二维码矩阵单边数据点数目
            int count = encodedData.Length;
            // 获取单个数据点边长
            double sideLength = Convert.ToDouble(size) / count;
            // 初始化背景色画笔
            SolidBrush backcolor = new SolidBrush(qrCodeBackgroundColor);
            // 初始化前景色画笔
            SolidBrush forecolor = new SolidBrush(qrCodeForegroundColor);
            // 定义画布
            Bitmap image = new Bitmap(size, size);
            // 获取GDI+绘图图画
            Graphics graph = Graphics.FromImage(image);
            // 先填充背景色
            graph.FillRectangle(backcolor, 0, 0, size, size);

            // 变量数据矩阵生成二维码
            for (int row = 0; row < count; row++)
            {
                for (int col = 0; col < count; col++)
                {
                    // 计算数据点矩阵起始坐标和宽高
                    x = Convert.ToInt32(Math.Round(col * sideLength));
                    y = Convert.ToInt32(Math.Round(row * sideLength));
                    w = Convert.ToInt32(Math.Ceiling((col + 1) * sideLength) - Math.Floor(col * sideLength));
                    h = Convert.ToInt32(Math.Ceiling((row + 1) * sideLength) - Math.Floor(row * sideLength));

                    // 绘制数据矩阵
                    graph.FillRectangle(encodedData[col][row] ? forecolor : backcolor, x, y, w, h);
                }
            }
            //Bitmap bitmap = qrCodeEncoder.Encode(data, Encoding.UTF8);//指定utf-8编码， 支持中文 
            image.Save(fileName);//保存位图
        }
    }

</script>
<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>首页</title>
    <link href="css/index.css" rel="stylesheet" />
    <script type="text/javascript">
        /*
        * 智能机浏览器版本信息:
        *
        */
        var browser = {
            versions: function () {
                var u = navigator.userAgent, app = navigator.appVersion;
                return {//移动终端浏览器版本信息
                    trident: u.indexOf('Trident') > -1, //IE内核
                    presto: u.indexOf('Presto') > -1, //opera内核
                    webKit: u.indexOf('AppleWebKit') > -1, //苹果、谷歌内核
                    gecko: u.indexOf('Gecko') > -1 && u.indexOf('KHTML') == -1, //火狐内核
                    mobile: !!u.match(/AppleWebKit.*Mobile.*/) || !!u.match(/AppleWebKit/), //是否为移动终端
                    ios: !!u.match(/\(i[^;]+;( U;)? CPU.+Mac OS X/), //ios终端
                    android: u.indexOf('Android') > -1 || u.indexOf('Linux') > -1, //android终端或者uc浏览器
                    iPhone: u.indexOf('iPhone') > -1 || u.indexOf('Mac') > -1, //是否为iPhone或者QQHD浏览器
                    iPad: u.indexOf('iPad') > -1, //是否iPad
                    webApp: u.indexOf('Safari') == -1 //是否web应该程序，没有头部与底部
                };
            }(),
            language: (navigator.browserLanguage || navigator.language).toLowerCase()
        }
        if (browser.versions.android || browser.versions.ios || browser.versions.iPhone || browser.versions.iPad) {
            location.href = "/m/index.aspx";
        }

    </script>
	<script src="js/jquery.min.js"></script>
     <script src="/js/entity.js"></script>
    <script>
        $(function () {
            $("#ios_url").attr("href", Download.iosUrl);
            $("#android_url").attr("href", Download.androUrl);
        })
    </script>
</head>
<body>
    <div class="wrap">
        <div class="header">
            <img src="images/logo.png" />
        </div>
        <div class="main">
            <div class="main-list clearfix">
                <div class="ios-list">
                    <div class="qrcode">
                        <img src="<%=qrcode %>" alt="二维码" />
                    </div>
                    <h3>IOS9.0安装提示</h3>
                    <strong>“未受信任的企业级开发者”?</strong>
                    <h3>解决方法：</h3>
                    <p>在系统中打开 设置 - 通用 - 描述文件（在iOS 9.2以后叫：设备管理），此时，可以看到有一个和刚刚弹出的提示中文字类似的描述文件。</p>
                    <p>然后，点击对应描述文件进入后，再点击按钮 信任，即可运行</p>
                </div>
                <div class="main-info">
                    <h1>移动端最新上线</h1>
                    <p>好友组局、多样玩法、战绩回放、实时语音、走心互动</p>
                </div>
            </div>
            <div class="index-btn clearfix">
                <a id="ios_url" href="http://xmvip.vip/mOGdO" target="_blank">
                    <img src="../images/apple_download.png" alt="" title="" />
                </a>
                <a href="register.html">
                    <img src="../images/register_btn.png" alt="" title="" />
                </a>
                <a id="android_url"  href="http://xmvip.vip/mOGdO" target="_blank">
                    <img src="../images/android_download.png" alt="" title="" />
                </a>
            </div>
        </div>
        <div class="footer">
            <p>授权监管 我们将不留余力的为您提供优质的服务</p>
        </div>
    </div>
</body>
</html>

using System;
namespace Game.Web.Pay.JFPay
{
    public class RequestBean
    {
        /// <summary>
        /// 商户应用号
        /// </summary>
        public string p1_yingyongnum { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string p2_ordernumber { get; set; }
        /// <summary>
        /// 商户订单金额
        /// </summary>
        public string p3_money { get; set; }
        /// <summary>
        /// 商户订单时间
        /// </summary>
        public string p6_ordertime { get; set; }

        /// <summary>
        /// 产品支付类型编码
        /// </summary>
        public string p7_productcode { get; set; }
        /// <summary>
        /// 订单签名
        /// </summary>
        public string p8_sign { get; set; }
        /// <summary>
        /// 签名方式
        /// </summary>
        public string p9_signtype { get; set; }
        /// <summary>
        /// 银行卡或卡类编码
        /// </summary>
        public string p10_bank_card_code { get; set; }
        /// <summary>
        /// 商户支付银行卡类型id
        /// </summary>
        public int p11_cardtype { get; set; }
        /// <summary>
        /// 商户支付银行卡类型长度
        /// </summary>
        public string p12_channel { get; set; }
        /// <summary>
        /// 订单失效时间
        /// </summary>
        public string p13_orderfailertime { get; set; }
        /// <summary>
        /// 商户游戏账号
        /// </summary>        
        public string p14_customname { get; set; }
        /// <summary>
        /// 商户联系内容
        /// </summary>
        public string p15_customcontact { get; set; }
        /// <summary>
        /// 付款ip地址
        /// </summary>
        public string p16_customip { get; set; }
        /// <summary>
        /// 商户名称
        /// </summary>
        /// <returns></returns>
        public string p17_product { get; set; }
        /// <summary>
        /// 商品种类
        /// </summary>
        /// <returns></returns>
        public string p18_productcat { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        /// <returns></returns>
        public string p19_productnum { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        /// <returns></returns>
        public string p20_pdesc { get; set; }
        /// <summary>
        /// 对接版本
        /// </summary>
        /// <returns></returns>
        public string p21_version { get; set; }
        /// <summary>
        /// SDK版本
        /// </summary>
        /// <returns></returns>
        public string p22_sdkversion { get; set; }
        /// <summary>
        /// 编码格式
        /// </summary>
        /// <returns></returns>
        public string p23_charset { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string p24_remark { get; set; }
        /// <summary>
        /// 商户终端设备值:1 pc 2 ios  3 安卓
        /// </summary>
        /// <returns></returns>
        public string p25_terminal { get; set; }
        /// <summary>
        /// 预留参数
        /// </summary>
        /// <returns></returns>
        public string p26_ext1 { get; set; }
        /// <summary>
        /// 预留参数
        /// </summary>
        /// <returns></returns>
        public string p27_ext2 { get; set; }
        /// <summary>
        /// 预留参数
        /// </summary>
        /// <returns></returns>
        public string p28_ext3 { get; set; }
        /// <summary>
        /// 预留参数
        /// </summary>
        /// <returns></returns>
        public string p29_ext4 { get; set; }
    }
}

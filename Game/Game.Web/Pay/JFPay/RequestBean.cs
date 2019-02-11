using System;
namespace Game.Web.Pay.JFPay
{
    public class RequestBean
    {
        /// <summary>
        /// �̻�Ӧ�ú�
        /// </summary>
        public string p1_yingyongnum { get; set; }
        /// <summary>
        /// �̻�������
        /// </summary>
        public string p2_ordernumber { get; set; }
        /// <summary>
        /// �̻��������
        /// </summary>
        public string p3_money { get; set; }
        /// <summary>
        /// �̻�����ʱ��
        /// </summary>
        public string p6_ordertime { get; set; }

        /// <summary>
        /// ��Ʒ֧�����ͱ���
        /// </summary>
        public string p7_productcode { get; set; }
        /// <summary>
        /// ����ǩ��
        /// </summary>
        public string p8_sign { get; set; }
        /// <summary>
        /// ǩ����ʽ
        /// </summary>
        public string p9_signtype { get; set; }
        /// <summary>
        /// ���п��������
        /// </summary>
        public string p10_bank_card_code { get; set; }
        /// <summary>
        /// �̻�֧�����п�����id
        /// </summary>
        public int p11_cardtype { get; set; }
        /// <summary>
        /// �̻�֧�����п����ͳ���
        /// </summary>
        public string p12_channel { get; set; }
        /// <summary>
        /// ����ʧЧʱ��
        /// </summary>
        public string p13_orderfailertime { get; set; }
        /// <summary>
        /// �̻���Ϸ�˺�
        /// </summary>        
        public string p14_customname { get; set; }
        /// <summary>
        /// �̻���ϵ����
        /// </summary>
        public string p15_customcontact { get; set; }
        /// <summary>
        /// ����ip��ַ
        /// </summary>
        public string p16_customip { get; set; }
        /// <summary>
        /// �̻�����
        /// </summary>
        /// <returns></returns>
        public string p17_product { get; set; }
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        /// <returns></returns>
        public string p18_productcat { get; set; }
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        /// <returns></returns>
        public string p19_productnum { get; set; }
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        /// <returns></returns>
        public string p20_pdesc { get; set; }
        /// <summary>
        /// �ԽӰ汾
        /// </summary>
        /// <returns></returns>
        public string p21_version { get; set; }
        /// <summary>
        /// SDK�汾
        /// </summary>
        /// <returns></returns>
        public string p22_sdkversion { get; set; }
        /// <summary>
        /// �����ʽ
        /// </summary>
        /// <returns></returns>
        public string p23_charset { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        public string p24_remark { get; set; }
        /// <summary>
        /// �̻��ն��豸ֵ:1 pc 2 ios  3 ��׿
        /// </summary>
        /// <returns></returns>
        public string p25_terminal { get; set; }
        /// <summary>
        /// Ԥ������
        /// </summary>
        /// <returns></returns>
        public string p26_ext1 { get; set; }
        /// <summary>
        /// Ԥ������
        /// </summary>
        /// <returns></returns>
        public string p27_ext2 { get; set; }
        /// <summary>
        /// Ԥ������
        /// </summary>
        /// <returns></returns>
        public string p28_ext3 { get; set; }
        /// <summary>
        /// Ԥ������
        /// </summary>
        /// <returns></returns>
        public string p29_ext4 { get; set; }
    }
}

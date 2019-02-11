using Game.Entity.Accounts;
using Game.Entity.NativeWeb;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
namespace Game.Web.Ashx
{
    public class Shop : System.Web.IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public void ProcessRequest(System.Web.HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string text = GameRequest.GetQueryString("action").ToLower();
            string a;
            if ((a = text) != null)
            {
                if (a == "buyaward")
                {
                    this.BuyAward(context);
                }
                else
                {
                    if (a == "returnaward")
                    {
                        this.ReturnAward(context);
                    }
                    else
                    {
                        if (a == "mobilegetawardlist")
                        {
                            this.MobileGetAwardList(context);
                        }
                        else
                        {
                            if (a == "mobilegetawardinfo")
                            {
                                this.MobileGetAwardInfo(context);
                            }
                            else
                            {
                                if (a == "mobilebuyaward")
                                {
                                    this.MobileBuyAward(context);
                                }
                            }
                        }
                    }
                }
            }
        }
        public void BuyAward(System.Web.HttpContext context)
        {
            Message message = new Message();
            AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
            if (!Fetch.IsUserOnline())
            {
                ajaxJsonValid.code = 1;
                ajaxJsonValid.msg = "请先登录";
                context.Response.Write(ajaxJsonValid.SerializeToJson());
            }
            else
            {
                int queryInt = GameRequest.GetQueryInt("TypeID", 0);
                int formInt = GameRequest.GetFormInt("awardID", 0);
                int formInt2 = GameRequest.GetFormInt("counts", 0);
                string text = TextFilter.FilterScript(GameRequest.GetFormString("name"));
                string text2 = TextFilter.FilterScript(GameRequest.GetFormString("phone"));
                int formInt3 = GameRequest.GetFormInt("province", -1);
                int formInt4 = GameRequest.GetFormInt("city", -1);
                int formInt5 = GameRequest.GetFormInt("area", -1);
                string text3 = TextFilter.FilterScript(GameRequest.GetFormString("address"));
                if (formInt == 0)
                {
                    ajaxJsonValid.msg = "非常抱歉，你所选购的商品不存在！";
                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                }
                else
                {
                    if (formInt2 <= 0)
                    {
                        ajaxJsonValid.msg = "请输入正确的兑换数量！";
                        context.Response.Write(ajaxJsonValid.SerializeToJson());
                    }
                    else
                    {
                        if (formInt2 > 100)
                        {
                            ajaxJsonValid.msg = "兑换数量不能超过100！";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                        }
                        else
                        {
                            AwardInfo awardInfo = FacadeManage.aideNativeWebFacade.GetAwardInfo(formInt);
                            int needInfo = awardInfo.NeedInfo;
                            int num = 1;
                            int num2 = 2;
                            int num3 = 8;
                            if ((needInfo & num) == num)
                            {
                                message = Shop.CheckingRealNameFormat(text, false);
                                if (!message.Success)
                                {
                                    ajaxJsonValid.msg = "请输入正确的收件人";
                                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                                    return;
                                }
                            }
                            if ((needInfo & num2) == num2)
                            {
                                message = Shop.CheckingMobilePhoneNumFormat(text2, false);
                                if (!message.Success)
                                {
                                    ajaxJsonValid.msg = "请输入正确的手机号码";
                                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                                    return;
                                }
                            }
                            if ((needInfo & num3) == num3)
                            {
                                if (formInt3 == -1)
                                {
                                    ajaxJsonValid.msg = "请选择省份";
                                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                                    return;
                                }
                                if (formInt4 == -1)
                                {
                                    ajaxJsonValid.msg = "请选择城市";
                                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                                    return;
                                }
                                if (formInt5 == -1)
                                {
                                    ajaxJsonValid.msg = "请选择地区";
                                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                                    return;
                                }
                                if (string.IsNullOrEmpty(text3))
                                {
                                    ajaxJsonValid.msg = "请输入详细地址";
                                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                                    return;
                                }
                            }
                            UserInfo userInfo = FacadeManage.aideAccountsFacade.GetUserGlobalInfo(Fetch.GetUserCookie().UserID, 0, "").EntityList[0] as UserInfo;
                            int num4 = awardInfo.Price * formInt2;
                            if (num4 > userInfo.UserMedal)
                            {
                                ajaxJsonValid.msg = "很抱歉！您的元宝数不足，不能兑换该奖品";
                                context.Response.Write(ajaxJsonValid.SerializeToJson());
                            }
                            else
                            {
                                if (awardInfo.Inventory <= 0)
                                {
                                    ajaxJsonValid.msg = "很抱歉！奖品的库存数不足，请更新其他奖品或者等待补充库存";
                                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                                }
                                else
                                {
                                    userInfo.UserMedal -= num4;
                                    AwardOrder awardOrder = new AwardOrder();
                                    awardOrder.UserID = userInfo.UserID;
                                    awardOrder.AwardID = formInt;
                                    awardOrder.AwardPrice = awardInfo.Price;
                                    awardOrder.AwardCount = formInt2;
                                    awardOrder.TotalAmount = num4;
                                    awardOrder.Compellation = text;
                                    awardOrder.MobilePhone = text2;
                                    awardOrder.QQ = "";
                                    awardOrder.Province = formInt3;
                                    awardOrder.City = formInt4;
                                    awardOrder.Area = formInt5;
                                    awardOrder.DwellingPlace = text3;
                                    awardOrder.PostalCode = "";
                                    awardOrder.BuyIP = Utility.UserIP;
                                    message = FacadeManage.aideNativeWebFacade.BuyAward(awardOrder);
                                    if (message.Success)
                                    {
                                        ajaxJsonValid.SetValidDataValue(true);
                                        ajaxJsonValid.msg = "恭喜您！兑换成功";
                                        awardOrder = (message.EntityList[0] as AwardOrder);
                                        if (queryInt == 0)
                                        {
                                            ajaxJsonValid.AddDataItem("uri", "/Shop/Order.aspx?param=" + awardOrder.AwardID);
                                        }
                                        else
                                        {
                                            ajaxJsonValid.AddDataItem("uri", "/Mobile/Shop/Order.aspx?param=" + awardOrder.AwardID);
                                        }
                                        context.Response.Write(ajaxJsonValid.SerializeToJson());
                                    }
                                    else
                                    {
                                        ajaxJsonValid.msg = message.Content;
                                        context.Response.Write(ajaxJsonValid.SerializeToJson());
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public void ReturnAward(System.Web.HttpContext context)
        {
            new Message();
            AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
            if (!Fetch.IsUserOnline())
            {
                ajaxJsonValid.code = 1;
                ajaxJsonValid.msg = "请先登录";
                context.Response.Write(ajaxJsonValid.SerializeToJson());
            }
            else
            {
                int queryInt = GameRequest.GetQueryInt("orderid", 0);
                if (queryInt != 0)
                {
                    AwardOrder awardOrder = FacadeManage.aideNativeWebFacade.GetAwardOrder(queryInt, Fetch.GetUserCookie().UserID);
                    if (awardOrder == null)
                    {
                        ajaxJsonValid.msg = "申请退货失败，订单不存在";
                        context.Response.Write(ajaxJsonValid.SerializeToJson());
                    }
                    else
                    {
                        if (awardOrder.OrderStatus != 1 && awardOrder.OrderStatus != 2)
                        {
                            ajaxJsonValid.msg = "此订单暂不允许退货";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                        }
                        else
                        {
                            AwardInfo awardInfo = FacadeManage.aideNativeWebFacade.GetAwardInfo(awardOrder.AwardID);
                            if (!awardInfo.IsReturn)
                            {
                                ajaxJsonValid.msg = "此商品属于不予退货服务的产品范畴";
                                context.Response.Write(ajaxJsonValid.SerializeToJson());
                            }
                            else
                            {
                                awardOrder.OrderStatus = 3;
                                FacadeManage.aideNativeWebFacade.UpdateAwardOrderStatus(awardOrder);
                                ajaxJsonValid.SetValidDataValue(true);
                                ajaxJsonValid.msg = "申请退货成功，请等待客服审核";
                                context.Response.Write(ajaxJsonValid.SerializeToJson());
                            }
                        }
                    }
                }
            }
        }
        public void MobileGetAwardList(System.Web.HttpContext context)
        {
            AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
            int queryInt = GameRequest.GetQueryInt("page", 1);
            int queryInt2 = GameRequest.GetQueryInt("pageSize", 20);
            string pkey = "ORDER BY SortID DESC";
            string whereQuery = " WHERE Nullity=0";
            PagerSet list = FacadeManage.aideNativeWebFacade.GetList("AwardInfo", queryInt, queryInt2, pkey, whereQuery);
            System.Collections.Generic.IList<AwardInfo> list2 = DataHelper.ConvertDataTableToObjects<AwardInfo>(list.PageSet.Tables[0]);
            if (list2 != null)
            {
                foreach (AwardInfo current in list2)
                {
                    current.SmallImage = Fetch.GetUploadFileUrl(current.SmallImage);
                    current.BigImage = Fetch.GetUploadFileUrl(current.BigImage);
                }
            }
            ajaxJsonValid.AddDataItem("List", list2);
            ajaxJsonValid.AddDataItem("RecordCount", list.RecordCount);
            ajaxJsonValid.SetValidDataValue(true);
            context.Response.Write(ajaxJsonValid.SerializeToJson());
        }
        public void MobileGetAwardInfo(System.Web.HttpContext context)
        {
            int queryInt = GameRequest.GetQueryInt("awardID", 0);
            AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
            if (queryInt == 0)
            {
                ajaxJsonValid.msg = "缺少参数奖品ID";
                context.Response.Write(ajaxJsonValid.SerializeToJson());
            }
            else
            {
                AwardInfo awardInfo = FacadeManage.aideNativeWebFacade.GetAwardInfo(queryInt);
                if (awardInfo != null)
                {
                    awardInfo.SmallImage = Fetch.GetUploadFileUrl(awardInfo.SmallImage);
                    awardInfo.BigImage = Fetch.GetUploadFileUrl(awardInfo.BigImage);
                }
                ajaxJsonValid.AddDataItem("Data", awardInfo);
                ajaxJsonValid.SetValidDataValue(true);
                context.Response.Write(ajaxJsonValid.SerializeToJson());
            }
        }
        public void MobileBuyAward(System.Web.HttpContext context)
        {
            Message message = new Message();
            AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
            int formInt = GameRequest.GetFormInt("userID", 0);
            string formString = GameRequest.GetFormString("signature");
            string formString2 = GameRequest.GetFormString("time");
            Message message2 = FacadeManage.aideAccountsFacade.CheckUserSignature(formInt, formString2, formString);
            if (!message2.Success)
            {
                ajaxJsonValid.msg = message2.Content;
                context.Response.Write(ajaxJsonValid.SerializeToJson());
            }
            else
            {
                int formInt2 = GameRequest.GetFormInt("awardID", 0);
                int formInt3 = GameRequest.GetFormInt("counts", 0);
                string text = TextFilter.FilterScript(GameRequest.GetFormString("name"));
                string text2 = TextFilter.FilterScript(GameRequest.GetFormString("phone"));
                int formInt4 = GameRequest.GetFormInt("province", -1);
                int formInt5 = GameRequest.GetFormInt("city", -1);
                int formInt6 = GameRequest.GetFormInt("area", -1);
                string text3 = TextFilter.FilterScript(GameRequest.GetFormString("address"));
                if (formInt2 == 0)
                {
                    ajaxJsonValid.msg = "非常抱歉，你所选购的商品不存在！";
                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                }
                else
                {
                    if (formInt3 <= 0)
                    {
                        ajaxJsonValid.msg = "请输入正确的兑换数量！";
                        context.Response.Write(ajaxJsonValid.SerializeToJson());
                    }
                    else
                    {
                        if (formInt3 > 99)
                        {
                            ajaxJsonValid.msg = "每次兑换的数量最多为 99 件";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                        }
                        else
                        {
                            AwardInfo awardInfo = FacadeManage.aideNativeWebFacade.GetAwardInfo(formInt2);
                            message = Shop.CheckingRealNameFormat(text, false);
                            if (!message.Success)
                            {
                                ajaxJsonValid.msg = "请输入正确的收件人";
                                context.Response.Write(ajaxJsonValid.SerializeToJson());
                            }
                            else
                            {
                                message = Shop.CheckingMobilePhoneNumFormat(text2, false);
                                if (!message.Success)
                                {
                                    ajaxJsonValid.msg = "请输入正确的手机号码";
                                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                                }
                                else
                                {
                                    if (formInt4 == -1)
                                    {
                                        ajaxJsonValid.msg = "请选择省份";
                                        context.Response.Write(ajaxJsonValid.SerializeToJson());
                                    }
                                    else
                                    {
                                        if (formInt5 == -1)
                                        {
                                            ajaxJsonValid.msg = "请选择城市";
                                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                                        }
                                        else
                                        {
                                            if (formInt6 == -1)
                                            {
                                                ajaxJsonValid.msg = "请选择地区";
                                                context.Response.Write(ajaxJsonValid.SerializeToJson());
                                            }
                                            else
                                            {
                                                if (string.IsNullOrEmpty(text3))
                                                {
                                                    ajaxJsonValid.msg = "请输入详细地址";
                                                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                                                }
                                                else
                                                {
                                                    if (awardInfo.Price > 20000000)
                                                    {
                                                        ajaxJsonValid.msg = "很抱歉，该商品暂停兑换！";
                                                        context.Response.Write(ajaxJsonValid.SerializeToJson());
                                                    }
                                                    else
                                                    {
                                                        UserInfo userInfo = FacadeManage.aideAccountsFacade.GetUserGlobalInfo(formInt, 0, "").EntityList[0] as UserInfo;
                                                        int num = awardInfo.Price * formInt3;
                                                        if (num > userInfo.UserMedal)
                                                        {
                                                            ajaxJsonValid.msg = "很抱歉！您的元宝数不足，不能兑换该奖品";
                                                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                                                        }
                                                        else
                                                        {
                                                            if (awardInfo.Inventory <= formInt3)
                                                            {
                                                                ajaxJsonValid.msg = "很抱歉！奖品的库存数不足，请更新其他奖品或者等待补充库存";
                                                                context.Response.Write(ajaxJsonValid.SerializeToJson());
                                                            }
                                                            else
                                                            {
                                                                userInfo.UserMedal -= num;
                                                                AwardOrder awardOrder = new AwardOrder();
                                                                awardOrder.UserID = userInfo.UserID;
                                                                awardOrder.AwardID = formInt2;
                                                                awardOrder.AwardPrice = awardInfo.Price;
                                                                awardOrder.AwardCount = formInt3;
                                                                awardOrder.TotalAmount = num;
                                                                awardOrder.Compellation = text;
                                                                awardOrder.MobilePhone = text2;
                                                                awardOrder.QQ = "";
                                                                awardOrder.Province = formInt4;
                                                                awardOrder.City = formInt5;
                                                                awardOrder.Area = formInt6;
                                                                awardOrder.DwellingPlace = text3;
                                                                awardOrder.PostalCode = "";
                                                                awardOrder.BuyIP = Utility.UserIP;
                                                                message = FacadeManage.aideNativeWebFacade.BuyAward(awardOrder);
                                                                if (message.Success)
                                                                {
                                                                    ajaxJsonValid.SetValidDataValue(true);
                                                                    ajaxJsonValid.msg = "恭喜您！兑换成功";
                                                                    awardOrder = (message.EntityList[0] as AwardOrder);
                                                                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                                                                }
                                                                else
                                                                {
                                                                    ajaxJsonValid.msg = message.Content;
                                                                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static Message CheckingRealNameFormat(string realName, bool isAllowNull)
        {
            Message message = new Message();
            Message result;
            if (isAllowNull && string.IsNullOrEmpty(realName))
            {
                result = message;
            }
            else
            {
                if (!isAllowNull && string.IsNullOrEmpty(realName))
                {
                    message.Success = false;
                    message.Content = "真实姓名不能为空";
                    result = message;
                }
                else
                {
                    if (realName.Length > 16)
                    {
                        message.Success = false;
                        message.Content = "真实姓名太长";
                        result = message;
                    }
                    else
                    {
                        result = message;
                    }
                }
            }
            return result;
        }
        public static Message CheckingQQFormat(string qq, bool isAllowNull)
        {
            Message message = new Message();
            Message result;
            if (isAllowNull && string.IsNullOrEmpty(qq))
            {
                result = message;
            }
            else
            {
                if (!isAllowNull && string.IsNullOrEmpty(qq))
                {
                    message.Success = false;
                    message.Content = "QQ号码不能为空";
                    result = message;
                }
                else
                {
                    Regex regex = new Regex("^\\d{4,20}$");
                    if (!string.IsNullOrEmpty(qq) && !regex.IsMatch(qq))
                    {
                        message.Success = false;
                        message.Content = "QQ号码格式不对";
                        result = message;
                    }
                    else
                    {
                        result = message;
                    }
                }
            }
            return result;
        }
        public static Message CheckingMobilePhoneNumFormat(string mobilePhoneNum, bool isAllowNull)
        {
            Message message = new Message();
            Message result;
            if (isAllowNull && string.IsNullOrEmpty(mobilePhoneNum))
            {
                result = message;
            }
            else
            {
                if (!isAllowNull && string.IsNullOrEmpty(mobilePhoneNum))
                {
                    message.Success = false;
                    message.Content = "电话号码不能为空";
                    result = message;
                }
                else
                {
                    Regex regex = new Regex("^\\d{11}$", RegexOptions.Compiled);
                    if (!regex.IsMatch(mobilePhoneNum))
                    {
                        message.Success = false;
                        message.Content = "移动电话格式不正确";
                        result = message;
                    }
                    else
                    {
                        result = message;
                    }
                }
            }
            return result;
        }
    }
}

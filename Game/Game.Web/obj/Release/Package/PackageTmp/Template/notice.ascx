<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="/Template/Notice.ascx.cs" Inherits="Game.Web.Notice" %>
<!-- 公告栏start -->
<div class="notice">
    <div class="notice-info clearfix">
        <span class="fl notice-pic"></span>
        <div class="fl notice-list">
            <ul class="" id="bulletinBoard">
                <asp:Repeater ID="rptData" runat="server">
                    <ItemTemplate>
                        <li><%#Eval("Body") %></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
</div>
<!-- 公告栏end -->

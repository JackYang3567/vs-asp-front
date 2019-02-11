/**
 * Created by ouye-61 on 2017/5/19.
 */
 var tag;
 var public_scrop = {};
$(function(){ 
	// 导航栏切换
	$(".nav-info a:eq(" + tag + ")").addClass("active").siblings().removeClass("active");

}); 

var tabShow = function(tab, con, className) {
     tab.click(function(){
         var indx = tab.index(this);
         tab.removeClass(className);
         $(this).addClass(className);
         con.hide();
         con.eq(indx).show();
     })
 };

// 公告栏滚动
function bulletinBoardMove(obj) {
    var speed=-2;
    var oUl = $("#bulletinBoard")[0];
    if (oUl.offsetLeft < -(oUl.offsetWidth)) {
            oUl.style.left = 0;
    }
    if (oUl.offsetLeft > 0) {
        oUl.style.left = -(oUl.offsetWidth) + 'px';
    }
    oUl.style.left = oUl.offsetLeft + speed + 'px';
}
setInterval(bulletinBoardMove,30);//全局变量 ，保存返回的定时器

// 关闭页面底部的广告
public_scrop.advertisementClose = function(obj) {
	$(obj).parent().hide();
}
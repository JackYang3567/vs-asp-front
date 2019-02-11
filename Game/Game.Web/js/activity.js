/**
 * Created by ouye-61 on 2017/5/19.
 */
var tag = 4;
$(function(){ 
	// 子导航栏tab
	tabShow($(".activity-nav-tit li"),$(".activity-list-info"),"active");
}); 

 // "活动一览"－－点击图片时下面的内容展开与收起
$(".activity li[activity]").on("click", function () {
    $(this).find("div:first").slideToggle("slow").closest("li").siblings().children(".activety-list-alert").slideUp("slow");
});
/**
 * Created by ouye-61 on 2017/5/19.
 */
var tag = 0;
var scrop_index = {};
$(function(){ 
	// banner滚动
    scrop_index.banner = $("#full-screen-slider").banner({
        onBanner:function(pictureArray,pointArray){}
    });
    scrop_index.banner.bannerroll($('#slides li'),  $('.full-screen li'));

	//"热门游戏"图片滚动的调用left
	$(".hot-game-list div").jMarquee({ visible: 4, step: 2, direction: "left" });

	// 子导航栏tab
	tabShow($("#indexSubNavTab li"),$(".index-subnav-info"),"active");
}); 


/**
 * jQuery jslides 1.1.0
 *
 * http://www.cactussoft.cn
 *
 * Copyright (c) 2009 - 2013 Jerry
 *
 * Dual licensed under the MIT and GPL licenses:
 *   http://www.opensource.org/licenses/mit-license.php
 *   http://www.gnu.org/licenses/gpl.html
 */

$.extend($.fn, {
	banner:function(options){
		var defaults = {
			onBanner: function (picArray,pointArray) { }
		};
		var output = {};
		//计数器
		output.banner_index = 1;
		//自动轮播
		output.banner_time =null;
		var opts = $.extend(defaults, options);
		output.bannerroll=function(picArray,pointArray){
			//图片对象
			output.bpicArray=picArray;
			//图片按钮对象
			output.bpointArray=pointArray;
			//图片标题对象
			//output.contentArray=contentArray;
			//隐藏其他图片显示第一张图片
			output.bpicArray.eq(0).show().siblings().hide();
			output.bpointArray.eq(0).addClass("current").siblings().removeClass("current");
			output.banner_time=setInterval(banner_fn,3000);
			//圆点点击事件
			output.bpointArray.hover(function(){
				clearInterval(output.banner_time);
				banner(this);
			},function(){
				output.banner_index = $(this).index() + 1;
				output.banner_time = setInterval(banner_fn,3000);
			});
			output.bpicArray.hover(function(){
				clearInterval(output.banner_time);
				banner(this);
			},function(){
				output.banner_index = $(this).index() + 1;
				output.banner_time = setInterval(banner_fn,3000);
			});
		};
		function banner(obj){
			output.bpicArray.eq($(obj).index()).fadeIn("slow").siblings().fadeOut("slow");
			$(obj).addClass("current").siblings().removeClass("current");
		}
		function banner_fn(){
			if(output.banner_index >= output.bpicArray.length){
				output.banner_index = 0;
			}
			banner(output.bpointArray.eq(output.banner_index).first());
			output.banner_index++;
		}
		return output;
	}

});
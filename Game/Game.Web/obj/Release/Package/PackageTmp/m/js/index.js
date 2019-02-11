var on = 0;
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
setInterval(bulletinBoardMove,80);//全局变量 ，保存返回的定时器

// 弹窗弹出
$("#trustTutorial").on("click", function() {
    $(this).closest(".wrap").siblings().show("show");
})

// 弹窗关闭
$(".alert-list span").on("click", function() {
    $(this).closest(".alert-list").hide("show").siblings(".window-mask").hide();
})
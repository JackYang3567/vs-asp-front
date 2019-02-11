$(".linkback").on('click', function () {
    var e = document.getElementById("awardQqQun1");//对象是content
    e.select(); //选择对象
    document.execCommand("Copy"); //执行浏览器复制命令
    alert("链接复制成功！");
});
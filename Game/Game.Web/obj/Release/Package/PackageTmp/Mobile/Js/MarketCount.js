/**
 * Created by ouye-61 on 2017/2/25.
 */
var option = "0";
var ClassName = new Array("一级", "二级", "三级", "四级", "五级");

(function () {
    $("#btn_tiqu").bind("click", function () {
        if (confirm("您确定要提取码？")) {
            AjaxSubmit();
        }
    });
    AjaxGetData();
})(window);
//tab切换
function tabChange(obj, timespan) {
    option = timespan
    $(obj).addClass("active").siblings().removeClass("active");
    AjaxGetData();
}

//异步获取数据
function AjaxGetData() {
    $.post("/WS/Promoter.aspx", { action: "UserSpreadInfo", dtype: option }, function (data) {
        var jsonData = $.parseJSON(data);
        if (jsonData.code == -1) {
            document.write(jsonData.msg);
            return;
        }
        if (jsonData.code == 0) {
            var html = "";
            $.each(jsonData.data, function (i, item) {
                html += stringFormat("<tr>");
                html += stringFormat("<td><span>{0}</span></td>", ClassName[item.lev - 1]);
                html += stringFormat("<td><span>{0}</span></td>", item.ChildAllGx);
                html += stringFormat("<td><span>{0}</span></td>", item.Rate * 100 + '%');
                html += stringFormat("<td><span>{0}</span></td>", item.Myrev);
                html += "</tr>"
            })
            $('#market-list').html(html);
        }
    })
}
//异步提取金额
function AjaxSubmit() {
    var issubmit = true;
    var price = $("#glod").val();
    if (price == "") {
        $.dialog.alert("请输入提取金额！");
        issubmit = false;
    } else if (isNaN(parseFloat(price))) {
        $.dialog.alert("提取金额数据格式错误！");
        issubmit = false;
    } else if (parseFloat(price) <= 0) {
        $.dialog.alert("提取金额不能少于0！");
        issubmit = false;
    } else {
        $.post("/WS/Promoter.aspx", { action: "SpreadBalance", gold: price }, function (data) {
            var jsonData = $.parseJSON(data);
            if (jsonData.code == 0) {
                $.dialog.alert("提取成功，请到金库查收");
            } else {
                $.dialog.alert(jsonData.msg);
            }
        })
    }
}

//字符串格式化
function stringFormat() {
    if (arguments.length == 0)
        return null;
    var str = arguments[0];
    for (var i = 1; i < arguments.length; i++) {
        var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
        str = str.replace(re, arguments[i]);
    }
    return str;
}
/*
 *调用方式：$(分页父元素id).paging(请求地址，请求数据，列表展示函数给插件调用)
 *$("#pagebox").paging("www.aijia.com",{},pageList);
 */
$.extend($.fn, {
    paging:function(action,postData,pageList){//（请求地址，请求参数，列表展示函数）
        var that=$(this);
        var output={};
        var  pageCount = 120; //总页数
        var  pageIndex = 1;//当前页
        var  pageTotal =190;//总条数
        var pageperCount=20;//每页多少条
        //绑定插件初始加载第一页
        paginbyIndex(1);
        //分页获取数据的方法 
        function getData(index) { 
            postData.pageIndex = index;
            $.ajax({
                type: "post",
                dataType: "json",
                url: action, 
                async: false,
                data: postData, 
                ajaxStart: function () {
                },
                complete: function () { 
                }, 
                success: function (json) {
 
                    if (typeof (json) != "undefined") {
                        if (json.Code > 0) {
                            alert(json.Msg);
                            return;
                        }
                        pageTotal = json.Total;
                        pageCount = Math.ceil(pageTotal / pageperCount);
                        var d = json.Data;
 
                        var dtemp = []; 
                        for (var i = (index - 1) * pageperCount; i < index * pageperCount; i++)
                        {
 
 
                            if (i<pageTotal)
                            { 
 
 
                                dtemp.push(d[i]);
                            }
                        }  
                        pageList(d);
                    }
                }
            });
        }
        //下一页事件
        function nextPage(){
            if (pageIndex >= pageCount) {
                pageIndex = pageCount;
            } else {
                pageIndex++;
            }
            getData(pageIndex);
            creatPaginBar();
        }
        //上一页
        function upPage(){
            if (pageIndex == 1) {
                pageIndex = 1;
            } else {
                pageIndex--;
            }
            getData(pageIndex);
            creatPaginBar();
        }
        //当前页
        function paginbyIndex(index){
            pageIndex =  parseInt(index)>0 ? index : 1;
            getData(pageIndex);
            creatPaginBar();
        }
        function creatPaginBar(){
            $(that).html("");
            if(pageCount<=0){
                $(that).html("没有找到相应的数据");
                return ;
            }
            var html="";
            //如果当前页是第一页，则上一页不能操作
            if(pageIndex==1){
                html+= '<span class="page-up disable noClick" >上一页</span>';
            }else{
                html+= '<span class="page-up page-up-action" >上一页</span>';
            }
            if(pageCount<=8){
                //如果总页数小于等于8条，全部显示
                for(var i=1;i<=pageCount;i++){
                    if(pageIndex==i){
                        html+='<span class="page-show" data='+i+'>'+i+'</span>';
                    }else{
                        html+=' <span class="page-num" data='+i+'>'+i+'</span>';
                    }

                }
            }else{
                if(pageIndex<6){
                    //如果当前页少于6，前面显示6个
                    for(var i=1;i<=6;i++){
                        if(pageIndex==i){
                            html+='<span class="page-show" data='+i+'>'+i+'</span>';
                        }else{
                            html+=' <span class="page-num" data='+i+'>'+i+'</span>';
                        }
                    }
                    //第七个显示。。。
                    html+='<span class="diao">...</span>';
                    //最后一个
                    html+=' <span class="page-num" data='+pageCount+'>'+pageCount+'</span>';
                }else if(pageIndex>(pageCount-4)){
                    //如果当前页在最后的5个里，最后5个都显示
                    html+=' <span class="page-num page-first"  data="1" >'+1+'</span>';
                    html+=' <span class="page-num"  data="2" >'+2+'</span>';
                    html+='<span class="diao">...</span>';
                    for(var i=pageCount-4;i<=pageCount;i++){
                        if(i==pageIndex){
                            html+='<span class="page-show" data='+i+'>'+i+'</span>';
                        }else{
                            html+=' <span class="page-num" data='+i+'>'+i+'</span>';
                        }
                    }
                }else{
                    html+=' <span class="page-num" data="1">'+1+'</span>';
                    html+=' <span class="page-num" data="2">'+2+'</span>';
                    html+='<span class="diao">...</span>';
                    var q = pageIndex -1;
                    var h = pageIndex+1;
                    html+=' <span class="page-num"  data='+q+'>'+q+'</span>';
                    html+='<span class="page-show" data='+pageIndex+'>'+pageIndex+'</span>';
                    html+=' <span class="page-num" data='+h+'>'+h+'</span>';
                    //第七个显示。。。
                    html+='<span class="diao">...</span>';
                    //最后一个
                    html+=' <span class="page-num" data='+pageCount+'>'+pageCount+'</span>';
                }
            }
            //下一页
            if(pageIndex ==pageCount){//最后一页，不能操作
                html+= '<span class="page-next disable noClick" >下一页</span>';
            }else{
                html+= '<span class="page-next page-next-action" >下一页</span>';
            }
			html+='<span class="page-count">共'+pageCount+'页</span>';
            $(that).html(html);
            //上一页
            $(that).find(".page-up-action").on("click",function(){
                upPage();
            });
            //下一页
            $(that).find(".page-next-action").on("click",function(){
                nextPage();
            });
            //中间
            $(that).find(".page-num").on("click",function(){
                paginbyIndex(parseInt($(this).attr("data")));
            });
        }
        return output;
    }
});




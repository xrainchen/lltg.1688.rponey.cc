


//关闭iframe页面
var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
$(function () {
    //关闭iframe
    $('#Back').click(function () {
        //关闭弹出；
        parent.layer.close(index);
    });
});

function DoSubmitForm(formId, url) {
    try {
        if ($(formId).valid()) {
            $.post(url,
               $(formId).serialize(),// 你的formid
            function (data) {
                if (data.statusCode == 200) {
                    swal({
                        title: "提示",
                        text: data.message,
                        type: "success",
                        showCancelButton: false,
                        confirmButtonColor: "#DD6B55",
                        confirmButtonText: "确定",
                        closeOnConfirm: true
                    }, function () {
                        window.parent.refreshPage();
                        //关闭弹出；
                        parent.layer.close(index);
                    });
                   // window.parent.refreshPage();
                    //关闭弹出；
                  //  parent.layer.close(index);
                    //并且调用父窗口JS方法页面刷新列表
                }
                else {
                    swal({
                        title: "提示",
                        text: data.message,
                        type: "error"
                    });
                }
            }, "json");
        }
    } catch (e) {
        swal({
            title: "提示",
            text: e.message,
            type: "error"
        });
    }
}

function refreshPage() {
    $(".btn-primary").click();
}

//显示服务端页面
function ShowPage(url,area,title) {
    //屏蔽浏览器滚动条
    layer.open({
        type: 2,
        area: area,
        title: title,
        fixed: false, //不固定
        maxmin: true,
        content: url
    });
}

//执行服务端方法
function DoAction(url, tipInfo) {
    swal({
        title: "提示",
        text: tipInfo,
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            url: url,
            type: "post",
            success: function (data) {
                if (data.statusCode == 200) {
                    swal({
                        title: "成功",
                        text: data.message,
                        type: "success",
                        showCancelButton: false,
                        confirmButtonColor: "#DD6B55",
                        confirmButtonText: "确定",
                        closeOnConfirm: true
                    }, function () {
                        refreshPage();
                    });
                } else {
                    swal("失败", data.message, "error");
                }
            }
        });
    });
}

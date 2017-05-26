//关闭iframe页面
var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
$(function () {
    //关闭iframe
    $('#Back').click(function () {
        //关闭弹出；
        parent.layer.close(index);
    });
});

function DoAjaxPostSubmitForm(form) {
    try {
        if ($(form).valid()) {
            var url = $(form).attr("action");
            $.post(url,$(form).serialize(),function (data) {
                if (data.statusCode === 200) {
                    parent.parent.toastr.success(data.message);
                    parent.layer.close(index);
                    try {
                        parent.window.location.reload();
                    } catch (e) {
                        console.log(e);
                    } 
                }
                else {
                    toastr.warning(data.message);
                }
            }, "json");
        }
    } catch (e) {
        toastr.warning(e.message);
    }
    return false;
}

function refreshPage() {
    $(".btn-primary").click();
}

//显示服务端页面
function ShowPage(url, area, title) {
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
        title:'',
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
                if (data.statusCode === 200) {
                    swal({
                        title: '',
                        text: data.message,
                        type: "success"
                    },function() {
                        window.location.reload();;
                    });
                }
                else {
                    toastr.warning(data.message);
                }
            }
        });
    });
}
function DoAction(url, tipInfo,data) {
    swal({
        title: '',
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
            data:data,
            success: function (data) {
                if (data.statusCode === 200) {
                    swal({
                        title: '',
                        text: data.message,
                        type: "success"
                    }, function () {
                        window.location.reload();;
                    });
                }
                else {
                    toastr.warning(data.message);
                }
            }
        });
    });
}

﻿$(function () {
    try {
        if (window.parent.closewave && typeof (window.parent.closewave) == "function") {
            window.parent.closewave();
        }
    } catch (e) {
        alert("检测window.parent.closewave是否存在发生异常！");
    }
})
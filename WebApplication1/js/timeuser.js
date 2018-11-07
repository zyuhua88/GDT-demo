(function ($) {
    funObj = { timeUserFun: 'timeUserFun', }

    $[funObj.timeUserFun] = function (time, us_id) {
        var time = time || 2;
        var userTime = time * 60;
        var usid = us_id;
        var objTime = {
            init: 0,
            time: function () {
                objTime.init += 1;
                if (objTime.init == userTime) {
                    console.log(111) // 用户到达未操作事件 做一些处理
                } else {
                    ajaxs();
                }
            },
            eventFun: function () {
                clearInterval(testUser);
                objTime.init = 0;
                testUser = setInterval(objTime.time, 1000);
            }
        }
        var testUser = setInterval(objTime.time, 1000);
        var body = document.querySelector('html');
        body.addEventListener("click", objTime.eventFun);
        body.addEventListener("keydown", objTime.eventFun);
        body.addEventListener("mousemove", objTime.eventFun);
        body.addEventListener("mousewheel", objTime.eventFun);
    }
})(window);

function ajaxs() {
    $.ajax({
        url: "http://localhost:57319/api/users/gdt/on_line?us_id=" + usid,
        type: "post",
        contentType: "application/json",
        success: function () { }
    });
}


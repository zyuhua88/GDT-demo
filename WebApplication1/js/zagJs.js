///使用前请先引用jquery
function http(url,method,data,func) {
    $.ajax({
        url: url,
        type: method,
        contentType: "application/json",
        data: data,
        success: function (res) {
            return typeof func === 'function' && func(res);
        }
    })
}

///同步
function https(url, method, data, func) {
    $.ajax({
        url: url,
        type: method,
        async: false,
        contentType: "application/json",
        data: data,
        success: function (res) {
            return typeof func === 'function' && func(res);
        }
    })
}


////遍历JSON数据
function fors(target, json) {
    var t = document.getElementById(target);
    var html = "";
    var html2 = "";

    for (var i = 0; i < json.length; i++){
        var html1 = t.innerHTML;
        for (var item in json[i]) {
            var reg = new RegExp("{{" + item + "}}", "g");
            var text = json[i][item];
            if (json[i][item] === null || json[i][item]==="") {
                text = "";
            }
            html = html1.replace(reg, text);
            html1 = html;
        }
        
        html2 += html;
    }
    t.innerHTML = html2;
}

//时间戳转换成日期
function timestampToTime(timestamp) {
    var date = new Date(timestamp * 1000);//时间戳为10位需*1000，时间戳为13位的话不需乘1000
    Y = date.getFullYear() + '-';
    M = (date.getMonth() + 1 < 10 ? '0' + (date.getMonth() + 1) : date.getMonth() + 1) + '-';
    D = date.getDate() + ' ';
    h = date.getHours() + ':';
    m = date.getMinutes() + ':';
    s = date.getSeconds();
    return Y + M + D + h + m + s;
}
//时间戳转换成日期
function timestampToTime2(timestamp) {
    var date = new Date(timestamp * 1000);//时间戳为10位需*1000，时间戳为13位的话不需乘1000
    Y = date.getFullYear() + '-';
    M = (date.getMonth() + 1 < 10 ? '0' + (date.getMonth() + 1) : date.getMonth() + 1) + '-';
    D = date.getDate() + ' ';
    return Y + M + D;
}

///获取url参数的方法
function getParameter(name) {

    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");

    var r = window.location.search.substr(1).match(reg);

    if (r !== null) return unescape(r[2]);
    return "";

} 

function bindForm(data) {
    
    for (var i in data) {
        for (var item in data[i]) {
            $("input:text").each(function (index, items) {
                if ($(this).attr('name') === item) {
                    $(this).val(data[i][item]);
                }
            })
            $(":radio[name='" + item + "'][value='" + data[i][item] + "']").attr("checked", true);

            $("textarea").each(function (index, items) {
                if ($(this).attr('name') === item) {
                    $(this).val(data[i][item]);
                }
            })
            $("select").each(function (index, items) {
                if ($(this).attr('name') === item) {
                    $(this).val(data[i][item]);
                }
            })
        }
    }
    
}

function setData() {
    var d = {};
    $("input").each(function (index, items) {
        if ($(this).attr("type") === 'radio') {
            d[$(this).attr("name")] = $('input:radio[name="' + $(this).attr("name") + '"]:checked').val()
        } else {
            d[$(this).attr("name")] = $(this).val();
        }
    })
    $("select").each(function (index, items) {
        d[$(this).attr("name")] = $(this).val()
    })
    
    $("textarea").each(function (index, items) {
        d[$(this).attr("name")] = $(this).val()
    })
    
    return d;
}



function setTarget() {
    var cachehtml = document.getElementById("body").innerHTML;
    var body = cachehtml.toString();
    for (var item in page) {
        var r = RegExp("{{" + item + "}}", "g");
        var key = item;
        var p = page[key];
        var t = "\{{" + item + "}}";
        body.replace(t, p);
    }
    document.getElementById("body").innerHTML = body;
}


window.myStorage = (new (function () {
    var storage;
    if (window.localStorage) {
        storage = localStorage;
    } else {
        storage = cookieStorage;
    }
    this.setItem = function (key, value) {
        storage.setItem(key, value);
    }
    this.getItem = function (key) {
        return storage.getItem(key);
    }
    this.removeItem = function (key) {
        storage.removeItem(key);
    }
    this.clear = function () {
        storage.clear();
    }
})());
layui.use(['jquery'], function () {
        $ = layui.jquery;
        var item = location.href.split("/");
        var isLoginView = item[item.length - 1].toLowerCase() == "login" ? true : false;//是否是登录界面
        var storageMsg = localStorage.getItem("LicenseInfo");
        let autJson1 = JSON.parse(storageMsg);
        //伪造或者不存在授权信息---自动至登录页面
        if (storageMsg == null || autJson1["expired-date"] == undefined ||
            autJson1["expired-time"] == undefined || autJson1["access-token"] == undefined ||
            autJson1["x-access-token"] == undefined) {
            if (isLoginView) return;
            location.href = "/home/login";
        }
        //拦截所有的授权头-并添加相应的头文件
        $.ajaxPrefilter(function (options) {
            let curstorage = localStorage.getItem("LicenseInfo");
            let autJson = JSON.parse(curstorage);
            console.log(options.url.toLowerCase());
            let curdata = new Date();
            let aut = 'Bearer ' + autJson["access-token"];
            //console.log(curdata);
            if (!options.beforeSend) {
                if (curstorage == null || autJson["expired-date"] == undefined ||
                    autJson["expired-time"] == undefined || autJson["access-token"] == undefined ||
                    autJson["x-access-token"] == undefined) {
                    if (isLoginView) return;
                    location.href = "/home/login";
                }
                else {
                    if (new Date(autJson["expired-date"]) >= curdata) {
                        options.beforeSend = function (xhr) {
                            xhr.setRequestHeader('Authorization', aut);
                        }
                    }
                    else {
                        let refaut = 'Bearer ' + autJson["x-access-token"];
                        options.beforeSend = function (xhr) {
                            xhr.setRequestHeader('Authorization', aut);
                            xhr.setRequestHeader('x-Authorization', refaut);
                        }  
                    }
                }

            }
        });
    
    //授权信息过期，刷新token并更新存取信息-所有的ajax增加授权
    //拦截ajax结果,异常跳转至异常提示
    $.ajaxSetup({
        complete: function (XMLHttpRequest, textStatus) {
            let refreshToken = XMLHttpRequest.getResponseHeader('x-access-token');
            let token = XMLHttpRequest.getResponseHeader('access-token');

            if (textStatus == "success" && token != null && refreshToken != null
                && token != undefined && refreshToken != undefined) {
                let curdate = new Date();
                let expiretime = JSON.parse(localStorage.getItem("LicenseInfo"))["expired-time"];
                let refreshAut = {
                    'expired-date': new Date(curdate.setMinutes(curdate.getMinutes() + expiretime)),
                    'expired-time': expiretime,
                    'access-token': token,
                    'x-access-token': refreshToken
                };

                localStorage.setItem("LicenseInfo", JSON.stringify(refreshAut));
            }
            //console.log(XMLHttpRequest + "---" + textStatus)
        }
    });
    refreshToken(isLoginView);
    });


function refreshToken(isLoginView, expiretime = null) {
    $.ajax({
        url: "/getLoginUser",
        type: "Get",
        success: function (json, status, req) {
            //console.log(json);
            if (json.success && json.code===200) {
                if (isLoginView) {
                    location.href = "/Home";
                } else {
                    //$("#userName").html(json.data.name);
                }
            }
            else {
                if (isLoginView) {
                    location.href = "/home/login";
                }                 
            }
        }
    });
}


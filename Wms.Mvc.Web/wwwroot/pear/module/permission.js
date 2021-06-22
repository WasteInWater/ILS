layui.define(['jquery','context','popup'], function(exports) {
	"use strict";

	var MOD_NAME = 'permission',
		$ = layui.jquery,
		popup = layui.popup,
		context = layui.context;

	var permission = new function() {}
	
	var curWwwPath = window.document.location.href;
	var pathName = window.document.location.pathname;
	var pos = curWwwPath.indexOf(pathName);
	var localhostPath = curWwwPath.substring(0, pos);
	
	var basePath = localhostPath + "/";

	var isloginView = pathName.toLowerCase() === "/home/login" ? true : false;

	var curstorage = context.get("LicenseInfo");
	var autJson = JSON.parse(curstorage);
	if (curstorage == null || curstorage == undefined
		|| autJson["expired-date"] == undefined ||
		autJson["expired-time"] == undefined || autJson["access-token"] == undefined ||
		autJson["x-access-token"] == undefined) {
		if (!isloginView) {
			popup.failure("暂未认证，请前往登录", function () {
				top.location.href = basePath + 'Home/Login';
			})
        }
	}

	//拦截所有的授权头-并添加相应的头文件
	$.ajaxPrefilter(function (options) {
		let curstorage = context.get("LicenseInfo");
		let autJson = JSON.parse(curstorage);
		
		let curdata = new Date();
		let aut = 'Bearer ' + autJson["access-token"];
		
		if (!options.beforeSend) {
			if (curstorage == null || autJson["expired-date"] == undefined ||
				autJson["expired-time"] == undefined || autJson["access-token"] == undefined ||
				autJson["x-access-token"] == undefined) {
				if (isloginView) return;
				top.location.href = basePath + 'Home/Login';
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
	$.ajaxSetup({
		cache: false,
		complete: function (xhr, textStatus) {
			let refreshToken = xhr.getResponseHeader('x-access-token');
			let token = xhr.getResponseHeader('access-token');
			console.log(xhr);
			if (xhr.responseJSON.code == 401) {
				popup.failure("暂未认证，请前往登录", function () {
					top.location.href = basePath + 'Home/Login';
				})
			}
			else if (textStatus == "success" && token != null && refreshToken != null
				&& token != undefined && refreshToken != undefined) {
				let curdate = new Date();
				let expiretime = JSON.parse(context.get("LicenseInfo"))["expired-time"];
				let refreshAut = {
					'expired-date': new Date(curdate.setMinutes(curdate.getMinutes() + expiretime)),
					'expired-time': expiretime,
					'access-token': token,
					'x-access-token': refreshToken
				};
				context.put("LicenseInfo", JSON.stringify(refreshAut));
            }
	    }
	});
	exports(MOD_NAME, permission);
});

using Furion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wms.Core;

namespace Wms.Mvc.Web.Controllers
{
    public class HomeController : Controller
    {
        //[SecurityDefine("WS.Home.Index")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Config()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Error()
        {
            var m = HttpContext;
            ViewData["StatusCode"] = HttpContext.Response.StatusCode;


            return View();
        }
        /// <summary>
        /// 获取缓存验证码并写入至cookies中
        /// </summary>
        [AllowAnonymous]
        public void Vcode()
        {
            var bgImg = Path.Combine(App.WebHostEnvironment.WebRootPath, "admin/images/captcha.gif");
            System.IO.MemoryStream ms = ToolVcode.GetValidateImg(out string code, bgImg);
            Response.Cookies.Append("ws.Vcode", code, new CookieOptions() { Expires = DateTime.Now.AddMinutes(3) });

            Response.ContentType = "image/jpeg";
            Response.Body.WriteAsync(ms.GetBuffer(), 0, (int)ms.Length);
            Response.Body.DisposeAsync();
            
        }
        /// <summary>
        /// 验证验证码是否正确
        /// </summary>
        /// <param name="vcode">用户输入验证码</param>
        /// <returns></returns>
        [AllowAnonymous]
        public bool VertifyVcode([FromQuery]string vcode)
        {
            HttpContext.Request.Cookies.TryGetValue("ws.Vcode", out string vcodeCache);
            
            if (string.Compare(vcode.Trim(),vcodeCache,StringComparison.OrdinalIgnoreCase)==-1||string.IsNullOrEmpty(vcodeCache)|| string.IsNullOrEmpty(vcode))
            {
                return false;
            }
            return true;
        }
    }
}

using Furion.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Wms.Core.Service
{
    /// <summary>
    /// 用户登录输出参数
    /// </summary>
    [SkipScan]
    public class LoginOutput
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTimeOffset Birthday { get; set; }

        /// <summary>
        /// 性别(字典 1男 2女)
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public String Phone { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public String Tel { get; set; }

        /// <summary>
        /// 管理员类型（0超级管理员 1非管理员）
        /// </summary>
        public int AdminType { get; set; }

        /// <summary>
        /// 最后登陆IP
        /// </summary>
        public string LastLoginIp { get; set; }

        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public DateTimeOffset LastLoginTime { get; set; }

        /// <summary>
        /// 最后登陆地址
        /// </summary>
        public string LastLoginAddress { get; set; }

        /// <summary>
        /// 最后登陆所用浏览器
        /// </summary>
        public string LastLoginBrowser { get; set; }

        /// <summary>
        /// 最后登陆所用系统
        /// </summary>
        public string LastLoginOs { get; set; }

        /// <summary>
        /// 员工信息
        /// </summary>
        public EmpOutput LoginEmpInfo { get; set; } = new EmpOutput();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wms.Core
{
    public abstract class LayuiPageInput
    {
        [Required(ErrorMessage ="页码不能为空"),Range(1,int.MaxValue,ErrorMessage =("页码只能在1-2147483647之间有效"))]
        public virtual int PageIndex { get; set; } = 1;

        [Required(ErrorMessage = "页码容量不能为空"), Range(5, 200, ErrorMessage = ("页码容量介于5-200之间有效"))]
        public virtual int PageSize { get; set; } = 20;

        public virtual string SearchBeginTime { get; set; }

        public virtual string SearchEndTime { get; set; }
    }

    /// <summary>
    /// 通用输入扩展参数（带权限）
    /// </summary>
    public class GrantInputBase : LayuiPageInput
    {
        /// <summary>
        /// 授权菜单
        /// </summary>
        public List<long> GrantMenuIdList { get; set; } = new List<long>();

        /// <summary>
        /// 授权角色
        /// </summary>
        public virtual List<long> GrantRoleIdList { get; set; } = new List<long>();

        /// <summary>
        /// 授权数据
        /// </summary>
        public virtual List<long> GrantOrgIdList { get; set; } = new List<long>();
    }
}

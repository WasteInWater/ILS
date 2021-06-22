using System.Collections.Generic;

namespace Wms.Core.Service
{
    public class LayuiMenu
    {
        /// <summary>
        ///  菜单主键Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Href { get; set; }
        /// <summary>
        /// 打开方式
        /// </summary>
        public string OpenType { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 子级菜单
        /// </summary>
        public List<LayuiMenu> Children { get; set; }
    }
}

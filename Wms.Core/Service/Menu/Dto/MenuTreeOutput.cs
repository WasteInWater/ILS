using System.Collections;
using System.Collections.Generic;

namespace Wms.Core.Service
{
    /// <summary>
    /// 菜单树---授权、新增编辑时选择
    /// </summary>
    public class MenuTreeOutput : ITreeNode
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 父Id
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 是否为结尾
        /// </summary>
        public bool Last { get; set; }
  
        /// <summary>
        /// 子节点
        /// </summary>
        public List<MenuTreeOutput> Children { get; set; } = new List<MenuTreeOutput>();

        public long GetId()
        {
            return Id;
        }

        public long GetPid()
        {
            return ParentId;
        }

        public void SetChildren(IList children)
        {
            Children = (List<MenuTreeOutput>)children;
        }
    }
}

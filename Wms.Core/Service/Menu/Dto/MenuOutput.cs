using System.Collections;
using System.Collections.Generic;

namespace Wms.Core.Service
{
    /// <summary>
    /// 菜单树（列表形式）
    /// </summary>
    public class MenuOutput : MenuInput 
    {
        /// <summary>
        /// 菜单Id
        /// </summary>
        public long Id { get; set; }
    }
}

using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Wms.Core.SeedData
{
    public class SysRoleMenuSeedData : IEntitySeedData<SysRoleMenu>
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="dbContextLocator"></param>
        /// <returns></returns>
        public IEnumerable<SysRoleMenu> HasData(DbContext dbContext, Type dbContextLocator)
        {
            return new[]
            {
                new SysRoleMenu{ SysRoleId=142307070910554, SysMenuId=142307070910560 },
                new SysRoleMenu{ SysRoleId=142307070910554, SysMenuId=142307070910561 },
                new SysRoleMenu{ SysRoleId=142307070910554, SysMenuId=142307070910562 },
            };
        }
    }
}

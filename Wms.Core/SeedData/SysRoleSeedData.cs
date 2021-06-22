using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Wms.Core
{
    /// <summary>
    /// 系统角色表种子数据
    /// </summary>
    public class SysRoleSeedData : IEntitySeedData<SysRole>
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="dbContextLocator"></param>
        /// <returns></returns>
        public IEnumerable<SysRole> HasData(DbContext dbContext, Type dbContextLocator)
        {
            return new[]
            {
                new SysRole{ Id=142307070910554, Name="系统管理员", Code="sys_manager_role", Sort=100, DataScopeType=1, Remark="系统管理员", Status=0 }, 
            };
        }
    }
}

using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Wms.Core
{
    /// <summary>
    /// 系统应用表种子数据
    /// </summary>
    public class SysAppSeedData : IEntitySeedData<SysApp>
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="dbContextLocator"></param>
        /// <returns></returns>
        public IEnumerable<SysApp> HasData(DbContext dbContext, Type dbContextLocator)
        {
            return new[]
            {
                new SysApp{Id=142307070902341, Name="系统管理", Code="system_manage", Active="Y", Status=0, Sort=100 },
                new SysApp{Id=142307070922869, Name="业务应用", Code="busapp", Active="N", Status=0, Sort=200 },
            };
        }
    }
}

using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Wms.Core
{
    /// <summary>
    /// 系统员工表种子数据
    /// </summary>
    public class SysEmpSeedData : IEntitySeedData<SysEmp>
    {
        /// <summary>
        /// 员工种子数据
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="dbContextLocator"></param>
        /// <returns></returns>
        public IEnumerable<SysEmp> HasData(DbContext dbContext, Type dbContextLocator)
        {
            return new[]
            {
                new SysEmp{ Id=142307070910551, JobNum="D1001", OrgId=142307070910539, OrgName="WS集团" },
                new SysEmp{ Id=142307070910552, JobNum="D1002", OrgId=142307070910539, OrgName="WS集团" },

            };
        }
    }
}

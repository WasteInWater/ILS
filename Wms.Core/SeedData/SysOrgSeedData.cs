using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Wms.Core
{
    /// <summary>
    /// 系统机构表种子数据
    /// </summary>
    public class SysOrgSeedData : IEntitySeedData<SysOrg>
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="dbContextLocator"></param>
        /// <returns></returns>
        public IEnumerable<SysOrg> HasData(DbContext dbContext, Type dbContextLocator)
        {
            return new[]
            {
                new SysOrg{ Id=142307070910539, Pid=0, Pids="[0],", Name="艾米集团", Code="amjt", Sort=100, Remark="华夏集团", Status=0 },
                new SysOrg{ Id=142307070910540, Pid=142307070910539, Pids="[0],[142307070910539],", Name="ws公司", Code="amjt_bj", Sort=100, Remark="ws公司", Status=0 },
          
            };
        }
    }
}

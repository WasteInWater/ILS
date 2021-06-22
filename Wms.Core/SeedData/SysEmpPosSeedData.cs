﻿using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Wms.Core
{
    /// <summary>
    /// 系统员工职位表种子数据
    /// </summary>
    public class SysEmpPosSeedData : IEntitySeedData<SysEmpPos>
    {
        /// <summary>
        /// 员工种子数据
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="dbContextLocator"></param>
        /// <returns></returns>
        public IEnumerable<SysEmpPos> HasData(DbContext dbContext, Type dbContextLocator)
        {
            return new[]
            {
                new SysEmpPos{SysEmpId=142307070910551, SysPosId=142307070910550 },
                new SysEmpPos{SysEmpId=142307070910551, SysPosId=142307070910548 },
                new SysEmpPos{SysEmpId=142307070910552, SysPosId=142307070910549 },
                
            };
        }
    }
}

﻿using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Wms.Core
{
    /// <summary>
    /// 系统职位表种子数据
    /// </summary>
    public class SysPosSeedData : IEntitySeedData<SysPos>
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="dbContextLocator"></param>
        /// <returns></returns>
        public IEnumerable<SysPos> HasData(DbContext dbContext, Type dbContextLocator)
        {
            return new[]
            {
                new SysPos{ Id=142307070910547, Name="总经理", Code="zjl", Sort=100, Remark="总经理", Status=0 },
                new SysPos{ Id=142307070910548, Name="副总经理", Code="fzjl", Sort=101, Remark="副总经理", Status=0 },
                new SysPos{ Id=142307070910549, Name="部门经理", Code="bmjl", Sort=102, Remark="部门经理", Status=0 },
                new SysPos{Id=142307070910550, Name="开发项目组", Code="gzry", Sort=103, Remark="工作人员", Status=0 },
            };
        }
    }
}

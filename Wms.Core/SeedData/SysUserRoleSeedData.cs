﻿using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Wms.Core.SeedData
{
    public class SysUserRoleSeedData : IEntitySeedData<SysUserRole>
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="dbContextLocator"></param>
        /// <returns></returns>
        public IEnumerable<SysUserRole> HasData(DbContext dbContext, Type dbContextLocator)
        {
            return new[]
            {
                new SysUserRole{SysUserId=142307070910552, SysRoleId=142307070910554 }
            };
        }
    }
}

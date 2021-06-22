using Furion;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;
using Wms.Core;
using Yitter.IdGenerator;

namespace Wms.EntityFramework.Core
{
    [AppDbContext("ILSConnectionString", DbProvider.SqlServer)]
    public class DefaultDbContext : AppDbContext<DefaultDbContext>, IModelBuilderFilter
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {

        }

        public void OnCreating(ModelBuilder modelBuilder, EntityTypeBuilder entityBuilder, DbContext dbContext, Type dbContextLocator)
        {//// 设置软删除表达式
            var expression = base.FakeDeleteQueryFilterExpression(entityBuilder, dbContext);
            if (expression == null) return;

            entityBuilder.HasQueryFilter(expression);
        }
        protected override void SavingChangesEvent(DbContextEventData eventData, InterceptionResult<int> result)
        {
            // 获取当前事件对应上下文
            var dbContext = eventData.Context;
            // 获取所有更改，删除，新增的实体，但排除审计实体（避免死循环）
            var entities = dbContext.ChangeTracker.Entries()
                                    .Where(u => u.Entity.GetType() != typeof(SysLogAudit) && u.Entity.GetType() != typeof(SysLogOp) && u.Entity.GetType() != typeof(SysLogVis) &&
                                          (u.State == EntityState.Modified || u.State == EntityState.Deleted || u.State == EntityState.Added))
                                    .ToList();
            if (entities == null || entities.Count < 1) return;


            // 当前操作者信息
            var userId = App.User.FindFirst(ClaimConst.Claim_UserId)?.Value;

            foreach (var entity in entities)
            {
                if (entity.Entity.GetType().IsSubclassOf(typeof(DEntityBase)))
                {
                    var obj = entity.Entity as DEntityBase;
                    if (entity.State == EntityState.Added)
                    {
                        obj.Id = YitIdHelper.NextId();
                        obj.CreatedTime = DateTimeOffset.Now;
                        if (!string.IsNullOrEmpty(userId))
                        {
                            obj.CreatedUserId = long.Parse(userId);
                        }
                    }
                    else if (entity.State == EntityState.Modified)
                    {
                        obj.ModifyTime = DateTimeOffset.Now;
                        obj.ModifyUserId = long.Parse(userId);
                    }
                }
            }
        }


    }
}

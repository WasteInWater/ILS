using Furion;
using Furion.DatabaseAccessor;
using Microsoft.Extensions.DependencyInjection;


namespace Wms.EntityFramework.Core
{
    [AppStartup(95)]
    public class Startup: AppStartup
    {
        public  void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseAccessor(options =>
            {
                options.AddDbPool<DefaultDbContext>(DbProvider.SqlServer);
            }, "Wms.Database.Migrations");

        }
    }
}

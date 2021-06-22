using Furion;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Text.Json;
using Wms.Core;
using Wms.Web.Core.AuthHandlers;
using Yitter.IdGenerator;

namespace Wms.Web.Core
{
    [AppStartup(100)]
    public class Startup: AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddRemoteRequest();
            services.AddConfigurableOptions<CacheOptions>();
            services.AddJwt<JwtHandler> (enableGlobalAuthorize:true)
                .AddCookie();


            services.AddControllersWithViews(o=> {
                o.EnableEndpointRouting = false;
            }).AddRazorRuntimeCompilation()
                .AddMvcFilter<RequestActionHandler>()
                .AddInjectWithUnifyResult<RestfulResultProvider>()
                .AddJsonOptions(options =>
                {
                    //options.JsonSerializerOptions.DefaultBufferSize = 10_0000;//返回较大数据数据序列化时会截断，原因：默认缓冲区大小（以字节为单位）为16384。
                    options.JsonSerializerOptions.Converters.AddDateFormatString("yyyy-MM-dd HH:mm:ss");
                    
                });
            services.AddSignalR();
            var workerId = ushort.Parse(App.Configuration["SnowId:WorkerId"] ?? "1");
            YitIdHelper.SetIdGenerator(new IdGeneratorOptions { WorkerId = workerId });

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseUnifyResultStatusCodes();
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            //app.UseCookiePolicy();
            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseInject();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<SignalRHub>("/SignalRHub");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

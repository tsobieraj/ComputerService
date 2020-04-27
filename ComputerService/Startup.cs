using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerService
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            Globals.EMAIL = _config["ConnectionStrings:Email"];
            Globals.EMAIL_PASSWORD = _config["ConnectionStrings:EmailPassword"];

            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=ItemDB;Trusted_Connection=true"));
            //services.BuildServiceProvider().GetService<AppDbContext>().Database.Migrate();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.SignIn.RequireConfirmedEmail = true;

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.AddMvc(options => {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddXmlSerializerFormatters();

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = "488660029477-25453oq62ni28klb0fgj3avmapldenip.apps.googleusercontent.com";
                    options.ClientSecret = "Q2PgSRkcBhiZd9B4ChvANihj";
                })
                .AddFacebook(options =>
                {
                    options.AppId = "1024172041299511";
                    options.AppSecret = "19b4351345af0bf2730b8941b1e69283";
                });


            services.AddScoped<IItemRepository, SQLItemRepository>();
            services.AddScoped<IEntryRepository, SQLEntryRepository>();
            services.AddScoped<IOrderRepository, SQLOrderRepository>();
            services.AddScoped<IOrderItemRepository, SQLOrderItemRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            HttpHelper.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseSession();
            app.UseStaticFiles();
            app.UseAuthentication();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}

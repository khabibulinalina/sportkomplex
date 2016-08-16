using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sportcomplex.Data;
using Sportcomplex.Models;
using Sportcomplex.Cartline;
using Microsoft.AspNetCore.Identity;

namespace Sportcomplex
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddMvc();
            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddMemoryCache();
            services.AddSession();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Main/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();
            app.UseSession();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Mains}/{action=Index}/{id?}");
            });

            using (var serviceScope = app.ApplicationServices  // Создаем Service Scope для инициализации всех сервисов
                    .GetRequiredService<IServiceScopeFactory>()
                    .CreateScope())
            {  // Получаем экземпляр ApplcationDbContext из ServiceProvider-а
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                // Применяем непримененные миграции
                    context.Database.Migrate();
                // Получаем RoleManager
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                // Проверяем, есть ли роль Admins. Если нет - добавляем.
                var admins = roleManager.FindByNameAsync("Admins").Result;
                if (admins == null)
                {
                   var roleResult = roleManager.CreateAsync(new IdentityRole("Admins")).Result;
                }
                var users = roleManager.FindByNameAsync("Users").Result;
                if (users == null)
                {
                    var roleResult = roleManager.CreateAsync(new IdentityRole("Users")).Result;
                }
                // Получаем UserManager
                var userManager =
               serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
                // Проверяем, есть ли пользователь
               var admin = userManager.FindByNameAsync("admin@csdevents.com").Result;
                if (admin == null)
                {                  // Если нет - создаем
                  var userResult = userManager.CreateAsync(new ApplicationUser
                    {
                        UserName = "admin@csdevents.com",
                        Email = "admin@csdevents.com"
                    }, "AdminPass123!").Result;
                    admin = userManager.FindByNameAsync("admin@csdevents.com").Result;
                    // И добавляем ему роль Admins
                    userManager.AddToRoleAsync(admin, "Admins").Wait();
                }
            }  //Alina123! password user
        }
    }
}

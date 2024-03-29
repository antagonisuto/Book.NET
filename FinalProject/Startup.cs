﻿using System;
using FinalProject.Data;
using FinalProject.Hubs;
using FinalProject.Models;
using FinalProject.Services.Authors;
using FinalProject.Services.Books;
using FinalProject.Services.BooksHaveAuthors;
using FinalProject.Services.BooksInventory;
using FinalProject.Services.BooksRequests;
using FinalProject.Services.Publishers;
using FinalProject.Services.Userss;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddMvc();
        //}
        private IConfigurationRoot _confSting;

        public Startup(IHostingEnvironment hostEnv)
        {
            _confSting = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("appsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(1000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddDbContext<AppDBContext>(options => options.UseNpgsql(_confSting.GetConnectionString("DefaultConnection")));
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSignalR();

            services.AddIdentity<Userss, IdentityRole>()
               .AddEntityFrameworkStores<AppDBContext>();

            services.AddMvc();
            services.AddHttpContextAccessor();

            services.AddScoped<AuthorsService>();
            services.AddScoped<IAuthorsRepository, AuthorsRepository>();

            services.AddScoped<BooksService>();
            services.AddScoped<IBooksRepository, BooksRepository>();

            services.AddScoped<BooksHaveAuthorsService>();
            services.AddScoped<IBooksHaveAuthorsRepository, BooksHaveAuthorsRepository>();

            services.AddScoped<BooksInventoryService>();
            services.AddScoped<IBooksInventoryRepository, BooksInventoryRepository>();

            services.AddScoped<BooksRequestsService>();
            services.AddScoped<IBooksRequestsRepository, BooksRequestsRepository>();

            services.AddScoped<PublishersService>();
            services.AddScoped<IPublishersRepository, PublishersRepository>();

            services.AddScoped<UserssService>();
            services.AddScoped<IUserssRepository, UserssRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chatHub");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Main}/{action=Index}/{id?}");
            });

           
            app.UseCookiePolicy();
        }
    }
}

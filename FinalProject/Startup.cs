using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
            services.AddDbContext<AppDBContext>(options => options.UseNpgsql(_confSting.GetConnectionString("DefaultConnection")));
            //services.AddDefaultIdentity<Users, IdentityRole<long>>().AddEntityFrameworkStores<AppDBContext, long>()
            // .AddDefaultTokenProviders();
            services.AddIdentity<Userss, IdentityRole>()
               .AddEntityFrameworkStores<AppDBContext>();

            services.AddMvc();
           

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
            services.AddScoped<IBooksRepository, BooksRepository>();
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Userss}/{action=Index}/{id?}");
            });
           
        }
    }
}

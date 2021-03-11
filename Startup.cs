using Bookstore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //Add set
        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //Add this connection thing
            services.AddDbContext<BookstoreDbContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookstoreConnection"]);
            });

            //Add Scope something
            services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();

            //Add Razor Pages
            services.AddRazorPages();

            //For adding session storage for cart
            services.AddDistributedMemoryCache();
            services.AddSession();

            //Added from Textbook Ch. 9
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //Use session data
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Catgory and page number
                endpoints.MapControllerRoute("catpage",
                    "{category}/{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                //Just page number
                endpoints.MapControllerRoute("page",
                    "{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                //Just category
                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", pageNum = 1 });

                //Our pagination page numbers
                endpoints.MapControllerRoute(
                    "pagination",
                    "P{pageNum}", //Page route name /P2 for page 2
                    //"Books/{page}", //Customize page route names
                    new {Controller = "Home", action = "Index"});

                //Default
                endpoints.MapDefaultControllerRoute();

                //Add endpoint for Razor Pages
                endpoints.MapRazorPages();
            });

            SeedData.EnsurePopulated(app); 
        }
    }
}

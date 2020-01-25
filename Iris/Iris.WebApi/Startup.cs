using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iris.BusinessLayer.Abstract;
using Iris.BusinessLayer.Concrete;
using Iris.DataAccessLayer.Abstract;
using Iris.DataAccessLayer.Concrete;
using Iris.WebApi.GlobalExceptionHandling;
using Iris.WebApi.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Iris.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //ASP.NET CORE DI
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IEfPersonDAL, EfPersonDAL>();
            services.AddScoped<IChildService, ChildService>();
            services.AddScoped<IEfChildDAL, EfChildDAL>();
            services.AddScoped<IAddressService, AddressService>(); 
            services.AddScoped<IEfAddressDAL, EfAddressDAL>();


            services.AddResponseCaching(options =>
            {
                options.MaximumBodySize = 1024;
                options.UseCaseSensitivePaths = true;
            });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider(new IrisLoggerProvider(env));
            if (env.IsDevelopment())
            {
                
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //Global Exception Handling
                app.UseExceptionHandler("/Error");
            }
            app.ConfigureExceptionHandler(loggerFactory);
            app.UseHttpsRedirection();
            app.UseResponseCaching();
            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(100)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };

                await next();
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

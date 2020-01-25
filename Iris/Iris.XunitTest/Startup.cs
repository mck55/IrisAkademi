using Iris.BusinessLayer.Abstract;
using Iris.BusinessLayer.Concrete;
using Iris.DataAccessLayer.Abstract;
using Iris.DataAccessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

[assembly: TestFramework("Iris.XunitTest.Startup", "Iris.XunitTest")]
namespace Iris.XunitTest
{
    public class Startup: DependencyInjectionTestFramework
    {
        public Startup(IMessageSink messageSink) : base(messageSink) { }

        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IEfPersonDAL, EfPersonDAL>();
            services.AddScoped<IChildService, ChildService>();
            services.AddScoped<IEfChildDAL, EfChildDAL>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IEfAddressDAL, EfAddressDAL>();
        }
    }
}

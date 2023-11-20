using DemoApi.Application.Interface.Authentication;
using DemoApi.Application.Interface.Service;
using DemoApi.Domain.Repository;
using DemoApi.Infracstructure.Authentication;
using DemoApi.Infracstructure.Data;
using DemoApi.Infracstructure.Repository;
using DemoApi.Infracstructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Infracstructure
{
    public class InfracstructureConfig
    {
        public static void Config(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<CustomerDbContext>(option => option.UseMySql(configuration.GetConnectionString("Connect"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql")));
            services.Configure<JwtSetting>(configuration.GetSection(JwtSetting.SectionString));
            services.AddScoped<IDateTimeProvide, DateTimeProvide>();
            services.AddScoped<IAccountQueryRepository, AccountQueryRepository>();
            services.AddScoped<IAccountCommandRepository, AccountCommandRepository>();


            services.AddScoped<ICustomerQueryRepository, CustomerQueyRepository>();
            services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        }
    }
}

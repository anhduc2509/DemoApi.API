using DemoApi.Application.Service.Authentication;
using DemoApi.Domain.Repository;
using MediatR.Pipeline;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DemoApi.Application
{
    public class ApplicationConfig
    {
        public static void Config(IServiceCollection services)
        {
            services.AddTransient<IAuthentService, AuthenSerivce>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}

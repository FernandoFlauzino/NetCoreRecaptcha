using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreRecaptcha.Application.Interface;
using NetCoreRecaptcha.Application.Interface.Api;
using NetCoreRecaptcha.Infra.Repositories;
using NetCoreRecaptcha.Service;
using System;
using System.IO;

namespace NetCoreRecaptcha.Infra.IoC
{
    public static class DependencyInjector
    {
        private static IServiceProvider _serviceProvider;
        private static IServiceCollection _services;
        public static T GetService<T>()
        {
            _services = _services ?? RegisterServices();
            _serviceProvider = _serviceProvider ?? _services.BuildServiceProvider();
            return _serviceProvider.GetService<T>();
        }

        public static IServiceCollection RegisterServices()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            IConfiguration configuration = builder.Build();

            return RegisterServices(new ServiceCollection(), configuration);
        }

        public static IServiceCollection RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;

            services.AddScoped<IGoogleRecaptchaService, GoogleRecaptchaService>();

            services.AddScoped<IGoogleRecaptchaRepository, GoogleRecaptchaRepository>();

            services.AddMvc();

            services.AddControllersWithViews();

            return _services;
        }
    }
}

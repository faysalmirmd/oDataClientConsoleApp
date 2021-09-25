using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Extensions.Client;
using ODataClientConsoleApp.Data;
using ODataClientConsoleApp.Util;
using ODataClientConsoleApp.View;

namespace ODataClientConsoleApp
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IPeopleRepository, PeopleRepository>();
            services.AddSingleton<IPeopleSearchRepository, PeopleSearchRepository>();
            services.AddSingleton<IView, ConsoleView>();

            //Registering all commands
            var commands = AssemblyUtil.GetTypes("ODataClientConsoleApp.Command", "Command", "Base");
            commands.ToList().ForEach(type => services.AddTransient(type));

            var serviceProvider = services.BuildServiceProvider();
            var config = serviceProvider.GetService<IConfigurationRoot>();

            services.AddODataClient("TripPin")
                .ConfigureODataClient(dsc =>
                {
                    dsc.BaseUri = new Uri(config.GetValue<string>("serviceRoot"));
                }).AddHttpClient();

            return services;
        }
    }
}
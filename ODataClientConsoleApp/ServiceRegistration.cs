using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Extensions.Client;
using ODataClientConsoleApp.Command;
using ODataClientConsoleApp.Data;
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

            services.AddTransient<ListCommand>();
            services.AddTransient<CreateCommand>();
            services.AddTransient<UpdateCommand>();
            services.AddTransient<RemoveCommand>();
            services.AddTransient<SearchCommand>();
            services.AddTransient<DetailsCommand>();
            services.AddTransient<FilterCommand>();

            services.AddODataClient("TripPin")
                .ConfigureODataClient(dsc =>
                {
                    //dsc.BaseUri = new Uri("https://services.odata.org/v4/(S(lqbvtwide0ngdev54adgc0lu))/TripPinServiceRW/");
                    dsc.BaseUri = new Uri("https://services.odata.org/V4/TripPinServiceRW/");
                }).AddHttpClient();

            return services;
        }
    }
}

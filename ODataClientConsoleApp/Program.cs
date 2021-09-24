using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using ODataClientConsoleApp.Command;
using ODataClientConsoleApp.CommandLineOption;
using ODataClientConsoleApp.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ODataClientConsoleApp.Util;

namespace ODataClientConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = ConfigureServices(new ServiceCollection());
            
            var input = "--help";

            while (true)
            {
                input = input?.Replace("\t", " ");

                if (input == "exit") break;
                if (string.IsNullOrEmpty(input))
                {
                    input = Console.ReadLine();
                    continue;
                }

                try
                {
                    var result = Parser.Default.ParseArguments<ListOption, CreateOption,
                        SearchOption, FilterOption, DetailsOption>(CommandLineUtil.CommandLineToArgs(input));
                    
                    var task = result
                        .MapResult(
                            (ListOption _) => serviceProvider.ResolveWith<ListCommand>().Execute(),
                            (CreateOption opts) => serviceProvider.ResolveWith<CreateCommand>(opts).Execute(),
                            (SearchOption opts) => serviceProvider.ResolveWith<SearchCommand>(opts).Execute(),
                            (FilterOption opts) => serviceProvider.ResolveWith<FilterCommand>(opts).Execute(),
                            (DetailsOption opts) => serviceProvider.ResolveWith<DetailsCommand>(opts).Execute(),
                            _ => Task.CompletedTask);

                    await task;
                    
                    input = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception occurred: " + ex.Message);
                    break;
                }
            }
        }

        private static IServiceProvider ConfigureServices(IServiceCollection serviceCollection)
        {
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            //    .AddJsonFile("appsettings.json", false)
            //    .Build();
            
            //serviceCollection.AddSingleton(configuration);
            //serviceCollection.AddTransient<App>();
            serviceCollection.RegisterServices();

            return serviceCollection.BuildServiceProvider();
        }
    }
}

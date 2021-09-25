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
                    var result = Parser.Default.ParseArguments<ListOption, DetailsOption, CreateOption, UpdateOption, RemoveOption, BatchCommitOption,
                        SearchOption, FilterOption>(CommandLineUtil.CommandLineToArgs(input));
                    
                    var task = result
                        .MapResult(
                            (ListOption _) => serviceProvider.ResolveWith<ListCommand>().Execute(),
                            (CreateOption opts) => opts.Batch ? serviceProvider.ResolveWith<CreateBatchCommand>(opts).Execute() 
                                : serviceProvider.ResolveWith<CreateCommand>(opts).Execute(),
                            (UpdateOption opts) => opts.Batch ? serviceProvider.ResolveWith<UpdateBatchCommand>(opts).Execute() 
                                : serviceProvider.ResolveWith<UpdateCommand>(opts).Execute(),
                            (RemoveOption opts) => opts.Batch ? serviceProvider.ResolveWith<RemoveBatchCommand>(opts).Execute() 
                                : serviceProvider.ResolveWith<RemoveCommand>(opts).Execute(),
                            (SearchOption opts) => serviceProvider.ResolveWith<SearchCommand>(opts).Execute(),
                            (FilterOption opts) => serviceProvider.ResolveWith<FilterCommand>(opts).Execute(),
                            (DetailsOption opts) => serviceProvider.ResolveWith<DetailsCommand>(opts).Execute(),
                            (BatchCommitOption _) => serviceProvider.ResolveWith<BatchCommitCommand>().Execute(),
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

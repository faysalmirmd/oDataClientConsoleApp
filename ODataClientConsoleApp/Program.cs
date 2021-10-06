using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ODataClientConsoleApp.Command;
using ODataClientConsoleApp.CommandLineOption;
using ODataClientConsoleApp.Extensions;
using ODataClientConsoleApp.Util;

namespace ODataClientConsoleApp
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var serviceProvider = ConfigureServices(new ServiceCollection());
            var types = AssemblyUtil.GetTypes("ODataClientConsoleApp.CommandLineOption", "Option", "Base").ToList();
            var commandTypes = AssemblyUtil.GetTypes("ODataClientConsoleApp.Command", "Command", "Base").ToList();
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
                    var res = Parser.Default.ParseArguments(CommandLineUtil.CommandLineToArgs(input), types.ToArray());

                    var commandType = commandTypes.FirstOrDefault(ct => ct.Name.Equals(res.TypeInfo.Current.Name.Replace("Option", "Command")));

                    if (commandType != null)
                    {
                        await MapResult(serviceProvider, res, commandTypes);
                    }
                    
                    input = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception occurred: " + ex.Message);
                    break;
                }
            }
        }

        private static Task MapResult<TOption>(IServiceProvider serviceProvider, ParserResult<TOption> parserResult, IReadOnlyCollection<Type> commandTypes) 
            where TOption: class 
        {
            return parserResult.MapResult(opt =>
            {
                var commandType = commandTypes.FirstOrDefault(ct => ct.Name.Equals(parserResult.TypeInfo.Current.Name.Replace("Option", 
                    (opt is DataModificationBaseOption) ? "BatchCommand" : "Command")));
                return ((ICommand) serviceProvider.ResolveWith(commandType, opt)).Execute();
            }, _ => Task.CompletedTask);
        }

        private static IServiceProvider ConfigureServices(IServiceCollection serviceCollection)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)?.FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            serviceCollection.AddSingleton(configuration);
            serviceCollection.RegisterServices();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
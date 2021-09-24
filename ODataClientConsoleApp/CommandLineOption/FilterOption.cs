using CommandLine;

namespace ODataClientConsoleApp.CommandLineOption
{
    [Verb("filter", HelpText = "filter by oData filter query param with parameter -f \"<filterQueryValue>\" i.e -f \"FirstName eq 'Scott'\"")]
    public class FilterOption
    {
        [Option('f', "FilterQuery", Required = true, HelpText = "OData Filter Query Parameter", Default = "")]
        public string FilterQuery { get; set; }
    }
}

using CommandLine;

namespace ODataClientConsoleApp.CommandLineOption
{
    [Verb("search", HelpText = "search people by UserName with parameter -u <username> or full text search -s <text>")]
    public class SearchOption
    {
        [Option('u', "UserName", HelpText = "username for People", Default = "")]
        public string UserName { get; set; }

        [Option('s', "SearchText", HelpText = "Search Text", Default = "")]
        public string SearchText { get; set; }
    }
}

using CommandLine;

namespace ODataClientConsoleApp.CommandLineOption
{
    [Verb("search", HelpText = "search people by UserName with parameter -u <username> or for full text search, -s <text>")]
    public class SearchOption : PersonKeyBaseOption
    {
        [Option('u', "UserName", HelpText = "username for People", Default = "")]
        public override string UserName { get; set; }

        [Option('s', "SearchText", HelpText = "Search Text", Default = "")]
        public string SearchText { get; set; }
    }
}

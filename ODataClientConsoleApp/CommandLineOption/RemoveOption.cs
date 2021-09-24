using CommandLine;

namespace ODataClientConsoleApp.CommandLineOption
{
    [Verb("remove", HelpText = "remove person by UserName with parameter -u <username>")]
    public class RemoveOption
    {
        [Option('u', "UserName", Required = true, HelpText = "username for People", Default = "")]
        public string UserName { get; set; }
    }
}

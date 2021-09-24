using CommandLine;

namespace ODataClientConsoleApp.CommandLineOption
{
    [Verb("details", HelpText = "Details view of a person by UserName with parameter -u <username>")]
    public class DetailsOption
    {
        [Option('u', "UserName", Required = true, HelpText = "Username for the Person")]
        public string UserName { get; set; }
    }
}

using CommandLine;

namespace ODataClientConsoleApp.CommandLineOption
{
    [Verb("remove", HelpText = "remove person by UserName with parameter -u <username>, add -b true for batch operation")]
    public class RemoveOption : PersonKeyBaseOption
    {
        [Option('b', "Batch", HelpText = "Operation is Batch mode", Default = false)]
        public bool Batch { get; set; }
    }
}

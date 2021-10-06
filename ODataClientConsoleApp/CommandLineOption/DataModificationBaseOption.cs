using CommandLine;

namespace ODataClientConsoleApp.CommandLineOption
{
    public class DataModificationBaseOption : PersonKeyBaseOption
    {
        [Option('b', "Batch", HelpText = "Operation is Batch mode", Default = false)]
        public bool Batch { get; set; }
    }
}
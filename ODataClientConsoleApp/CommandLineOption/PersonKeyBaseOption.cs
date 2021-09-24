using CommandLine;

namespace ODataClientConsoleApp.CommandLineOption
{
    public class PersonKeyBaseOption
    {
        [Option('u', "UserName", Required = true, HelpText = "Username for the Person")]
        public virtual string UserName { get; set; }
    }
}
using CommandLine;

namespace ODataClientConsoleApp.CommandLineOption
{
    [Verb("remove", HelpText = "remove person by UserName with parameter -u <username>, add -b true for batch operation")]
    public class RemoveOption : DataModificationBaseOption
    {
        
    }
}

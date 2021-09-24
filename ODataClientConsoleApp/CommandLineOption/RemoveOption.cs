using CommandLine;

namespace ODataClientConsoleApp.CommandLineOption
{
    [Verb("remove", HelpText = "remove person by UserName with parameter -u <username>")]
    public class RemoveOption : PersonKeyBaseOption
    {
       
    }
}

using CommandLine;

namespace ODataClientConsoleApp.CommandLineOption
{
    [Verb("details", HelpText = "Details view of a person by UserName with parameter -u <username> i.e details -u russellwhyte")]
    public class DetailsOption : PersonKeyBaseOption
    {

    }
}

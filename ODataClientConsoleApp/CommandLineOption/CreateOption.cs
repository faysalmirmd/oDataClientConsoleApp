using CommandLine;

namespace ODataClientConsoleApp.CommandLineOption
{
    [Verb("create", HelpText = "Create a person with parameters, add -b true for batch operation\n" +
                                   "UserName -u <username>\n" +
                                   "FirstName -f <firstname>\n" +
                                   "LastName -l <lastname>\n" +
                                   "Emails -e <comma separated emails>\n" +
                                   "Gender -g <gender> i.e male/female/unknown\n" +
                                   "Address -a <address>\n" +
                                   "City -c <city>\n" +
                                   "Country -s <country>\n" +
                                   "Region -r <region>\n" +
                                   "Note: Double quote(\"\") is required around parameter values containing whitespace i. e \n" +
                                   "create -u <username> -s \"United states\"")]
    public class CreateOption : CreateUpdateBaseOption
    {
        
    }
}
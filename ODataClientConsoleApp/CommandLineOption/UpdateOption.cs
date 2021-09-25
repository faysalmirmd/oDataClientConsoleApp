using CommandLine;

namespace ODataClientConsoleApp.CommandLineOption
{
    [Verb("update", HelpText = "Update a person by UserName -u <username> with parameters to update\n" +
                                   "FirstName -f <firstname>\n" +
                                   "LastName -l <lastname>\n" +
                                   "Emails -e <comma separated emails>\n" +
                                   "Gender -g <gender> i.e male/female/unknown\n" +
                                   "Address -a <address>\n" +
                                   "City -c <city>\n" +
                                   "Country -s <country>\n" +
                                   "Region -r <region>\n")]
    public class UpdateOption : CreateUpdateBaseOption
    {
        [Option('f', "FirstName", HelpText = "FirstName for the Person")]
        public override string FirstName { get; set; }

        [Option('l', "LastName", HelpText = "LastName for the Person")]
        public override string LastName { get; set; }
    }
}
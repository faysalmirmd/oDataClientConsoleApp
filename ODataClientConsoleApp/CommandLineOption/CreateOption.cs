using CommandLine;

namespace ODataClientConsoleApp.CommandLineOption
{
    [Verb("create", HelpText = "Create a person with parameters\n" +
                                   "UserName -u <username>\n" +
                                   "FirstName -f <firstname>\n" +
                                   "LastName -l <lastname>\n" +
                                   "Emails -e <comma separated emails>\n" +
                                   "Gender -g <gender> i.e male/female/unknown\n" +
                                   "Address -a <address>\n" +
                                   "City -c <city>\n" +
                                   "Country -s <country>\n" +
                                   "Region -r <region>\n")]
    public class CreateOption : PersonKeyBaseOption
    {
        [Option('f', "FirstName", Required = true, HelpText = "FirstName for the Person")]
        public string FirstName { get; set; }

        [Option('l', "LastName", Required = true, HelpText = "LastName for the Person")]
        public string LastName { get; set; }

        [Option('e', "Emails", HelpText = "Emails for the Person", Default = "")]
        public string Emails { get; set; }

        [Option('g', "Gender", HelpText = "Gender for the Person i.e. Male/Female", Default = "")]
        public string Gender { get; set; }

        [Option('a', "Address", HelpText = "Address for the Person", Default = "")]
        public string Address { get; set; }

        [Option('c', "City", HelpText = "City for the Person", Default = "")]
        public string City { get; set; }

        [Option('s', "Country", HelpText = "Country for the Person", Default = "")]
        public string Country { get; set; }

        [Option('r', "Region", HelpText = "City Region for the Person", Default = "")]
        public string Region { get; set; }
    }
}
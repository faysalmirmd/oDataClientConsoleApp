using CommandLine;

namespace ODataClientConsoleApp.CommandLineOption
{
    [Verb("update", HelpText = "Update a person by UserName -u <username> with parameters to update, add -b true for batch operation\n" +
                                   "FirstName -f <firstname>\n" +
                                   "LastName -l <lastname>\n" +
                                   "Emails -e <comma separated emails>\n" +
                                   "Gender -g <gender> i.e male/female/unknown\n" +
                                   "Address -a <address>\n" +
                                   "City -c <city>\n" +
                                   "Country -s <country>\n" +
                                   "Region -r <region>\n" +
                                   "Note: Double quote(\"\") is required around parameter values containing whitespace i. e \n" +
                                   "update -u <username> -a \"Bandar Utama, 47800 Petaling Jaya, Selangor\"")]
    public class UpdateOption : CreateUpdateBaseOption
    {
        [Option('f', "FirstName", HelpText = "FirstName for the Person")]
        public override string FirstName { get; set; }

        [Option('l', "LastName", HelpText = "LastName for the Person")]
        public override string LastName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace ODataClientConsoleApp.CommandLineOption
{
    public class EditUpdateBaseOption : PersonKeyBaseOption
    {
        [Option('f', "FirstName", Required = true, HelpText = "FirstName for the Person")]
        public virtual string FirstName { get; set; }

        [Option('l', "LastName", Required = true, HelpText = "LastName for the Person")]
        public virtual string LastName { get; set; }

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

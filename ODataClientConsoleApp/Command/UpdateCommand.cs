using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OData.SampleService.Models.TripPin;
using ODataClientConsoleApp.CommandLineOption;
using ODataClientConsoleApp.Data;
using ODataClientConsoleApp.Util;
using ODataClientConsoleApp.View;

namespace ODataClientConsoleApp.Command
{
    public class UpdateCommand : BaseCommand, ICommand
    {
        private readonly UpdateOption _option;
        public UpdateCommand(IPeopleRepository peopleRepository, IView view, UpdateOption option) : base(peopleRepository, view)
        {
            _option = option;
        }

        public async Task Execute()
        {
            var result = await ValidatePerson();
            if (!result)
            {
                View.ShowMessage("Person already exists. try with different username");
                return;
            }

            var person = new Person
            {
                UserName = _option.UserName,
                FirstName = _option.FirstName,
                LastName = _option.LastName,
                Emails = new ObservableCollection<string>(),
                AddressInfo = new ObservableCollection<Location>(),
                Concurrency = 635519729375200400
            };

            if (!SetEmails(person))
            {
                View.ShowMessage("Invalid Email Address provided.");
                return;
            }

            SetAddress(person);
            SetGender(person);

            await PeopleRepository.CreatePerson(person);
            await ShowCreatedPerson(person);
        }

        private async Task<bool> ValidatePerson()
        {
            var existingPerson = await PeopleRepository.FindByUserName(_option.UserName);
            return existingPerson == null;
        }

        private async Task ShowCreatedPerson(Person person)
        {
            var createdPerson = await PeopleRepository.FindByUserName(_option.UserName);
            if (createdPerson != null)
                View.ShowPersonDetails(person);
            else
                View.ShowMessage("Person not created.");
        }

        private void SetAddress(Person person)
        {
            if (!string.IsNullOrEmpty(_option.Address)
                || !string.IsNullOrEmpty(_option.City)
                || !string.IsNullOrEmpty(_option.Country))
                person.AddressInfo.Add(new Location
                {
                    Address = _option.Address,
                    City = new City { CountryRegion = _option.Country, Name = _option.City, Region = _option.Region }
                });
        }

        private bool SetEmails(Person person)
        {
            if (string.IsNullOrEmpty(_option.Emails)) return true;

            _option.Emails = StringUtil.ReplaceWhitespace(_option.Emails, "");

            var emails = _option.Emails.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            if (emails.Any(e => !ValidationUtil.IsValidEmail(e))) return false;
            emails.ForEach(e => person.Emails.Add(e));
            return true;
        }

        private void SetGender(Person person)
        {
            if (!string.IsNullOrEmpty(_option.Gender))
                person.Gender = _option.Gender.Equals("female", StringComparison.InvariantCultureIgnoreCase)
                    ? PersonGender.Female
                    : PersonGender.Male;
            else
                person.Gender = PersonGender.Unknown;
        }
    }
}

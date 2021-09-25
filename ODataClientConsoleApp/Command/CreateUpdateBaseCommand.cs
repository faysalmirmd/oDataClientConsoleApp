using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OData.SampleService.Models.TripPin;
using ODataClientConsoleApp.CommandLineOption;
using ODataClientConsoleApp.Data;
using ODataClientConsoleApp.Util;
using ODataClientConsoleApp.View;

namespace ODataClientConsoleApp.Command
{
    public abstract class CreateUpdateBaseCommand : BaseCommand, ICommand
    {
        private readonly CreateUpdateBaseOption _option;

        protected CreateUpdateBaseCommand(IPeopleRepository peopleRepository, IView view,
            CreateUpdateBaseOption option) :
            base(peopleRepository, view)
        {
            _option = option;
        }

        public async Task Execute()
        {
            if (!await ValidatePerson()) return;

            var person = await GetPerson();

            if (!string.IsNullOrEmpty(_option.FirstName)) person.FirstName = _option.FirstName;
            if (!string.IsNullOrEmpty(_option.LastName)) person.LastName = _option.LastName;

            if (!SetEmails(person))
            {
                View.ShowMessage("Invalid Email Address provided.");
                return;
            }

            SetAddress(person);
            SetGender(person);

            await CreateOrUpdatePerson(person);
        }

        protected abstract Task<Person> GetPerson();
        protected abstract Task<bool> ValidatePerson();
        protected abstract Task CreateOrUpdatePerson(Person person);
        protected abstract void SetAddress(Person person);
        protected abstract void SetGender(Person person);

        private bool SetEmails(Person person)
        {
            if (string.IsNullOrEmpty(_option.Emails)) return true;

            _option.Emails = StringUtil.ReplaceWhitespace(_option.Emails, "");

            var emails = _option.Emails.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            if (emails.Any(e => !ValidationUtil.IsValidEmail(e))) return false;
            emails.ForEach(e => person.Emails.Add(e));
            return true;
        }

        protected void UpdatePersonGender(Person person)
        {
            if (_option.Gender.Equals("female", StringComparison.InvariantCultureIgnoreCase))
                person.Gender = PersonGender.Female;
            else if (_option.Gender.Equals("male", StringComparison.InvariantCultureIgnoreCase))
                person.Gender = PersonGender.Male;
            else
                person.Gender = PersonGender.Unknown;
        }
    }
}
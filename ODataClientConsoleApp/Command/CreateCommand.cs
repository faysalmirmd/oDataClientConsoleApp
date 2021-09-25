using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.OData.SampleService.Models.TripPin;
using ODataClientConsoleApp.CommandLineOption;
using ODataClientConsoleApp.Data;
using ODataClientConsoleApp.View;

namespace ODataClientConsoleApp.Command
{
    public class CreateCommand : CreateUpdateBaseCommand
    {
        private readonly CreateOption _option;

        public CreateCommand(IPeopleRepository peopleRepository, IView view,
            CreateOption option) : base(
            peopleRepository, view, option)
        {
            _option = option;
        }

        protected override Task<Person> GetPerson()
        {
            var person = new Person
            {
                UserName = _option.UserName,
                Emails = new ObservableCollection<string>(),
                AddressInfo = new ObservableCollection<Location>(),
                Concurrency = 635519729375200400
            };

            return Task.FromResult(person);
        }

        protected override async Task<bool> ValidatePerson()
        {
            var existingPerson = await PeopleRepository.FindByUserName(_option.UserName);
            if (existingPerson == null) return true;
            View.ShowMessage("Person already exists. try with a different username");
            return false;
        }

        protected override async Task CreateOrUpdatePerson(Person person)
        {
            PeopleRepository.CreatePerson(person);
            await PeopleRepository.SaveChanges();
            await ShowCreatedPerson(person);
        }

        private async Task ShowCreatedPerson(Person person)
        {
            var createdPerson = await PeopleRepository.FindByUserName(_option.UserName);
            if (createdPerson != null)
                View.ShowPersonDetails(person);
            else
                View.ShowMessage("Person not created.");
        }

        protected override void SetAddress(Person person)
        {
            if (!string.IsNullOrEmpty(_option.Address)
                || !string.IsNullOrEmpty(_option.City)
                || !string.IsNullOrEmpty(_option.Country))
                person.AddressInfo.Add(new Location
                {
                    Address = _option.Address,
                    City = new City {CountryRegion = _option.Country, Name = _option.City, Region = _option.Region}
                });
        }

        protected override void SetGender(Person person)
        {
            if (!string.IsNullOrEmpty(_option.Gender))
                UpdatePersonGender(person);
            else
                person.Gender = PersonGender.Unknown;
        }
    }
}
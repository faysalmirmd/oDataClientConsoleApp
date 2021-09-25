using System.Linq;
using System.Threading.Tasks;
using Microsoft.OData.SampleService.Models.TripPin;
using ODataClientConsoleApp.CommandLineOption;
using ODataClientConsoleApp.Data;
using ODataClientConsoleApp.View;

namespace ODataClientConsoleApp.Command
{
    public class UpdateCommand : CreateUpdateBaseCommand
    {
        private readonly UpdateOption _option;

        public UpdateCommand(IPeopleRepository peopleRepository, IView view, UpdateOption option) : base(
            peopleRepository, view, option)
        {
            _option = option;
        }

        protected override async Task<Person> GetPerson()
        {
            var person = await PeopleRepository.FindByUserName(_option.UserName);
            return person;
        }

        protected override async Task<bool> ValidatePerson()
        {
            var existingPerson = await PeopleRepository.FindByUserName(_option.UserName);
            if (existingPerson != null) return true;
            View.ShowMessage("Person does not exist. Provide the accurate username.");
            return false;
        }

        protected override void SetAddress(Person person)
        {
            if (string.IsNullOrEmpty(_option.Address) && string.IsNullOrEmpty(_option.City) &&
                string.IsNullOrEmpty(_option.Country)) return;

            if (!person.AddressInfo.Any())
                person.AddressInfo.Add(
                    new Location
                    {
                        City = new City
                        {
                            Name = string.Empty,
                            CountryRegion = string.Empty,
                            Region = string.Empty
                        }
                    });

            if (!string.IsNullOrEmpty(_option.Address)) person.AddressInfo[0].Address = _option.Address;
            if (!string.IsNullOrEmpty(_option.City)) person.AddressInfo[0].City.Name = _option.City;
            if (!string.IsNullOrEmpty(_option.Country)) person.AddressInfo[0].City.CountryRegion = _option.Country;
            if (!string.IsNullOrEmpty(_option.Region)) person.AddressInfo[0].City.Region = _option.Region;
        }

        protected override void SetGender(Person person)
        {
            if (!string.IsNullOrEmpty(_option.Gender)) UpdatePersonGender(person);
        }

        protected override async Task CreateOrUpdatePerson(Person person)
        {
            await PeopleRepository.UpdatePerson(person);
            View.ShowMessage("Person updated");
        }
    }
}
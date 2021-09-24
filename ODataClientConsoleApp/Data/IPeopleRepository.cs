using Microsoft.OData.SampleService.Models.TripPin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODataClientConsoleApp.Data
{
    public interface IPeopleRepository
    {
        public Task CreatePerson(Person person);
        public Task RemovePerson(string userName);
        public Task UpdatePerson(Person person);
        public Task<IEnumerable<Person>> FindAll();
        public Task<Person> FindByUserName(string userName);
        Task<IEnumerable<Person>> Filter(string optionFilterQuery);
    }
}

using Microsoft.OData.SampleService.Models.TripPin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODataClientConsoleApp.Data
{
    public interface IPeopleRepository
    {
        public void CreatePerson(Person person);
        public Task RemovePerson(string userName);
        public void UpdatePerson(Person person);
        public Task SaveChanges();
        public Task SaveChangesInBatch();
        public Task<IEnumerable<Person>> FindAll();
        public Task<Person> FindByUserName(string userName);
        Task<List<List<Person>>> Filter(List<string> filterQueries);
    }
}

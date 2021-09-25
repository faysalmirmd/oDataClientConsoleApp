using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.OData.Extensions.Client;
using Microsoft.OData.SampleService.Models.TripPin;

namespace ODataClientConsoleApp.Data
{
    public class PeopleRepository : BaseRepository, IPeopleRepository
    {
        public PeopleRepository(IODataClientFactory oDataClientFactory) : base(oDataClientFactory)
        {
        }

        public async Task CreatePerson(Person person)
        {
            Context.AddObject("People", person);
            await Context.SaveChangesAsync();
        }

        public async Task RemovePerson(string userName)
        {
            var person = await FindByUserName(userName);
            Context.DeleteObject(person);
            await Context.SaveChangesAsync();
        }

        public async Task UpdatePerson(Person person)
        {
            Context.UpdateObject(person);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> FindAll()
        {
            var people = await Context.People.ExecuteAsync();
            return people;
        }

        public async Task<Person> FindByUserName(string userName)
        {
            var person = await Context.People.ByKey(userName).GetValueAsync();
            return person;
        }

        public async Task<IEnumerable<Person>> Filter(string optionFilterQuery)
        {
            var result = await Context.People.AddQueryOption("$filter", optionFilterQuery).ExecuteAsync();
            return result;
        }
    }
}
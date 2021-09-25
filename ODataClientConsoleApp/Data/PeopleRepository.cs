using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OData.Client;
using Microsoft.OData.Extensions.Client;
using Microsoft.OData.SampleService.Models.TripPin;

namespace ODataClientConsoleApp.Data
{
    public class PeopleRepository : BaseRepository, IPeopleRepository
    {
        public PeopleRepository(IODataClientFactory oDataClientFactory) : base(oDataClientFactory)
        {
        }

        public void CreatePerson(Person person)
        {
            Context.AddObject("People", person);
        }

        public async Task RemovePerson(string userName)
        {
            var person = await FindByUserName(userName);
            Context.DeleteObject(person);
        }

        public void UpdatePerson(Person person)
        {
            Context.UpdateObject(person);
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

        public async Task<List<List<Person>>> Filter(List<string> filterQueries)
        {
            DataServiceRequest[] queries = filterQueries.Select(q => Context.People.AddQueryOption("$filter", q)).ToArray();
            var batchResponse = await Context.ExecuteBatchAsync(queries);
            var list = new List<List<Person>>();

            foreach (var response in batchResponse)
            {
                if (response is QueryOperationResponse<Person> people)
                {
                    list.Add(people.ToList());
                }
            }
            
            return list;
        }

        public Task SaveChanges()
        {
            return Context.SaveChangesAsync();
        }

        public Task SaveChangesInBatch()
        {
            return Context.SaveChangesAsync(SaveChangesOptions.BatchWithSingleChangeset);
        }
    }
}
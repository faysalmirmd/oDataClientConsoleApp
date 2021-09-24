using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<List<Person>> FindAll()
        {
            IEnumerable<Person> people = await Context.People.ExecuteAsync();
            return people.ToList();
        }

        public async Task<Person> FindByUserName(string userName)
        {
            var person = await Context.People.ByKey(userName).GetValueAsync();
            return person;
        }

        public async Task<IEnumerable<Person>> Search(string searchText)
        {
            var person = Context.People.AddQueryOption("$filter", "FirstName eq 'Scott'");
            //person.GetType().GetProperty("RequestUri").SetValue(person, new Uri(person.RequestUri.AbsoluteUri + $"$search={searchText}"), null);

            foreach (Person person1 in person)
            {
                //Console.WriteLine($"Username: {person.UserName} First Name: {person.FirstName} Gender: {person.Gender}");
            }
            return person;
        }

        public async Task<IEnumerable<Person>> Filter(string optionFilterQuery)
        {
            var result = await Context.People.AddQueryOption("$filter", optionFilterQuery).ExecuteAsync();
            return result;
        }
    }
}

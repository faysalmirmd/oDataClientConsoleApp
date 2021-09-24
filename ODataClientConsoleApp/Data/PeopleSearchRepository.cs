using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.OData.Client;
using Microsoft.OData.Extensions.Client;
using Microsoft.OData.SampleService.Models.TripPin;

namespace ODataClientConsoleApp.Data
{
    public class PeopleSearchRepository : IPeopleSearchRepository
    {
        private readonly DefaultContainer _context;
        private string _searchText;

        public PeopleSearchRepository(IODataClientFactory oDataClientFactory)
        {
            _context = oDataClientFactory.CreateClient<DefaultContainer>(
                //new Uri("https://services.odata.org/V4/TripPinServiceRW/"));
                new Uri("https://services.odata.org/v4/(S(34wtn2c0hkuk5ekg0pjr513b))/TripPinServiceRW/"));
        }

        public async Task<IEnumerable<Person>> Search(string searchText)
        {
            _searchText = searchText;
            _context.BuildingRequest += ContextOnBuildingRequest;

            var people = await _context.People.ExecuteAsync();

            _context.BuildingRequest -= ContextOnBuildingRequest;
            return people;
        }

        private void ContextOnBuildingRequest(object? sender, BuildingRequestEventArgs eventArgs)
        {
            eventArgs.RequestUri =
                new Uri(
                    $"https://services.odata.org/v4/(S(34wtn2c0hkuk5ekg0pjr513b))/TripPinServiceRW/People?$search={_searchText}");
        }
    }
}
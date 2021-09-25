using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.OData.Client;
using Microsoft.OData.Extensions.Client;
using Microsoft.OData.SampleService.Models.TripPin;

namespace ODataClientConsoleApp.Data
{
    public class PeopleSearchRepository : IPeopleSearchRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DefaultContainer _context;
        private string _searchText;

        public PeopleSearchRepository(IODataClientFactory oDataClientFactory, IConfigurationRoot configuration)
        {
            _configuration = configuration;
            _context = oDataClientFactory.CreateClient<DefaultContainer>(
                new Uri(_configuration.GetValue<string>("serviceRoot")));
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
                    $"{_configuration.GetValue<string>("serviceRoot")}People?$search={_searchText}");
        }
    }
}
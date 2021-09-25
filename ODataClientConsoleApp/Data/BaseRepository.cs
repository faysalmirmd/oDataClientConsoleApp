using System;
using Microsoft.Extensions.Configuration;
using Microsoft.OData.Extensions.Client;
using Microsoft.OData.SampleService.Models.TripPin;

namespace ODataClientConsoleApp.Data
{
    public abstract class BaseRepository
    {
        protected readonly DefaultContainer Context;

        protected BaseRepository(IODataClientFactory oDataClientFactory, IConfigurationRoot configuration)
        {
            Context = oDataClientFactory.CreateClient<DefaultContainer>(
                new Uri(configuration.GetValue<string>("serviceRoot")));
        }
    }
}
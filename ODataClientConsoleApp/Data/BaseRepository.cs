using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OData.Extensions.Client;
using Microsoft.OData.SampleService.Models.TripPin;

namespace ODataClientConsoleApp.Data
{
    public abstract class BaseRepository
    {
        protected readonly DefaultContainer Context;

        protected BaseRepository(IODataClientFactory oDataClientFactory)
        {
            Context = oDataClientFactory.CreateClient<DefaultContainer>(
                //new Uri("https://services.odata.org/V4/TripPinServiceRW/"));
                new Uri("https://services.odata.org/v4/(S(34wtn2c0hkuk5ekg0pjr513b))/TripPinServiceRW/"));
        }
    }
}

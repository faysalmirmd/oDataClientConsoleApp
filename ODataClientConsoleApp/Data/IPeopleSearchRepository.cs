using Microsoft.OData.SampleService.Models.TripPin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODataClientConsoleApp.Data
{
    public interface IPeopleSearchRepository
    {
        Task<IEnumerable<Person>> Search(string searchText);
    }
}

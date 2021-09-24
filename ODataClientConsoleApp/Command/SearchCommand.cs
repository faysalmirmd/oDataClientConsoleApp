using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OData.SampleService.Models.TripPin;
using ODataClientConsoleApp.CommandLineOption;
using ODataClientConsoleApp.Data;
using ODataClientConsoleApp.View;

namespace ODataClientConsoleApp.Command
{
    public class SearchCommand : BaseCommand, ICommand
    {
        private readonly SearchOption _option;
        private readonly IPeopleSearchRepository _peopleSearchRepository;

        public SearchCommand(IPeopleRepository peopleRepository, IPeopleSearchRepository peopleSearchRepository, IView view, SearchOption option) : base(
            peopleRepository, view)
        {
            _peopleSearchRepository = peopleSearchRepository;
            _option = option;
        }

        public async Task Execute()
        {
            var people = new List<Person>();
            if (!string.IsNullOrEmpty(_option.SearchText))
            {
                people = (await _peopleSearchRepository.Search(_option.SearchText)).ToList();
                if (!string.IsNullOrEmpty(_option.UserName))
                {
                    people = people.Where(p => p.UserName.Equals(_option.UserName)).ToList();
                }
            }
            else if (!string.IsNullOrEmpty(_option.UserName))
            {
                var person = await PeopleRepository.FindByUserName(_option.UserName);
                people.Add(person);
            }
            else
            {
                View.ShowMessage("Person not found.");
                return;
            }

            if (people.Any())
                View.ShowPeople(people);
            else
                View.ShowMessage("Person not found.");
        }
    }
}
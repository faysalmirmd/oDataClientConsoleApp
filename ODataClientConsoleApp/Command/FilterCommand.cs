using System.Linq;
using System.Threading.Tasks;
using ODataClientConsoleApp.CommandLineOption;
using ODataClientConsoleApp.Data;
using ODataClientConsoleApp.View;

namespace ODataClientConsoleApp.Command
{
    public class FilterCommand : BaseCommand, ICommand
    {
        private readonly FilterOption _option;

        public FilterCommand(IPeopleRepository peopleRepository, IView view, FilterOption option) : base(
            peopleRepository, view)
        {
            _option = option;
        }

        public async Task Execute()
        {
            var queries = _option.FilterQuery.Split('|').ToList();
            var peopleList = (await PeopleRepository.Filter(queries)).ToList();
            var index = 0;
            foreach (var people in peopleList)
            {
                View.ShowMessage($"Result of Query {queries[index]}:");
                if (people.Any())
                    View.ShowPeople(people);
                else
                    View.ShowMessage("No person found.");
                index++;
            }
        }
    }
}
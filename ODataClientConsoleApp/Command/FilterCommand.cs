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
            var people = (await PeopleRepository.Filter(_option.FilterQuery)).ToList();
            if (people.Any())
                View.ShowPeople(people);
            else
                View.ShowMessage("No person found.");
        }
    }
}
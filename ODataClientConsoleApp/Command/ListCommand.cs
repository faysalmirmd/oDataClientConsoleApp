using System.Threading.Tasks;
using ODataClientConsoleApp.CommandLineOption;
using ODataClientConsoleApp.Data;
using ODataClientConsoleApp.View;

namespace ODataClientConsoleApp.Command
{
    public class ListCommand : BaseCommand, ICommand
    {
        private readonly ListOption _option;
        public ListCommand(IPeopleRepository peopleRepository, IView view, ListOption option) : base(peopleRepository, view)
        {
            _option = option;
        }

        public async Task Execute()
        {
            View.ShowLoading();
            var people = await PeopleRepository.FindAll();
            View.HideLoading();

            View.ShowPeople(people);
        }
    }
}
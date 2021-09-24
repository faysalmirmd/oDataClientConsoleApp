using System.Threading.Tasks;
using ODataClientConsoleApp.Data;
using ODataClientConsoleApp.View;

namespace ODataClientConsoleApp.Command
{
    public class ListCommand : BaseCommand, ICommand
    {
        public ListCommand(IPeopleRepository peopleRepository, IView view) : base(peopleRepository, view)
        {
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
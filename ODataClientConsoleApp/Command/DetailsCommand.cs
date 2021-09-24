using System.Threading.Tasks;
using ODataClientConsoleApp.CommandLineOption;
using ODataClientConsoleApp.Data;
using ODataClientConsoleApp.View;

namespace ODataClientConsoleApp.Command
{
    public class DetailsCommand : BaseCommand, ICommand
    {
        private readonly DetailsOption _option;

        public DetailsCommand(IPeopleRepository peopleRepository, IView view, DetailsOption option) : base(
            peopleRepository, view)
        {
            _option = option;
        }

        public async Task Execute()
        {
            var person = await PeopleRepository.FindByUserName(_option.UserName);
            if (person != null)
                View.ShowPersonDetails(person);
            else
                View.ShowMessage("Person not found with the username provided.");
        }
    }
}
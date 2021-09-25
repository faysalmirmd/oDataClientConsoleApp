using System.Threading.Tasks;
using ODataClientConsoleApp.CommandLineOption;
using ODataClientConsoleApp.Data;
using ODataClientConsoleApp.View;

namespace ODataClientConsoleApp.Command
{
    public class RemoveBatchCommand : RemoveCommand
    {
        public RemoveBatchCommand(IPeopleRepository peopleRepository, IView view, RemoveOption options) : base(
            peopleRepository, view, options)
        {
        }

        protected override async Task RemovePerson(string userName)
        {
            await PeopleRepository.RemovePerson(userName);
            View.ShowMessage("Person added for batch remove.");
        }
    }
}
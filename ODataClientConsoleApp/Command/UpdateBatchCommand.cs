using System.Threading.Tasks;
using Microsoft.OData.SampleService.Models.TripPin;
using ODataClientConsoleApp.CommandLineOption;
using ODataClientConsoleApp.Data;
using ODataClientConsoleApp.View;

namespace ODataClientConsoleApp.Command
{
    public class UpdateBatchCommand : UpdateCommand
    {
        public UpdateBatchCommand(IPeopleRepository peopleRepository, IView view, UpdateOption option) : base(
            peopleRepository, view, option)
        {
        }

        protected override Task CreateOrUpdatePerson(Person person)
        {
            PeopleRepository.UpdatePerson(person);
            View.ShowMessage("Person added for batch Update.");
            return Task.CompletedTask;
        }
    }
}
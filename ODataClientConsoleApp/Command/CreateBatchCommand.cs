using System.Threading.Tasks;
using Microsoft.OData.SampleService.Models.TripPin;
using ODataClientConsoleApp.CommandLineOption;
using ODataClientConsoleApp.Data;
using ODataClientConsoleApp.View;

namespace ODataClientConsoleApp.Command
{
    public class CreateBatchCommand : CreateCommand
    {
        public CreateBatchCommand(IPeopleRepository peopleBatchRepository, IView view, CreateOption option) : 
            base(peopleBatchRepository, view, option)
        {
        }

        protected override Task CreateOrUpdatePerson(Person person)
        {
            PeopleRepository.CreatePerson(person);
            View.ShowMessage("Person added for batch Create.");
            return Task.CompletedTask;
        }
    }
}
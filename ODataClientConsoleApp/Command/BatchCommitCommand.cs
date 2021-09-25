using System.Threading.Tasks;
using ODataClientConsoleApp.Data;
using ODataClientConsoleApp.View;

namespace ODataClientConsoleApp.Command
{
    public class BatchCommitCommand : BaseCommand, ICommand
    {
        public BatchCommitCommand(IPeopleRepository peopleRepository, IView view) : base(peopleRepository, view)
        {
        }

        public async Task Execute()
        {
            await PeopleRepository.SaveChangesInBatch();
            View.ShowMessage("Batch Committed.");
        }
    }
}
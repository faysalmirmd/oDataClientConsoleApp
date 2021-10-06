using System.Threading.Tasks;
using ODataClientConsoleApp.CommandLineOption;
using ODataClientConsoleApp.Data;
using ODataClientConsoleApp.View;

namespace ODataClientConsoleApp.Command
{
    public class BatchCommitCommand : BaseCommand, ICommand
    {
        private readonly BatchCommitOption _option;
        public BatchCommitCommand(IPeopleRepository peopleRepository, IView view, BatchCommitOption option) : base(peopleRepository, view)
        {
            _option = option;
        }

        public async Task Execute()
        {
            await PeopleRepository.SaveChangesInBatch();
            View.ShowMessage("Batch Committed.");
        }
    }
}
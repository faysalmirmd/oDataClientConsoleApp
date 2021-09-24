using System.Threading.Tasks;

namespace ODataClientConsoleApp.Command
{
    public interface ICommand
    {
        Task Execute();
    }
}
